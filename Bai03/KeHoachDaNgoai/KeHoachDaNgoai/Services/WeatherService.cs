using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KeHoachDaNgoai.Services;

public class WeatherResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Suggestion { get; set; }
    public bool IsBeyondForecast { get; set; }

    public string LocationName { get; set; } = string.Empty;
    public DateOnly Date { get; set; }

    public int WeatherCode { get; set; }
    public string WeatherDescription { get; set; } = string.Empty;
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public int PrecipitationProbability { get; set; }
    public bool RainWarning => PrecipitationProbability >= 60;
}

public class GeocodingResponse
{
    [JsonPropertyName("results")]
    public List<GeocodingItem>? Results { get; set; }
}

public class GeocodingItem
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("admin1")]
    public string? Admin1 { get; set; }
}

public class ForecastResponse
{
    [JsonPropertyName("daily")]
    public DailyData? Daily { get; set; }
}

public class DailyData
{
    [JsonPropertyName("time")]
    public List<string>? Time { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int>? WeatherCode { get; set; }

    [JsonPropertyName("temperature_2m_max")]
    public List<double>? Temperature2mMax { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double>? Temperature2mMin { get; set; }

    [JsonPropertyName("precipitation_probability_max")]
    public List<int>? PrecipitationProbabilityMax { get; set; }
}

public static class WeatherService
{
    // Shared HttpClient with 8s timeout as strictly required in Task 7
    private static readonly HttpClient SharedClient = new()
    {
        Timeout = TimeSpan.FromSeconds(8)
    };

    public static string RemoveDiacritics(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        string normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        // Replace special Vietnamese characters
        result = result.Replace("Đ", "D").Replace("đ", "d");
        return result;
    }

    public static async Task<WeatherResult> GetWeatherAsync(string location, DateOnly tripDate)
    {
        var result = new WeatherResult
        {
            LocationName = location,
            Date = tripDate
        };

        if (string.IsNullOrWhiteSpace(location))
        {
            result.Success = false;
            result.ErrorMessage = LocalizationService.T("ValDestinationRequired");
            return result;
        }

        try
        {
            // Step 1: Geocoding API
            string langParam = LocalizationService.IsVietnamese ? "vi" : "en";
            string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(location.Trim())}&count=1&language={langParam}";

            var geoResponse = await SharedClient.GetAsync(geoUrl);
            geoResponse.EnsureSuccessStatusCode();

            string geoJson = await geoResponse.Content.ReadAsStringAsync();
            var geoData = JsonSerializer.Deserialize<GeocodingResponse>(geoJson);

            GeocodingItem? selectedLocation = geoData?.Results?.FirstOrDefault();

            // If empty, try unaccented version as automatic fallback
            if (selectedLocation == null)
            {
                string unaccented = RemoveDiacritics(location.Trim());
                if (!string.Equals(unaccented, location.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    string fallbackGeoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(unaccented)}&count=1&language={langParam}";
                    var fallbackResponse = await SharedClient.GetAsync(fallbackGeoUrl);
                    if (fallbackResponse.IsSuccessStatusCode)
                    {
                        string fallbackJson = await fallbackResponse.Content.ReadAsStringAsync();
                        var fallbackData = JsonSerializer.Deserialize<GeocodingResponse>(fallbackJson);
                        selectedLocation = fallbackData?.Results?.FirstOrDefault();
                    }
                }
            }

            // If still not found, return friendly error with unaccented suggestion
            if (selectedLocation == null)
            {
                string suggestion = RemoveDiacritics(location.Trim());
                result.Success = false;
                result.Suggestion = suggestion;
                result.ErrorMessage = string.Format(
                    LocalizationService.T("LocationNotFound"),
                    location,
                    string.IsNullOrWhiteSpace(suggestion) ? "Da Lat" : suggestion);
                return result;
            }

            // Step 2: Forecast API (16 days)
            double lat = selectedLocation.Latitude;
            double lon = selectedLocation.Longitude;
            string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";

            var forecastResponse = await SharedClient.GetAsync(forecastUrl);
            forecastResponse.EnsureSuccessStatusCode();

            string forecastJson = await forecastResponse.Content.ReadAsStringAsync();
            var forecastData = JsonSerializer.Deserialize<ForecastResponse>(forecastJson);

            var daily = forecastData?.Daily;
            if (daily?.Time == null || daily.Time.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = LocalizationService.T("NoForecastAvailable");
                return result;
            }

            // Format tripDate as YYYY-MM-DD to locate index in daily.time
            string targetDateStr = tripDate.ToString("yyyy-MM-dd");
            int index = daily.Time.IndexOf(targetDateStr);

            if (index < 0)
            {
                // Date is beyond the 16-day forecast or in the past
                result.Success = true;
                result.IsBeyondForecast = true;
                result.ErrorMessage = LocalizationService.T("NoForecastAvailable");
                return result;
            }

            // Extract values at target index
            result.WeatherCode = daily.WeatherCode != null && index < daily.WeatherCode.Count
                ? daily.WeatherCode[index]
                : 0;

            result.TempMin = daily.Temperature2mMin != null && index < daily.Temperature2mMin.Count
                ? Math.Round(daily.Temperature2mMin[index], 1)
                : 0;

            result.TempMax = daily.Temperature2mMax != null && index < daily.Temperature2mMax.Count
                ? Math.Round(daily.Temperature2mMax[index], 1)
                : 0;

            result.PrecipitationProbability = daily.PrecipitationProbabilityMax != null && index < daily.PrecipitationProbabilityMax.Count
                ? daily.PrecipitationProbabilityMax[index]
                : 0;

            result.WeatherDescription = LocalizationService.GetWeatherDescription(result.WeatherCode);
            result.Success = true;
            return result;
        }
        catch (HttpRequestException)
        {
            result.Success = false;
            result.ErrorMessage = LocalizationService.T("NetworkError");
            return result;
        }
        catch (TaskCanceledException)
        {
            result.Success = false;
            result.ErrorMessage = LocalizationService.T("NetworkError");
            return result;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorMessage = string.Format(LocalizationService.T("WeatherApiError"), ex.Message);
            return result;
        }
    }
}

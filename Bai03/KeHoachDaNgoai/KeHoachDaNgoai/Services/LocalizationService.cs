using System;
using System.Collections.Generic;
using System.Globalization;

namespace KeHoachDaNgoai.Services;

public static class LocalizationService
{
    public const string Vietnamese = "vi-VN";
    public const string English = "en-US";

    public static string CurrentLanguage { get; private set; } = Vietnamese;
    public static CultureInfo CurrentCulture => new CultureInfo(CurrentLanguage);

    public static void SetLanguage(string language)
    {
        if (language == English)
        {
            CurrentLanguage = English;
        }
        else
        {
            CurrentLanguage = Vietnamese;
        }
    }

    public static bool IsVietnamese => CurrentLanguage == Vietnamese;

    public static string GetVehicleName(string internalName)
    {
        if (IsVietnamese)
        {
            return internalName switch
            {
                "Motorbike" => "Xe máy",
                "Car" => "Ô tô",
                "Coach" => "Xe khách",
                "Bus" => "Xe khách",
                "Train" => "Tàu hỏa",
                _ => internalName
            };
        }
        else
        {
            return internalName switch
            {
                "Xe máy" => "Motorbike",
                "Ô tô" => "Car",
                "Xe khách" => "Coach",
                "Tàu hỏa" => "Train",
                _ => internalName
            };
        }
    }

    public static string[] GetVehicleList()
    {
        return IsVietnamese
            ? new[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" }
            : new[] { "Motorbike", "Car", "Coach", "Train" };
    }

    public static string ToStandardVehicle(string displayName)
    {
        return displayName switch
        {
            "Motorbike" => "Xe máy",
            "Car" => "Ô tô",
            "Coach" => "Xe khách",
            "Train" => "Tàu hỏa",
            _ => displayName
        };
    }

    public static string FormatDate(DateOnly date)
    {
        return date.ToString(IsVietnamese ? "dd/MM/yyyy" : "MM/dd/yyyy", CurrentCulture);
    }

    public static string FormatCurrency(decimal amount)
    {
        if (IsVietnamese)
        {
            return amount.ToString("#,##0", new CultureInfo("vi-VN"));
        }
        else
        {
            return amount.ToString("$#,##0", new CultureInfo("en-US"));
        }
    }

    public static string GetWeatherDescription(int weatherCode)
    {
        if (IsVietnamese)
        {
            return weatherCode switch
            {
                0 => "Trời quang",
                1 => "Trời quang đãng",
                2 => "Có mây rải rác",
                3 => "Nhiều mây",
                45 or 48 => "Sương mù",
                51 => "Mưa phùn nhẹ",
                53 => "Mưa phùn vừa",
                55 => "Mưa phùn dày hạt",
                56 or 57 => "Mưa phùn băng giá",
                61 => "Mưa nhẹ",
                63 => "Mưa vừa",
                65 => "Mưa to",
                66 or 67 => "Mưa đá",
                71 or 73 or 75 or 77 => "Tuyết rơi",
                80 => "Mưa rào nhẹ",
                81 => "Mưa rào vừa",
                82 => "Mưa rào to",
                85 or 86 => "Mưa tuyết",
                95 => "Dông",
                96 or 99 => "Dông kèm mưa đá",
                _ => weatherCode >= 51 && weatherCode <= 67 || weatherCode >= 80 && weatherCode <= 82 ? "Mưa" : "Có mây"
            };
        }
        else
        {
            return weatherCode switch
            {
                0 => "Clear sky",
                1 => "Mainly clear",
                2 => "Partly cloudy",
                3 => "Overcast",
                45 or 48 => "Foggy",
                51 => "Light drizzle",
                53 => "Moderate drizzle",
                55 => "Dense drizzle",
                56 or 57 => "Freezing drizzle",
                61 => "Slight rain",
                63 => "Moderate rain",
                65 => "Heavy rain",
                66 or 67 => "Freezing rain",
                71 or 73 or 75 or 77 => "Snowfall",
                80 => "Light rain showers",
                81 => "Moderate rain showers",
                82 => "Violent rain showers",
                85 or 86 => "Snow showers",
                95 => "Thunderstorm",
                96 or 99 => "Thunderstorm with hail",
                _ => weatherCode >= 51 && weatherCode <= 67 || weatherCode >= 80 && weatherCode <= 82 ? "Rain" : "Cloudy"
            };
        }
    }

    public static string T(string key)
    {
        if (Translations.TryGetValue(key, out var dict))
        {
            if (dict.TryGetValue(CurrentLanguage, out var val))
            {
                return val;
            }
        }
        return key;
    }

    private static readonly Dictionary<string, Dictionary<string, string>> Translations = new()
    {
        ["AppTitle"] = new()
        {
            [Vietnamese] = "Kế hoạch dã ngoại cuối tuần",
            [English] = "Weekend Picnic Planner"
        },
        ["HeaderTitle"] = new()
        {
            [Vietnamese] = "Kế hoạch dã ngoại cuối tuần",
            [English] = "Weekend Picnic Planner"
        },
        ["Language"] = new()
        {
            [Vietnamese] = "Ngôn ngữ",
            [English] = "Language"
        },
        ["TripInfoGroup"] = new()
        {
            [Vietnamese] = "Thông tin chuyến đi",
            [English] = "Trip Information"
        },
        ["TripName"] = new()
        {
            [Vietnamese] = "Tên chuyến",
            [English] = "Trip Name"
        },
        ["Destination"] = new()
        {
            [Vietnamese] = "Địa điểm",
            [English] = "Destination"
        },
        ["DepartureDate"] = new()
        {
            [Vietnamese] = "Ngày đi",
            [English] = "Departure Date"
        },
        ["PeopleCount"] = new()
        {
            [Vietnamese] = "Số người",
            [English] = "People"
        },
        ["Budget"] = new()
        {
            [Vietnamese] = "Ngân sách",
            [English] = "Budget"
        },
        ["Vehicle"] = new()
        {
            [Vietnamese] = "Phương tiện",
            [English] = "Vehicle"
        },
        ["Completed"] = new()
        {
            [Vietnamese] = "Đã hoàn thành",
            [English] = "Completed"
        },
        ["Notes"] = new()
        {
            [Vietnamese] = "Ghi chú",
            [English] = "Notes"
        },
        ["Add"] = new()
        {
            [Vietnamese] = "Thêm",
            [English] = "Add"
        },
        ["Edit"] = new()
        {
            [Vietnamese] = "Sửa",
            [English] = "Update"
        },
        ["Delete"] = new()
        {
            [Vietnamese] = "Xóa",
            [English] = "Delete"
        },
        ["Refresh"] = new()
        {
            [Vietnamese] = "Làm mới",
            [English] = "Reset"
        },
        ["CheckWeather"] = new()
        {
            [Vietnamese] = "Xem thời tiết",
            [English] = "Check Weather"
        },
        ["WeatherForecastFor"] = new()
        {
            [Vietnamese] = "Dự báo thời tiết ngày {0} - {1}",
            [English] = "Weather forecast for {0} - {1}"
        },
        ["Temperature"] = new()
        {
            [Vietnamese] = "Nhiệt độ: {0}°C - {1}°C",
            [English] = "Temperature: {0}°C - {1}°C"
        },
        ["RainProbability"] = new()
        {
            [Vietnamese] = "Khả năng mưa: {0}%",
            [English] = "Rain probability: {0}%"
        },
        ["RainWarningAdvice"] = new()
        {
            [Vietnamese] = "Nên mang áo mưa hoặc cân nhắc dời lịch",
            [English] = "Should bring a raincoat or consider rescheduling"
        },
        ["GoodWeatherAdvice"] = new()
        {
            [Vietnamese] = "Thời tiết thuận lợi cho chuyến dã ngoại!",
            [English] = "Weather looks favorable for your trip!"
        },
        ["NoForecastAvailable"] = new()
        {
            [Vietnamese] = "Chưa có dữ liệu dự báo (chỉ dự báo tối đa 16 ngày)",
            [English] = "No forecast data available (maximum 16 days ahead)"
        },
        ["SearchPlaceholder"] = new()
        {
            [Vietnamese] = "Tìm tên chuyến hoặc địa điểm...",
            [English] = "Search trip name or destination..."
        },
        ["OnlyUncompleted"] = new()
        {
            [Vietnamese] = "Chỉ hiện chuyến chưa hoàn thành",
            [English] = "Show only uncompleted trips"
        },
        ["Search"] = new()
        {
            [Vietnamese] = "Tìm",
            [English] = "Search"
        },
        ["ShowAll"] = new()
        {
            [Vietnamese] = "Bỏ lọc",
            [English] = "Show All"
        },
        ["FilterByDate"] = new()
        {
            [Vietnamese] = "Khoảng ngày:",
            [English] = "Date range:"
        },
        ["FromDate"] = new()
        {
            [Vietnamese] = "Từ",
            [English] = "From"
        },
        ["ToDate"] = new()
        {
            [Vietnamese] = "Đến",
            [English] = "To"
        },
        ["ColId"] = new()
        {
            [Vietnamese] = "Mã",
            [English] = "ID"
        },
        ["ColTripName"] = new()
        {
            [Vietnamese] = "Tên chuyến",
            [English] = "Trip Name"
        },
        ["ColDestination"] = new()
        {
            [Vietnamese] = "Địa điểm",
            [English] = "Destination"
        },
        ["ColDepartureDate"] = new()
        {
            [Vietnamese] = "Ngày đi",
            [English] = "Departure Date"
        },
        ["ColPeopleCount"] = new()
        {
            [Vietnamese] = "Số người",
            [English] = "People"
        },
        ["ColBudget"] = new()
        {
            [Vietnamese] = "Ngân sách",
            [English] = "Budget"
        },
        ["ColVehicle"] = new()
        {
            [Vietnamese] = "Phương tiện",
            [English] = "Vehicle"
        },
        ["ColCompleted"] = new()
        {
            [Vietnamese] = "Hoàn thành",
            [English] = "Completed"
        },
        ["ColNotes"] = new()
        {
            [Vietnamese] = "Ghi chú",
            [English] = "Notes"
        },
        ["ValTripNameRequired"] = new()
        {
            [Vietnamese] = "Vui lòng nhập tên chuyến đi!",
            [English] = "Please enter trip name!"
        },
        ["ValDestinationRequired"] = new()
        {
            [Vietnamese] = "Vui lòng nhập địa điểm!",
            [English] = "Please enter destination!"
        },
        ["ValDatePast"] = new()
        {
            [Vietnamese] = "Ngày đi không được nhỏ hơn hôm nay khi thêm mới!",
            [English] = "Departure date cannot be earlier than today for new trips!"
        },
        ["ValPeopleMin"] = new()
        {
            [Vietnamese] = "Số người phải từ 1 người trở lên!",
            [English] = "Number of people must be at least 1!"
        },
        ["ValBudgetMin"] = new()
        {
            [Vietnamese] = "Ngân sách không được âm!",
            [English] = "Budget cannot be negative!"
        },
        ["ValSelectTripToEdit"] = new()
        {
            [Vietnamese] = "Vui lòng chọn chuyến đi cần sửa!",
            [English] = "Please select a trip to update!"
        },
        ["ValSelectTripToDelete"] = new()
        {
            [Vietnamese] = "Vui lòng chọn chuyến đi cần xóa!",
            [English] = "Please select a trip to delete!"
        },
        ["ConfirmDeleteTitle"] = new()
        {
            [Vietnamese] = "Xác nhận xóa",
            [English] = "Confirm Delete"
        },
        ["ConfirmDeleteMessage"] = new()
        {
            [Vietnamese] = "Bạn có chắc chắn muốn xóa chuyến đi '{0}' không?",
            [English] = "Are you sure you want to delete trip '{0}'?"
        },
        ["AddSuccess"] = new()
        {
            [Vietnamese] = "Thêm chuyến đi thành công!",
            [English] = "Trip added successfully!"
        },
        ["UpdateSuccess"] = new()
        {
            [Vietnamese] = "Cập nhật chuyến đi thành công!",
            [English] = "Trip updated successfully!"
        },
        ["DeleteSuccess"] = new()
        {
            [Vietnamese] = "Xóa chuyến đi thành công!",
            [English] = "Trip deleted successfully!"
        },
        ["LocationNotFound"] = new()
        {
            [Vietnamese] = "Không tìm thấy địa danh '{0}'. Bạn hãy thử nhập tên không dấu (ví dụ: '{1}').",
            [English] = "Location '{0}' not found. Try entering an unaccented name (e.g. '{1}')."
        },
        ["NetworkError"] = new()
        {
            [Vietnamese] = "Lỗi kết nối mạng: Không thể tải dữ liệu thời tiết. Vui lòng kiểm tra lại kết nối internet.",
            [English] = "Network error: Unable to fetch weather data. Please check your internet connection."
        },
        ["WeatherApiError"] = new()
        {
            [Vietnamese] = "Không thể lấy thông tin thời tiết: {0}",
            [English] = "Unable to fetch weather info: {0}"
        },
        ["LoadingWeather"] = new()
        {
            [Vietnamese] = "Đang tải dữ liệu thời tiết...",
            [English] = "Loading weather forecast..."
        },
        ["SelectTripPrompt"] = new()
        {
            [Vietnamese] = "Chọn một chuyến đi để xem dự báo thời tiết",
            [English] = "Select a trip to view weather forecast"
        }
    };
}

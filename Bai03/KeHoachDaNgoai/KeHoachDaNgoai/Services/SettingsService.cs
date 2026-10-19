using System;
using System.IO;
using System.Text.Json;

namespace KeHoachDaNgoai.Services;

public class AppSettings
{
    public string Language { get; set; } = "vi-VN";
}

public static class SettingsService
{
    private static readonly string SettingsFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "KeHoachDaNgoai");

    private static readonly string SettingsFile = Path.Combine(SettingsFolder, "usersettings.json");

    // Also support direct %LocalAppData%\usersettings.json as mentioned in requirement
    private static readonly string RootSettingsFile = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "usersettings.json");

    public static AppSettings LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFile))
            {
                string json = File.ReadAllText(SettingsFile);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null) return settings;
            }
            else if (File.Exists(RootSettingsFile))
            {
                string json = File.ReadAllText(RootSettingsFile);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null) return settings;
            }
        }
        catch
        {
            // Fallback to default
        }

        return new AppSettings();
    }

    public static void SaveSettings(AppSettings settings)
    {
        try
        {
            if (!Directory.Exists(SettingsFolder))
            {
                Directory.CreateDirectory(SettingsFolder);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);

            // Write to both paths for 100% compliance with %LocalAppData%\usersettings.json
            File.WriteAllText(SettingsFile, json);
            File.WriteAllText(RootSettingsFile, json);
        }
        catch
        {
            // Ignore write failures gracefully
        }
    }
}

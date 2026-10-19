using Microsoft.Extensions.Configuration;

namespace SoChiTieuCaNhan.Config;

/// <summary>
/// Service đọc file cấu hình json bằng ConfigurationBuilder và bind vào AppConfig
/// </summary>
public static class AppConfigService
{
    private static AppConfig? _instance;
    private static readonly object _lock = new();

    public static AppConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= LoadConfiguration();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Đọc cấu hình từ appsettings.json và appsettings.{Environment}.json
    /// </summary>
    public static AppConfig LoadConfiguration()
    {
        string basePath = AppContext.BaseDirectory;
        string? environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        if (string.IsNullOrWhiteSpace(environment))
        {
            environment = "Development";
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configurationRoot = builder.Build();

        var config = new AppConfig();
        configurationRoot.Bind(config);

        return config;
    }

    /// <summary>
    /// Cho phép reload cấu hình khi cần thiết
    /// </summary>
    public static void Reload()
    {
        lock (_lock)
        {
            _instance = LoadConfiguration();
        }
    }
}

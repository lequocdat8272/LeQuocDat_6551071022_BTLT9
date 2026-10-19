namespace SoChiTieuCaNhan.Config;

/// <summary>
/// Lớp cấu hình strongly-typed cho ứng dụng
/// </summary>
public class AppConfig
{
    public ConnectionStringsConfig ConnectionStrings { get; set; } = new();
    public LoggingConfig Logging { get; set; } = new();
}

public class ConnectionStringsConfig
{
    public string DefaultConnection { get; set; } = string.Empty;
}

public class LoggingConfig
{
    public string LogDirectory { get; set; } = "Logs";
}

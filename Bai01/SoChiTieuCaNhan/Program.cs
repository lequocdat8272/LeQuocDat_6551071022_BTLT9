using System;
using System.IO;
using System.Windows.Forms;
using Serilog;
using SoChiTieuCaNhan.Config;

namespace SoChiTieuCaNhan;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        if (args.Length > 0 && args[0] == "--test")
        {
            TestRunner.RunTests();
            return;
        }

        // 1. Đọc cấu hình thư mục logs từ AppConfig
        string logDir = AppConfigService.Instance.Logging.LogDirectory;
        string logPath = Path.Combine(AppContext.BaseDirectory, logDir, "log-.txt");

        // 2. Khởi tạo Serilog ghi file theo ngày vào thư mục Logs cạnh file .exe với UTF-8 encoding
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                path: logPath,
                rollingInterval: RollingInterval.Day,
                encoding: System.Text.Encoding.UTF8,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("=== Ứng dụng 'Sổ chi tiêu cá nhân' bắt đầu khởi động ===");

        try
        {
            ApplicationConfiguration.Initialize();
            Application.SetDefaultFont(new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point));
            Application.Run(new FormChiTieu());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng bị lỗi nghiêm trọng không xử lý được: {Message}", ex.Message);
            MessageBox.Show($"Ứng dụng bị dừng đột ngột do lỗi nghiêm trọng:\n{ex.Message}", 
                            "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
            Log.Information("=== Ứng dụng 'Sổ chi tiêu cá nhân' kết thúc phiên làm việc ===");
            Log.CloseAndFlush();
        }
    }    
}
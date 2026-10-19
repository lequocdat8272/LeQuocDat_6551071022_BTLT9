using Serilog;

namespace QuanLyNhaTro;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Cấu hình Serilog ghi log vào thư mục logs/ với rolling hàng ngày
        string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        string logFilePath = Path.Combine(logDirectory, "app-.log");

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                path: logFilePath,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Quản lý nhà trọ bắt đầu khởi chạy.");

        // 2. Cấu hình ứng dụng WinForms
        ApplicationConfiguration.Initialize();

        // 3. Đăng ký chế độ bắt lỗi toàn cục
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        // Bắt lỗi trên UI Thread
        Application.ThreadException += (sender, e) =>
        {
            Log.Error(e.Exception, "Lỗi giao diện chưa được xử lý (Application.ThreadException)");
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        // Bắt lỗi trên AppDomain / Background Threads
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                Log.Fatal(ex, "Lỗi hệ thống chưa được xử lý (AppDomain.CurrentDomain.UnhandledException)");
            }
            else
            {
                Log.Fatal("Lỗi hệ thống không xác định: {ExceptionObject}", e.ExceptionObject);
            }
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        try
        {
            // 4. Khởi chạy form Quản lý khách thuê
            Application.Run(new FormKhachThue());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Lỗi nghiêm trọng cấp ứng dụng.");
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng Quản lý nhà trọ đang đóng.");
            Log.CloseAndFlush();
        }
    }
}
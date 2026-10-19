using System;
using System.Windows.Forms;
using Serilog;

namespace BanHangQuanTraSua
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("logs/trasua-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Ứng dụng Bán hàng Quán trà sữa khởi động.");
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng gặp lỗi không mong muốn.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
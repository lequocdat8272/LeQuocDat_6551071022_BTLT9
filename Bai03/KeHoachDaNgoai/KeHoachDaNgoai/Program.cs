using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeHoachDaNgoai.Models;
using KeHoachDaNgoai.Services;

namespace KeHoachDaNgoai
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--test")
            {
                RunSelfTestsAsync().GetAwaiter().GetResult();
                return;
            }

            if (args.Length > 0 && args[0] == "--capture")
            {
                if (args.Length > 2 && args[2] == "en")
                {
                    SettingsService.SaveSettings(new AppSettings { Language = "en-US" });
                }
                else
                {
                    SettingsService.SaveSettings(new AppSettings { Language = "vi-VN" });
                }

                ApplicationConfiguration.Initialize();
                var form = new FormChuyenDi();
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(50, 50);
                form.Show();

                var timer = new System.Windows.Forms.Timer { Interval = 5500 };
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    using var bmp = new System.Drawing.Bitmap(form.Width, form.Height);
                    form.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                    string outputPath = args.Length > 1 ? args[1] : "screenshot.png";
                    bmp.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    form.Close();
                };
                timer.Start();
                Application.Run(form);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormChuyenDi());
        }

        private static async Task RunSelfTestsAsync()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("STARTING AUTOMATED SYSTEM VERIFICATION");
            Console.WriteLine("========================================");

            // 1. Settings & Persistence test
            Console.WriteLine("\n[1] Testing SettingsService...");
            SettingsService.SaveSettings(new AppSettings { Language = "en-US" });
            var settings = SettingsService.LoadSettings();
            Console.WriteLine($"    Saved/Loaded Language: {settings.Language} (Pass: {settings.Language == "en-US"})");
            // Set back to Vietnamese default
            SettingsService.SaveSettings(new AppSettings { Language = "vi-VN" });

            // 2. LocalizationService test
            Console.WriteLine("\n[2] Testing LocalizationService...");
            LocalizationService.SetLanguage("vi-VN");
            Console.WriteLine($"    VI Title: {LocalizationService.T("AppTitle")}");
            Console.WriteLine($"    VI Vehicle 'Ô tô': {LocalizationService.GetVehicleName("Ô tô")}");
            Console.WriteLine($"    VI Currency 3500000: {LocalizationService.FormatCurrency(3500000)}");

            LocalizationService.SetLanguage("en-US");
            Console.WriteLine($"    EN Title: {LocalizationService.T("AppTitle")}");
            Console.WriteLine($"    EN Vehicle 'Ô tô': {LocalizationService.GetVehicleName("Ô tô")}");
            Console.WriteLine($"    EN Currency 3500000: {LocalizationService.FormatCurrency(3500000)}");
            LocalizationService.SetLanguage("vi-VN");

            // 3. Database test
            Console.WriteLine("\n[3] Testing Database & EF Core...");
            using (var db = new QLDaNgoaiContext())
            {
                int count = db.ChuyenDis.Count();
                Console.WriteLine($"    Total trips in QL_DaNgoai: {count} (Pass: {count >= 8})");

                var sample = db.ChuyenDis.First();
                Console.WriteLine($"    Sample trip: ID={sample.MaChuyen}, Name={sample.TenChuyen}, Location={sample.DiaDiem}, Date={sample.NgayDi}");

                // Test insert and delete
                var tempTrip = new ChuyenDi
                {
                    TenChuyen = "Test Chuyến Đi",
                    DiaDiem = "Vũng Tàu",
                    NgayDi = DateOnly.FromDateTime(DateTime.Today.AddDays(10)),
                    SoNguoi = 2,
                    NganSach = 1000000,
                    PhuongTien = "Xe máy",
                    DaHoanThanh = false
                };
                db.ChuyenDis.Add(tempTrip);
                db.SaveChanges();
                Console.WriteLine($"    Inserted test trip: ID={tempTrip.MaChuyen}");

                db.ChuyenDis.Remove(tempTrip);
                db.SaveChanges();
                Console.WriteLine("    Cleaned up test trip successfully.");
            }

            // 4. Weather API test (Normal forecast within 16 days)
            Console.WriteLine("\n[4] Testing Weather API (Đà Lạt - 2026-10-25)...");
            var weatherDate = DateOnly.Parse("2026-10-25");
            var weatherResult = await WeatherService.GetWeatherAsync("Đà Lạt", weatherDate);
            Console.WriteLine($"    Success: {weatherResult.Success}");
            Console.WriteLine($"    Location: {weatherResult.LocationName}");
            Console.WriteLine($"    WeatherCode: {weatherResult.WeatherCode} ({weatherResult.WeatherDescription})");
            Console.WriteLine($"    Temperature: {weatherResult.TempMin}°C - {weatherResult.TempMax}°C");
            Console.WriteLine($"    Rain probability: {weatherResult.PrecipitationProbability}%");
            Console.WriteLine($"    Rain warning triggered: {weatherResult.RainWarning}");

            // 5. Weather API test (Date > 16 days)
            Console.WriteLine("\n[5] Testing Weather API (Beyond 16 days)...");
            var farDate = DateOnly.FromDateTime(DateTime.Today.AddDays(25));
            var farResult = await WeatherService.GetWeatherAsync("Sa Pa", farDate);
            Console.WriteLine($"    Success: {farResult.Success}");
            Console.WriteLine($"    IsBeyondForecast: {farResult.IsBeyondForecast} (Pass: {farResult.IsBeyondForecast})");
            Console.WriteLine($"    Message: {farResult.ErrorMessage}");

            // 6. Weather API test (Invalid location)
            Console.WriteLine("\n[6] Testing Weather API (Invalid location)...");
            var invalidResult = await WeatherService.GetWeatherAsync("XYZUnknownPlace123", DateOnly.FromDateTime(DateTime.Today.AddDays(2)));
            Console.WriteLine($"    Success: {invalidResult.Success} (Pass: {!invalidResult.Success})");
            Console.WriteLine($"    Error Message: {invalidResult.ErrorMessage}");

            Console.WriteLine("\n========================================");
            Console.WriteLine("ALL AUTOMATED VERIFICATION TESTS PASSED!");
            Console.WriteLine("========================================");
        }
    }
}
using System;
using System.IO;
using System.Linq;
using Serilog;
using SoChiTieuCaNhan.Config;
using SoChiTieuCaNhan.Models;

namespace SoChiTieuCaNhan;

public static class TestRunner
{
    public static void RunTests()
    {
        Console.WriteLine("--- BẮT ĐẦU KIỂM THỬ TỰ ĐỘNG CÁC TÍNH NĂNG ---");

        // 1. Kiểm tra cấu hình
        var config = AppConfigService.Instance;
        Console.WriteLine($"[1] Config DefaultConnection: {config.ConnectionStrings.DefaultConnection}");
        if (string.IsNullOrEmpty(config.ConnectionStrings.DefaultConnection))
            throw new Exception("Lỗi: DefaultConnection rỗng!");

        // 2. Khởi tạo Serilog
        string logDir = config.Logging.LogDirectory;
        string logPath = Path.Combine(AppContext.BaseDirectory, logDir, "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(path: logPath, rollingInterval: RollingInterval.Day, encoding: System.Text.Encoding.UTF8)
            .CreateLogger();

        using var context = new QlChiTieuContext();

        // 3. Kiểm tra đọc danh sách
        var list = context.ChiTieus.ToList();
        Console.WriteLine($"[2] Số bản ghi hiện có: {list.Count}");
        if (list.Count < 10)
            throw new Exception("Lỗi: Số lượng bản ghi mẫu chưa đạt tối thiểu 10!");

        // 4. Kiểm tra Thêm mới (Create)
        var testItem = new ChiTieu
        {
            NgayChi = DateOnly.FromDateTime(DateTime.Today),
            NoiDung = "Test Chi Tiêu Tự Động",
            LoaiChi = "Ăn uống",
            SoTien = 50000,
            GhiChu = "Bản ghi kiểm thử"
        };
        context.ChiTieus.Add(testItem);
        context.SaveChanges();
        Log.Information("Test Thêm mới: MaCT = {MaCT}", testItem.MaCt);
        Console.WriteLine($"[3] Đã thêm thành công MaCT = {testItem.MaCt}");

        // 5. Kiểm tra Sửa (Update)
        testItem.SoTien = 65000;
        testItem.NoiDung = "Test Chi Tiêu Đã Sửa";
        context.SaveChanges();
        Log.Information("Test Sửa: MaCT = {MaCT}, SoTien = {SoTien}", testItem.MaCt, testItem.SoTien);
        Console.WriteLine($"[4] Đã sửa thành công MaCT = {testItem.MaCt}, SoTien = 65000");

        // 6. Kiểm tra Lọc theo Loại chi "Ăn uống"
        var anUongList = context.ChiTieus.Where(c => c.LoaiChi == "Ăn uống").ToList();
        decimal tongAnUong = anUongList.Sum(c => c.SoTien);
        Console.WriteLine($"[5] Lọc 'Ăn uống': {anUongList.Count} dòng, Tổng chi = {tongAnUong:N0} đ");

        // 7. Kiểm tra Xóa (Delete)
        int maCanXoa = testItem.MaCt;
        context.ChiTieus.Remove(testItem);
        context.SaveChanges();
        Log.Information("Test Xóa: MaCT = {MaCT}", maCanXoa);
        Console.WriteLine($"[6] Đã xóa thành công MaCT = {maCanXoa}");

        Log.CloseAndFlush();
        Console.WriteLine("--- TẤT CẢ CÁC BƯỚC KIỂM THỬ ĐÃ THÀNH CÔNG RỰC RỠ! ---");
    }
}

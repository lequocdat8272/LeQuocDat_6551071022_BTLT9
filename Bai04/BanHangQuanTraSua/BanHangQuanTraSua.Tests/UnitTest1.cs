using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using BanHangQuanTraSua.Configurations;
using BanHangQuanTraSua.Models;

namespace BanHangQuanTraSua.Tests;

[TestClass]
public class IntegrationTests
{
    [TestMethod]
    public void TestDatabaseConnectionAndSeedData()
    {
        using var db = new QLTraSuaContext();
        var danhMucs = db.DanhMucMons.ToList();
        Assert.IsTrue(danhMucs.Count >= 4, "Phải có ít nhất 4 danh mục món.");

        var monUongs = db.MonUongs.Include(m => m.MaDmNavigation).ToList();
        Assert.IsTrue(monUongs.Count >= 12, "Phải có ít nhất 12 món uống.");

        foreach (var mon in monUongs)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(mon.TenMon), "Tên món không được trống.");
            Assert.IsTrue(mon.GiaBan > 0, "Giá bán phải lớn hơn 0.");
            Assert.IsNotNull(mon.MaDmNavigation, "Mỗi món phải thuộc một danh mục hợp lệ.");
        }
    }

    [TestMethod]
    public void TestPaymentConfiguration()
    {
        var config = ConfigurationHelper.GetPaymentConfig();
        Assert.IsNotNull(config, "Cấu hình Payment không được null.");
        Assert.IsFalse(string.IsNullOrWhiteSpace(config.BankId), "BankId không được trống.");
        Assert.IsFalse(string.IsNullOrWhiteSpace(config.AccountNo), "AccountNo không được trống.");
        Assert.IsFalse(string.IsNullOrWhiteSpace(config.AccountName), "AccountName không được trống.");
        Assert.IsFalse(string.IsNullOrWhiteSpace(config.Template), "Template không được trống.");
    }

    [TestMethod]
    public async Task TestVietQrGenerationAndDownload()
    {
        var config = ConfigurationHelper.GetPaymentConfig();
        decimal tongTien = 120000;
        string noiDung = "TRASUA HD9999";

        string qrUrl = $"https://img.vietqr.io/image/{Uri.EscapeDataString(config.BankId)}-{Uri.EscapeDataString(config.AccountNo)}-{Uri.EscapeDataString(config.Template)}.png?amount={Uri.EscapeDataString(((long)tongTien).ToString())}&addInfo={Uri.EscapeDataString(noiDung)}&accountName={Uri.EscapeDataString(config.AccountName)}";

        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(10);
        byte[] bytes = await client.GetByteArrayAsync(qrUrl);

        Assert.IsNotNull(bytes, "Dữ liệu ảnh tải về không được null.");
        Assert.IsTrue(bytes.Length > 1000, "Dữ liệu ảnh PNG phải có kích thước hợp lệ.");

        // Check PNG signature: 89 50 4E 47 0D 0A 1A 0A
        Assert.AreEqual(0x89, bytes[0]);
        Assert.AreEqual(0x50, bytes[1]);
        Assert.AreEqual(0x4E, bytes[2]);
        Assert.AreEqual(0x47, bytes[3]);
    }

    [TestMethod]
    public void TestCreateInvoiceSingleSaveChanges()
    {
        using var db = new QLTraSuaContext();
        var firstDrink = db.MonUongs.First();

        var hoaDon = new HoaDon
        {
            NgayLap = DateTime.Now,
            TongTien = firstDrink.GiaBan * 2,
            HinhThucTt = "Chuyển khoản",
            DaThanhToan = true
        };

        hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
        {
            MaMon = firstDrink.MaMon,
            SoLy = 2,
            DonGia = firstDrink.GiaBan
        });

        db.HoaDons.Add(hoaDon);
        int rowsAffected = db.SaveChanges();

        Assert.IsTrue(rowsAffected >= 2, "SaveChanges phải lưu cả HoaDon và ChiTietHoaDon trong 1 lần.");
        Assert.IsTrue(hoaDon.MaHd > 0, "MaHD identity phải được gán.");

        // Verify retrieval
        var retrieved = db.HoaDons
            .Include(h => h.ChiTietHoaDons)
            .FirstOrDefault(h => h.MaHd == hoaDon.MaHd);

        Assert.IsNotNull(retrieved);
        Assert.AreEqual(1, retrieved.ChiTietHoaDons.Count);
        Assert.AreEqual(firstDrink.MaMon, retrieved.ChiTietHoaDons.First().MaMon);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BanHangQuanTraSua.Configurations;
using BanHangQuanTraSua.Models;

namespace BanHangQuanTraSua
{
    public partial class Form1 : Form
    {
        private class DrinkItemDisplay
        {
            public MonUong Mon { get; set; } = null!;
            public override string ToString()
            {
                return $"{Mon.TenMon} - {Mon.GiaBan:N0}";
            }
        }

        private class CartRowView
        {
            public int MaMon { get; set; }
            public string TenMon { get; set; } = string.Empty;
            public int SoLy { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLy * DonGia;
            public string DonGiaStr => DonGia.ToString("N0");
            public string ThanhTienStr => ThanhTien.ToString("N0");
        }

        private readonly List<CartItem> _cart = new();
        private decimal _tongTien = 0;
        private int _pendingMaHd = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            UpdateCartGrid();
        }

        private void LoadDanhMuc()
        {
            try
            {
                using var db = new QLTraSuaContext();
                var danhMucs = db.DanhMucMons.OrderBy(d => d.MaDm).ToList();

                cboDanhMuc.DataSource = danhMucs;
                cboDanhMuc.DisplayMember = "TenDm";
                cboDanhMuc.ValueMember = "MaDm";

                if (danhMucs.Count > 0)
                {
                    cboDanhMuc.SelectedIndex = 0;
                    if (cboDanhMuc.SelectedValue is int maDm)
                    {
                        LoadMonTheoDanhMuc(maDm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Lỗi kết nối CSDL khi nạp danh mục.");
            }
        }

        private void LoadMonTheoDanhMuc(int maDm)
        {
            try
            {
                using var db = new QLTraSuaContext();
                var mons = db.MonUongs
                    .Where(m => m.MaDm == maDm && m.DangBan)
                    .OrderBy(m => m.TenMon)
                    .ToList();

                lstMonUong.Items.Clear();
                foreach (var m in mons)
                {
                    lstMonUong.Items.Add(new DrinkItemDisplay { Mon = m });
                }

                if (lstMonUong.Items.Count > 0)
                {
                    lstMonUong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue is int maDm)
            {
                LoadMonTheoDanhMuc(maDm);
            }
        }

        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            ThemMonDuocChon();
        }

        private void lstMonUong_DoubleClick(object sender, EventArgs e)
        {
            ThemMonDuocChon();
        }

        private void ThemMonDuocChon()
        {
            if (lstMonUong.SelectedItem is not DrinkItemDisplay displayItem)
            {
                MessageBox.Show("Vui lòng chọn một món từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLy = (int)numSoLy.Value;
            if (soLy <= 0) soLy = 1;

            var existing = _cart.FirstOrDefault(c => c.MaMon == displayItem.Mon.MaMon);
            if (existing != null)
            {
                existing.SoLy += soLy;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    MaMon = displayItem.Mon.MaMon,
                    TenMon = displayItem.Mon.TenMon,
                    SoLy = soLy,
                    DonGia = displayItem.Mon.GiaBan
                });
            }

            UpdateCartGrid();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trong đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDonHang.CurrentRow.DataBoundItem is CartRowView row)
            {
                var item = _cart.FirstOrDefault(c => c.MaMon == row.MaMon);
                if (item != null)
                {
                    _cart.Remove(item);
                    UpdateCartGrid();
                }
            }
        }

        private void UpdateCartGrid()
        {
            var viewList = _cart.Select(c => new CartRowView
            {
                MaMon = c.MaMon,
                TenMon = c.TenMon,
                SoLy = c.SoLy,
                DonGia = c.DonGia
            }).ToList();

            dgvDonHang.DataSource = null;
            dgvDonHang.DataSource = viewList;

            _tongTien = _cart.Sum(c => c.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {_tongTien:N0} đ";

            if (_cart.Count == 0)
            {
                ResetPaymentDisplay();
            }
        }

        private void ResetPaymentDisplay()
        {
            picQR.Image?.Dispose();
            picQR.Image = null;
            lblSoTien.Text = "Số tiền:    0 đ";
            lblNoiDung.Text = "Nội dung: ";
            _pendingMaHd = 0;
        }

        private async void btnThanhToanChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0 || _tongTien <= 0)
            {
                MessageBox.Show("Đơn hàng đang trống! Vui lòng thêm món trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnThanhToanChuyenKhoan.Enabled = false;

                using var db = new QLTraSuaContext();
                _pendingMaHd = (db.HoaDons.Max(h => (int?)h.MaHd) ?? 0) + 1;
                string noiDung = $"TRASUA HD{_pendingMaHd}";

                var config = ConfigurationHelper.GetPaymentConfig();

                lblSoTien.Text = $"Số tiền:    {_tongTien:N0} đ";
                lblNoiDung.Text = $"Nội dung:  {noiDung}";

                // Log with Serilog without exposing full account number (Task 7)
                string maskedAccount = MaskAccountNumber(config.AccountNo);
                Log.Information("Tạo mã QR cho hóa đơn HD{MaHD}, Số tiền: {TongTien:N0} đ, Ngân hàng: {BankId}, TK: {AccountMasked}",
                    _pendingMaHd, _tongTien, config.BankId, maskedAccount);

                // Construct VietQR URL (Task 5)
                string qrUrl = $"https://img.vietqr.io/image/{Uri.EscapeDataString(config.BankId)}-{Uri.EscapeDataString(config.AccountNo)}-{Uri.EscapeDataString(config.Template)}.png?amount={Uri.EscapeDataString(((long)_tongTien).ToString())}&addInfo={Uri.EscapeDataString(noiDung)}&accountName={Uri.EscapeDataString(config.AccountName)}";

                await LoadQrImageAsync(qrUrl, config, noiDung, _tongTien, _pendingMaHd);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi bất ngờ khi xử lý thanh toán chuyển khoản cho hóa đơn HD{MaHD}.", _pendingMaHd);
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnThanhToanChuyenKhoan.Enabled = true;
            }
        }

        private async Task LoadQrImageAsync(string qrUrl, PaymentConfig config, string noiDung, decimal tongTien, int maHd)
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(6);

                byte[] imageBytes = await httpClient.GetByteArrayAsync(qrUrl);
                using var ms = new MemoryStream(imageBytes);
                var bmp = new Bitmap(ms);

                picQR.Image?.Dispose();
                picQR.Image = bmp;
            }
            catch (Exception ex)
            {
                // Task 7: Serilog ghi Error khi tải ảnh QR thất bại, và hiển thị fallback chuyển tay
                Log.Error(ex, "Tải ảnh mã QR cho hóa đơn HD{MaHD} thất bại.", maHd);

                picQR.Image?.Dispose();
                picQR.Image = CreateFallbackQrImage(config, noiDung, tongTien);

                MessageBox.Show(
                    "Không thể tải mã ảnh QR từ máy chủ VietQR (có thể do mất kết nối mạng).\n\n" +
                    $"Quý khách có thể chuyển khoản thủ công theo thông tin:\n" +
                    $"- Ngân hàng: {config.BankId.ToUpper()}\n" +
                    $"- STK: {config.AccountNo}\n" +
                    $"- Tên tài khoản: {config.AccountName}\n" +
                    $"- Số tiền: {tongTien:N0} đ\n" +
                    $"- Nội dung: {noiDung}\n\n" +
                    "Hoặc quý khách có thể chuyển sang thanh toán 'Tiền mặt'.",
                    "Chuyển khoản thủ công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private Bitmap CreateFallbackQrImage(PaymentConfig config, string noiDung, decimal tongTien)
        {
            int w = picQR.Width > 0 ? picQR.Width : 210;
            int h = picQR.Height > 0 ? picQR.Height : 235;
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            using var pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, 1, 1, w - 2, h - 2);

            using var brushTitle = new SolidBrush(Color.DarkRed);
            using var fontTitle = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            g.DrawString("MẤT KẾT NỐI INTERNET", fontTitle, brushTitle, new PointF(10, 10));

            using var fontSubtitle = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            using var brushSub = new SolidBrush(Color.Gray);
            g.DrawString("Chuyển khoản thủ công:", fontSubtitle, brushSub, new PointF(10, 32));

            using var fontContent = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            using var brushContent = new SolidBrush(Color.Black);
            string info = $"• NH: {config.BankId.ToUpper()}\n" +
                          $"• STK: {config.AccountNo}\n" +
                          $"• Chủ TK: {config.AccountName}\n" +
                          $"• Số tiền: {tongTien:N0} đ\n" +
                          $"• ND: {noiDung}";
            g.DrawString(info, fontContent, brushContent, new RectangleF(10, 52, w - 20, h - 60));

            return bmp;
        }

        private string MaskAccountNumber(string accountNo)
        {
            if (string.IsNullOrWhiteSpace(accountNo)) return "****";
            if (accountNo.Length <= 4) return "****";
            return accountNo.Substring(0, 3) + "****" + accountNo.Substring(accountNo.Length - 3);
        }

        private void btnDaNhanTien_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0 || _tongTien <= 0)
            {
                MessageBox.Show("Chưa có đơn hàng để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLTraSuaContext();
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    TongTien = _tongTien,
                    HinhThucTt = "Chuyển khoản",
                    DaThanhToan = true
                };

                foreach (var item in _cart)
                {
                    hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaMon = item.MaMon,
                        SoLy = item.SoLy,
                        DonGia = item.DonGia
                    });
                }

                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                Log.Information("Lưu hóa đơn HD{MaHD} thành công (Chuyển khoản), Tổng tiền: {TongTien:N0} đ, {Count} món.",
                    hoaDon.MaHd, hoaDon.TongTien, _cart.Count);

                MessageBox.Show($"Thanh toán chuyển khoản thành công!\nMã hóa đơn: HD{hoaDon.MaHd}\nTổng tiền: {hoaDon.TongTien:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                UpdateCartGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi lưu hóa đơn chuyển khoản vào CSDL.");
                MessageBox.Show($"Lỗi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0 || _tongTien <= 0)
            {
                MessageBox.Show("Chưa có món nào trong đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"Xác nhận thanh toán tiền mặt cho đơn hàng?\nTổng tiền: {_tongTien:N0} đ",
                "Xác nhận thanh toán tiền mặt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog != DialogResult.Yes) return;

            try
            {
                using var db = new QLTraSuaContext();
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    TongTien = _tongTien,
                    HinhThucTt = "Tiền mặt",
                    DaThanhToan = true
                };

                foreach (var item in _cart)
                {
                    hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaMon = item.MaMon,
                        SoLy = item.SoLy,
                        DonGia = item.DonGia
                    });
                }

                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                Log.Information("Lưu hóa đơn HD{MaHD} thành công (Tiền mặt), Tổng tiền: {TongTien:N0} đ, {Count} món.",
                    hoaDon.MaHd, hoaDon.TongTien, _cart.Count);

                MessageBox.Show($"Thanh toán tiền mặt thành công!\nMã hóa đơn: HD{hoaDon.MaHd}\nTổng tiền: {hoaDon.TongTien:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                UpdateCartGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi lưu hóa đơn tiền mặt vào CSDL.");
                MessageBox.Show($"Lỗi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuThucDon_Click(object sender, EventArgs e)
        {
            using var f = new FormThucDon();
            f.ShowDialog(this);

            // Reload menu when returning
            LoadDanhMuc();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            using var f = new FormHoaDon();
            f.ShowDialog(this);
        }

        private void mnuTaiLai_Click(object sender, EventArgs e)
        {
            LoadDanhMuc();
            MessageBox.Show("Đã tải lại danh mục và thực đơn từ CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using BanHangQuanTraSua.Models;

namespace BanHangQuanTraSua
{
    public partial class FormHoaDon : Form
    {
        private bool _locTheoNgay = true;

        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Today;
            LoadDanhSachHoaDon();
        }

        private void LoadDanhSachHoaDon()
        {
            using var db = new QLTraSuaContext();
            var query = db.HoaDons.AsQueryable();

            if (_locTheoNgay)
            {
                var targetDate = dtpNgay.Value.Date;
                var nextDate = targetDate.AddDays(1);
                query = query.Where(h => h.NgayLap >= targetDate && h.NgayLap < nextDate);
            }

            var invoices = query
                .OrderByDescending(h => h.NgayLap)
                .Select(h => new
                {
                    h.MaHd,
                    NgayLapStr = h.NgayLap.ToString("dd/MM/yyyy HH:mm:ss"),
                    h.HinhThucTt,
                    TrangThaiTT = h.DaThanhToan ? "Đã thanh toán" : "Chưa TT",
                    h.DaThanhToan,
                    h.TongTien,
                    TongTienStr = h.TongTien.ToString("N0") + " đ"
                })
                .ToList();

            dgvHoaDon.DataSource = invoices;

            // Recalculate revenue
            decimal doanhThu = invoices.Where(h => h.DaThanhToan).Sum(h => h.TongTien);
            if (_locTheoNgay)
            {
                lblDoanhThuNgay.Text = $"Doanh thu ngày {dtpNgay.Value:dd/MM/yyyy}: {doanhThu:N0} đ";
            }
            else
            {
                lblDoanhThuNgay.Text = $"Tổng doanh thu (tất cả): {doanhThu:N0} đ";
            }

            if (invoices.Count == 0)
            {
                dgvChiTiet.DataSource = null;
            }
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                dgvChiTiet.DataSource = null;
                return;
            }

            if (dgvHoaDon.CurrentRow.Cells["colMaHD"].Value is int maHd)
            {
                LoadChiTietHoaDon(maHd);
            }
        }

        private void LoadChiTietHoaDon(int maHd)
        {
            using var db = new QLTraSuaContext();
            var chiTiets = db.ChiTietHoaDons
                .Include(ct => ct.MaMonNavigation)
                .Where(ct => ct.MaHd == maHd)
                .Select(ct => new
                {
                    TenMon = ct.MaMonNavigation.TenMon,
                    ct.SoLy,
                    DonGiaStr = ct.DonGia.ToString("N0") + " đ",
                    ThanhTienStr = (ct.SoLy * ct.DonGia).ToString("N0") + " đ"
                })
                .ToList();

            dgvChiTiet.DataSource = chiTiets;
            gbChiTiet.Text = $"Chi tiết các món - Hóa đơn HD{maHd}";
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            _locTheoNgay = true;
            LoadDanhSachHoaDon();
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            _locTheoNgay = true;
            dtpNgay.Value = DateTime.Today;
            LoadDanhSachHoaDon();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            _locTheoNgay = false;
            LoadDanhSachHoaDon();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using BanHangQuanTraSua.Models;

namespace BanHangQuanTraSua
{
    public partial class FormThucDon : Form
    {
        private int _selectedMaMon = -1;

        public FormThucDon()
        {
            InitializeComponent();
        }

        private void FormThucDon_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadDanhSachMon();
        }

        private void LoadDanhMuc()
        {
            using var db = new QLTraSuaContext();
            var danhMucs = db.DanhMucMons.OrderBy(d => d.MaDm).ToList();

            // Setup cboDanhMuc
            cboDanhMuc.DataSource = new List<DanhMucMon>(danhMucs);
            cboDanhMuc.DisplayMember = "TenDm";
            cboDanhMuc.ValueMember = "MaDm";

            // Setup cboLocDanhMuc (with "Tất cả")
            var locList = new List<DanhMucMon>
            {
                new DanhMucMon { MaDm = 0, TenDm = "-- Tất cả danh mục --" }
            };
            locList.AddRange(danhMucs);

            cboLocDanhMuc.DataSource = locList;
            cboLocDanhMuc.DisplayMember = "TenDm";
            cboLocDanhMuc.ValueMember = "MaDm";
            cboLocDanhMuc.SelectedIndex = 0;
        }

        private void LoadDanhSachMon()
        {
            using var db = new QLTraSuaContext();
            var query = db.MonUongs
                .Include(m => m.MaDmNavigation)
                .AsQueryable();

            // Filter by name
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.TenMon.Contains(keyword));
            }

            // Filter by category
            if (cboLocDanhMuc.SelectedValue is int maDm && maDm > 0)
            {
                query = query.Where(m => m.MaDm == maDm);
            }

            var list = query
                .OrderBy(m => m.MaDm)
                .ThenBy(m => m.TenMon)
                .Select(m => new
                {
                    m.MaMon,
                    m.TenMon,
                    TenDM = m.MaDmNavigation.TenDm,
                    GiaBan = m.GiaBan,
                    GiaBanStr = m.GiaBan.ToString("N0") + " đ",
                    m.DangBan,
                    TrangThai = m.DangBan ? "Đang bán" : "Ngừng bán",
                    m.MaDm
                })
                .ToList();

            dgvMonUong.DataSource = list;
        }

        private void dgvMonUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMonUong.Rows.Count) return;

            var row = dgvMonUong.Rows[e.RowIndex];
            _selectedMaMon = Convert.ToInt32(row.Cells["colMaMon"].Value);
            txtTenMon.Text = row.Cells["colTenMon"].Value?.ToString() ?? "";
            
            using var db = new QLTraSuaContext();
            var mon = db.MonUongs.Find(_selectedMaMon);
            if (mon != null)
            {
                cboDanhMuc.SelectedValue = mon.MaDm;
                numGiaBan.Value = mon.GiaBan;
                chkDangBan.Checked = mon.DangBan;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món uống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }

            if (cboDanhMuc.SelectedValue is not int maDm)
            {
                MessageBox.Show("Vui lòng chọn danh mục cho món!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLTraSuaContext();
                var monMoi = new MonUong
                {
                    TenMon = tenMon,
                    MaDm = maDm,
                    GiaBan = numGiaBan.Value,
                    DangBan = chkDangBan.Checked
                };

                db.MonUongs.Add(monMoi);
                db.SaveChanges();

                MessageBox.Show($"Thêm món '{tenMon}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachMon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaMon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một món trong danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Tên món không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }

            if (cboDanhMuc.SelectedValue is not int maDm)
            {
                MessageBox.Show("Vui lòng chọn danh mục cho món!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLTraSuaContext();
                var mon = db.MonUongs.Find(_selectedMaMon);
                if (mon == null)
                {
                    MessageBox.Show("Không tìm thấy món cần sửa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mon.TenMon = tenMon;
                mon.MaDm = maDm;
                mon.GiaBan = numGiaBan.Value;
                mon.DangBan = chkDangBan.Checked;

                db.SaveChanges();

                MessageBox.Show($"Cập nhật món '{tenMon}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachMon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaMon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một món trong danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa món '{txtTenMon.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new QLTraSuaContext();
                var mon = db.MonUongs.Find(_selectedMaMon);
                if (mon == null)
                {
                    MessageBox.Show("Món không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if this drink has invoice details
                bool isUsedInInvoices = db.ChiTietHoaDons.Any(c => c.MaMon == _selectedMaMon);
                if (isUsedInInvoices)
                {
                    var opt = MessageBox.Show(
                        "Món này đã phát sinh trong các hóa đơn trước đó, không thể xóa vĩnh viễn khỏi CSDL.\nBạn có muốn chuyển trạng thái món sang 'Ngừng bán' không?",
                        "Cảnh báo ràng buộc dữ liệu",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (opt == DialogResult.Yes)
                    {
                        mon.DangBan = false;
                        db.SaveChanges();
                        MessageBox.Show("Đã chuyển trạng thái món sang 'Ngừng bán'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LamMoi();
                        LoadDanhSachMon();
                    }
                    return;
                }

                db.MonUongs.Remove(mon);
                db.SaveChanges();

                MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadDanhSachMon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            _selectedMaMon = -1;
            txtTenMon.Clear();
            if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
            numGiaBan.Value = 30000;
            chkDangBan.Checked = true;
            dgvMonUong.ClearSelection();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachMon();
        }

        private void cboLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachMon();
        }
    }
}

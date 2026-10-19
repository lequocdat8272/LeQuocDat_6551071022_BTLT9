using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SoChiTieuCaNhan.Models;

namespace SoChiTieuCaNhan;

public partial class FormChiTieu : Form
{
    private int? _selectedMaCt = null;

    public FormChiTieu()
    {
        InitializeComponent();
    }

    private void FormChiTieu_Load(object sender, EventArgs e)
    {
        try
        {
            // Thiết lập giá trị mặc định cho control nhập liệu
            dtpNgayChi.Value = DateTime.Today;
            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;

            // Thiết lập giá trị mặc định cho control tìm kiếm
            if (cboTimLoaiChi.Items.Count > 0)
                cboTimLoaiChi.SelectedIndex = 0; // "Tất cả"

            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            // Tải dữ liệu ban đầu
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi khởi tạo FormChiTieu: {Message}", ex.Message);
            MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Tải và lọc dữ liệu danh sách chi tiêu từ cơ sở dữ liệu
    /// </summary>
    private void LoadData()
    {
        try
        {
            using var context = new QlChiTieuContext();

            // Kiểm tra kết nối CSDL
            var query = context.ChiTieus.AsNoTracking().AsQueryable();

            // Lọc theo nội dung nếu có nhập
            string tuKhoa = txtTimNoiDung.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(c => c.NoiDung.Contains(tuKhoa));
            }

            // Lọc theo loại chi
            string loaiChiChon = cboTimLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
            if (loaiChiChon != "Tất cả")
            {
                query = query.Where(c => c.LoaiChi == loaiChiChon);
            }

            // Lọc theo khoảng thời gian
            DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Khoảng ngày lọc không hợp lệ: 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            query = query.Where(c => c.NgayChi >= tuNgay && c.NgayChi <= denNgay);

            // Sắp xếp giảm dần theo ngày chi và mã
            var danhSach = query.OrderByDescending(c => c.NgayChi).ThenByDescending(c => c.MaCt).ToList();

            // Gán dữ liệu lên DataGridView
            dgvDanhSach.DataSource = danhSach;

            // Cập nhật tổng chi theo kết quả hiển thị
            decimal tongChi = danhSach.Sum(c => c.SoTien);
            lblTongChi.Text = $"Tổng chi: {tongChi:N0} đ";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi truy cập CSDL để tải danh sách chi tiêu: {Message}", ex.Message);
            MessageBox.Show($"Đã xảy ra lỗi khi kết nối hoặc truy vấn cơ sở dữ liệu:\n{ex.Message}\nVui lòng kiểm tra lại cấu hình chuỗi kết nối trong appsettings.json.", 
                            "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu đầu vào
    /// </summary>
    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
        {
            MessageBox.Show("Nội dung chi tiêu không được để trống!", "Dữ liệu không hợp lệ", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNoiDung.Focus();
            return false;
        }

        if (numSoTien.Value <= 0)
        {
            MessageBox.Show("Số tiền chi tiêu phải lớn hơn 0!", "Dữ liệu không hợp lệ", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numSoTien.Focus();
            return false;
        }

        if (dtpNgayChi.Value.Date > DateTime.Today)
        {
            MessageBox.Show("Ngày chi không được lớn hơn ngày hôm nay!", "Dữ liệu không hợp lệ", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgayChi.Focus();
            return false;
        }

        if (cboLoaiChi.SelectedIndex < 0)
        {
            MessageBox.Show("Vui lòng chọn loại chi tiêu!", "Dữ liệu không hợp lệ", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboLoaiChi.Focus();
            return false;
        }

        return true;
    }

    /// <summary>
    /// Thêm khoản chi mới
    /// </summary>
    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;

        try
        {
            using var context = new QlChiTieuContext();

            var chiTieuMoi = new ChiTieu
            {
                NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date),
                NoiDung = txtNoiDung.Text.Trim(),
                LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                SoTien = numSoTien.Value,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };

            context.ChiTieus.Add(chiTieuMoi);
            context.SaveChanges();

            // Ghi log thông tin thêm mới
            Log.Information("Thêm khoản chi mới thành công. MaCT: {MaCT}, Ngày: {NgayChi}, Nội dung: {NoiDung}, Loại: {LoaiChi}, Số tiền: {SoTien:N0} đ", 
                            chiTieuMoi.MaCt, chiTieuMoi.NgayChi, chiTieuMoi.NoiDung, chiTieuMoi.LoaiChi, chiTieuMoi.SoTien);

            MessageBox.Show($"Thêm mới khoản chi thành công! (Mã: {chiTieuMoi.MaCt:D3})", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới form và dữ liệu
            ResetInputs();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi CSDL khi Thêm khoản chi: {Message}", ex.Message);
            MessageBox.Show($"Không thể thêm khoản chi do lỗi cơ sở dữ liệu:\n{ex.Message}", 
                            "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Sửa khoản chi đã chọn
    /// </summary>
    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!_selectedMaCt.HasValue)
        {
            MessageBox.Show("Vui lòng bấm chọn một dòng chi tiêu trên bảng để sửa!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs())
            return;

        try
        {
            using var context = new QlChiTieuContext();
            var chiTieu = context.ChiTieus.Find(_selectedMaCt.Value);

            if (chiTieu == null)
            {
                MessageBox.Show("Không tìm thấy khoản chi này trong cơ sở dữ liệu (có thể đã bị xóa)!", 
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            chiTieu.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
            chiTieu.NoiDung = txtNoiDung.Text.Trim();
            chiTieu.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
            chiTieu.SoTien = numSoTien.Value;
            chiTieu.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

            context.SaveChanges();

            // Ghi log cập nhật
            Log.Information("Cập nhật khoản chi thành công. MaCT: {MaCT}, Ngày: {NgayChi}, Nội dung: {NoiDung}, Loại: {LoaiChi}, Số tiền: {SoTien:N0} đ", 
                            chiTieu.MaCt, chiTieu.NgayChi, chiTieu.NoiDung, chiTieu.LoaiChi, chiTieu.SoTien);

            MessageBox.Show($"Cập nhật khoản chi mã {chiTieu.MaCt:D3} thành công!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi CSDL khi Sửa khoản chi (MaCT: {MaCT}): {Message}", _selectedMaCt.Value, ex.Message);
            MessageBox.Show($"Không thể cập nhật khoản chi do lỗi cơ sở dữ liệu:\n{ex.Message}", 
                            "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Xóa khoản chi đã chọn
    /// </summary>
    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (!_selectedMaCt.HasValue)
        {
            MessageBox.Show("Vui lòng chọn một dòng chi tiêu trên bảng để xóa!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int maXoa = _selectedMaCt.Value;
        var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa khoản chi mã {maXoa:D3} (\"{txtNoiDung.Text}\") không?", 
                                           "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        try
        {
            using var context = new QlChiTieuContext();
            var chiTieu = context.ChiTieus.Find(maXoa);

            if (chiTieu != null)
            {
                context.ChiTieus.Remove(chiTieu);
                context.SaveChanges();

                // Ghi log xóa
                Log.Information("Xóa khoản chi thành công. MaCT: {MaCT}", maXoa);

                MessageBox.Show($"Đã xóa thành công khoản chi mã {maXoa:D3}!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Khoản chi đã được xóa trước đó hoặc không tồn tại!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetInputs();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi CSDL khi Xóa khoản chi (MaCT: {MaCT}): {Message}", maXoa, ex.Message);
            MessageBox.Show($"Không thể xóa khoản chi do lỗi cơ sở dữ liệu:\n{ex.Message}", 
                            "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Làm mới giao diện và tải lại dữ liệu ban đầu
    /// </summary>
    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();

        // Đặt lại bộ lọc
        txtTimNoiDung.Clear();
        if (cboTimLoaiChi.Items.Count > 0)
            cboTimLoaiChi.SelectedIndex = 0; // "Tất cả"
        dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        dtpDenNgay.Value = DateTime.Today;

        LoadData();
    }

    /// <summary>
    /// Đặt lại các trường nhập liệu
    /// </summary>
    private void ResetInputs()
    {
        _selectedMaCt = null;
        dtpNgayChi.Value = DateTime.Today;
        txtNoiDung.Clear();
        if (cboLoaiChi.Items.Count > 0)
            cboLoaiChi.SelectedIndex = 0;
        numSoTien.Value = 0;
        txtGhiChu.Clear();
        dgvDanhSach.ClearSelection();
    }

    /// <summary>
    /// Tìm kiếm và lọc danh sách chi tiêu
    /// </summary>
    private void btnTim_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    /// <summary>
    /// Khi người dùng bấm vào một dòng trong DataGridView
    /// </summary>
    private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvDanhSach.Rows.Count)
            return;

        var row = dgvDanhSach.Rows[e.RowIndex];
        if (row.DataBoundItem is ChiTieu item)
        {
            _selectedMaCt = item.MaCt;
            dtpNgayChi.Value = item.NgayChi.ToDateTime(TimeOnly.MinValue);
            txtNoiDung.Text = item.NoiDung;

            int loaiChiIndex = cboLoaiChi.FindStringExact(item.LoaiChi);
            if (loaiChiIndex >= 0)
                cboLoaiChi.SelectedIndex = loaiChiIndex;
            else
                cboLoaiChi.Text = item.LoaiChi;

            numSoTien.Value = item.SoTien;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;
        }
    }

    /// <summary>
    /// Định dạng dữ liệu hiển thị trên DataGridView
    /// </summary>
    private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value == null)
            return;

        // Định dạng cột Mã: 001, 002,...
        if (dgvDanhSach.Columns[e.ColumnIndex].Name == "colMa" && e.Value is int ma)
        {
            e.Value = ma.ToString("D3");
            e.FormattingApplied = true;
        }
        // Định dạng cột Ngày chi: dd/MM/yyyy
        else if (dgvDanhSach.Columns[e.ColumnIndex].Name == "colNgayChi" && e.Value is DateOnly ngay)
        {
            e.Value = ngay.ToString("dd/MM/yyyy");
            e.FormattingApplied = true;
        }
        // Định dạng cột Số tiền: 35.000, 60.000,...
        else if (dgvDanhSach.Columns[e.ColumnIndex].Name == "colSoTien" && e.Value is decimal soTien)
        {
            e.Value = string.Format("{0:N0}", soTien);
            e.FormattingApplied = true;
        }
    }
}

using System.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaTro.Models;
using Serilog;

namespace QuanLyNhaTro;

public partial class FormKhachThue : Form
{
    private static readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    private int? _selectedMaKhach = null;
    private List<CustomerDisplayModel> _allCustomers = new();
    private List<ProvinceItem> _loadedProvinces = new();
    private bool _isApiAvailable = true;
    private bool _isLoadingProvince = false;

    public FormKhachThue()
    {
        InitializeComponent();
        dgvKhachThue.CellFormatting += dgvKhachThue_CellFormatting;
        txtTimKiem.TextChanged += (s, e) => ApplyFilter();
        cboLocPhong.SelectedIndexChanged += (s, e) => ApplyFilter();
        cboLocTinh.SelectedIndexChanged += (s, e) => ApplyFilter();
    }

    private void dgvKhachThue_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvKhachThue.Columns[e.ColumnIndex].Name == "colGiaThue" && e.Value is decimal val)
        {
            e.Value = string.Format("{0:N0} đ", val);
            e.FormattingApplied = true;
        }
    }

    private async void FormKhachThue_Load(object sender, EventArgs e)
    {
        try
        {
            await LoadRoomDataAsync();
            await LoadCustomerGridAsync();
            LoadRoomFilterData();
            LoadProvinceFilterData();

            // Gọi API bất đồng bộ nạp danh sách Tỉnh/Thành
            await LoadProvincesFromApiAsync();

            // Nếu có dữ liệu, chọn dòng Nguyễn Văn An (hoặc dòng đầu tiên) để hiển thị đồng bộ như ảnh đề bài
            if (dgvKhachThue.Rows.Count > 1)
            {
                dgvKhachThue.Rows[1].Selected = true;
                dgvKhachThue_CellClick(dgvKhachThue, new DataGridViewCellEventArgs(0, 1));
            }
            else if (dgvKhachThue.Rows.Count > 0)
            {
                dgvKhachThue.Rows[0].Selected = true;
                dgvKhachThue_CellClick(dgvKhachThue, new DataGridViewCellEventArgs(0, 0));
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi khởi tạo form FormKhachThue");
            MessageBox.Show("Đã xảy ra lỗi trong quá trình khởi tạo dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region 1. Load Data từ Database

    /// <summary>
    /// Nạp danh sách phòng vào ComboBox phòng.
    /// Nếu includeCurrentRoomId != null (khi sửa/chọn dòng), thêm cả phòng hiện tại của khách vào danh sách.
    /// Khi thêm mới (includeCurrentRoomId == null), chỉ liệt kê các phòng hợp lệ (phòng "Trống").
    /// </summary>
    private async Task LoadRoomDataAsync(int? includeCurrentRoomId = null)
    {
        try
        {
            using var context = new QlNhaTroContext();
            List<PhongTro> phongList;

            if (includeCurrentRoomId.HasValue)
            {
                // Khi đang xem hoặc sửa khách: lấy các phòng "Trống" HOẶC phòng mà khách này đang ở
                phongList = await context.PhongTros
                    .Where(p => p.TinhTrang == "Trống" || p.MaPhong == includeCurrentRoomId.Value)
                    .OrderBy(p => p.TenPhong)
                    .ToListAsync();
            }
            else
            {
                // Khi thêm mới: ComboBox phòng chỉ liệt kê các phòng hợp lệ (phòng "Trống") theo quy tắc
                phongList = await context.PhongTros
                    .Where(p => p.TinhTrang == "Trống")
                    .OrderBy(p => p.TenPhong)
                    .ToListAsync();
            }

            var roomItems = phongList.Select(p => new RoomComboBoxItem
            {
                MaPhong = p.MaPhong,
                TenPhong = p.TenPhong,
                GiaThue = p.GiaThue,
                TinhTrang = p.TinhTrang
            }).ToList();

            cboPhong.DataSource = null;
            cboPhong.DisplayMember = "DisplayText";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.DataSource = roomItems;

            if (roomItems.Count > 0)
            {
                if (includeCurrentRoomId.HasValue)
                {
                    cboPhong.SelectedValue = includeCurrentRoomId.Value;
                }
                else
                {
                    cboPhong.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh sách phòng từ CSDL");
            MessageBox.Show("Không thể tải danh sách phòng từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Nạp dữ liệu khách thuê và kết quả JOIN lên DataGridView
    /// </summary>
    private async Task LoadCustomerGridAsync()
    {
        try
        {
            using var context = new QlNhaTroContext();
            var list = await context.KhachThues
                .Include(k => k.MaPhongNavigation)
                .OrderBy(k => k.MaPhong)
                .ThenBy(k => k.HoTen)
                .Select(k => new CustomerDisplayModel
                {
                    MaKhach = k.MaKhach,
                    HoTen = k.HoTen,
                    GioiTinh = k.GioiTinh,
                    NgaySinh = k.NgaySinh,
                    SoDienThoai = k.SoDienThoai,
                    MaPhong = k.MaPhong,
                    TenPhong = k.MaPhongNavigation != null ? k.MaPhongNavigation.TenPhong : "",
                    GiaThue = k.MaPhongNavigation != null ? k.MaPhongNavigation.GiaThue : 0,
                    MaTinh = k.MaTinh,
                    TenTinh = k.TenTinh,
                    MaPhuongXa = k.MaPhuongXa,
                    TenPhuongXa = k.TenPhuongXa,
                    DaDangKyTamTru = k.DaDangKyTamTru
                })
                .ToListAsync();

            _allCustomers = list;
            ApplyFilter();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh sách khách thuê");
            MessageBox.Show("Không thể tải danh sách khách thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadRoomFilterData()
    {
        try
        {
            using var context = new QlNhaTroContext();
            var rooms = context.PhongTros.OrderBy(p => p.TenPhong).Select(p => p.TenPhong).ToList();
            cboLocPhong.Items.Clear();
            cboLocPhong.Items.Add("Tất cả");
            foreach (var r in rooms)
            {
                cboLocPhong.Items.Add(r);
            }
            cboLocPhong.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp bộ lọc phòng");
        }
    }

    private void LoadProvinceFilterData()
    {
        try
        {
            var provinces = _allCustomers
                .Select(c => c.TenTinh)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            cboLocTinh.Items.Clear();
            cboLocTinh.Items.Add("Tất cả");
            foreach (var p in provinces)
            {
                cboLocTinh.Items.Add(p);
            }
            cboLocTinh.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp bộ lọc tỉnh");
        }
    }

    #endregion

    #region 2. Gọi API Hành chính Việt Nam (Task 3 & Task 8)

    private async Task LoadProvincesFromApiAsync()
    {
        _isLoadingProvince = true;
        cboTinhThanh.DataSource = null;
        cboTinhThanh.Text = "Đang tải…";
        cboTinhThanh.Enabled = false;
        cboPhuongXa.Enabled = false;
        lblStatus.Text = "Đang tải danh sách tỉnh/thành từ open-api.vn...";

        try
        {
            var response = await _httpClient.GetAsync("https://provinces.open-api.vn/api/v2/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var provinces = JsonSerializer.Deserialize<List<ProvinceItem>>(json);

            if (provinces != null && provinces.Count > 0)
            {
                _loadedProvinces = provinces;
                _isApiAvailable = true;

                cboTinhThanh.DisplayMember = "name";
                cboTinhThanh.ValueMember = "code";
                cboTinhThanh.DataSource = provinces;
                cboTinhThanh.SelectedIndex = -1;
                cboTinhThanh.Text = "";

                lblStatus.Text = $"Đã tải {provinces.Count} tỉnh/thành từ provinces.open-api.vn";
            }
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is TimeoutException)
        {
            _isApiAvailable = false;
            Log.Warning(ex, "Không tải được danh sách địa chỉ từ provinces.open-api.vn, chuyển sang chế độ gõ tay.");
            MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Cảnh báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lblStatus.Text = "Không tải được địa chỉ từ API. Đang ở chế độ nhập tay.";
            cboTinhThanh.DataSource = null;
            cboTinhThanh.Items.Clear();
            cboTinhThanh.Text = "";
            cboPhuongXa.DataSource = null;
            cboPhuongXa.Items.Clear();
            cboPhuongXa.Text = "";
        }
        catch (Exception ex)
        {
            _isApiAvailable = false;
            Log.Error(ex, "Lỗi không xác định khi gọi API tỉnh thành.");
            lblStatus.Text = "Lỗi khi gọi API tỉnh thành.";
        }
        finally
        {
            _isLoadingProvince = false;
            cboTinhThanh.Enabled = true;
            cboPhuongXa.Enabled = true;
        }
    }

    private async void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isLoadingProvince || !_isApiAvailable) return;

        if (cboTinhThanh.SelectedValue is int provinceCode)
        {
            await LoadWardsByProvinceCodeAsync(provinceCode);
        }
    }

    private async Task LoadWardsByProvinceCodeAsync(int provinceCode, int? selectWardCode = null, string? selectWardName = null)
    {
        cboPhuongXa.DataSource = null;
        cboPhuongXa.Text = "Đang tải…";
        cboPhuongXa.Enabled = false;

        try
        {
            var response = await _httpClient.GetAsync($"https://provinces.open-api.vn/api/v2/p/{provinceCode}?depth=2");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var detail = JsonSerializer.Deserialize<ProvinceDetailItem>(json);
            var wards = detail?.wards ?? new List<WardItem>();

            cboPhuongXa.DisplayMember = "name";
            cboPhuongXa.ValueMember = "code";
            cboPhuongXa.DataSource = wards;

            if (selectWardCode.HasValue && selectWardCode.Value > 0)
            {
                cboPhuongXa.SelectedValue = selectWardCode.Value;
            }
            else if (!string.IsNullOrWhiteSpace(selectWardName))
            {
                var match = wards.FirstOrDefault(w => string.Equals(w.name, selectWardName, StringComparison.OrdinalIgnoreCase));
                if (match != null)
                {
                    cboPhuongXa.SelectedValue = match.code;
                }
                else
                {
                    cboPhuongXa.SelectedIndex = -1;
                    cboPhuongXa.Text = selectWardName;
                }
            }
            else
            {
                cboPhuongXa.SelectedIndex = -1;
                cboPhuongXa.Text = "";
            }
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is TimeoutException)
        {
            Log.Warning(ex, $"Không thể tải danh sách phường/xã cho tỉnh {provinceCode}");
            MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Cảnh báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhuongXa.DataSource = null;
            cboPhuongXa.Items.Clear();
            if (!string.IsNullOrWhiteSpace(selectWardName))
            {
                cboPhuongXa.Text = selectWardName;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Lỗi không xác định khi tải phường/xã tỉnh {provinceCode}");
        }
        finally
        {
            cboPhuongXa.Enabled = true;
        }
    }

    #endregion

    #region 3. CRUD Thao tác dữ liệu (Task 4)

    private async void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        try
        {
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            DateOnly ngaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            string soDienThoai = txtSoDienThoai.Text.Trim();

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maPhong = (int)cboPhong.SelectedValue;

            int? maTinh = cboTinhThanh.SelectedValue as int?;
            string tenTinh = cboTinhThanh.Text.Trim();

            int? maPhuongXa = cboPhuongXa.SelectedValue as int?;
            string tenPhuongXa = cboPhuongXa.Text.Trim();

            bool daDangKyTamTru = chkTamTru.Checked;

            using var context = new QlNhaTroContext();

            var khach = new KhachThue
            {
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                SoDienThoai = soDienThoai,
                MaPhong = maPhong,
                MaTinh = maTinh,
                TenTinh = tenTinh,
                MaPhuongXa = maPhuongXa,
                TenPhuongXa = tenPhuongXa,
                DaDangKyTamTru = daDangKyTamTru
            };

            context.KhachThues.Add(khach);

            // Quy tắc: Khi thêm khách vào phòng thì phòng chuyển "Đang thuê"
            var phong = await context.PhongTros.FindAsync(maPhong);
            if (phong != null)
            {
                phong.TinhTrang = "Đang thuê";
            }

            await context.SaveChangesAsync();

            MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadCustomerGridAsync();
            LoadProvinceFilterData();
            btnLamMoi_Click(sender, e);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm khách thuê");
            MessageBox.Show("Đã xảy ra lỗi khi thêm khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!_selectedMaKhach.HasValue)
        {
            MessageBox.Show("Vui lòng chọn khách thuê cần sửa từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs()) return;

        try
        {
            using var context = new QlNhaTroContext();
            var khach = await context.KhachThues.FindAsync(_selectedMaKhach.Value);
            if (khach == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu khách thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int oldMaPhong = khach.MaPhong;
            int newMaPhong = (int)cboPhong.SelectedValue!;

            khach.HoTen = txtHoTen.Text.Trim();
            khach.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
            khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            khach.SoDienThoai = txtSoDienThoai.Text.Trim();
            khach.MaPhong = newMaPhong;
            khach.MaTinh = cboTinhThanh.SelectedValue as int?;
            khach.TenTinh = cboTinhThanh.Text.Trim();
            khach.MaPhuongXa = cboPhuongXa.SelectedValue as int?;
            khach.TenPhuongXa = cboPhuongXa.Text.Trim();
            khach.DaDangKyTamTru = chkTamTru.Checked;

            // Nếu đổi phòng
            if (oldMaPhong != newMaPhong)
            {
                var newPhong = await context.PhongTros.FindAsync(newMaPhong);
                if (newPhong != null)
                {
                    newPhong.TinhTrang = "Đang thuê";
                }
            }

            await context.SaveChangesAsync();

            // Kiểm tra phòng cũ: nếu không còn khách nào thì chuyển về "Trống"
            if (oldMaPhong != newMaPhong)
            {
                bool hasRemaining = await context.KhachThues.AnyAsync(k => k.MaPhong == oldMaPhong);
                if (!hasRemaining)
                {
                    var oldPhong = await context.PhongTros.FindAsync(oldMaPhong);
                    if (oldPhong != null)
                    {
                        oldPhong.TinhTrang = "Trống";
                        await context.SaveChangesAsync();
                    }
                }
            }

            MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadCustomerGridAsync();
            LoadProvinceFilterData();
            btnLamMoi_Click(sender, e);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi cập nhật thông tin khách thuê");
            MessageBox.Show("Đã xảy ra lỗi khi sửa khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!_selectedMaKhach.HasValue)
        {
            MessageBox.Show("Vui lòng chọn khách thuê cần xóa từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách thuê này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var context = new QlNhaTroContext();
            var khach = await context.KhachThues.FindAsync(_selectedMaKhach.Value);
            if (khach == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu khách thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = khach.MaPhong;
            context.KhachThues.Remove(khach);
            await context.SaveChangesAsync();

            // Quy tắc: Khi xóa người cuối cùng của phòng thì phòng trở lại "Trống"
            bool hasRemaining = await context.KhachThues.AnyAsync(k => k.MaPhong == maPhong);
            if (!hasRemaining)
            {
                var phong = await context.PhongTros.FindAsync(maPhong);
                if (phong != null)
                {
                    phong.TinhTrang = "Trống";
                    await context.SaveChangesAsync();
                }
            }

            MessageBox.Show("Xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadCustomerGridAsync();
            LoadProvinceFilterData();
            btnLamMoi_Click(sender, e);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xóa khách thuê");
            MessageBox.Show("Đã xảy ra lỗi khi xóa khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        _selectedMaKhach = null;
        txtHoTen.Text = "";
        radNam.Checked = true;
        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        txtSoDienThoai.Text = "";
        chkTamTru.Checked = false;
        cboTinhThanh.SelectedIndex = -1;
        cboTinhThanh.Text = "";
        cboPhuongXa.DataSource = null;
        cboPhuongXa.Items.Clear();
        cboPhuongXa.Text = "";

        // Nạp lại danh sách phòng hợp lệ khi thêm mới (chỉ phòng "Trống")
        await LoadRoomDataAsync(null);

        dgvKhachThue.ClearSelection();
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên khách thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return false;
        }

        if (cboPhong.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn phòng trọ hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhong.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cboTinhThanh.Text))
        {
            MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTinhThanh.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cboPhuongXa.Text))
        {
            MessageBox.Show("Vui lòng chọn hoặc nhập Phường/Xã.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhuongXa.Focus();
            return false;
        }

        return true;
    }

    #endregion

    #region 4. DataGridView Selection (Task 5)

    private async void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

        var selectedRow = dgvKhachThue.Rows[e.RowIndex];
        if (selectedRow.DataBoundItem is CustomerDisplayModel item)
        {
            _selectedMaKhach = item.MaKhach;

            txtHoTen.Text = item.HoTen;
            if (item.GioiTinh == "Nam") radNam.Checked = true;
            else radNu.Checked = true;

            dtpNgaySinh.Value = item.NgaySinh.ToDateTime(TimeOnly.MinValue);
            txtSoDienThoai.Text = item.SoDienThoai;
            chkTamTru.Checked = item.DaDangKyTamTru;

            // Nạp lại danh sách phòng bao gồm phòng hiện tại của khách
            await LoadRoomDataAsync(item.MaPhong);
            cboPhong.SelectedValue = item.MaPhong;

            // Xử lý Tỉnh/Thành
            if (_isApiAvailable && _loadedProvinces.Count > 0)
            {
                ProvinceItem? foundProvince = null;
                if (item.MaTinh.HasValue && item.MaTinh.Value > 0)
                {
                    foundProvince = _loadedProvinces.FirstOrDefault(p => p.code == item.MaTinh.Value);
                }
                if (foundProvince == null && !string.IsNullOrWhiteSpace(item.TenTinh))
                {
                    foundProvince = _loadedProvinces.FirstOrDefault(p => p.name.Contains(item.TenTinh, StringComparison.OrdinalIgnoreCase) || item.TenTinh.Contains(p.name, StringComparison.OrdinalIgnoreCase));
                }

                if (foundProvince != null)
                {
                    _isLoadingProvince = true;
                    cboTinhThanh.SelectedValue = foundProvince.code;
                    _isLoadingProvince = false;

                    await LoadWardsByProvinceCodeAsync(foundProvince.code, item.MaPhuongXa, item.TenPhuongXa);
                }
                else
                {
                    cboTinhThanh.SelectedIndex = -1;
                    cboTinhThanh.Text = item.TenTinh;
                    cboPhuongXa.DataSource = null;
                    cboPhuongXa.Text = item.TenPhuongXa;
                }
            }
            else
            {
                cboTinhThanh.SelectedIndex = -1;
                cboTinhThanh.Text = item.TenTinh;
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Text = item.TenPhuongXa;
            }
        }
    }

    #endregion

    #region 5. Tìm kiếm & Lọc (Task 6)

    private void btnTim_Click(object sender, EventArgs e)
    {
        ApplyFilter();
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimKiem.Text = "";
        if (cboLocPhong.Items.Count > 0) cboLocPhong.SelectedIndex = 0;
        if (cboLocTinh.Items.Count > 0) cboLocTinh.SelectedIndex = 0;
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var filtered = _allCustomers.AsEnumerable();

        string keyword = txtTimKiem.Text.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            filtered = filtered.Where(k =>
                (!string.IsNullOrEmpty(k.HoTen) && k.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(k.SoDienThoai) && k.SoDienThoai.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
        }

        if (cboLocPhong.SelectedIndex > 0 && cboLocPhong.SelectedItem != null)
        {
            string selectedPhong = cboLocPhong.SelectedItem.ToString()!;
            filtered = filtered.Where(k => k.TenPhong == selectedPhong);
        }

        if (cboLocTinh.SelectedIndex > 0 && cboLocTinh.SelectedItem != null)
        {
            string selectedTinh = cboLocTinh.SelectedItem.ToString()!;
            filtered = filtered.Where(k => k.TenTinh == selectedTinh);
        }

        dgvKhachThue.DataSource = filtered.ToList();
    }

    #endregion

    #region 6. Xử lý lỗi toàn cục & Nút kiểm tra lỗi (Task 7)

    private void btnGayLoiThu_Click(object sender, EventArgs e)
    {
        // Gây ra ngoại lệ chưa bắt để kiểm tra cơ chế bắt lỗi toàn cục và Serilog
        throw new InvalidOperationException("Đây là ngoại lệ thử nghiệm để kiểm tra cơ chế bắt lỗi toàn cục và ghi log Serilog!");
    }

    #endregion
}

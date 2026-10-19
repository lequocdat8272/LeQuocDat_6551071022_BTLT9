using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeHoachDaNgoai.Models;
using KeHoachDaNgoai.Services;
using Microsoft.EntityFrameworkCore;

namespace KeHoachDaNgoai;

public partial class FormChuyenDi : Form
{
    private readonly QLDaNgoaiContext _context;
    private int? _selectedMaChuyen = null;
    private WeatherResult? _lastWeatherResult = null;
    private bool _isInitializing = true;
    private bool _isUpdatingLanguage = false;

    public FormChuyenDi()
    {
        InitializeComponent();
        _context = new QLDaNgoaiContext();

        // Enable double buffering on DataGridView to prevent flickering
        typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, dgvChuyenDi, new object[] { true });

        Load += FormChuyenDi_Load;
        FormClosing += FormChuyenDi_FormClosing;
    }

    private void FormChuyenDi_Load(object? sender, EventArgs e)
    {
        // 1. Load saved language setting
        var settings = SettingsService.LoadSettings();
        LocalizationService.SetLanguage(settings.Language);

        // 2. Setup Language ComboBox
        cboNgonNgu.Items.Clear();
        cboNgonNgu.Items.Add("Tiếng Việt");
        cboNgonNgu.Items.Add("English");
        cboNgonNgu.SelectedIndex = LocalizationService.IsVietnamese ? 0 : 1;
        cboNgonNgu.SelectedIndexChanged += cboNgonNgu_SelectedIndexChanged;

        // 3. Setup Date pickers
        dtpNgayDi.Value = DateTime.Today.AddDays(6);
        dtpTuNgay.Value = DateTime.Today;
        dtpDenNgay.Value = DateTime.Today.AddDays(30);

        // 4. Setup Events
        SetupEvents();

        // 5. Apply localized text to UI
        ApplyLanguage();

        // 6. Load initial data
        LoadData();

        _isInitializing = false;

        // Auto select first row if available to populate inputs & weather
        if (dgvChuyenDi.Rows.Count > 0)
        {
            dgvChuyenDi.Rows[0].Selected = true;
            dgvChuyenDi_SelectionChanged(this, EventArgs.Empty);
        }
    }

    private void SetupEvents()
    {
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnXemThoiTiet.Click += async (s, e) => await CheckWeatherForCurrentInputAsync();

        btnTim.Click += (s, e) => LoadData();
        btnBoLoc.Click += btnBoLoc_Click;

        txtTimKiem.TextChanged += (s, e) => LoadData();
        chkChuaHoanThanh.CheckedChanged += (s, e) => LoadData();
        chkLocNgay.CheckedChanged += (s, e) =>
        {
            dtpTuNgay.Enabled = chkLocNgay.Checked;
            dtpDenNgay.Enabled = chkLocNgay.Checked;
            LoadData();
        };
        dtpTuNgay.ValueChanged += (s, e) => { if (chkLocNgay.Checked) LoadData(); };
        dtpDenNgay.ValueChanged += (s, e) => { if (chkLocNgay.Checked) LoadData(); };

        dgvChuyenDi.SelectionChanged += dgvChuyenDi_SelectionChanged;
        dgvChuyenDi.CellFormatting += dgvChuyenDi_CellFormatting;

        txtNganSach.KeyPress += txtNganSach_KeyPress;
        txtNganSach.Leave += txtNganSach_Leave;

        lblWarningIcon.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(lblWarningIcon.BackColor);
            e.Graphics.FillEllipse(brush, 1, 1, lblWarningIcon.Width - 3, lblWarningIcon.Height - 3);
            using var font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            using var textBrush = new SolidBrush(Color.White);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(lblWarningIcon.Text, font, textBrush, new RectangleF(0, 0, lblWarningIcon.Width, lblWarningIcon.Height), sf);
        };
    }

    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

    private void ApplyLanguage()
    {
        _isUpdatingLanguage = true;

        if (txtTimKiem.IsHandleCreated)
        {
            SendMessage(txtTimKiem.Handle, 0x1501, 0, LocalizationService.T("SearchPlaceholder"));
        }

        Text = LocalizationService.T("AppTitle");
        lblAppHeader.Text = LocalizationService.T("HeaderTitle");
        lblNgônNgu.Text = LocalizationService.T("Language");

        grpThongTin.Text = LocalizationService.T("TripInfoGroup");
        lblTenChuyen.Text = LocalizationService.T("TripName");
        lblDiaDiem.Text = LocalizationService.T("Destination");
        lblNgayDi.Text = LocalizationService.T("DepartureDate");
        lblSoNguoi.Text = LocalizationService.T("PeopleCount");
        lblNganSach.Text = LocalizationService.T("Budget");
        lblPhuongTien.Text = LocalizationService.T("Vehicle");
        chkDaHoanThanh.Text = LocalizationService.T("Completed");

        btnThem.Text = LocalizationService.T("Add");
        btnSua.Text = LocalizationService.T("Edit");
        btnXoa.Text = LocalizationService.T("Delete");
        btnLamMoi.Text = LocalizationService.T("Refresh");
        btnXemThoiTiet.Text = LocalizationService.T("CheckWeather");

        chkChuaHoanThanh.Text = LocalizationService.T("OnlyUncompleted");
        chkLocNgay.Text = LocalizationService.T("FilterByDate");
        btnTim.Text = LocalizationService.T("Search");
        btnBoLoc.Text = LocalizationService.T("ShowAll");

        // Grid Column Headers
        colMaChuyen.HeaderText = LocalizationService.T("ColId");
        colTenChuyen.HeaderText = LocalizationService.T("ColTripName");
        colDiaDiem.HeaderText = LocalizationService.T("ColDestination");
        colNgayDi.HeaderText = LocalizationService.T("ColDepartureDate");
        colSoNguoi.HeaderText = LocalizationService.T("ColPeopleCount");
        colNganSach.HeaderText = LocalizationService.T("ColBudget");
        colPhuongTien.HeaderText = LocalizationService.T("ColVehicle");
        colDaHoanThanh.HeaderText = LocalizationService.T("ColCompleted");

        // Update Vehicle ComboBox items while preserving selection
        string? currentVehicle = cboPhuongTien.SelectedItem?.ToString();
        string standardVehicle = currentVehicle != null
            ? LocalizationService.ToStandardVehicle(currentVehicle)
            : "Ô tô";

        cboPhuongTien.Items.Clear();
        foreach (var v in LocalizationService.GetVehicleList())
        {
            cboPhuongTien.Items.Add(v);
        }
        string localizedVehicle = LocalizationService.GetVehicleName(standardVehicle);
        int idx = cboPhuongTien.FindStringExact(localizedVehicle);
        cboPhuongTien.SelectedIndex = idx >= 0 ? idx : 0;

        // Date Picker formats
        string dateFormat = LocalizationService.IsVietnamese ? "dd/MM/yyyy" : "MM/dd/yyyy";
        dtpNgayDi.Format = DateTimePickerFormat.Custom;
        dtpTuNgay.Format = DateTimePickerFormat.Custom;
        dtpDenNgay.Format = DateTimePickerFormat.Custom;
        dtpNgayDi.CustomFormat = dateFormat;
        dtpTuNgay.CustomFormat = dateFormat;
        dtpDenNgay.CustomFormat = dateFormat;

        // Reformat budget text box
        if (decimal.TryParse(CleanNumericString(txtNganSach.Text), out decimal budgetVal))
        {
            txtNganSach.Text = LocalizationService.FormatCurrency(budgetVal);
        }

        // Re-render weather card if data exists
        if (_lastWeatherResult != null)
        {
            DisplayWeatherResult(_lastWeatherResult);
        }
        else
        {
            lblWeatherHeader.Text = LocalizationService.T("SelectTripPrompt");
            lblWeatherDesc.Text = "";
            lblTemperature.Text = "";
            lblRainProbability.Text = "";
            pnlWarning.Visible = false;
        }

        // Refresh grid formatting
        dgvChuyenDi.Refresh();

        _isUpdatingLanguage = false;
    }

    private void cboNgonNgu_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_isUpdatingLanguage) return;

        string newLang = cboNgonNgu.SelectedIndex == 1
            ? LocalizationService.English
            : LocalizationService.Vietnamese;

        LocalizationService.SetLanguage(newLang);
        SettingsService.SaveSettings(new AppSettings { Language = newLang });

        ApplyLanguage();
    }

    private void LoadData()
    {
        try
        {
            var query = _context.ChuyenDis.AsNoTracking().AsQueryable();

            // Filter by search text (trip name or destination)
            string search = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenChuyen.Contains(search) || c.DiaDiem.Contains(search));
            }

            // Filter uncompleted
            if (chkChuaHoanThanh.Checked)
            {
                query = query.Where(c => !c.DaHoanThanh);
            }

            // Filter date range
            if (chkLocNgay.Checked)
            {
                var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
                query = query.Where(c => c.NgayDi >= tuNgay && c.NgayDi <= denNgay);
            }

            var list = query.OrderBy(c => c.MaChuyen).ToList();

            dgvChuyenDi.DataSource = list;

            // Restore selection if applicable
            if (_selectedMaChuyen.HasValue)
            {
                for (int i = 0; i < dgvChuyenDi.Rows.Count; i++)
                {
                    if (dgvChuyenDi.Rows[i].DataBoundItem is ChuyenDi cd && cd.MaChuyen == _selectedMaChuyen.Value)
                    {
                        dgvChuyenDi.ClearSelection();
                        dgvChuyenDi.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvChuyenDi_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value == null) return;

        string colName = dgvChuyenDi.Columns[e.ColumnIndex].Name;

        if (colName == "colNgayDi" && e.Value is DateOnly d)
        {
            e.Value = LocalizationService.FormatDate(d);
            e.FormattingApplied = true;
        }
        else if (colName == "colNganSach" && e.Value is decimal amount)
        {
            e.Value = LocalizationService.FormatCurrency(amount);
            e.FormattingApplied = true;
        }
        else if (colName == "colPhuongTien" && e.Value is string pt)
        {
            e.Value = LocalizationService.GetVehicleName(pt);
            e.FormattingApplied = true;
        }
    }

    private async void dgvChuyenDi_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isUpdatingLanguage || _isInitializing) return;

        if (dgvChuyenDi.SelectedRows.Count > 0 && dgvChuyenDi.SelectedRows[0].DataBoundItem is ChuyenDi cd)
        {
            _selectedMaChuyen = cd.MaChuyen;
            txtTenChuyen.Text = cd.TenChuyen;
            txtDiaDiem.Text = cd.DiaDiem;
            dtpNgayDi.Value = cd.NgayDi.ToDateTime(TimeOnly.MinValue);
            nudSoNguoi.Value = Math.Max(1, Math.Min(1000, cd.SoNguoi));
            txtNganSach.Text = LocalizationService.FormatCurrency(cd.NganSach);

            string localizedVehicle = LocalizationService.GetVehicleName(cd.PhuongTien);
            int idx = cboPhuongTien.FindStringExact(localizedVehicle);
            cboPhuongTien.SelectedIndex = idx >= 0 ? idx : 0;

            chkDaHoanThanh.Checked = cd.DaHoanThanh;

            // Automatically query weather for the selected trip
            await CheckWeatherAsync(cd.DiaDiem, cd.NgayDi);
        }
    }

    private async Task CheckWeatherForCurrentInputAsync()
    {
        string diaDiem = txtDiaDiem.Text.Trim();
        var ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
        await CheckWeatherAsync(diaDiem, ngayDi);
    }

    private async Task CheckWeatherAsync(string diaDiem, DateOnly ngayDi)
    {
        if (string.IsNullOrWhiteSpace(diaDiem))
        {
            MessageBox.Show(
                LocalizationService.T("ValDestinationRequired"),
                LocalizationService.T("Destination"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Lock button and show Marquee ProgressBar while loading
            btnXemThoiTiet.Enabled = false;
            pbLoading.Visible = true;
            lblWeatherHeader.Text = LocalizationService.T("LoadingWeather");

            var result = await WeatherService.GetWeatherAsync(diaDiem, ngayDi);
            _lastWeatherResult = result;
            DisplayWeatherResult(result);
        }
        finally
        {
            btnXemThoiTiet.Enabled = true;
            pbLoading.Visible = false;
        }
    }

    private void DisplayWeatherResult(WeatherResult res)
    {
        string dateFormatted = LocalizationService.FormatDate(res.Date);
        lblWeatherHeader.Text = string.Format(LocalizationService.T("WeatherForecastFor"), dateFormatted, res.LocationName);

        if (!res.Success)
        {
            iconWeather.ClearIcon();
            lblWeatherDesc.Text = "";
            lblTemperature.Text = "";
            lblRainProbability.Text = "";

            pnlWarning.Visible = true;
            pnlWarning.BackColor = Color.FromArgb(254, 242, 242); // Soft red
            lblWarningIcon.BackColor = Color.FromArgb(220, 38, 38);
            lblWarningIcon.Text = "!";
            lblWarningText.ForeColor = Color.FromArgb(153, 27, 27);
            lblWarningText.Text = res.ErrorMessage ?? "Error";
            return;
        }

        if (res.IsBeyondForecast)
        {
            iconWeather.ClearIcon();
            lblWeatherDesc.Text = LocalizationService.T("NoForecastAvailable");
            lblTemperature.Text = "";
            lblRainProbability.Text = "";
            pnlWarning.Visible = false;
            return;
        }

        // Valid forecast data
        iconWeather.WeatherCode = res.WeatherCode;
        lblWeatherDesc.Text = LocalizationService.GetWeatherDescription(res.WeatherCode);
        lblTemperature.Text = string.Format(LocalizationService.T("Temperature"), res.TempMin, res.TempMax);
        lblRainProbability.Text = string.Format(LocalizationService.T("RainProbability"), res.PrecipitationProbability);

        if (res.RainWarning)
        {
            // Precipitation probability >= 60%: Orange background + advice
            pnlWarning.Visible = true;
            pnlWarning.BackColor = Color.FromArgb(254, 227, 199); // Soft orange
            lblWarningIcon.BackColor = Color.FromArgb(234, 88, 12);
            lblWarningIcon.Text = "!";
            lblWarningText.ForeColor = Color.FromArgb(124, 45, 18);
            lblWarningText.Text = LocalizationService.T("RainWarningAdvice");
        }
        else
        {
            // Good weather: favorable advice
            pnlWarning.Visible = true;
            pnlWarning.BackColor = Color.FromArgb(220, 252, 231); // Soft green
            lblWarningIcon.BackColor = Color.FromArgb(22, 163, 74);
            lblWarningIcon.Text = "✓";
            lblWarningText.ForeColor = Color.FromArgb(20, 83, 45);
            lblWarningText.Text = LocalizationService.T("GoodWeatherAdvice");
        }
    }

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateTripInput(isAdding: true)) return;

        try
        {
            var cd = new ChuyenDi
            {
                TenChuyen = txtTenChuyen.Text.Trim(),
                DiaDiem = txtDiaDiem.Text.Trim(),
                NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date),
                SoNguoi = (int)nudSoNguoi.Value,
                NganSach = ParseCurrency(txtNganSach.Text),
                PhuongTien = LocalizationService.ToStandardVehicle(cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô"),
                DaHoanThanh = chkDaHoanThanh.Checked
            };

            _context.ChuyenDis.Add(cd);
            _context.SaveChanges();

            _selectedMaChuyen = cd.MaChuyen;
            LoadData();

            MessageBox.Show(
                LocalizationService.T("AddSuccess"),
                LocalizationService.T("AppTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thêm chuyến đi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (!_selectedMaChuyen.HasValue)
        {
            MessageBox.Show(
                LocalizationService.T("ValSelectTripToEdit"),
                LocalizationService.T("Edit"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateTripInput(isAdding: false)) return;

        try
        {
            var cd = _context.ChuyenDis.Find(_selectedMaChuyen.Value);
            if (cd == null)
            {
                MessageBox.Show("Chuyến đi không tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cd.TenChuyen = txtTenChuyen.Text.Trim();
            cd.DiaDiem = txtDiaDiem.Text.Trim();
            cd.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
            cd.SoNguoi = (int)nudSoNguoi.Value;
            cd.NganSach = ParseCurrency(txtNganSach.Text);
            cd.PhuongTien = LocalizationService.ToStandardVehicle(cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô");
            cd.DaHoanThanh = chkDaHoanThanh.Checked;

            _context.SaveChanges();
            LoadData();

            MessageBox.Show(
                LocalizationService.T("UpdateSuccess"),
                LocalizationService.T("AppTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi cập nhật chuyến đi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (!_selectedMaChuyen.HasValue)
        {
            MessageBox.Show(
                LocalizationService.T("ValSelectTripToDelete"),
                LocalizationService.T("Delete"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var cd = _context.ChuyenDis.Find(_selectedMaChuyen.Value);
        if (cd == null) return;

        var confirm = MessageBox.Show(
            string.Format(LocalizationService.T("ConfirmDeleteMessage"), cd.TenChuyen),
            LocalizationService.T("ConfirmDeleteTitle"),
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            try
            {
                _context.ChuyenDis.Remove(cd);
                _context.SaveChanges();

                _selectedMaChuyen = null;
                btnLamMoi_Click(this, EventArgs.Empty);
                LoadData();

                MessageBox.Show(
                    LocalizationService.T("DeleteSuccess"),
                    LocalizationService.T("AppTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa chuyến đi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        _selectedMaChuyen = null;
        txtTenChuyen.Text = "";
        txtDiaDiem.Text = "";
        dtpNgayDi.Value = DateTime.Today.AddDays(7);
        nudSoNguoi.Value = 2;
        txtNganSach.Text = LocalizationService.FormatCurrency(3000000);
        cboPhuongTien.SelectedIndex = 0;
        chkDaHoanThanh.Checked = false;

        _lastWeatherResult = null;
        iconWeather.ClearIcon();
        lblWeatherHeader.Text = LocalizationService.T("SelectTripPrompt");
        lblWeatherDesc.Text = "";
        lblTemperature.Text = "";
        lblRainProbability.Text = "";
        pnlWarning.Visible = false;

        dgvChuyenDi.ClearSelection();
        txtTenChuyen.Focus();
    }

    private void btnBoLoc_Click(object? sender, EventArgs e)
    {
        txtTimKiem.Text = "";
        chkChuaHoanThanh.Checked = false;
        chkLocNgay.Checked = false;
        dtpTuNgay.Value = DateTime.Today;
        dtpDenNgay.Value = DateTime.Today.AddDays(30);
        LoadData();
    }

    private bool ValidateTripInput(bool isAdding)
    {
        if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
        {
            MessageBox.Show(
                LocalizationService.T("ValTripNameRequired"),
                LocalizationService.T("TripName"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtTenChuyen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
        {
            MessageBox.Show(
                LocalizationService.T("ValDestinationRequired"),
                LocalizationService.T("Destination"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtDiaDiem.Focus();
            return false;
        }

        // Validate NgayDi: "ngày đi không nhỏ hơn hôm nay khi thêm mới"
        if (isAdding && dtpNgayDi.Value.Date < DateTime.Today)
        {
            MessageBox.Show(
                LocalizationService.T("ValDatePast"),
                LocalizationService.T("DepartureDate"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            dtpNgayDi.Focus();
            return false;
        }

        // Validate SoNguoi: >= 1
        if (nudSoNguoi.Value < 1)
        {
            MessageBox.Show(
                LocalizationService.T("ValPeopleMin"),
                LocalizationService.T("PeopleCount"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            nudSoNguoi.Focus();
            return false;
        }

        // Validate NganSach: >= 0
        decimal budget = ParseCurrency(txtNganSach.Text);
        if (budget < 0)
        {
            MessageBox.Show(
                LocalizationService.T("ValBudgetMin"),
                LocalizationService.T("Budget"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtNganSach.Focus();
            return false;
        }

        return true;
    }

    private static string CleanNumericString(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return "0";
        var chars = text.Where(c => char.IsDigit(c) || c == '-' || c == '.' || c == ',').ToArray();
        string cleaned = new string(chars)
            .Replace("₫", "")
            .Replace("$", "")
            .Trim();

        // If Vietnamese culture, '.' is thousand separator, ',' is decimal separator
        if (LocalizationService.IsVietnamese)
        {
            cleaned = cleaned.Replace(".", "").Replace(",", ".");
        }
        else
        {
            cleaned = cleaned.Replace(",", "");
        }

        return string.IsNullOrWhiteSpace(cleaned) ? "0" : cleaned;
    }

    private static decimal ParseCurrency(string text)
    {
        string cleaned = CleanNumericString(text);
        if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
        {
            return val;
        }
        return 0;
    }

    private void txtNganSach_KeyPress(object? sender, KeyPressEventArgs e)
    {
        // Allow control keys, digits, commas, periods
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
        {
            e.Handled = true;
        }
    }

    private void txtNganSach_Leave(object? sender, EventArgs e)
    {
        decimal val = ParseCurrency(txtNganSach.Text);
        txtNganSach.Text = LocalizationService.FormatCurrency(val);
    }

    private void FormChuyenDi_FormClosing(object? sender, FormClosingEventArgs e)
    {
        _context.Dispose();
    }
}

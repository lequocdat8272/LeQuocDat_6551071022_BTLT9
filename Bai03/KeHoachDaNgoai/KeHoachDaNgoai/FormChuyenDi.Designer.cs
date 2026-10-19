namespace KeHoachDaNgoai;

partial class FormChuyenDi
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dgvCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dgvCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dgvCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        
        lblAppHeader = new System.Windows.Forms.Label();
        lblNgônNgu = new System.Windows.Forms.Label();
        cboNgonNgu = new System.Windows.Forms.ComboBox();
        grpThongTin = new System.Windows.Forms.GroupBox();
        btnLamMoi = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnThem = new System.Windows.Forms.Button();
        chkDaHoanThanh = new System.Windows.Forms.CheckBox();
        cboPhuongTien = new System.Windows.Forms.ComboBox();
        lblPhuongTien = new System.Windows.Forms.Label();
        txtNganSach = new System.Windows.Forms.TextBox();
        lblNganSach = new System.Windows.Forms.Label();
        nudSoNguoi = new System.Windows.Forms.NumericUpDown();
        lblSoNguoi = new System.Windows.Forms.Label();
        dtpNgayDi = new System.Windows.Forms.DateTimePicker();
        lblNgayDi = new System.Windows.Forms.Label();
        txtDiaDiem = new System.Windows.Forms.TextBox();
        lblDiaDiem = new System.Windows.Forms.Label();
        txtTenChuyen = new System.Windows.Forms.TextBox();
        lblTenChuyen = new System.Windows.Forms.Label();
        btnXemThoiTiet = new System.Windows.Forms.Button();
        pbLoading = new System.Windows.Forms.ProgressBar();
        pnlWeatherCard = new System.Windows.Forms.Panel();
        pnlWarning = new System.Windows.Forms.Panel();
        lblWarningIcon = new System.Windows.Forms.Label();
        lblWarningText = new System.Windows.Forms.Label();
        lblRainProbability = new System.Windows.Forms.Label();
        lblTemperature = new System.Windows.Forms.Label();
        lblWeatherDesc = new System.Windows.Forms.Label();
        iconWeather = new KeHoachDaNgoai.Controls.WeatherIconControl();
        lblWeatherHeader = new System.Windows.Forms.Label();
        pnlFilter = new System.Windows.Forms.Panel();
        btnBoLoc = new System.Windows.Forms.Button();
        btnTim = new System.Windows.Forms.Button();
        dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        lblDenNgay = new System.Windows.Forms.Label();
        dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        chkLocNgay = new System.Windows.Forms.CheckBox();
        chkChuaHoanThanh = new System.Windows.Forms.CheckBox();
        txtTimKiem = new System.Windows.Forms.TextBox();
        dgvChuyenDi = new System.Windows.Forms.DataGridView();
        colMaChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTenChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDiaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSoNguoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNganSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPhuongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDaHoanThanh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        
        grpThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
        pnlWeatherCard.SuspendLayout();
        pnlWarning.SuspendLayout();
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
        SuspendLayout();

        // 
        // lblAppHeader
        // 
        lblAppHeader.AutoSize = true;
        lblAppHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblAppHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
        lblAppHeader.Location = new System.Drawing.Point(18, 14);
        lblAppHeader.Name = "lblAppHeader";
        lblAppHeader.Size = new System.Drawing.Size(287, 28);
        lblAppHeader.TabIndex = 0;
        lblAppHeader.Text = "Kế hoạch dã ngoại cuối tuần";

        // 
        // lblNgônNgu
        // 
        lblNgônNgu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        lblNgônNgu.AutoSize = true;
        lblNgônNgu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblNgônNgu.Location = new System.Drawing.Point(825, 20);
        lblNgônNgu.Name = "lblNgônNgu";
        lblNgônNgu.Size = new System.Drawing.Size(68, 17);
        lblNgônNgu.TabIndex = 1;
        lblNgônNgu.Text = "Ngôn ngữ";

        // 
        // cboNgonNgu
        // 
        cboNgonNgu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        cboNgonNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboNgonNgu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboNgonNgu.FormattingEnabled = true;
        cboNgonNgu.Location = new System.Drawing.Point(899, 16);
        cboNgonNgu.Name = "cboNgonNgu";
        cboNgonNgu.Size = new System.Drawing.Size(125, 25);
        cboNgonNgu.TabIndex = 2;

        // 
        // grpThongTin
        // 
        grpThongTin.Controls.Add(btnLamMoi);
        grpThongTin.Controls.Add(btnXoa);
        grpThongTin.Controls.Add(btnSua);
        grpThongTin.Controls.Add(btnThem);
        grpThongTin.Controls.Add(chkDaHoanThanh);
        grpThongTin.Controls.Add(cboPhuongTien);
        grpThongTin.Controls.Add(lblPhuongTien);
        grpThongTin.Controls.Add(txtNganSach);
        grpThongTin.Controls.Add(lblNganSach);
        grpThongTin.Controls.Add(nudSoNguoi);
        grpThongTin.Controls.Add(lblSoNguoi);
        grpThongTin.Controls.Add(dtpNgayDi);
        grpThongTin.Controls.Add(lblNgayDi);
        grpThongTin.Controls.Add(txtDiaDiem);
        grpThongTin.Controls.Add(lblDiaDiem);
        grpThongTin.Controls.Add(txtTenChuyen);
        grpThongTin.Controls.Add(lblTenChuyen);
        grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        grpThongTin.Location = new System.Drawing.Point(20, 52);
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Size = new System.Drawing.Size(560, 260);
        grpThongTin.TabIndex = 3;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin chuyến đi";

        // 
        // lblTenChuyen
        // 
        lblTenChuyen.AutoSize = true;
        lblTenChuyen.Location = new System.Drawing.Point(14, 28);
        lblTenChuyen.Name = "lblTenChuyen";
        lblTenChuyen.Size = new System.Drawing.Size(76, 17);
        lblTenChuyen.TabIndex = 0;
        lblTenChuyen.Text = "Tên chuyến";

        // 
        // txtTenChuyen
        // 
        txtTenChuyen.Location = new System.Drawing.Point(125, 24);
        txtTenChuyen.Name = "txtTenChuyen";
        txtTenChuyen.Size = new System.Drawing.Size(420, 24);
        txtTenChuyen.TabIndex = 1;

        // 
        // lblDiaDiem
        // 
        lblDiaDiem.AutoSize = true;
        lblDiaDiem.Location = new System.Drawing.Point(14, 58);
        lblDiaDiem.Name = "lblDiaDiem";
        lblDiaDiem.Size = new System.Drawing.Size(59, 17);
        lblDiaDiem.TabIndex = 2;
        lblDiaDiem.Text = "Địa điểm";

        // 
        // txtDiaDiem
        // 
        txtDiaDiem.Location = new System.Drawing.Point(125, 54);
        txtDiaDiem.Name = "txtDiaDiem";
        txtDiaDiem.Size = new System.Drawing.Size(420, 24);
        txtDiaDiem.TabIndex = 3;

        // 
        // lblNgayDi
        // 
        lblNgayDi.AutoSize = true;
        lblNgayDi.Location = new System.Drawing.Point(14, 89);
        lblNgayDi.Name = "lblNgayDi";
        lblNgayDi.Size = new System.Drawing.Size(54, 17);
        lblNgayDi.TabIndex = 4;
        lblNgayDi.Text = "Ngày đi";

        // 
        // dtpNgayDi
        // 
        dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpNgayDi.Location = new System.Drawing.Point(125, 84);
        dtpNgayDi.Name = "dtpNgayDi";
        dtpNgayDi.Size = new System.Drawing.Size(130, 24);
        dtpNgayDi.TabIndex = 5;

        // 
        // lblSoNguoi
        // 
        lblSoNguoi.AutoSize = true;
        lblSoNguoi.Location = new System.Drawing.Point(14, 120);
        lblSoNguoi.Name = "lblSoNguoi";
        lblSoNguoi.Size = new System.Drawing.Size(61, 17);
        lblSoNguoi.TabIndex = 6;
        lblSoNguoi.Text = "Số người";

        // 
        // nudSoNguoi
        // 
        nudSoNguoi.Location = new System.Drawing.Point(125, 116);
        nudSoNguoi.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSoNguoi.Name = "nudSoNguoi";
        nudSoNguoi.Size = new System.Drawing.Size(130, 24);
        nudSoNguoi.TabIndex = 7;
        nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // 
        // lblNganSach
        // 
        lblNganSach.AutoSize = true;
        lblNganSach.Location = new System.Drawing.Point(14, 151);
        lblNganSach.Name = "lblNganSach";
        lblNganSach.Size = new System.Drawing.Size(70, 17);
        lblNganSach.TabIndex = 8;
        lblNganSach.Text = "Ngân sách";

        // 
        // txtNganSach
        // 
        txtNganSach.Location = new System.Drawing.Point(125, 147);
        txtNganSach.Name = "txtNganSach";
        txtNganSach.Size = new System.Drawing.Size(130, 24);
        txtNganSach.TabIndex = 9;

        // 
        // lblPhuongTien
        // 
        lblPhuongTien.AutoSize = true;
        lblPhuongTien.Location = new System.Drawing.Point(14, 182);
        lblPhuongTien.Name = "lblPhuongTien";
        lblPhuongTien.Size = new System.Drawing.Size(81, 17);
        lblPhuongTien.TabIndex = 10;
        lblPhuongTien.Text = "Phương tiện";

        // 
        // cboPhuongTien
        // 
        cboPhuongTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboPhuongTien.FormattingEnabled = true;
        cboPhuongTien.Location = new System.Drawing.Point(125, 178);
        cboPhuongTien.Name = "cboPhuongTien";
        cboPhuongTien.Size = new System.Drawing.Size(130, 25);
        cboPhuongTien.TabIndex = 11;

        // 
        // chkDaHoanThanh
        // 
        chkDaHoanThanh.AutoSize = true;
        chkDaHoanThanh.Location = new System.Drawing.Point(14, 214);
        chkDaHoanThanh.Name = "chkDaHoanThanh";
        chkDaHoanThanh.Size = new System.Drawing.Size(113, 21);
        chkDaHoanThanh.TabIndex = 12;
        chkDaHoanThanh.Text = "Đã hoàn thành";
        chkDaHoanThanh.UseVisualStyleBackColor = true;

        // 
        // btnThem
        // 
        btnThem.BackColor = System.Drawing.SystemColors.ButtonFace;
        btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
        btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnThem.Location = new System.Drawing.Point(150, 215);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(90, 32);
        btnThem.TabIndex = 13;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = false;

        // 
        // btnSua
        // 
        btnSua.BackColor = System.Drawing.SystemColors.ButtonFace;
        btnSua.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
        btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnSua.Location = new System.Drawing.Point(250, 215);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(90, 32);
        btnSua.TabIndex = 14;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = false;

        // 
        // btnXoa
        // 
        btnXoa.BackColor = System.Drawing.SystemColors.ButtonFace;
        btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
        btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnXoa.Location = new System.Drawing.Point(350, 215);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(90, 32);
        btnXoa.TabIndex = 15;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = false;

        // 
        // btnLamMoi
        // 
        btnLamMoi.BackColor = System.Drawing.SystemColors.ButtonFace;
        btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
        btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnLamMoi.Location = new System.Drawing.Point(450, 215);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(95, 32);
        btnLamMoi.TabIndex = 16;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = false;

        // 
        // btnXemThoiTiet
        // 
        btnXemThoiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        btnXemThoiTiet.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnXemThoiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXemThoiTiet.Location = new System.Drawing.Point(600, 60);
        btnXemThoiTiet.Name = "btnXemThoiTiet";
        btnXemThoiTiet.Size = new System.Drawing.Size(150, 32);
        btnXemThoiTiet.TabIndex = 4;
        btnXemThoiTiet.Text = "Xem thời tiết";
        btnXemThoiTiet.UseVisualStyleBackColor = true;

        // 
        // pbLoading
        // 
        pbLoading.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        pbLoading.Location = new System.Drawing.Point(760, 64);
        pbLoading.MarqueeAnimationSpeed = 30;
        pbLoading.Name = "pbLoading";
        pbLoading.Size = new System.Drawing.Size(264, 24);
        pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        pbLoading.TabIndex = 5;
        pbLoading.Visible = false;

        // 
        // pnlWeatherCard
        // 
        pnlWeatherCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlWeatherCard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
        pnlWeatherCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlWeatherCard.Controls.Add(pnlWarning);
        pnlWeatherCard.Controls.Add(lblRainProbability);
        pnlWeatherCard.Controls.Add(lblTemperature);
        pnlWeatherCard.Controls.Add(lblWeatherDesc);
        pnlWeatherCard.Controls.Add(iconWeather);
        pnlWeatherCard.Controls.Add(lblWeatherHeader);
        pnlWeatherCard.Location = new System.Drawing.Point(600, 98);
        pnlWeatherCard.Name = "pnlWeatherCard";
        pnlWeatherCard.Size = new System.Drawing.Size(424, 214);
        pnlWeatherCard.TabIndex = 6;

        // 
        // lblWeatherHeader
        // 
        lblWeatherHeader.AutoSize = true;
        lblWeatherHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblWeatherHeader.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        lblWeatherHeader.Location = new System.Drawing.Point(12, 10);
        lblWeatherHeader.Name = "lblWeatherHeader";
        lblWeatherHeader.Size = new System.Drawing.Size(248, 19);
        lblWeatherHeader.TabIndex = 0;
        lblWeatherHeader.Text = "Dự báo thời tiết ngày 25/10/2026 - Đà Lạt";

        // 
        // iconWeather
        // 
        iconWeather.BackColor = System.Drawing.Color.Transparent;
        iconWeather.Location = new System.Drawing.Point(16, 42);
        iconWeather.Name = "iconWeather";
        iconWeather.Size = new System.Drawing.Size(100, 85);
        iconWeather.TabIndex = 1;

        // 
        // lblWeatherDesc
        // 
        lblWeatherDesc.AutoSize = true;
        lblWeatherDesc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblWeatherDesc.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
        lblWeatherDesc.Location = new System.Drawing.Point(135, 42);
        lblWeatherDesc.Name = "lblWeatherDesc";
        lblWeatherDesc.Size = new System.Drawing.Size(147, 30);
        lblWeatherDesc.TabIndex = 2;
        lblWeatherDesc.Text = "Mưa rào nhẹ";

        // 
        // lblTemperature
        // 
        lblTemperature.AutoSize = true;
        lblTemperature.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTemperature.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        lblTemperature.Location = new System.Drawing.Point(136, 78);
        lblTemperature.Name = "lblTemperature";
        lblTemperature.Size = new System.Drawing.Size(135, 19);
        lblTemperature.TabIndex = 3;
        lblTemperature.Text = "Nhiệt độ: 14°C - 22°C";

        // 
        // lblRainProbability
        // 
        lblRainProbability.AutoSize = true;
        lblRainProbability.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblRainProbability.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        lblRainProbability.Location = new System.Drawing.Point(136, 102);
        lblRainProbability.Name = "lblRainProbability";
        lblRainProbability.Size = new System.Drawing.Size(124, 19);
        lblRainProbability.TabIndex = 4;
        lblRainProbability.Text = "Khả năng mưa: 75%";

        // 
        // pnlWarning
        // 
        pnlWarning.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlWarning.BackColor = System.Drawing.Color.FromArgb(254, 227, 199);
        pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlWarning.Controls.Add(lblWarningIcon);
        pnlWarning.Controls.Add(lblWarningText);
        pnlWarning.Location = new System.Drawing.Point(16, 142);
        pnlWarning.Name = "pnlWarning";
        pnlWarning.Size = new System.Drawing.Size(390, 56);
        pnlWarning.TabIndex = 5;

        // 
        // lblWarningIcon
        // 
        lblWarningIcon.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
        lblWarningIcon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblWarningIcon.ForeColor = System.Drawing.Color.White;
        lblWarningIcon.Location = new System.Drawing.Point(10, 14);
        lblWarningIcon.Name = "lblWarningIcon";
        lblWarningIcon.Size = new System.Drawing.Size(26, 26);
        lblWarningIcon.TabIndex = 0;
        lblWarningIcon.Text = "!";
        lblWarningIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // 
        // lblWarningText
        // 
        lblWarningText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        lblWarningText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblWarningText.ForeColor = System.Drawing.Color.FromArgb(124, 45, 18);
        lblWarningText.Location = new System.Drawing.Point(44, 9);
        lblWarningText.Name = "lblWarningText";
        lblWarningText.Size = new System.Drawing.Size(335, 36);
        lblWarningText.TabIndex = 1;
        lblWarningText.Text = "Nên mang áo mưa hoặc cân nhắc dời lịch";
        lblWarningText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // 
        // pnlFilter
        // 
        pnlFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlFilter.Controls.Add(btnBoLoc);
        pnlFilter.Controls.Add(btnTim);
        pnlFilter.Controls.Add(dtpDenNgay);
        pnlFilter.Controls.Add(lblDenNgay);
        pnlFilter.Controls.Add(dtpTuNgay);
        pnlFilter.Controls.Add(chkLocNgay);
        pnlFilter.Controls.Add(chkChuaHoanThanh);
        pnlFilter.Controls.Add(txtTimKiem);
        pnlFilter.Location = new System.Drawing.Point(20, 320);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Size = new System.Drawing.Size(1004, 38);
        pnlFilter.TabIndex = 7;

        // 
        // txtTimKiem
        // 
        txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtTimKiem.Location = new System.Drawing.Point(0, 7);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.Size = new System.Drawing.Size(230, 24);
        txtTimKiem.TabIndex = 0;

        // 
        // chkChuaHoanThanh
        // 
        chkChuaHoanThanh.AutoSize = true;
        chkChuaHoanThanh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        chkChuaHoanThanh.Location = new System.Drawing.Point(245, 9);
        chkChuaHoanThanh.Name = "chkChuaHoanThanh";
        chkChuaHoanThanh.Size = new System.Drawing.Size(225, 21);
        chkChuaHoanThanh.TabIndex = 1;
        chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
        chkChuaHoanThanh.UseVisualStyleBackColor = true;

        // 
        // chkLocNgay
        // 
        chkLocNgay.AutoSize = true;
        chkLocNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        chkLocNgay.Location = new System.Drawing.Point(485, 9);
        chkLocNgay.Name = "chkLocNgay";
        chkLocNgay.Size = new System.Drawing.Size(105, 21);
        chkLocNgay.TabIndex = 2;
        chkLocNgay.Text = "Khoảng ngày:";
        chkLocNgay.UseVisualStyleBackColor = true;

        // 
        // dtpTuNgay
        // 
        dtpTuNgay.Enabled = false;
        dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpTuNgay.Location = new System.Drawing.Point(595, 7);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.Size = new System.Drawing.Size(110, 24);
        dtpTuNgay.TabIndex = 3;

        // 
        // lblDenNgay
        // 
        lblDenNgay.AutoSize = true;
        lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblDenNgay.Location = new System.Drawing.Point(712, 10);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new System.Drawing.Size(13, 17);
        lblDenNgay.TabIndex = 4;
        lblDenNgay.Text = "-";

        // 
        // dtpDenNgay
        // 
        dtpDenNgay.Enabled = false;
        dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpDenNgay.Location = new System.Drawing.Point(732, 7);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.Size = new System.Drawing.Size(110, 24);
        dtpDenNgay.TabIndex = 5;

        // 
        // btnTim
        // 
        btnTim.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnTim.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnTim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnTim.Location = new System.Drawing.Point(858, 6);
        btnTim.Name = "btnTim";
        btnTim.Size = new System.Drawing.Size(68, 27);
        btnTim.TabIndex = 6;
        btnTim.Text = "Tìm";
        btnTim.UseVisualStyleBackColor = true;

        // 
        // btnBoLoc
        // 
        btnBoLoc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnBoLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnBoLoc.Location = new System.Drawing.Point(932, 6);
        btnBoLoc.Name = "btnBoLoc";
        btnBoLoc.Size = new System.Drawing.Size(68, 27);
        btnBoLoc.TabIndex = 7;
        btnBoLoc.Text = "Bỏ lọc";
        btnBoLoc.UseVisualStyleBackColor = true;

        // 
        // dgvChuyenDi
        // 
        dgvChuyenDi.AllowUserToAddRows = false;
        dgvChuyenDi.AllowUserToDeleteRows = false;
        dgvChuyenDi.AllowUserToResizeRows = false;
        dgvChuyenDi.AutoGenerateColumns = false;
        dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
        dgvChuyenDi.AlternatingRowsDefaultCellStyle = dgvCellStyle1;
        dgvChuyenDi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvChuyenDi.BackgroundColor = System.Drawing.Color.White;
        dgvChuyenDi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvCellStyle2.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
        dgvCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvChuyenDi.ColumnHeadersDefaultCellStyle = dgvCellStyle2;
        dgvChuyenDi.ColumnHeadersHeight = 32;
        dgvChuyenDi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colMaChuyen,
            colTenChuyen,
            colDiaDiem,
            colNgayDi,
            colSoNguoi,
            colNganSach,
            colPhuongTien,
            colDaHoanThanh
        });
        dgvCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dgvCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dgvCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dgvCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(2, 132, 199);
        dgvCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dgvCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvChuyenDi.DefaultCellStyle = dgvCellStyle3;
        dgvChuyenDi.EnableHeadersVisualStyles = false;
        dgvChuyenDi.Location = new System.Drawing.Point(20, 365);
        dgvChuyenDi.MultiSelect = false;
        dgvChuyenDi.Name = "dgvChuyenDi";
        dgvChuyenDi.ReadOnly = true;
        dgvChuyenDi.RowHeadersWidth = 35;
        dgvChuyenDi.RowTemplate.Height = 28;
        dgvChuyenDi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvChuyenDi.Size = new System.Drawing.Size(1004, 255);
        dgvChuyenDi.TabIndex = 8;

        // 
        // colMaChuyen
        // 
        colMaChuyen.DataPropertyName = "MaChuyen";
        colMaChuyen.HeaderText = "Mã";
        colMaChuyen.Name = "colMaChuyen";
        colMaChuyen.ReadOnly = true;
        colMaChuyen.Width = 65;

        // 
        // colTenChuyen
        // 
        colTenChuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colTenChuyen.DataPropertyName = "TenChuyen";
        colTenChuyen.HeaderText = "Tên chuyến";
        colTenChuyen.MinimumWidth = 140;
        colTenChuyen.Name = "colTenChuyen";
        colTenChuyen.ReadOnly = true;

        // 
        // colDiaDiem
        // 
        colDiaDiem.DataPropertyName = "DiaDiem";
        colDiaDiem.HeaderText = "Địa điểm";
        colDiaDiem.Name = "colDiaDiem";
        colDiaDiem.ReadOnly = true;
        colDiaDiem.Width = 130;

        // 
        // colNgayDi
        // 
        colNgayDi.DataPropertyName = "NgayDi";
        colNgayDi.HeaderText = "Ngày đi";
        colNgayDi.Name = "colNgayDi";
        colNgayDi.ReadOnly = true;
        colNgayDi.Width = 110;

        // 
        // colSoNguoi
        // 
        colSoNguoi.DataPropertyName = "SoNguoi";
        colSoNguoi.HeaderText = "Số người";
        colSoNguoi.Name = "colSoNguoi";
        colSoNguoi.ReadOnly = true;
        colSoNguoi.Width = 85;

        // 
        // colNganSach
        // 
        colNganSach.DataPropertyName = "NganSach";
        colNganSach.HeaderText = "Ngân sách";
        colNganSach.Name = "colNganSach";
        colNganSach.ReadOnly = true;
        colNganSach.Width = 120;

        // 
        // colPhuongTien
        // 
        colPhuongTien.DataPropertyName = "PhuongTien";
        colPhuongTien.HeaderText = "Phương tiện";
        colPhuongTien.Name = "colPhuongTien";
        colPhuongTien.ReadOnly = true;
        colPhuongTien.Width = 110;

        // 
        // colDaHoanThanh
        // 
        colDaHoanThanh.DataPropertyName = "DaHoanThanh";
        colDaHoanThanh.HeaderText = "Hoàn thành";
        colDaHoanThanh.Name = "colDaHoanThanh";
        colDaHoanThanh.ReadOnly = true;
        colDaHoanThanh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        colDaHoanThanh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        colDaHoanThanh.Width = 105;

        // 
        // FormChuyenDi
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
        ClientSize = new System.Drawing.Size(1044, 636);
        Controls.Add(dgvChuyenDi);
        Controls.Add(pnlFilter);
        Controls.Add(pnlWeatherCard);
        Controls.Add(pbLoading);
        Controls.Add(btnXemThoiTiet);
        Controls.Add(grpThongTin);
        Controls.Add(cboNgonNgu);
        Controls.Add(lblNgônNgu);
        Controls.Add(lblAppHeader);
        Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        MinimumSize = new System.Drawing.Size(980, 600);
        Name = "FormChuyenDi";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Kế hoạch dã ngoại cuối tuần";
        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
        pnlWeatherCard.ResumeLayout(false);
        pnlWeatherCard.PerformLayout();
        pnlWarning.ResumeLayout(false);
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblAppHeader;
    private System.Windows.Forms.Label lblNgônNgu;
    private System.Windows.Forms.ComboBox cboNgonNgu;
    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblTenChuyen;
    private System.Windows.Forms.TextBox txtTenChuyen;
    private System.Windows.Forms.Label lblDiaDiem;
    private System.Windows.Forms.TextBox txtDiaDiem;
    private System.Windows.Forms.Label lblNgayDi;
    private System.Windows.Forms.DateTimePicker dtpNgayDi;
    private System.Windows.Forms.Label lblSoNguoi;
    private System.Windows.Forms.NumericUpDown nudSoNguoi;
    private System.Windows.Forms.Label lblNganSach;
    private System.Windows.Forms.TextBox txtNganSach;
    private System.Windows.Forms.Label lblPhuongTien;
    private System.Windows.Forms.ComboBox cboPhuongTien;
    private System.Windows.Forms.CheckBox chkDaHoanThanh;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnXemThoiTiet;
    private System.Windows.Forms.ProgressBar pbLoading;
    private System.Windows.Forms.Panel pnlWeatherCard;
    private System.Windows.Forms.Label lblWeatherHeader;
    private KeHoachDaNgoai.Controls.WeatherIconControl iconWeather;
    private System.Windows.Forms.Label lblWeatherDesc;
    private System.Windows.Forms.Label lblTemperature;
    private System.Windows.Forms.Label lblRainProbability;
    private System.Windows.Forms.Panel pnlWarning;
    private System.Windows.Forms.Label lblWarningIcon;
    private System.Windows.Forms.Label lblWarningText;
    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.TextBox txtTimKiem;
    private System.Windows.Forms.CheckBox chkChuaHoanThanh;
    private System.Windows.Forms.CheckBox chkLocNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Button btnTim;
    private System.Windows.Forms.Button btnBoLoc;
    private System.Windows.Forms.DataGridView dgvChuyenDi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMaChuyen;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTenChuyen;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDiaDiem;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNgayDi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSoNguoi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNganSach;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongTien;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colDaHoanThanh;
}

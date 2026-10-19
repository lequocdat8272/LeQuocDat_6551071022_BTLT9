namespace QuanLyNhaTro;

partial class FormKhachThue
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

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        
        lblTieuDeThongTin = new System.Windows.Forms.Label();
        lblHoTen = new System.Windows.Forms.Label();
        txtHoTen = new System.Windows.Forms.TextBox();
        grpGioiTinh = new System.Windows.Forms.GroupBox();
        radNam = new System.Windows.Forms.RadioButton();
        radNu = new System.Windows.Forms.RadioButton();
        lblNgaySinh = new System.Windows.Forms.Label();
        dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
        lblSoDienThoai = new System.Windows.Forms.Label();
        txtSoDienThoai = new System.Windows.Forms.TextBox();
        lblPhong = new System.Windows.Forms.Label();
        cboPhong = new System.Windows.Forms.ComboBox();
        lblTinhThanh = new System.Windows.Forms.Label();
        cboTinhThanh = new System.Windows.Forms.ComboBox();
        lblPhuongXa = new System.Windows.Forms.Label();
        cboPhuongXa = new System.Windows.Forms.ComboBox();
        chkTamTru = new System.Windows.Forms.CheckBox();
        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();
        btnGayLoiThu = new System.Windows.Forms.Button();
        txtTimKiem = new System.Windows.Forms.TextBox();
        lblLocPhong = new System.Windows.Forms.Label();
        cboLocPhong = new System.Windows.Forms.ComboBox();
        lblLocTinh = new System.Windows.Forms.Label();
        cboLocTinh = new System.Windows.Forms.ComboBox();
        btnTim = new System.Windows.Forms.Button();
        btnBoLoc = new System.Windows.Forms.Button();
        dgvKhachThue = new System.Windows.Forms.DataGridView();
        colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colGiaThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colQueQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTamTru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        statusStrip1 = new System.Windows.Forms.StatusStrip();
        lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        
        grpGioiTinh.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhachThue).BeginInit();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // 
        // lblTieuDeThongTin
        // 
        lblTieuDeThongTin.AutoSize = true;
        lblTieuDeThongTin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTieuDeThongTin.Location = new System.Drawing.Point(22, 18);
        lblTieuDeThongTin.Name = "lblTieuDeThongTin";
        lblTieuDeThongTin.Size = new System.Drawing.Size(147, 19);
        lblTieuDeThongTin.TabIndex = 0;
        lblTieuDeThongTin.Text = "Thông tin khách thuê";

        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.Location = new System.Drawing.Point(34, 55);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new System.Drawing.Size(47, 17);
        lblHoTen.TabIndex = 1;
        lblHoTen.Text = "Họ tên";

        // 
        // txtHoTen
        // 
        txtHoTen.Location = new System.Drawing.Point(135, 52);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new System.Drawing.Size(205, 25);
        txtHoTen.TabIndex = 2;

        // 
        // grpGioiTinh
        // 
        grpGioiTinh.Controls.Add(radNam);
        grpGioiTinh.Controls.Add(radNu);
        grpGioiTinh.Location = new System.Drawing.Point(135, 83);
        grpGioiTinh.Name = "grpGioiTinh";
        grpGioiTinh.Size = new System.Drawing.Size(205, 38);
        grpGioiTinh.TabIndex = 3;
        grpGioiTinh.TabStop = false;

        // 
        // radNam
        // 
        radNam.AutoSize = true;
        radNam.Checked = true;
        radNam.Location = new System.Drawing.Point(10, 12);
        radNam.Name = "radNam";
        radNam.Size = new System.Drawing.Size(53, 21);
        radNam.TabIndex = 0;
        radNam.TabStop = true;
        radNam.Text = "Nam";
        radNam.UseVisualStyleBackColor = true;

        // 
        // radNu
        // 
        radNu.AutoSize = true;
        radNu.Location = new System.Drawing.Point(100, 12);
        radNu.Name = "radNu";
        radNu.Size = new System.Drawing.Size(43, 21);
        radNu.TabIndex = 1;
        radNu.Text = "Nữ";
        radNu.UseVisualStyleBackColor = true;

        // 
        // lblNgaySinh
        // 
        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Location = new System.Drawing.Point(34, 134);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Size = new System.Drawing.Size(66, 17);
        lblNgaySinh.TabIndex = 4;
        lblNgaySinh.Text = "Ngày sinh";

        // 
        // dtpNgaySinh
        // 
        dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNgaySinh.Location = new System.Drawing.Point(135, 130);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.Size = new System.Drawing.Size(205, 25);
        dtpNgaySinh.TabIndex = 5;

        // 
        // lblSoDienThoai
        // 
        lblSoDienThoai.AutoSize = true;
        lblSoDienThoai.Location = new System.Drawing.Point(34, 173);
        lblSoDienThoai.Name = "lblSoDienThoai";
        lblSoDienThoai.Size = new System.Drawing.Size(85, 17);
        lblSoDienThoai.TabIndex = 6;
        lblSoDienThoai.Text = "Số điện thoại";

        // 
        // txtSoDienThoai
        // 
        txtSoDienThoai.Location = new System.Drawing.Point(135, 170);
        txtSoDienThoai.Name = "txtSoDienThoai";
        txtSoDienThoai.Size = new System.Drawing.Size(205, 25);
        txtSoDienThoai.TabIndex = 7;

        // 
        // lblPhong
        // 
        lblPhong.AutoSize = true;
        lblPhong.Location = new System.Drawing.Point(34, 212);
        lblPhong.Name = "lblPhong";
        lblPhong.Size = new System.Drawing.Size(45, 17);
        lblPhong.TabIndex = 8;
        lblPhong.Text = "Phòng";

        // 
        // cboPhong
        // 
        cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboPhong.FormattingEnabled = true;
        cboPhong.Location = new System.Drawing.Point(135, 209);
        cboPhong.Name = "cboPhong";
        cboPhong.Size = new System.Drawing.Size(205, 25);
        cboPhong.TabIndex = 9;

        // 
        // lblTinhThanh
        // 
        lblTinhThanh.AutoSize = true;
        lblTinhThanh.Location = new System.Drawing.Point(34, 251);
        lblTinhThanh.Name = "lblTinhThanh";
        lblTinhThanh.Size = new System.Drawing.Size(71, 17);
        lblTinhThanh.TabIndex = 10;
        lblTinhThanh.Text = "Tỉnh/Thành";

        // 
        // cboTinhThanh
        // 
        cboTinhThanh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        cboTinhThanh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        cboTinhThanh.FormattingEnabled = true;
        cboTinhThanh.Location = new System.Drawing.Point(135, 248);
        cboTinhThanh.Name = "cboTinhThanh";
        cboTinhThanh.Size = new System.Drawing.Size(205, 25);
        cboTinhThanh.TabIndex = 11;
        cboTinhThanh.SelectedIndexChanged += cboTinhThanh_SelectedIndexChanged;

        // 
        // lblPhuongXa
        // 
        lblPhuongXa.AutoSize = true;
        lblPhuongXa.Location = new System.Drawing.Point(34, 290);
        lblPhuongXa.Name = "lblPhuongXa";
        lblPhuongXa.Size = new System.Drawing.Size(73, 17);
        lblPhuongXa.TabIndex = 12;
        lblPhuongXa.Text = "Phường/Xã";

        // 
        // cboPhuongXa
        // 
        cboPhuongXa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        cboPhuongXa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        cboPhuongXa.FormattingEnabled = true;
        cboPhuongXa.Location = new System.Drawing.Point(135, 287);
        cboPhuongXa.Name = "cboPhuongXa";
        cboPhuongXa.Size = new System.Drawing.Size(205, 25);
        cboPhuongXa.TabIndex = 13;

        // 
        // chkTamTru
        // 
        chkTamTru.AutoSize = true;
        chkTamTru.Location = new System.Drawing.Point(37, 335);
        chkTamTru.Name = "chkTamTru";
        chkTamTru.Size = new System.Drawing.Size(147, 21);
        chkTamTru.TabIndex = 14;
        chkTamTru.Text = "Đã đăng ký tạm trú";
        chkTamTru.UseVisualStyleBackColor = true;

        // 
        // btnThem
        // 
        btnThem.Location = new System.Drawing.Point(22, 375);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(76, 32);
        btnThem.TabIndex = 15;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Location = new System.Drawing.Point(104, 375);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(76, 32);
        btnSua.TabIndex = 16;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Location = new System.Drawing.Point(186, 375);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(76, 32);
        btnXoa.TabIndex = 17;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new System.Drawing.Point(268, 375);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(82, 32);
        btnLamMoi.TabIndex = 18;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // btnGayLoiThu
        // 
        btnGayLoiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnGayLoiThu.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnGayLoiThu.ForeColor = System.Drawing.Color.Gray;
        btnGayLoiThu.Location = new System.Drawing.Point(22, 417);
        btnGayLoiThu.Name = "btnGayLoiThu";
        btnGayLoiThu.Size = new System.Drawing.Size(95, 25);
        btnGayLoiThu.TabIndex = 19;
        btnGayLoiThu.Text = "Gây lỗi thử";
        btnGayLoiThu.UseVisualStyleBackColor = true;
        btnGayLoiThu.Click += btnGayLoiThu_Click;

        // 
        // txtTimKiem
        // 
        txtTimKiem.Location = new System.Drawing.Point(380, 52);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Tìm theo tên hoặc SĐT";
        txtTimKiem.Size = new System.Drawing.Size(185, 25);
        txtTimKiem.TabIndex = 20;

        // 
        // lblLocPhong
        // 
        lblLocPhong.AutoSize = true;
        lblLocPhong.Location = new System.Drawing.Point(575, 55);
        lblLocPhong.Name = "lblLocPhong";
        lblLocPhong.Size = new System.Drawing.Size(48, 17);
        lblLocPhong.TabIndex = 21;
        lblLocPhong.Text = "Phòng:";

        // 
        // cboLocPhong
        // 
        cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLocPhong.FormattingEnabled = true;
        cboLocPhong.Location = new System.Drawing.Point(626, 52);
        cboLocPhong.Name = "cboLocPhong";
        cboLocPhong.Size = new System.Drawing.Size(85, 25);
        cboLocPhong.TabIndex = 22;

        // 
        // lblLocTinh
        // 
        lblLocTinh.AutoSize = true;
        lblLocTinh.Location = new System.Drawing.Point(718, 55);
        lblLocTinh.Name = "lblLocTinh";
        lblLocTinh.Size = new System.Drawing.Size(36, 17);
        lblLocTinh.TabIndex = 23;
        lblLocTinh.Text = "Tỉnh:";

        // 
        // cboLocTinh
        // 
        cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLocTinh.FormattingEnabled = true;
        cboLocTinh.Location = new System.Drawing.Point(757, 52);
        cboLocTinh.Name = "cboLocTinh";
        cboLocTinh.Size = new System.Drawing.Size(95, 25);
        cboLocTinh.TabIndex = 24;

        // 
        // btnTim
        // 
        btnTim.Location = new System.Drawing.Point(858, 50);
        btnTim.Name = "btnTim";
        btnTim.Size = new System.Drawing.Size(56, 28);
        btnTim.TabIndex = 25;
        btnTim.Text = "Tìm";
        btnTim.UseVisualStyleBackColor = true;
        btnTim.Click += btnTim_Click;

        // 
        // btnBoLoc
        // 
        btnBoLoc.Location = new System.Drawing.Point(920, 50);
        btnBoLoc.Name = "btnBoLoc";
        btnBoLoc.Size = new System.Drawing.Size(65, 28);
        btnBoLoc.TabIndex = 26;
        btnBoLoc.Text = "Bỏ lọc";
        btnBoLoc.UseVisualStyleBackColor = true;
        btnBoLoc.Click += btnBoLoc_Click;

        // 
        // dgvKhachThue
        // 
        dgvKhachThue.AllowUserToAddRows = false;
        dgvKhachThue.AllowUserToDeleteRows = false;
        dgvKhachThue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvKhachThue.BackgroundColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvKhachThue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvKhachThue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colHoTen,
            colSoDienThoai,
            colPhong,
            colGiaThue,
            colQueQuan,
            colTamTru
        });
        dgvKhachThue.Location = new System.Drawing.Point(380, 88);
        dgvKhachThue.MultiSelect = false;
        dgvKhachThue.Name = "dgvKhachThue";
        dgvKhachThue.ReadOnly = true;
        dgvKhachThue.RowHeadersWidth = 25;
        dgvKhachThue.RowTemplate.Height = 25;
        dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvKhachThue.Size = new System.Drawing.Size(605, 345);
        dgvKhachThue.TabIndex = 27;
        dgvKhachThue.CellClick += dgvKhachThue_CellClick;

        // 
        // colHoTen
        // 
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.HeaderText = "Họ tên";
        colHoTen.MinimumWidth = 110;
        colHoTen.Name = "colHoTen";
        colHoTen.ReadOnly = true;
        colHoTen.Width = 125;

        // 
        // colSoDienThoai
        // 
        colSoDienThoai.DataPropertyName = "SoDienThoai";
        colSoDienThoai.HeaderText = "SĐT";
        colSoDienThoai.MinimumWidth = 80;
        colSoDienThoai.Name = "colSoDienThoai";
        colSoDienThoai.ReadOnly = true;
        colSoDienThoai.Width = 90;

        // 
        // colPhong
        // 
        colPhong.DataPropertyName = "TenPhong";
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        colPhong.DefaultCellStyle = dataGridViewCellStyle2;
        colPhong.HeaderText = "Phòng";
        colPhong.MinimumWidth = 50;
        colPhong.Name = "colPhong";
        colPhong.ReadOnly = true;
        colPhong.Width = 55;

        // 
        // colGiaThue
        // 
        colGiaThue.DataPropertyName = "GiaThue";
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle3.Format = "N0 đ";
        dataGridViewCellStyle3.NullValue = null;
        colGiaThue.DefaultCellStyle = dataGridViewCellStyle3;
        colGiaThue.HeaderText = "Giá thuê";
        colGiaThue.MinimumWidth = 80;
        colGiaThue.Name = "colGiaThue";
        colGiaThue.ReadOnly = true;
        colGiaThue.Width = 95;

        // 
        // colQueQuan
        // 
        colQueQuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colQueQuan.DataPropertyName = "QueQuan";
        colQueQuan.HeaderText = "Quê quán";
        colQueQuan.MinimumWidth = 110;
        colQueQuan.Name = "colQueQuan";
        colQueQuan.ReadOnly = true;

        // 
        // colTamTru
        // 
        colTamTru.DataPropertyName = "DaDangKyTamTru";
        colTamTru.HeaderText = "Tạm trú";
        colTamTru.MinimumWidth = 55;
        colTamTru.Name = "colTamTru";
        colTamTru.ReadOnly = true;
        colTamTru.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        colTamTru.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        colTamTru.Width = 60;

        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            lblStatus
        });
        statusStrip1.Location = new System.Drawing.Point(0, 452);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new System.Drawing.Size(1004, 22);
        statusStrip1.TabIndex = 28;
        statusStrip1.Text = "statusStrip1";

        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(164, 17);
        lblStatus.Text = "Đang kết nối API hành chính...";

        // 
        // FormKhachThue
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1004, 474);
        Controls.Add(statusStrip1);
        Controls.Add(dgvKhachThue);
        Controls.Add(btnBoLoc);
        Controls.Add(btnTim);
        Controls.Add(cboLocTinh);
        Controls.Add(lblLocTinh);
        Controls.Add(cboLocPhong);
        Controls.Add(lblLocPhong);
        Controls.Add(txtTimKiem);
        Controls.Add(btnGayLoiThu);
        Controls.Add(btnLamMoi);
        Controls.Add(btnXoa);
        Controls.Add(btnSua);
        Controls.Add(btnThem);
        Controls.Add(chkTamTru);
        Controls.Add(cboPhuongXa);
        Controls.Add(lblPhuongXa);
        Controls.Add(cboTinhThanh);
        Controls.Add(lblTinhThanh);
        Controls.Add(cboPhong);
        Controls.Add(lblPhong);
        Controls.Add(txtSoDienThoai);
        Controls.Add(lblSoDienThoai);
        Controls.Add(dtpNgaySinh);
        Controls.Add(lblNgaySinh);
        Controls.Add(grpGioiTinh);
        Controls.Add(txtHoTen);
        Controls.Add(lblHoTen);
        Controls.Add(lblTieuDeThongTin);
        Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        MinimumSize = new System.Drawing.Size(950, 480);
        Name = "FormKhachThue";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản lý nhà trọ - Khách thuê";
        Load += FormKhachThue_Load;
        grpGioiTinh.ResumeLayout(false);
        grpGioiTinh.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhachThue).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTieuDeThongTin;
    private System.Windows.Forms.Label lblHoTen;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.GroupBox grpGioiTinh;
    private System.Windows.Forms.RadioButton radNam;
    private System.Windows.Forms.RadioButton radNu;
    private System.Windows.Forms.Label lblNgaySinh;
    private System.Windows.Forms.DateTimePicker dtpNgaySinh;
    private System.Windows.Forms.Label lblSoDienThoai;
    private System.Windows.Forms.TextBox txtSoDienThoai;
    private System.Windows.Forms.Label lblPhong;
    private System.Windows.Forms.ComboBox cboPhong;
    private System.Windows.Forms.Label lblTinhThanh;
    private System.Windows.Forms.ComboBox cboTinhThanh;
    private System.Windows.Forms.Label lblPhuongXa;
    private System.Windows.Forms.ComboBox cboPhuongXa;
    private System.Windows.Forms.CheckBox chkTamTru;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnGayLoiThu;
    private System.Windows.Forms.TextBox txtTimKiem;
    private System.Windows.Forms.Label lblLocPhong;
    private System.Windows.Forms.ComboBox cboLocPhong;
    private System.Windows.Forms.Label lblLocTinh;
    private System.Windows.Forms.ComboBox cboLocTinh;
    private System.Windows.Forms.Button btnTim;
    private System.Windows.Forms.Button btnBoLoc;
    private System.Windows.Forms.DataGridView dgvKhachThue;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhong;
    private System.Windows.Forms.DataGridViewTextBoxColumn colGiaThue;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQueQuan;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colTamTru;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
}

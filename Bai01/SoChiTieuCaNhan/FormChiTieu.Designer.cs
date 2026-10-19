namespace SoChiTieuCaNhan;

partial class FormChiTieu
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        
        grpThongTin = new System.Windows.Forms.GroupBox();
        lblNgayChi = new System.Windows.Forms.Label();
        dtpNgayChi = new System.Windows.Forms.DateTimePicker();
        lblNoiDung = new System.Windows.Forms.Label();
        txtNoiDung = new System.Windows.Forms.TextBox();
        lblLoaiChi = new System.Windows.Forms.Label();
        cboLoaiChi = new System.Windows.Forms.ComboBox();
        lblSoTien = new System.Windows.Forms.Label();
        numSoTien = new System.Windows.Forms.NumericUpDown();
        lblGhiChu = new System.Windows.Forms.Label();
        txtGhiChu = new System.Windows.Forms.TextBox();
        
        grpTimKiem = new System.Windows.Forms.GroupBox();
        lblTimNoiDung = new System.Windows.Forms.Label();
        txtTimNoiDung = new System.Windows.Forms.TextBox();
        lblTimLoaiChi = new System.Windows.Forms.Label();
        cboTimLoaiChi = new System.Windows.Forms.ComboBox();
        lblTuNgay = new System.Windows.Forms.Label();
        dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        lblDenNgay = new System.Windows.Forms.Label();
        dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        btnTim = new System.Windows.Forms.Button();
        
        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();
        
        dgvDanhSach = new System.Windows.Forms.DataGridView();
        colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNgayChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colLoaiChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
        
        lblTongChi = new System.Windows.Forms.Label();

        grpThongTin.SuspendLayout();
        grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numSoTien).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
        SuspendLayout();

        // 
        // grpThongTin
        // 
        grpThongTin.Controls.Add(lblNgayChi);
        grpThongTin.Controls.Add(dtpNgayChi);
        grpThongTin.Controls.Add(lblNoiDung);
        grpThongTin.Controls.Add(txtNoiDung);
        grpThongTin.Controls.Add(lblLoaiChi);
        grpThongTin.Controls.Add(cboLoaiChi);
        grpThongTin.Controls.Add(lblSoTien);
        grpThongTin.Controls.Add(numSoTien);
        grpThongTin.Controls.Add(lblGhiChu);
        grpThongTin.Controls.Add(txtGhiChu);
        grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        grpThongTin.Location = new System.Drawing.Point(16, 12);
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Size = new System.Drawing.Size(540, 182);
        grpThongTin.TabIndex = 0;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin khoản chi";

        // lblNgayChi
        lblNgayChi.AutoSize = true;
        lblNgayChi.Location = new System.Drawing.Point(14, 27);
        lblNgayChi.Name = "lblNgayChi";
        lblNgayChi.Size = new System.Drawing.Size(62, 17);
        lblNgayChi.TabIndex = 0;
        lblNgayChi.Text = "Ngày chi";

        // dtpNgayChi
        dtpNgayChi.CustomFormat = "dd/MM/yyyy";
        dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNgayChi.Location = new System.Drawing.Point(82, 24);
        dtpNgayChi.Name = "dtpNgayChi";
        dtpNgayChi.Size = new System.Drawing.Size(160, 24);
        dtpNgayChi.TabIndex = 1;

        // lblNoiDung
        lblNoiDung.AutoSize = true;
        lblNoiDung.Location = new System.Drawing.Point(14, 59);
        lblNoiDung.Name = "lblNoiDung";
        lblNoiDung.Size = new System.Drawing.Size(62, 17);
        lblNoiDung.TabIndex = 2;
        lblNoiDung.Text = "Nội dung";

        // txtNoiDung
        txtNoiDung.Location = new System.Drawing.Point(82, 56);
        txtNoiDung.MaxLength = 100;
        txtNoiDung.Name = "txtNoiDung";
        txtNoiDung.Size = new System.Drawing.Size(160, 24);
        txtNoiDung.TabIndex = 3;

        // lblLoaiChi
        lblLoaiChi.AutoSize = true;
        lblLoaiChi.Location = new System.Drawing.Point(14, 91);
        lblLoaiChi.Name = "lblLoaiChi";
        lblLoaiChi.Size = new System.Drawing.Size(53, 17);
        lblLoaiChi.TabIndex = 4;
        lblLoaiChi.Text = "Loại chi";

        // cboLoaiChi
        cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLoaiChi.FormattingEnabled = true;
        cboLoaiChi.Items.AddRange(new object[] {
            "Ăn uống",
            "Đi lại",
            "Học tập",
            "Giải trí",
            "Khác"
        });
        cboLoaiChi.Location = new System.Drawing.Point(82, 88);
        cboLoaiChi.Name = "cboLoaiChi";
        cboLoaiChi.Size = new System.Drawing.Size(160, 25);
        cboLoaiChi.TabIndex = 5;

        // lblSoTien
        lblSoTien.AutoSize = true;
        lblSoTien.Location = new System.Drawing.Point(260, 59);
        lblSoTien.Name = "lblSoTien";
        lblSoTien.Size = new System.Drawing.Size(48, 17);
        lblSoTien.TabIndex = 6;
        lblSoTien.Text = "Số tiền";

        // numSoTien
        numSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        numSoTien.Location = new System.Drawing.Point(320, 56);
        numSoTien.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 }); // 1 tỷ
        numSoTien.Name = "numSoTien";
        numSoTien.Size = new System.Drawing.Size(200, 24);
        numSoTien.TabIndex = 7;
        numSoTien.ThousandsSeparator = true;

        // lblGhiChu
        lblGhiChu.AutoSize = true;
        lblGhiChu.Location = new System.Drawing.Point(14, 126);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Size = new System.Drawing.Size(51, 17);
        lblGhiChu.TabIndex = 8;
        lblGhiChu.Text = "Ghi chú";

        // txtGhiChu
        txtGhiChu.Location = new System.Drawing.Point(82, 123);
        txtGhiChu.MaxLength = 200;
        txtGhiChu.Multiline = true;
        txtGhiChu.Name = "txtGhiChu";
        txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtGhiChu.Size = new System.Drawing.Size(438, 48);
        txtGhiChu.TabIndex = 9;

        // 
        // grpTimKiem
        // 
        grpTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        grpTimKiem.Controls.Add(lblTimNoiDung);
        grpTimKiem.Controls.Add(txtTimNoiDung);
        grpTimKiem.Controls.Add(lblTimLoaiChi);
        grpTimKiem.Controls.Add(cboTimLoaiChi);
        grpTimKiem.Controls.Add(lblTuNgay);
        grpTimKiem.Controls.Add(dtpTuNgay);
        grpTimKiem.Controls.Add(lblDenNgay);
        grpTimKiem.Controls.Add(dtpDenNgay);
        grpTimKiem.Controls.Add(btnTim);
        grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        grpTimKiem.Location = new System.Drawing.Point(570, 12);
        grpTimKiem.Name = "grpTimKiem";
        grpTimKiem.Size = new System.Drawing.Size(370, 182);
        grpTimKiem.TabIndex = 1;
        grpTimKiem.TabStop = false;
        grpTimKiem.Text = "Tìm kiếm";

        // lblTimNoiDung
        lblTimNoiDung.AutoSize = true;
        lblTimNoiDung.Location = new System.Drawing.Point(15, 27);
        lblTimNoiDung.Name = "lblTimNoiDung";
        lblTimNoiDung.Size = new System.Drawing.Size(62, 17);
        lblTimNoiDung.TabIndex = 0;
        lblTimNoiDung.Text = "Nội dung";

        // txtTimNoiDung
        txtTimNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtTimNoiDung.Location = new System.Drawing.Point(85, 24);
        txtTimNoiDung.Name = "txtTimNoiDung";
        txtTimNoiDung.PlaceholderText = "Nhập nội dung...";
        txtTimNoiDung.Size = new System.Drawing.Size(265, 24);
        txtTimNoiDung.TabIndex = 1;

        // lblTimLoaiChi
        lblTimLoaiChi.AutoSize = true;
        lblTimLoaiChi.Location = new System.Drawing.Point(15, 59);
        lblTimLoaiChi.Name = "lblTimLoaiChi";
        lblTimLoaiChi.Size = new System.Drawing.Size(53, 17);
        lblTimLoaiChi.TabIndex = 2;
        lblTimLoaiChi.Text = "Loại chi";

        // cboTimLoaiChi
        cboTimLoaiChi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cboTimLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboTimLoaiChi.FormattingEnabled = true;
        cboTimLoaiChi.Items.AddRange(new object[] {
            "Tất cả",
            "Ăn uống",
            "Đi lại",
            "Học tập",
            "Giải trí",
            "Khác"
        });
        cboTimLoaiChi.Location = new System.Drawing.Point(85, 56);
        cboTimLoaiChi.Name = "cboTimLoaiChi";
        cboTimLoaiChi.Size = new System.Drawing.Size(265, 25);
        cboTimLoaiChi.TabIndex = 3;

        // lblTuNgay
        lblTuNgay.AutoSize = true;
        lblTuNgay.Location = new System.Drawing.Point(15, 93);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new System.Drawing.Size(55, 17);
        lblTuNgay.TabIndex = 4;
        lblTuNgay.Text = "Từ ngày";

        // dtpTuNgay
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new System.Drawing.Point(85, 90);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.Size = new System.Drawing.Size(140, 24);
        dtpTuNgay.TabIndex = 5;

        // lblDenNgay
        lblDenNgay.AutoSize = true;
        lblDenNgay.Location = new System.Drawing.Point(15, 127);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new System.Drawing.Size(63, 17);
        lblDenNgay.TabIndex = 6;
        lblDenNgay.Text = "Đến ngày";

        // dtpDenNgay
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpDenNgay.Location = new System.Drawing.Point(85, 124);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.Size = new System.Drawing.Size(140, 24);
        dtpDenNgay.TabIndex = 7;

        // btnTim
        btnTim.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnTim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnTim.Location = new System.Drawing.Point(245, 121);
        btnTim.Name = "btnTim";
        btnTim.Size = new System.Drawing.Size(105, 30);
        btnTim.TabIndex = 8;
        btnTim.Text = "Tìm";
        btnTim.UseVisualStyleBackColor = true;
        btnTim.Click += btnTim_Click;

        // 
        // btnThem
        // 
        btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(110, 203);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(90, 32);
        btnThem.TabIndex = 2;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnSua.Location = new System.Drawing.Point(212, 203);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(90, 32);
        btnSua.TabIndex = 3;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXoa.Location = new System.Drawing.Point(314, 203);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(90, 32);
        btnXoa.TabIndex = 4;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnLamMoi.Location = new System.Drawing.Point(416, 203);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(90, 32);
        btnLamMoi.TabIndex = 5;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // dgvDanhSach
        // 
        dgvDanhSach.AllowUserToAddRows = false;
        dgvDanhSach.AllowUserToDeleteRows = false;
        dgvDanhSach.AllowUserToResizeRows = false;
        dgvDanhSach.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
        dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colMa,
            colNgayChi,
            colNoiDung,
            colLoaiChi,
            colSoTien,
            colGhiChu
        });
        dgvDanhSach.Location = new System.Drawing.Point(16, 245);
        dgvDanhSach.MultiSelect = false;
        dgvDanhSach.Name = "dgvDanhSach";
        dgvDanhSach.ReadOnly = true;
        dgvDanhSach.RowHeadersWidth = 35;
        dgvDanhSach.RowTemplate.Height = 26;
        dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvDanhSach.Size = new System.Drawing.Size(924, 260);
        dgvDanhSach.TabIndex = 6;
        dgvDanhSach.CellClick += dgvDanhSach_CellClick;
        dgvDanhSach.CellFormatting += dgvDanhSach_CellFormatting;

        // colMa
        colMa.DataPropertyName = "MaCt";
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        colMa.DefaultCellStyle = dataGridViewCellStyle2;
        colMa.HeaderText = "Mã";
        colMa.Name = "colMa";
        colMa.ReadOnly = true;
        colMa.Width = 80;

        // colNgayChi
        colNgayChi.DataPropertyName = "NgayChi";
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        colNgayChi.DefaultCellStyle = dataGridViewCellStyle3;
        colNgayChi.HeaderText = "Ngày chi";
        colNgayChi.Name = "colNgayChi";
        colNgayChi.ReadOnly = true;
        colNgayChi.Width = 110;

        // colNoiDung
        colNoiDung.DataPropertyName = "NoiDung";
        colNoiDung.HeaderText = "Nội dung";
        colNoiDung.Name = "colNoiDung";
        colNoiDung.ReadOnly = true;
        colNoiDung.Width = 200;

        // colLoaiChi
        colLoaiChi.DataPropertyName = "LoaiChi";
        colLoaiChi.HeaderText = "Loại chi";
        colLoaiChi.Name = "colLoaiChi";
        colLoaiChi.ReadOnly = true;
        colLoaiChi.Width = 120;

        // colSoTien
        colSoTien.DataPropertyName = "SoTien";
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle4.Format = "N0";
        colSoTien.DefaultCellStyle = dataGridViewCellStyle4;
        colSoTien.HeaderText = "Số tiền";
        colSoTien.Name = "colSoTien";
        colSoTien.ReadOnly = true;
        colSoTien.Width = 120;

        // colGhiChu
        colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colGhiChu.DataPropertyName = "GhiChu";
        colGhiChu.HeaderText = "Ghi chú";
        colGhiChu.Name = "colGhiChu";
        colGhiChu.ReadOnly = true;

        // 
        // lblTongChi
        // 
        lblTongChi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        lblTongChi.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblTongChi.ForeColor = System.Drawing.Color.Red;
        lblTongChi.Location = new System.Drawing.Point(540, 515);
        lblTongChi.Name = "lblTongChi";
        lblTongChi.Size = new System.Drawing.Size(400, 32);
        lblTongChi.TabIndex = 7;
        lblTongChi.Text = "Tổng chi: 0 đ";
        lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // FormChiTieu
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(956, 555);
        Controls.Add(lblTongChi);
        Controls.Add(dgvDanhSach);
        Controls.Add(btnLamMoi);
        Controls.Add(btnXoa);
        Controls.Add(btnSua);
        Controls.Add(btnThem);
        Controls.Add(grpTimKiem);
        Controls.Add(grpThongTin);
        Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        MinimumSize = new System.Drawing.Size(900, 550);
        Name = "FormChiTieu";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Sổ chi tiêu cá nhân";
        Load += FormChiTieu_Load;

        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        grpTimKiem.ResumeLayout(false);
        grpTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numSoTien).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblNgayChi;
    private System.Windows.Forms.DateTimePicker dtpNgayChi;
    private System.Windows.Forms.Label lblNoiDung;
    private System.Windows.Forms.TextBox txtNoiDung;
    private System.Windows.Forms.Label lblLoaiChi;
    private System.Windows.Forms.ComboBox cboLoaiChi;
    private System.Windows.Forms.Label lblSoTien;
    private System.Windows.Forms.NumericUpDown numSoTien;
    private System.Windows.Forms.Label lblGhiChu;
    private System.Windows.Forms.TextBox txtGhiChu;

    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTimNoiDung;
    private System.Windows.Forms.TextBox txtTimNoiDung;
    private System.Windows.Forms.Label lblTimLoaiChi;
    private System.Windows.Forms.ComboBox cboTimLoaiChi;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Button btnTim;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.DataGridView dgvDanhSach;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNgayChi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiChi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
    private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;

    private System.Windows.Forms.Label lblTongChi;
}

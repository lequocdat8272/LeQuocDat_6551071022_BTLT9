namespace BanHangQuanTraSua
{
    partial class FormHoaDon
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDoanhThuNgay = new System.Windows.Forms.Label();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnHomNay = new System.Windows.Forms.Button();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocNgay = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhThucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colTenMonCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLyCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTienCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlTop.Controls.Add(this.lblDoanhThuNgay);
            this.pnlTop.Controls.Add(this.btnTatCa);
            this.pnlTop.Controls.Add(this.btnHomNay);
            this.pnlTop.Controls.Add(this.dtpNgay);
            this.pnlTop.Controls.Add(this.lblLocNgay);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblDoanhThuNgay
            // 
            this.lblDoanhThuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoanhThuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDoanhThuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(45)))));
            this.lblDoanhThuNgay.Location = new System.Drawing.Point(520, 15);
            this.lblDoanhThuNgay.Name = "lblDoanhThuNgay";
            this.lblDoanhThuNgay.Size = new System.Drawing.Size(450, 30);
            this.lblDoanhThuNgay.TabIndex = 4;
            this.lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";
            this.lblDoanhThuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.Location = new System.Drawing.Point(340, 16);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(90, 30);
            this.btnTatCa.TabIndex = 3;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // btnHomNay
            // 
            this.btnHomNay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnHomNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomNay.ForeColor = System.Drawing.Color.White;
            this.btnHomNay.Location = new System.Drawing.Point(240, 16);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(90, 30);
            this.btnHomNay.TabIndex = 2;
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.UseVisualStyleBackColor = false;
            this.btnHomNay.Click += new System.EventHandler(this.btnHomNay_Click);
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(100, 18);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(130, 24);
            this.dtpNgay.TabIndex = 1;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // lblLocNgay
            // 
            this.lblLocNgay.AutoSize = true;
            this.lblLocNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocNgay.Location = new System.Drawing.Point(15, 21);
            this.lblLocNgay.Name = "lblLocNgay";
            this.lblLocNgay.Size = new System.Drawing.Size(76, 17);
            this.lblLocNgay.TabIndex = 0;
            this.lblLocNgay.Text = "Chọn ngày:";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 60);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbHoaDon);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbChiTiet);
            this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.scMain.Size = new System.Drawing.Size(984, 460);
            this.scMain.SplitterDistance = 530;
            this.scMain.TabIndex = 1;
            // 
            // gbHoaDon
            // 
            this.gbHoaDon.Controls.Add(this.dgvHoaDon);
            this.gbHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbHoaDon.Location = new System.Drawing.Point(10, 10);
            this.gbHoaDon.Name = "gbHoaDon";
            this.gbHoaDon.Size = new System.Drawing.Size(510, 440);
            this.gbHoaDon.TabIndex = 0;
            this.gbHoaDon.TabStop = false;
            this.gbHoaDon.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.colNgayLap,
            this.colHinhThucTT,
            this.colDaThanhToan,
            this.colTongTien});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 20);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 30;
            this.dgvHoaDon.RowTemplate.Height = 28;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(504, 417);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
            // 
            // colMaHD
            // 
            this.colMaHD.DataPropertyName = "MaHd";
            this.colMaHD.FillWeight = 45F;
            this.colMaHD.HeaderText = "Mã HD";
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            // 
            // colNgayLap
            // 
            this.colNgayLap.DataPropertyName = "NgayLapStr";
            this.colNgayLap.FillWeight = 85F;
            this.colNgayLap.HeaderText = "Giờ lập";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.ReadOnly = true;
            // 
            // colHinhThucTT
            // 
            this.colHinhThucTT.DataPropertyName = "HinhThucTt";
            this.colHinhThucTT.FillWeight = 75F;
            this.colHinhThucTT.HeaderText = "Hình thức";
            this.colHinhThucTT.Name = "colHinhThucTT";
            this.colHinhThucTT.ReadOnly = true;
            // 
            // colDaThanhToan
            // 
            this.colDaThanhToan.DataPropertyName = "TrangThaiTT";
            this.colDaThanhToan.FillWeight = 75F;
            this.colDaThanhToan.HeaderText = "Trạng thái";
            this.colDaThanhToan.Name = "colDaThanhToan";
            this.colDaThanhToan.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTienStr";
            this.colTongTien.FillWeight = 75F;
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.dgvChiTiet);
            this.gbChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbChiTiet.Location = new System.Drawing.Point(10, 10);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(430, 440);
            this.gbChiTiet.TabIndex = 0;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết các món";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMonCT,
            this.colSoLyCT,
            this.colDonGiaCT,
            this.colThanhTienCT});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(3, 20);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 30;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(424, 417);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colTenMonCT
            // 
            this.colTenMonCT.DataPropertyName = "TenMon";
            this.colTenMonCT.FillWeight = 110F;
            this.colTenMonCT.HeaderText = "Tên món";
            this.colTenMonCT.Name = "colTenMonCT";
            this.colTenMonCT.ReadOnly = true;
            // 
            // colSoLyCT
            // 
            this.colSoLyCT.DataPropertyName = "SoLy";
            this.colSoLyCT.FillWeight = 40F;
            this.colSoLyCT.HeaderText = "SL";
            this.colSoLyCT.Name = "colSoLyCT";
            this.colSoLyCT.ReadOnly = true;
            // 
            // colDonGiaCT
            // 
            this.colDonGiaCT.DataPropertyName = "DonGiaStr";
            this.colDonGiaCT.FillWeight = 70F;
            this.colDonGiaCT.HeaderText = "Đơn giá";
            this.colDonGiaCT.Name = "colDonGiaCT";
            this.colDonGiaCT.ReadOnly = true;
            // 
            // colThanhTienCT
            // 
            this.colThanhTienCT.DataPropertyName = "ThanhTienStr";
            this.colThanhTienCT.FillWeight = 75F;
            this.colThanhTienCT.HeaderText = "Thành tiền";
            this.colThanhTienCT.Name = "colThanhTienCT";
            this.colThanhTienCT.ReadOnly = true;
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 520);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách hóa đơn & Doanh thu";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.gbChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblLocNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnHomNay;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Label lblDoanhThuNgay;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHinhThucTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMonCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLyCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTienCT;
    }
}

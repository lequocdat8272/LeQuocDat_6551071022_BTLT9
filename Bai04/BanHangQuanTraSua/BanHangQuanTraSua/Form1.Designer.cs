namespace BanHangQuanTraSua
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuThucDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiLai = new System.Windows.Forms.ToolStripMenuItem();
            this.gbChonMon = new System.Windows.Forms.GroupBox();
            this.btnThemVaoDon = new System.Windows.Forms.Button();
            this.numSoLy = new System.Windows.Forms.NumericUpDown();
            this.lblSoLy = new System.Windows.Forms.Label();
            this.lstMonUong = new System.Windows.Forms.ListBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.gbDonHienTai = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.btnDaNhanTien = new System.Windows.Forms.Button();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnTienMat = new System.Windows.Forms.Button();
            this.btnThanhToanChuyenKhoan = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gbChonMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).BeginInit();
            this.gbDonHienTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.gbThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThucDon,
            this.mnuHoaDon,
            this.mnuTaiLai});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuThucDon
            // 
            this.mnuThucDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuThucDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.mnuThucDon.Name = "mnuThucDon";
            this.mnuThucDon.Size = new System.Drawing.Size(126, 21);
            this.mnuThucDon.Text = "Quản lý thực đơn";
            this.mnuThucDon.Click += new System.EventHandler(this.mnuThucDon_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(207, 21);
            this.mnuHoaDon.Text = "Danh sách hóa đơn & Doanh thu";
            this.mnuHoaDon.Click += new System.EventHandler(this.mnuHoaDon_Click);
            // 
            // mnuTaiLai
            // 
            this.mnuTaiLai.Name = "mnuTaiLai";
            this.mnuTaiLai.Size = new System.Drawing.Size(117, 21);
            this.mnuTaiLai.Text = "Tải lại thực đơn";
            this.mnuTaiLai.Click += new System.EventHandler(this.mnuTaiLai_Click);
            // 
            // gbChonMon
            // 
            this.gbChonMon.Controls.Add(this.btnThemVaoDon);
            this.gbChonMon.Controls.Add(this.numSoLy);
            this.gbChonMon.Controls.Add(this.lblSoLy);
            this.gbChonMon.Controls.Add(this.lstMonUong);
            this.gbChonMon.Controls.Add(this.cboDanhMuc);
            this.gbChonMon.Controls.Add(this.lblDanhMuc);
            this.gbChonMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbChonMon.Location = new System.Drawing.Point(12, 33);
            this.gbChonMon.Name = "gbChonMon";
            this.gbChonMon.Size = new System.Drawing.Size(210, 485);
            this.gbChonMon.TabIndex = 1;
            this.gbChonMon.TabStop = false;
            this.gbChonMon.Text = "Chọn món";
            // 
            // btnThemVaoDon
            // 
            this.btnThemVaoDon.BackColor = System.Drawing.Color.White;
            this.btnThemVaoDon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThemVaoDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThemVaoDon.Location = new System.Drawing.Point(15, 430);
            this.btnThemVaoDon.Name = "btnThemVaoDon";
            this.btnThemVaoDon.Size = new System.Drawing.Size(180, 36);
            this.btnThemVaoDon.TabIndex = 5;
            this.btnThemVaoDon.Text = "Thêm vào đơn";
            this.btnThemVaoDon.UseVisualStyleBackColor = false;
            this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);
            // 
            // numSoLy
            // 
            this.numSoLy.Location = new System.Drawing.Point(75, 385);
            this.numSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLy.Name = "numSoLy";
            this.numSoLy.Size = new System.Drawing.Size(120, 24);
            this.numSoLy.TabIndex = 4;
            this.numSoLy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSoLy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLy
            // 
            this.lblSoLy.AutoSize = true;
            this.lblSoLy.Location = new System.Drawing.Point(15, 387);
            this.lblSoLy.Name = "lblSoLy";
            this.lblSoLy.Size = new System.Drawing.Size(40, 17);
            this.lblSoLy.TabIndex = 3;
            this.lblSoLy.Text = "Số ly:";
            // 
            // lstMonUong
            // 
            this.lstMonUong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstMonUong.FormattingEnabled = true;
            this.lstMonUong.ItemHeight = 17;
            this.lstMonUong.Location = new System.Drawing.Point(15, 80);
            this.lstMonUong.Name = "lstMonUong";
            this.lstMonUong.Size = new System.Drawing.Size(180, 293);
            this.lstMonUong.TabIndex = 2;
            this.lstMonUong.DoubleClick += new System.EventHandler(this.lstMonUong_DoubleClick);
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(15, 45);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(180, 24);
            this.cboDanhMuc.TabIndex = 1;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(15, 25);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(70, 17);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // gbDonHienTai
            // 
            this.gbDonHienTai.Controls.Add(this.lblTongTien);
            this.gbDonHienTai.Controls.Add(this.btnXoaDong);
            this.gbDonHienTai.Controls.Add(this.dgvDonHang);
            this.gbDonHienTai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbDonHienTai.Location = new System.Drawing.Point(232, 33);
            this.gbDonHienTai.Name = "gbDonHienTai";
            this.gbDonHienTai.Size = new System.Drawing.Size(370, 485);
            this.gbDonHienTai.TabIndex = 2;
            this.gbDonHienTai.TabStop = false;
            this.gbDonHienTai.Text = "Đơn hiện tại";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTien.Location = new System.Drawing.Point(15, 425);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(340, 45);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.White;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXoaDong.Location = new System.Drawing.Point(15, 380);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(340, 32);
            this.btnXoaDong.TabIndex = 1;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToDeleteRows = false;
            this.dgvDonHang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenMon,
            this.colSoLy,
            this.colDonGia,
            this.colThanhTien});
            this.dgvDonHang.Location = new System.Drawing.Point(15, 25);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersWidth = 25;
            this.dgvDonHang.RowTemplate.Height = 26;
            this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHang.Size = new System.Drawing.Size(340, 345);
            this.dgvDonHang.TabIndex = 0;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            this.colTenMon.Width = 120;
            // 
            // colSoLy
            // 
            this.colSoLy.DataPropertyName = "SoLy";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLy.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSoLy.HeaderText = "SL";
            this.colSoLy.Name = "colSoLy";
            this.colSoLy.ReadOnly = true;
            this.colSoLy.Width = 38;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGiaStr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 73;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTienStr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 84;
            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Controls.Add(this.btnDaNhanTien);
            this.gbThanhToan.Controls.Add(this.lblNoiDung);
            this.gbThanhToan.Controls.Add(this.lblSoTien);
            this.gbThanhToan.Controls.Add(this.picQR);
            this.gbThanhToan.Controls.Add(this.btnTienMat);
            this.gbThanhToan.Controls.Add(this.btnThanhToanChuyenKhoan);
            this.gbThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbThanhToan.Location = new System.Drawing.Point(612, 33);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(240, 485);
            this.gbThanhToan.TabIndex = 3;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thanh toán";
            // 
            // btnDaNhanTien
            // 
            this.btnDaNhanTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(45)))));
            this.btnDaNhanTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaNhanTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDaNhanTien.ForeColor = System.Drawing.Color.White;
            this.btnDaNhanTien.Location = new System.Drawing.Point(15, 428);
            this.btnDaNhanTien.Name = "btnDaNhanTien";
            this.btnDaNhanTien.Size = new System.Drawing.Size(210, 40);
            this.btnDaNhanTien.TabIndex = 5;
            this.btnDaNhanTien.Text = "Đã nhận tiền";
            this.btnDaNhanTien.UseVisualStyleBackColor = false;
            this.btnDaNhanTien.Click += new System.EventHandler(this.btnDaNhanTien_Click);
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoiDung.Location = new System.Drawing.Point(15, 385);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(210, 30);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "Nội dung: ";
            // 
            // lblSoTien
            // 
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoTien.Location = new System.Drawing.Point(15, 355);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(210, 25);
            this.lblSoTien.TabIndex = 3;
            this.lblSoTien.Text = "Số tiền:    0 đ";
            // 
            // picQR
            // 
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(15, 110);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(210, 235);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 2;
            this.picQR.TabStop = false;
            // 
            // btnTienMat
            // 
            this.btnTienMat.BackColor = System.Drawing.Color.White;
            this.btnTienMat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTienMat.Location = new System.Drawing.Point(15, 68);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(210, 32);
            this.btnTienMat.TabIndex = 1;
            this.btnTienMat.Text = "Tiền mặt";
            this.btnTienMat.UseVisualStyleBackColor = false;
            this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);
            // 
            // btnThanhToanChuyenKhoan
            // 
            this.btnThanhToanChuyenKhoan.BackColor = System.Drawing.Color.White;
            this.btnThanhToanChuyenKhoan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThanhToanChuyenKhoan.Location = new System.Drawing.Point(15, 25);
            this.btnThanhToanChuyenKhoan.Name = "btnThanhToanChuyenKhoan";
            this.btnThanhToanChuyenKhoan.Size = new System.Drawing.Size(210, 34);
            this.btnThanhToanChuyenKhoan.TabIndex = 0;
            this.btnThanhToanChuyenKhoan.Text = "Thanh toán chuyển khoản";
            this.btnThanhToanChuyenKhoan.UseVisualStyleBackColor = false;
            this.btnThanhToanChuyenKhoan.Click += new System.EventHandler(this.btnThanhToanChuyenKhoan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(864, 528);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.gbDonHienTai);
            this.Controls.Add(this.gbChonMon);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng - Quán trà sữa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbChonMon.ResumeLayout(false);
            this.gbChonMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).EndInit();
            this.gbDonHienTai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.gbThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuThucDon;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiLai;
        private System.Windows.Forms.GroupBox gbChonMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.ListBox lstMonUong;
        private System.Windows.Forms.Label lblSoLy;
        private System.Windows.Forms.NumericUpDown numSoLy;
        private System.Windows.Forms.Button btnThemVaoDon;
        private System.Windows.Forms.GroupBox gbDonHienTai;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Button btnThanhToanChuyenKhoan;
        private System.Windows.Forms.Button btnTienMat;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Button btnDaNhanTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}

namespace BanHangQuanTraSua
{
    partial class FormThucDon
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
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.numGiaBan = new System.Windows.Forms.NumericUpDown();
            this.chkDangBan = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocDM = new System.Windows.Forms.Label();
            this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.dgvMonUong = new System.Windows.Forms.DataGridView();
            this.colMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDangBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
            this.gbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonUong)).BeginInit();
            this.SuspendLayout();
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Controls.Add(this.chkDangBan);
            this.gbThongTin.Controls.Add(this.numGiaBan);
            this.gbThongTin.Controls.Add(this.lblGiaBan);
            this.gbThongTin.Controls.Add(this.cboDanhMuc);
            this.gbThongTin.Controls.Add(this.lblDanhMuc);
            this.gbThongTin.Controls.Add(this.txtTenMon);
            this.gbThongTin.Controls.Add(this.lblTenMon);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbThongTin.Location = new System.Drawing.Point(12, 12);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(340, 480);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin món uống";
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(15, 30);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(61, 17);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Tên món:";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(18, 52);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(305, 24);
            this.txtTenMon.TabIndex = 1;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(15, 90);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(70, 17);
            this.lblDanhMuc.TabIndex = 2;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(18, 112);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(305, 24);
            this.cboDanhMuc.TabIndex = 3;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(15, 150);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(79, 17);
            this.lblGiaBan.TabIndex = 4;
            this.lblGiaBan.Text = "Giá bán (đ):";
            // 
            // numGiaBan
            // 
            this.numGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numGiaBan.Location = new System.Drawing.Point(18, 172);
            this.numGiaBan.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numGiaBan.Name = "numGiaBan";
            this.numGiaBan.Size = new System.Drawing.Size(305, 24);
            this.numGiaBan.TabIndex = 5;
            this.numGiaBan.ThousandsSeparator = true;
            this.numGiaBan.Value = new decimal(new int[] { 30000, 0, 0, 0 });
            // 
            // chkDangBan
            // 
            this.chkDangBan.AutoSize = true;
            this.chkDangBan.Checked = true;
            this.chkDangBan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDangBan.Location = new System.Drawing.Point(18, 215);
            this.chkDangBan.Name = "chkDangBan";
            this.chkDangBan.Size = new System.Drawing.Size(84, 21);
            this.chkDangBan.TabIndex = 6;
            this.chkDangBan.Text = "Đang bán";
            this.chkDangBan.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.Location = new System.Drawing.Point(18, 260);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(145, 36);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm món";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.Location = new System.Drawing.Point(178, 260);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(145, 36);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa món";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.Location = new System.Drawing.Point(18, 310);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(145, 36);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.Location = new System.Drawing.Point(178, 310);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(145, 36);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTimKiem.Controls.Add(this.cboLocDanhMuc);
            this.gbTimKiem.Controls.Add(this.lblLocDM);
            this.gbTimKiem.Controls.Add(this.txtTimKiem);
            this.gbTimKiem.Controls.Add(this.lblTimKiem);
            this.gbTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTimKiem.Location = new System.Drawing.Point(365, 12);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(565, 75);
            this.gbTimKiem.TabIndex = 1;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm & Lọc";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(15, 30);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(61, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tên món:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(82, 27);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên món cần tìm...";
            this.txtTimKiem.Size = new System.Drawing.Size(190, 24);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblLocDM
            // 
            this.lblLocDM.AutoSize = true;
            this.lblLocDM.Location = new System.Drawing.Point(285, 30);
            this.lblLocDM.Name = "lblLocDM";
            this.lblLocDM.Size = new System.Drawing.Size(70, 17);
            this.lblLocDM.TabIndex = 2;
            this.lblLocDM.Text = "Danh mục:";
            // 
            // cboLocDanhMuc
            // 
            this.cboLocDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDanhMuc.FormattingEnabled = true;
            this.cboLocDanhMuc.Location = new System.Drawing.Point(360, 27);
            this.cboLocDanhMuc.Name = "cboLocDanhMuc";
            this.cboLocDanhMuc.Size = new System.Drawing.Size(190, 24);
            this.cboLocDanhMuc.TabIndex = 3;
            this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboLocDanhMuc_SelectedIndexChanged);
            // 
            // dgvMonUong
            // 
            this.dgvMonUong.AllowUserToAddRows = false;
            this.dgvMonUong.AllowUserToDeleteRows = false;
            this.dgvMonUong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonUong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonUong.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonUong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMon,
            this.colTenMon,
            this.colTenDM,
            this.colGiaBan,
            this.colDangBan});
            this.dgvMonUong.Location = new System.Drawing.Point(365, 95);
            this.dgvMonUong.MultiSelect = false;
            this.dgvMonUong.Name = "dgvMonUong";
            this.dgvMonUong.ReadOnly = true;
            this.dgvMonUong.RowHeadersWidth = 30;
            this.dgvMonUong.RowTemplate.Height = 28;
            this.dgvMonUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonUong.Size = new System.Drawing.Size(565, 397);
            this.dgvMonUong.TabIndex = 2;
            this.dgvMonUong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonUong_CellClick);
            // 
            // colMaMon
            // 
            this.colMaMon.DataPropertyName = "MaMon";
            this.colMaMon.FillWeight = 40F;
            this.colMaMon.HeaderText = "Mã";
            this.colMaMon.Name = "colMaMon";
            this.colMaMon.ReadOnly = true;
            // 
            // colTenMon
            // 
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.FillWeight = 110F;
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colTenDM
            // 
            this.colTenDM.DataPropertyName = "TenDM";
            this.colTenDM.FillWeight = 80F;
            this.colTenDM.HeaderText = "Danh mục";
            this.colTenDM.Name = "colTenDM";
            this.colTenDM.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "GiaBanStr";
            this.colGiaBan.FillWeight = 70F;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colDangBan
            // 
            this.colDangBan.DataPropertyName = "TrangThai";
            this.colDangBan.FillWeight = 60F;
            this.colDangBan.HeaderText = "Trạng thái";
            this.colDangBan.Name = "colDangBan";
            this.colDangBan.ReadOnly = true;
            // 
            // FormThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 504);
            this.Controls.Add(this.dgvMonUong);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.gbThongTin);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý thực đơn - Quán trà sữa";
            this.Load += new System.EventHandler(this.FormThucDon_Load);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonUong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.NumericUpDown numGiaBan;
        private System.Windows.Forms.CheckBox chkDangBan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocDM;
        private System.Windows.Forms.ComboBox cboLocDanhMuc;
        private System.Windows.Forms.DataGridView dgvMonUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDangBan;
    }
}

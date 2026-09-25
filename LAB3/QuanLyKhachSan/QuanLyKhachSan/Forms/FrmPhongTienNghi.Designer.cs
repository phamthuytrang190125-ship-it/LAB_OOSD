namespace QuanLyKhachSan
{
    partial class FrmPhongTienNghi
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
            this.tabPhongTienNghi = new System.Windows.Forms.TabControl();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.tabTienNghi = new System.Windows.Forms.TabPage();
            this.tabLapDat = new System.Windows.Forms.TabPage();

            this.lblSoPhong = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();

            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.txtKhuVuc = new System.Windows.Forms.TextBox();

            this.lblSucChua = new System.Windows.Forms.Label();
            this.txtSucChua = new System.Windows.Forms.TextBox();

            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();

            this.btnThemPhong = new System.Windows.Forms.Button();
            this.btnCapNhatPhong = new System.Windows.Forms.Button();
            this.btnXoaPhong = new System.Windows.Forms.Button();
            this.btnLamMoiPhong = new System.Windows.Forms.Button();

            this.dgvPhong = new System.Windows.Forms.DataGridView();

            this.lblPhieuLapDat = new System.Windows.Forms.Label();
            this.txtSoPhieuLapDat = new System.Windows.Forms.TextBox();

            this.lblMaTienNghi = new System.Windows.Forms.Label();
            this.txtMaTienNghi = new System.Windows.Forms.TextBox();

            this.lblPhongLapDat = new System.Windows.Forms.Label();
            this.txtPhongLapDat = new System.Windows.Forms.TextBox();

            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();

            this.btnLapPhieu = new System.Windows.Forms.Button();

            this.tabPhongTienNghi.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();

            // 
            // tabPhongTienNghi
            // 
            this.tabPhongTienNghi.Controls.Add(this.tabPhong);
            this.tabPhongTienNghi.Controls.Add(this.tabTienNghi);
            this.tabPhongTienNghi.Controls.Add(this.tabLapDat);
            this.tabPhongTienNghi.Location = new System.Drawing.Point(12, 12);
            this.tabPhongTienNghi.Name = "tabPhongTienNghi";
            this.tabPhongTienNghi.SelectedIndex = 0;
            this.tabPhongTienNghi.Size = new System.Drawing.Size(980, 570);
            this.tabPhongTienNghi.TabIndex = 0;

            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.lblSoPhong);
            this.tabPhong.Controls.Add(this.txtSoPhong);
            this.tabPhong.Controls.Add(this.lblKhuVuc);
            this.tabPhong.Controls.Add(this.txtKhuVuc);
            this.tabPhong.Controls.Add(this.lblSucChua);
            this.tabPhong.Controls.Add(this.txtSucChua);
            this.tabPhong.Controls.Add(this.lblDonGia);
            this.tabPhong.Controls.Add(this.txtDonGia);
            this.tabPhong.Controls.Add(this.btnThemPhong);
            this.tabPhong.Controls.Add(this.btnCapNhatPhong);
            this.tabPhong.Controls.Add(this.btnXoaPhong);
            this.tabPhong.Controls.Add(this.btnLamMoiPhong);
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Controls.Add(this.lblPhieuLapDat);
            this.tabPhong.Controls.Add(this.txtSoPhieuLapDat);
            this.tabPhong.Controls.Add(this.lblMaTienNghi);
            this.tabPhong.Controls.Add(this.txtMaTienNghi);
            this.tabPhong.Controls.Add(this.lblPhongLapDat);
            this.tabPhong.Controls.Add(this.txtPhongLapDat);
            this.tabPhong.Controls.Add(this.lblTinhTrang);
            this.tabPhong.Controls.Add(this.txtTinhTrang);
            this.tabPhong.Controls.Add(this.btnLapPhieu);
            this.tabPhong.Location = new System.Drawing.Point(4, 29);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(972, 537);
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Text = "Phòng";
            this.tabPhong.UseVisualStyleBackColor = true;

            // 
            // tabTienNghi
            // 
            this.tabTienNghi.Location = new System.Drawing.Point(4, 29);
            this.tabTienNghi.Name = "tabTienNghi";
            this.tabTienNghi.Padding = new System.Windows.Forms.Padding(3);
            this.tabTienNghi.Size = new System.Drawing.Size(972, 537);
            this.tabTienNghi.TabIndex = 1;
            this.tabTienNghi.Text = "Tiện nghi";
            this.tabTienNghi.UseVisualStyleBackColor = true;

            // 
            // tabLapDat
            // 
            this.tabLapDat.Location = new System.Drawing.Point(4, 29);
            this.tabLapDat.Name = "tabLapDat";
            this.tabLapDat.Padding = new System.Windows.Forms.Padding(3);
            this.tabLapDat.Size = new System.Drawing.Size(972, 537);
            this.tabLapDat.TabIndex = 2;
            this.tabLapDat.Text = "Lắp đặt / luân chuyển";
            this.tabLapDat.UseVisualStyleBackColor = true;

            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Location = new System.Drawing.Point(25, 45);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(75, 20);
            this.lblSoPhong.Text = "Số phòng:";

            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(110, 42);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(125, 26);

            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Location = new System.Drawing.Point(260, 45);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(68, 20);
            this.lblKhuVuc.Text = "Khu vực:";

            // 
            // txtKhuVuc
            // 
            this.txtKhuVuc.Location = new System.Drawing.Point(335, 42);
            this.txtKhuVuc.Name = "txtKhuVuc";
            this.txtKhuVuc.Size = new System.Drawing.Size(130, 26);

            // 
            // lblSucChua
            // 
            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Location = new System.Drawing.Point(490, 45);
            this.lblSucChua.Name = "lblSucChua";
            this.lblSucChua.Size = new System.Drawing.Size(102, 20);
            this.lblSucChua.Text = "Số người tối đa:";

            // 
            // txtSucChua
            // 
            this.txtSucChua.Location = new System.Drawing.Point(600, 42);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size(80, 26);

            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(700, 45);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(85, 20);
            this.lblDonGia.Text = "Đơn giá/ngày:";

            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(790, 42);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(140, 26);

            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(25, 85);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(90, 35);
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);

            // 
            // btnCapNhatPhong
            // 
            this.btnCapNhatPhong.Location = new System.Drawing.Point(125, 85);
            this.btnCapNhatPhong.Name = "btnCapNhatPhong";
            this.btnCapNhatPhong.Size = new System.Drawing.Size(100, 35);
            this.btnCapNhatPhong.Text = "Cập nhật";
            this.btnCapNhatPhong.UseVisualStyleBackColor = true;
            this.btnCapNhatPhong.Click += new System.EventHandler(this.btnCapNhatPhong_Click);

            // 
            // btnXoaPhong
            // 
            this.btnXoaPhong.Location = new System.Drawing.Point(235, 85);
            this.btnXoaPhong.Name = "btnXoaPhong";
            this.btnXoaPhong.Size = new System.Drawing.Size(90, 35);
            this.btnXoaPhong.Text = "Xóa";
            this.btnXoaPhong.UseVisualStyleBackColor = true;
            this.btnXoaPhong.Click += new System.EventHandler(this.btnXoaPhong_Click);

            // 
            // btnLamMoiPhong
            // 
            this.btnLamMoiPhong.Location = new System.Drawing.Point(335, 85);
            this.btnLamMoiPhong.Name = "btnLamMoiPhong";
            this.btnLamMoiPhong.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoiPhong.Text = "Làm mới";
            this.btnLamMoiPhong.UseVisualStyleBackColor = true;
            this.btnLamMoiPhong.Click += new System.EventHandler(this.btnLamMoiPhong_Click);

            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(25, 135);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowTemplate.Height = 32;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(905, 270);
            this.dgvPhong.TabIndex = 10;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);

            // 
            // lblPhieuLapDat
            // 
            this.lblPhieuLapDat.AutoSize = true;
            this.lblPhieuLapDat.Location = new System.Drawing.Point(25, 430);
            this.lblPhieuLapDat.Name = "lblPhieuLapDat";
            this.lblPhieuLapDat.Size = new System.Drawing.Size(85, 20);
            this.lblPhieuLapDat.Text = "Phiếu lắp đặt:";

            // 
            // txtSoPhieuLapDat
            // 
            this.txtSoPhieuLapDat.Location = new System.Drawing.Point(120, 427);
            this.txtSoPhieuLapDat.Name = "txtSoPhieuLapDat";
            this.txtSoPhieuLapDat.Size = new System.Drawing.Size(115, 26);

            // 
            // lblMaTienNghi
            // 
            this.lblMaTienNghi.AutoSize = true;
            this.lblMaTienNghi.Location = new System.Drawing.Point(255, 430);
            this.lblMaTienNghi.Name = "lblMaTienNghi";
            this.lblMaTienNghi.Size = new System.Drawing.Size(75, 20);
            this.lblMaTienNghi.Text = "Tiện nghi:";

            // 
            // txtMaTienNghi
            // 
            this.txtMaTienNghi.Location = new System.Drawing.Point(335, 427);
            this.txtMaTienNghi.Name = "txtMaTienNghi";
            this.txtMaTienNghi.Size = new System.Drawing.Size(100, 26);

            // 
            // lblPhongLapDat
            // 
            this.lblPhongLapDat.AutoSize = true;
            this.lblPhongLapDat.Location = new System.Drawing.Point(455, 430);
            this.lblPhongLapDat.Name = "lblPhongLapDat";
            this.lblPhongLapDat.Size = new System.Drawing.Size(55, 20);
            this.lblPhongLapDat.Text = "Phòng:";

            // 
            // txtPhongLapDat
            // 
            this.txtPhongLapDat.Location = new System.Drawing.Point(515, 427);
            this.txtPhongLapDat.Name = "txtPhongLapDat";
            this.txtPhongLapDat.Size = new System.Drawing.Size(100, 26);

            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(635, 430);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(75, 20);
            this.lblTinhTrang.Text = "Tình trạng:";

            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(715, 427);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(100, 26);

            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(810, 470);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(120, 35);
            this.btnLapPhieu.Text = "Lập phiếu";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);

            // 
            // FrmPhongTienNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 600);
            this.Controls.Add(this.tabPhongTienNghi);
            this.Name = "FrmPhongTienNghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng - Tiện nghi - Phiếu lắp đặt";
            this.Load += new System.EventHandler(this.FrmPhongTienNghi_Load);

            this.tabPhongTienNghi.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabPhongTienNghi;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.TabPage tabTienNghi;
        private System.Windows.Forms.TabPage tabLapDat;

        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.TextBox txtKhuVuc;
        private System.Windows.Forms.Label lblSucChua;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;

        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnCapNhatPhong;
        private System.Windows.Forms.Button btnXoaPhong;
        private System.Windows.Forms.Button btnLamMoiPhong;

        private System.Windows.Forms.DataGridView dgvPhong;

        private System.Windows.Forms.Label lblPhieuLapDat;
        private System.Windows.Forms.TextBox txtSoPhieuLapDat;
        private System.Windows.Forms.Label lblMaTienNghi;
        private System.Windows.Forms.TextBox txtMaTienNghi;
        private System.Windows.Forms.Label lblPhongLapDat;
        private System.Windows.Forms.TextBox txtPhongLapDat;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Button btnLapPhieu;
    }
}
namespace QuanLyKhachSan
{
    partial class FrmDatPhong
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
            this.tabDatPhong = new System.Windows.Forms.TabControl();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.tabDatPhongPage = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblKhach = new System.Windows.Forms.Label();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.lblKenhDat = new System.Windows.Forms.Label();
            this.cboKenh = new System.Windows.Forms.ComboBox();
            this.lblTienCoc = new System.Windows.Forms.Label();
            this.numCoc = new System.Windows.Forms.NumericUpDown();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.lblDanhSachPhieu = new System.Windows.Forms.Label();
            this.tabNhanPhong = new System.Windows.Forms.TabPage();
            this.btnThemKhach = new System.Windows.Forms.Button();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnNhanPhong = new System.Windows.Forms.Button();
            this.btnNoShow = new System.Windows.Forms.Button();
            this.btnThemNguoi = new System.Windows.Forms.Button();
            this.txtPhieuChon = new System.Windows.Forms.TextBox();
            this.txtNguoiPhong = new System.Windows.Forms.TextBox();
            this.txtNguoiTen = new System.Windows.Forms.TextBox();
            this.txtNguoiCMND = new System.Windows.Forms.TextBox();
            this.txtNguoiQT = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabDatPhong.SuspendLayout();
            this.tabDatPhongPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDatPhong
            // 
            this.tabDatPhong.Controls.Add(this.tabKhachHang);
            this.tabDatPhong.Controls.Add(this.tabDatPhongPage);
            this.tabDatPhong.Controls.Add(this.tabNhanPhong);
            this.tabDatPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabDatPhong.Location = new System.Drawing.Point(0, 0);
            this.tabDatPhong.Name = "tabDatPhong";
            this.tabDatPhong.SelectedIndex = 1;
            this.tabDatPhong.Size = new System.Drawing.Size(1184, 799);
            this.tabDatPhong.TabIndex = 0;
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.Location = new System.Drawing.Point(8, 43);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Size = new System.Drawing.Size(1168, 748);
            this.tabKhachHang.TabIndex = 0;
            this.tabKhachHang.Text = "[ Khách hàng ]";
            this.tabKhachHang.Click += new System.EventHandler(this.tabKhachHang_Click);
            // 
            // tabDatPhongPage
            // 
            this.tabDatPhongPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDatPhongPage.Controls.Add(this.dataGridView3);
            this.tabDatPhongPage.Controls.Add(this.dataGridView2);
            this.tabDatPhongPage.Controls.Add(this.dataGridView1);
            this.tabDatPhongPage.Controls.Add(this.lblSoPhieu);
            this.tabDatPhongPage.Controls.Add(this.txtSoPhieu);
            this.tabDatPhongPage.Controls.Add(this.lblKhach);
            this.tabDatPhongPage.Controls.Add(this.cboKhach);
            this.tabDatPhongPage.Controls.Add(this.lblKenhDat);
            this.tabDatPhongPage.Controls.Add(this.cboKenh);
            this.tabDatPhongPage.Controls.Add(this.lblTienCoc);
            this.tabDatPhongPage.Controls.Add(this.numCoc);
            this.tabDatPhongPage.Controls.Add(this.btnLapPhieu);
            this.tabDatPhongPage.Controls.Add(this.lblDanhSachPhieu);
            this.tabDatPhongPage.Location = new System.Drawing.Point(8, 43);
            this.tabDatPhongPage.Name = "tabDatPhongPage";
            this.tabDatPhongPage.Size = new System.Drawing.Size(1168, 748);
            this.tabDatPhongPage.TabIndex = 1;
            this.tabDatPhongPage.Text = "[ Đặt phòng ]";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dataGridView3.Location = new System.Drawing.Point(21, 463);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 82;
            this.dataGridView3.RowTemplate.Height = 33;
            this.dataGridView3.Size = new System.Drawing.Size(1120, 221);
            this.dataGridView3.TabIndex = 21;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Số phiếu";
            this.Column8.MinimumWidth = 10;
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Khách";
            this.Column9.MinimumWidth = 10;
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Ngày nhận";
            this.Column10.MinimumWidth = 10;
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Ngày trả dự kiến";
            this.Column11.MinimumWidth = 10;
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Cọc";
            this.Column12.MinimumWidth = 10;
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Kênh";
            this.Column13.MinimumWidth = 10;
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Trạng thái";
            this.Column14.MinimumWidth = 10;
            this.Column14.Name = "Column14";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(641, 129);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(500, 193);
            this.dataGridView2.TabIndex = 20;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Phòng chọn";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Số người";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Đơn giá/ ngày";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(25, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(541, 193);
            this.dataGridView1.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Phòng";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Khu";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sức chứa";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đơn giá";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(20, 20);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(154, 29);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số phiếu đặt:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(184, 17);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(100, 35);
            this.txtSoPhieu.TabIndex = 1;
            this.txtSoPhieu.Text = "DP001";
            // 
            // lblKhach
            // 
            this.lblKhach.AutoSize = true;
            this.lblKhach.Location = new System.Drawing.Point(334, 20);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(86, 29);
            this.lblKhach.TabIndex = 2;
            this.lblKhach.Text = "Khách:";
            // 
            // cboKhach
            // 
            this.cboKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhach.Location = new System.Drawing.Point(445, 15);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(150, 37);
            this.cboKhach.TabIndex = 3;
            // 
            // lblKenhDat
            // 
            this.lblKenhDat.AutoSize = true;
            this.lblKenhDat.Location = new System.Drawing.Point(622, 21);
            this.lblKenhDat.Name = "lblKenhDat";
            this.lblKenhDat.Size = new System.Drawing.Size(114, 29);
            this.lblKenhDat.TabIndex = 4;
            this.lblKenhDat.Text = "Kênh đặt:";
            // 
            // cboKenh
            // 
            this.cboKenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKenh.Location = new System.Drawing.Point(742, 17);
            this.cboKenh.Name = "cboKenh";
            this.cboKenh.Size = new System.Drawing.Size(120, 37);
            this.cboKenh.TabIndex = 5;
            // 
            // lblTienCoc
            // 
            this.lblTienCoc.AutoSize = true;
            this.lblTienCoc.Location = new System.Drawing.Point(891, 21);
            this.lblTienCoc.Name = "lblTienCoc";
            this.lblTienCoc.Size = new System.Drawing.Size(112, 29);
            this.lblTienCoc.TabIndex = 6;
            this.lblTienCoc.Text = "Tiền cọc:";
            // 
            // numCoc
            // 
            this.numCoc.Location = new System.Drawing.Point(1009, 20);
            this.numCoc.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numCoc.Name = "numCoc";
            this.numCoc.Size = new System.Drawing.Size(120, 35);
            this.numCoc.TabIndex = 7;
            this.numCoc.Value = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(883, 355);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(226, 49);
            this.btnLapPhieu.TabIndex = 17;
            this.btnLapPhieu.Text = "Lập phiếu đặt";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // lblDanhSachPhieu
            // 
            this.lblDanhSachPhieu.AutoSize = true;
            this.lblDanhSachPhieu.Location = new System.Drawing.Point(20, 430);
            this.lblDanhSachPhieu.Name = "lblDanhSachPhieu";
            this.lblDanhSachPhieu.Size = new System.Drawing.Size(194, 29);
            this.lblDanhSachPhieu.TabIndex = 18;
            this.lblDanhSachPhieu.Text = "Phiếu đặt phòng:";
            // 
            // tabNhanPhong
            // 
            this.tabNhanPhong.Location = new System.Drawing.Point(8, 43);
            this.tabNhanPhong.Name = "tabNhanPhong";
            this.tabNhanPhong.Size = new System.Drawing.Size(1168, 748);
            this.tabNhanPhong.TabIndex = 2;
            this.tabNhanPhong.Text = "[ Nhận phòng / Người lưu trú ]";
            // 
            // btnThemKhach
            // 
            this.btnThemKhach.Location = new System.Drawing.Point(0, 0);
            this.btnThemKhach.Name = "btnThemKhach";
            this.btnThemKhach.Size = new System.Drawing.Size(75, 23);
            this.btnThemKhach.TabIndex = 0;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(0, 0);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(100, 31);
            this.txtMaKH.TabIndex = 0;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(0, 0);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(100, 31);
            this.txtTenKH.TabIndex = 0;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(0, 0);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(100, 31);
            this.txtCMND.TabIndex = 0;
            // 
            // txtQT
            // 
            this.txtQT.Location = new System.Drawing.Point(0, 0);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(100, 31);
            this.txtQT.TabIndex = 0;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(0, 0);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 31);
            this.txtSDT.TabIndex = 0;
            // 
            // btnNhanPhong
            // 
            this.btnNhanPhong.Location = new System.Drawing.Point(0, 0);
            this.btnNhanPhong.Name = "btnNhanPhong";
            this.btnNhanPhong.Size = new System.Drawing.Size(75, 23);
            this.btnNhanPhong.TabIndex = 0;
            // 
            // btnNoShow
            // 
            this.btnNoShow.Location = new System.Drawing.Point(0, 0);
            this.btnNoShow.Name = "btnNoShow";
            this.btnNoShow.Size = new System.Drawing.Size(75, 23);
            this.btnNoShow.TabIndex = 0;
            // 
            // btnThemNguoi
            // 
            this.btnThemNguoi.Location = new System.Drawing.Point(0, 0);
            this.btnThemNguoi.Name = "btnThemNguoi";
            this.btnThemNguoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemNguoi.TabIndex = 0;
            // 
            // txtPhieuChon
            // 
            this.txtPhieuChon.Location = new System.Drawing.Point(0, 0);
            this.txtPhieuChon.Name = "txtPhieuChon";
            this.txtPhieuChon.Size = new System.Drawing.Size(100, 31);
            this.txtPhieuChon.TabIndex = 0;
            // 
            // txtNguoiPhong
            // 
            this.txtNguoiPhong.Location = new System.Drawing.Point(0, 0);
            this.txtNguoiPhong.Name = "txtNguoiPhong";
            this.txtNguoiPhong.Size = new System.Drawing.Size(100, 31);
            this.txtNguoiPhong.TabIndex = 0;
            // 
            // txtNguoiTen
            // 
            this.txtNguoiTen.Location = new System.Drawing.Point(0, 0);
            this.txtNguoiTen.Name = "txtNguoiTen";
            this.txtNguoiTen.Size = new System.Drawing.Size(100, 31);
            this.txtNguoiTen.TabIndex = 0;
            // 
            // txtNguoiCMND
            // 
            this.txtNguoiCMND.Location = new System.Drawing.Point(0, 0);
            this.txtNguoiCMND.Name = "txtNguoiCMND";
            this.txtNguoiCMND.Size = new System.Drawing.Size(100, 31);
            this.txtNguoiCMND.TabIndex = 0;
            // 
            // txtNguoiQT
            // 
            this.txtNguoiQT.Location = new System.Drawing.Point(0, 0);
            this.txtNguoiQT.Name = "txtNguoiQT";
            this.txtNguoiQT.Size = new System.Drawing.Size(100, 31);
            this.txtNguoiQT.TabIndex = 0;
            // 
            // FrmDatPhong
            // 
            this.ClientSize = new System.Drawing.Size(1184, 799);
            this.Controls.Add(this.tabDatPhong);
            this.Name = "FrmDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng - Đặt phòng - Nhận phòng";
            this.Load += new System.EventHandler(this.FrmDatPhong_Load);
            this.tabDatPhong.ResumeLayout(false);
            this.tabDatPhongPage.ResumeLayout(false);
            this.tabDatPhongPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDatPhong;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabDatPhongPage;
        private System.Windows.Forms.TabPage tabNhanPhong;

        // Controls Đặt Phòng
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblKhach;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.Label lblKenhDat;
        private System.Windows.Forms.ComboBox cboKenh;
        private System.Windows.Forms.Label lblTienCoc;
        private System.Windows.Forms.NumericUpDown numCoc;

        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Label lblDanhSachPhieu;

        // Biến rác ẩn của các Tab Khách Hàng / Nhận Phòng
        private System.Windows.Forms.Button btnThemKhach;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnNhanPhong;
        private System.Windows.Forms.Button btnNoShow;
        private System.Windows.Forms.Button btnThemNguoi;
        private System.Windows.Forms.TextBox txtPhieuChon;
        private System.Windows.Forms.TextBox txtNguoiPhong;
        private System.Windows.Forms.TextBox txtNguoiTen;
        private System.Windows.Forms.TextBox txtNguoiCMND;
        private System.Windows.Forms.TextBox txtNguoiQT;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
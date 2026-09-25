namespace QuanLyKhachSan
{
    partial class FrmTraPhong
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
            this.lblPhieu = new System.Windows.Forms.Label();
            this.cboDat = new System.Windows.Forms.ComboBox();
            this.lblSoDB = new System.Windows.Forms.Label();
            this.txtSoDB = new System.Windows.Forms.TextBox();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.txtMucDo = new System.Windows.Forms.TextBox();
            this.lblTienDB = new System.Windows.Forms.Label();
            this.numDenBu = new System.Windows.Forms.NumericUpDown();
            this.btnLapDB = new System.Windows.Forms.Button();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.numSoNgay = new System.Windows.Forms.NumericUpDown();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.cboNV2 = new System.Windows.Forms.ComboBox();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.colHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhieuDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboHT = new System.Windows.Forms.ComboBox();
            this.lblTienTT = new System.Windows.Forms.Label();
            this.numTienTT = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.txtMaTT = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhieu
            // 
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Location = new System.Drawing.Point(20, 20);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(161, 32);
            this.lblPhieu.TabIndex = 0;
            this.lblPhieu.Text = "Phiếu đang ở:";
            // 
            // cboDat
            // 
            this.cboDat.Location = new System.Drawing.Point(187, 17);
            this.cboDat.Name = "cboDat";
            this.cboDat.Size = new System.Drawing.Size(120, 40);
            this.cboDat.TabIndex = 1;
            this.cboDat.Text = "DP001";
            // 
            // lblSoDB
            // 
            this.lblSoDB.AutoSize = true;
            this.lblSoDB.Location = new System.Drawing.Point(39, 330);
            this.lblSoDB.Name = "lblSoDB";
            this.lblSoDB.Size = new System.Drawing.Size(197, 32);
            this.lblSoDB.TabIndex = 5;
            this.lblSoDB.Text = "Số phiếu đền bù:";
            // 
            // txtSoDB
            // 
            this.txtSoDB.Location = new System.Drawing.Point(242, 323);
            this.txtSoDB.Name = "txtSoDB";
            this.txtSoDB.Size = new System.Drawing.Size(100, 39);
            this.txtSoDB.TabIndex = 6;
            this.txtSoDB.Text = "DB001";
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Location = new System.Drawing.Point(369, 330);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(101, 32);
            this.lblMucDo.TabIndex = 7;
            this.lblMucDo.Text = "Mức độ:";
            // 
            // txtMucDo
            // 
            this.txtMucDo.Location = new System.Drawing.Point(476, 327);
            this.txtMucDo.Name = "txtMucDo";
            this.txtMucDo.Size = new System.Drawing.Size(158, 39);
            this.txtMucDo.TabIndex = 8;
            this.txtMucDo.Text = "Hư hỏng nhẹ";
            // 
            // lblTienDB
            // 
            this.lblTienDB.AutoSize = true;
            this.lblTienDB.Location = new System.Drawing.Point(662, 330);
            this.lblTienDB.Name = "lblTienDB";
            this.lblTienDB.Size = new System.Drawing.Size(94, 32);
            this.lblTienDB.TabIndex = 9;
            this.lblTienDB.Text = "Số tiền:";
            // 
            // numDenBu
            // 
            this.numDenBu.Location = new System.Drawing.Point(762, 327);
            this.numDenBu.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numDenBu.Name = "numDenBu";
            this.numDenBu.Size = new System.Drawing.Size(100, 39);
            this.numDenBu.TabIndex = 10;
            this.numDenBu.Value = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            // 
            // btnLapDB
            // 
            this.btnLapDB.Location = new System.Drawing.Point(873, 330);
            this.btnLapDB.Name = "btnLapDB";
            this.btnLapDB.Size = new System.Drawing.Size(217, 50);
            this.btnLapDB.TabIndex = 12;
            this.btnLapDB.Text = "Lập phiếu đền bù";
            this.btnLapDB.Click += new System.EventHandler(this.btnLapDB_Click);
            // 
            // lblSoHD
            // 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Location = new System.Drawing.Point(39, 397);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(142, 32);
            this.lblSoHD.TabIndex = 13;
            this.lblSoHD.Text = "Số hóa đơn:";
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(200, 390);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(100, 39);
            this.txtSoHD.TabIndex = 14;
            this.txtSoHD.Text = "HD001";
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Location = new System.Drawing.Point(314, 397);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Size = new System.Drawing.Size(202, 32);
            this.lblSoNgay.TabIndex = 15;
            this.lblSoNgay.Text = "Số ngày tính tiền:";
            // 
            // numSoNgay
            // 
            this.numSoNgay.Location = new System.Drawing.Point(540, 390);
            this.numSoNgay.Name = "numSoNgay";
            this.numSoNgay.Size = new System.Drawing.Size(80, 39);
            this.numSoNgay.TabIndex = 16;
            this.numSoNgay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnLapHD
            // 
            this.btnLapHD.Location = new System.Drawing.Point(878, 397);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(176, 41);
            this.btnLapHD.TabIndex = 17;
            this.btnLapHD.Text = "Lập hóa đơn";
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // cboNV2
            // 
            this.cboNV2.Location = new System.Drawing.Point(0, 0);
            this.cboNV2.Name = "cboNV2";
            this.cboNV2.Size = new System.Drawing.Size(121, 33);
            this.cboNV2.TabIndex = 0;
            // 
            // dgvHD
            // 
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvHD.ColumnHeadersHeight = 46;
            this.dgvHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHD,
            this.colPhieuDat,
            this.colTienPhong,
            this.colTienDV,
            this.colTongTien,
            this.colTrangThai});
            this.dgvHD.Location = new System.Drawing.Point(20, 455);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.RowHeadersVisible = false;
            this.dgvHD.RowHeadersWidth = 82;
            this.dgvHD.Size = new System.Drawing.Size(1070, 142);
            this.dgvHD.TabIndex = 18;
            this.dgvHD.SelectionChanged += new System.EventHandler(this.dgvHD_SelectionChanged);
            // 
            // colHD
            // 
            this.colHD.HeaderText = "Hóa đơn";
            this.colHD.MinimumWidth = 10;
            this.colHD.Name = "colHD";
            // 
            // colPhieuDat
            // 
            this.colPhieuDat.HeaderText = "Phiếu đặt";
            this.colPhieuDat.MinimumWidth = 10;
            this.colPhieuDat.Name = "colPhieuDat";
            // 
            // colTienPhong
            // 
            this.colTienPhong.HeaderText = "Tiền phòng";
            this.colTienPhong.MinimumWidth = 10;
            this.colTienPhong.Name = "colTienPhong";
            // 
            // colTienDV
            // 
            this.colTienDV.HeaderText = "Tiền dịch vụ";
            this.colTienDV.MinimumWidth = 10;
            this.colTienDV.Name = "colTienDV";
            // 
            // colTongTien
            // 
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 10;
            this.colTongTien.Name = "colTongTien";
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 10;
            this.colTrangThai.Name = "colTrangThai";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(20, 613);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(124, 32);
            this.lblHinhThuc.TabIndex = 19;
            this.lblHinhThuc.Text = "Hình thức:";
            // 
            // cboHT
            // 
            this.cboHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHT.Location = new System.Drawing.Point(160, 610);
            this.cboHT.Name = "cboHT";
            this.cboHT.Size = new System.Drawing.Size(120, 40);
            this.cboHT.TabIndex = 20;
            // 
            // lblTienTT
            // 
            this.lblTienTT.AutoSize = true;
            this.lblTienTT.Location = new System.Drawing.Point(314, 613);
            this.lblTienTT.Name = "lblTienTT";
            this.lblTienTT.Size = new System.Drawing.Size(94, 32);
            this.lblTienTT.TabIndex = 21;
            this.lblTienTT.Text = "Số tiền:";
            // 
            // numTienTT
            // 
            this.numTienTT.Location = new System.Drawing.Point(434, 611);
            this.numTienTT.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTienTT.Name = "numTienTT";
            this.numTienTT.Size = new System.Drawing.Size(120, 39);
            this.numTienTT.TabIndex = 22;
            this.numTienTT.Value = new decimal(new int[] {
            1200000,
            0,
            0,
            0});
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(620, 606);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(158, 47);
            this.btnThanhToan.TabIndex = 23;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Location = new System.Drawing.Point(821, 603);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(269, 53);
            this.btnTraPhong.TabIndex = 24;
            this.btnTraPhong.Text = "Hoàn tất trả phòng";
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // txtMaTT
            // 
            this.txtMaTT.Location = new System.Drawing.Point(0, 0);
            this.txtMaTT.Name = "txtMaTT";
            this.txtMaTT.Size = new System.Drawing.Size(100, 31);
            this.txtMaTT.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(40, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(302, 216);
            this.dataGridView1.TabIndex = 25;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView2.Location = new System.Drawing.Point(393, 90);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(327, 216);
            this.dataGridView2.TabIndex = 26;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView3.Location = new System.Drawing.Point(749, 90);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 82;
            this.dataGridView3.RowTemplate.Height = 33;
            this.dataGridView3.Size = new System.Drawing.Size(341, 216);
            this.dataGridView3.TabIndex = 27;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Phòng";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Đơn giá/ ngày";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tiện nghi";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Loại";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tình trạng";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Tiện nghi đền bù";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Mức độ";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Số tiền";
            this.Column8.MinimumWidth = 10;
            this.Column8.Name = "Column8";
            // 
            // FrmTraPhong
            // 
            this.ClientSize = new System.Drawing.Size(1102, 668);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblPhieu);
            this.Controls.Add(this.cboDat);
            this.Controls.Add(this.lblSoDB);
            this.Controls.Add(this.txtSoDB);
            this.Controls.Add(this.lblMucDo);
            this.Controls.Add(this.txtMucDo);
            this.Controls.Add(this.lblTienDB);
            this.Controls.Add(this.numDenBu);
            this.Controls.Add(this.btnLapDB);
            this.Controls.Add(this.lblSoHD);
            this.Controls.Add(this.txtSoHD);
            this.Controls.Add(this.lblSoNgay);
            this.Controls.Add(this.numSoNgay);
            this.Controls.Add(this.btnLapHD);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.lblHinhThuc);
            this.Controls.Add(this.cboHT);
            this.Controls.Add(this.lblTienTT);
            this.Controls.Add(this.numTienTT);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnTraPhong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmTraPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả phòng - Đền bù - Hóa đơn - Thanh toán";
            this.Load += new System.EventHandler(this.FrmTraPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.ComboBox cboDat;
        private System.Windows.Forms.Label lblSoDB;
        private System.Windows.Forms.TextBox txtSoDB;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.TextBox txtMucDo;
        private System.Windows.Forms.Label lblTienDB;
        private System.Windows.Forms.NumericUpDown numDenBu;
        private System.Windows.Forms.Button btnLapDB;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label lblSoNgay;
        private System.Windows.Forms.NumericUpDown numSoNgay;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.ComboBox cboNV2;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhieuDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.Label lblTienTT;
        private System.Windows.Forms.NumericUpDown numTienTT;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.TextBox txtMaTT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}
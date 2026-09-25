namespace QuanLyKhachSan
{
    partial class FrmDanhMuc
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
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.tabLoaiTienNghi = new System.Windows.Forms.TabPage();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.tabQuyDinhDenBu = new System.Windows.Forms.TabPage();

            // Controls Tab Dịch Vụ (Chuẩn theo hình thầy)
            this.lblDVMa = new System.Windows.Forms.Label();
            this.txtDVMa = new System.Windows.Forms.TextBox();
            this.lblDVTen = new System.Windows.Forms.Label();
            this.txtDVTen = new System.Windows.Forms.TextBox();
            this.lblDVDVT = new System.Windows.Forms.Label();
            this.txtDVDVT = new System.Windows.Forms.TextBox();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDV = new System.Windows.Forms.DataGridView();

            // Cột cho DataGridView Dịch Vụ
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Controls Tab Khu Vực (Để không bị trống như hình của bạn)
            this.lblKhuMa = new System.Windows.Forms.Label();
            this.txtKhuMa = new System.Windows.Forms.TextBox();
            this.lblKhuTen = new System.Windows.Forms.Label();
            this.txtKhuTen = new System.Windows.Forms.TextBox();
            this.btnThemKhu = new System.Windows.Forms.Button();
            this.dgvKhu = new System.Windows.Forms.DataGridView();

            // Khai báo ẩn các control khác để code C# không báo lỗi
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.txtNVVaiTro = new System.Windows.Forms.TextBox();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.txtLoaiMa = new System.Windows.Forms.TextBox();
            this.txtLoaiTen = new System.Windows.Forms.TextBox();
            this.btnThemLoaiTN = new System.Windows.Forms.Button();
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView();
            this.txtQDMa = new System.Windows.Forms.TextBox();
            this.cboQDLoai = new System.Windows.Forms.ComboBox();
            this.txtQDMucDo = new System.Windows.Forms.TextBox();
            this.numQDTien = new System.Windows.Forms.NumericUpDown();
            this.btnThemQD = new System.Windows.Forms.Button();
            this.dgvQD = new System.Windows.Forms.DataGridView();
            this.numDVGia = new System.Windows.Forms.NumericUpDown();

            this.tabDanhMuc.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.tabKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).BeginInit();
            this.SuspendLayout();

            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.tabKhuVuc);
            this.tabDanhMuc.Controls.Add(this.tabNhanVien);
            this.tabDanhMuc.Controls.Add(this.tabLoaiTienNghi);
            this.tabDanhMuc.Controls.Add(this.tabDichVu);
            this.tabDanhMuc.Controls.Add(this.tabQuyDinhDenBu);
            this.tabDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.SelectedIndex = 3; // Mở sẵn tab Dịch vụ
            this.tabDanhMuc.Size = new System.Drawing.Size(950, 520);

            // ==========================================
            // TAB DỊCH VỤ (Giống 100% hình thầy)
            // ==========================================
            this.tabDichVu.Controls.Add(this.lblDVMa);
            this.tabDichVu.Controls.Add(this.txtDVMa);
            this.tabDichVu.Controls.Add(this.lblDVTen);
            this.tabDichVu.Controls.Add(this.txtDVTen);
            this.tabDichVu.Controls.Add(this.lblDVDVT);
            this.tabDichVu.Controls.Add(this.txtDVDVT);
            this.tabDichVu.Controls.Add(this.btnThemDV);
            this.tabDichVu.Controls.Add(this.dgvDV);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Text = "[ Dịch vụ ]";
            this.tabDichVu.BackColor = System.Drawing.Color.WhiteSmoke;

            // Mã
            this.lblDVMa.AutoSize = true;
            this.lblDVMa.Location = new System.Drawing.Point(30, 25);
            this.lblDVMa.Text = "Mã:";
            this.txtDVMa.Location = new System.Drawing.Point(70, 22);
            this.txtDVMa.Name = "txtDVMa";
            this.txtDVMa.Size = new System.Drawing.Size(120, 21);
            this.txtDVMa.Text = "DV01";

            // Tên
            this.lblDVTen.AutoSize = true;
            this.lblDVTen.Location = new System.Drawing.Point(230, 25);
            this.lblDVTen.Text = "Tên:";
            this.txtDVTen.Location = new System.Drawing.Point(280, 22);
            this.txtDVTen.Name = "txtDVTen";
            this.txtDVTen.Size = new System.Drawing.Size(200, 21);
            this.txtDVTen.Text = "Ăn sáng";

            // Đơn vị
            this.lblDVDVT.AutoSize = true;
            this.lblDVDVT.Location = new System.Drawing.Point(520, 25);
            this.lblDVDVT.Text = "Đơn vị / Vai trò:";
            this.txtDVDVT.Location = new System.Drawing.Point(630, 22);
            this.txtDVDVT.Name = "txtDVDVT";
            this.txtDVDVT.Size = new System.Drawing.Size(120, 21);
            this.txtDVDVT.Text = "Suất";

            // Nút Thêm
            this.btnThemDV.Location = new System.Drawing.Point(780, 20);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(100, 26);
            this.btnThemDV.Text = "Thêm";

            // Bảng DataGridView
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa, this.colTen, this.colLoai, this.colDonVi, this.colDonGia});
            this.dgvDV.Location = new System.Drawing.Point(30, 70);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.RowHeadersVisible = false;
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.Size = new System.Drawing.Size(870, 390);

            // Tên Cột
            this.colMa.HeaderText = "Mã";
            this.colTen.HeaderText = "Tên";
            this.colLoai.HeaderText = "Loại / Vai trò";
            this.colDonVi.HeaderText = "Đơn vị";
            this.colDonGia.HeaderText = "Đơn giá / Mức";

            // ==========================================
            // TAB KHU VỰC
            // ==========================================
            this.tabKhuVuc.Controls.Add(this.lblKhuMa);
            this.tabKhuVuc.Controls.Add(this.txtKhuMa);
            this.tabKhuVuc.Controls.Add(this.lblKhuTen);
            this.tabKhuVuc.Controls.Add(this.txtKhuTen);
            this.tabKhuVuc.Controls.Add(this.btnThemKhu);
            this.tabKhuVuc.Controls.Add(this.dgvKhu);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Text = "[ Khu vực ]";

            this.lblKhuMa.AutoSize = true;
            this.lblKhuMa.Location = new System.Drawing.Point(30, 25);
            this.lblKhuMa.Text = "Mã khu vực:";
            this.txtKhuMa.Location = new System.Drawing.Point(120, 22);
            this.txtKhuMa.Size = new System.Drawing.Size(120, 21);

            this.lblKhuTen.AutoSize = true;
            this.lblKhuTen.Location = new System.Drawing.Point(280, 25);
            this.lblKhuTen.Text = "Tên khu vực:";
            this.txtKhuTen.Location = new System.Drawing.Point(380, 22);
            this.txtKhuTen.Size = new System.Drawing.Size(200, 21);

            this.btnThemKhu.Location = new System.Drawing.Point(620, 20);
            this.btnThemKhu.Size = new System.Drawing.Size(100, 26);
            this.btnThemKhu.Text = "Thêm";

            this.dgvKhu.Location = new System.Drawing.Point(30, 70);
            this.dgvKhu.Size = new System.Drawing.Size(870, 390);
            this.dgvKhu.BackgroundColor = System.Drawing.Color.White;

            // ==========================================
            // CÁC TAB CÒN LẠI (Tạo vỏ để không lỗi)
            // ==========================================
            this.tabNhanVien.Text = "[ Nhân viên ]";
            this.tabLoaiTienNghi.Text = "[ Loại tiện nghi ]";
            this.tabQuyDinhDenBu.Text = "[ Quy định đền bù ]";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 520);
            this.Controls.Add(this.tabDanhMuc);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khách sạn";

            this.tabDanhMuc.ResumeLayout(false);
            this.tabDichVu.ResumeLayout(false);
            this.tabDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.tabKhuVuc.ResumeLayout(false);
            this.tabKhuVuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tabKhuVuc;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabLoaiTienNghi;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabQuyDinhDenBu;

        // Dịch vụ
        private System.Windows.Forms.Label lblDVMa;
        private System.Windows.Forms.TextBox txtDVMa;
        private System.Windows.Forms.Label lblDVTen;
        private System.Windows.Forms.TextBox txtDVTen;
        private System.Windows.Forms.Label lblDVDVT;
        private System.Windows.Forms.TextBox txtDVDVT;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;

        // Khu vực
        private System.Windows.Forms.Label lblKhuMa;
        private System.Windows.Forms.TextBox txtKhuMa;
        private System.Windows.Forms.Label lblKhuTen;
        private System.Windows.Forms.TextBox txtKhuTen;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.DataGridView dgvKhu;

        // Biến rác ẩn
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.TextBox txtNVVaiTro;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.TextBox txtLoaiMa;
        private System.Windows.Forms.TextBox txtLoaiTen;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.DataGridView dgvLoaiTN;
        private System.Windows.Forms.TextBox txtQDMa;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.TextBox txtQDMucDo;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.DataGridView dgvQD;
        private System.Windows.Forms.NumericUpDown numDVGia;
    }
}
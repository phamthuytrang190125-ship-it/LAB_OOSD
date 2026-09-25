namespace QuanLyKhachSan
{
    partial class FrmThongKe
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
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.lblTitleDV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(30, 35);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(105, 32);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtTu
            // 
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTu.Location = new System.Drawing.Point(100, 32);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(120, 39);
            this.dtTu.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(250, 35);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(122, 32);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtDen
            // 
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDen.Location = new System.Drawing.Point(330, 32);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(120, 39);
            this.dtDen.TabIndex = 3;
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(480, 28);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(100, 30);
            this.btnTK.TabIndex = 4;
            this.btnTK.Text = "Thống kê";
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(600, 28);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvTongHop
            // 
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTongHop.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTongHop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTongHop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTongHop.ColumnHeadersHeight = 46;
            this.dgvTongHop.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTongHop.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTongHop.Location = new System.Drawing.Point(30, 80);
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.RowHeadersVisible = false;
            this.dgvTongHop.RowHeadersWidth = 82;
            this.dgvTongHop.Size = new System.Drawing.Size(700, 100);
            this.dgvTongHop.TabIndex = 6;
            this.dgvTongHop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTongHop_CellContentClick);
            // 
            // dgvDV
            // 
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDV.ColumnHeadersHeight = 46;
            this.dgvDV.Location = new System.Drawing.Point(30, 230);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.ReadOnly = true;
            this.dgvDV.RowHeadersVisible = false;
            this.dgvDV.RowHeadersWidth = 82;
            this.dgvDV.Size = new System.Drawing.Size(720, 200);
            this.dgvDV.TabIndex = 8;
            // 
            // lblTitleDV
            // 
            this.lblTitleDV.AutoSize = true;
            this.lblTitleDV.Location = new System.Drawing.Point(30, 200);
            this.lblTitleDV.Name = "lblTitleDV";
            this.lblTitleDV.Size = new System.Drawing.Size(194, 32);
            this.lblTitleDV.TabIndex = 7;
            this.lblTitleDV.Text = "Dịch vụ sử dụng:";
            // 
            // FrmThongKe
            // 
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvTongHop);
            this.Controls.Add(this.lblTitleDV);
            this.Controls.Add(this.dgvDV);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê khách sạn";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnDong;

        // Đây chính là 2 cái dgv bắt buộc phải có theo Bảng 8.7
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Label lblTitleDV;
    }
}
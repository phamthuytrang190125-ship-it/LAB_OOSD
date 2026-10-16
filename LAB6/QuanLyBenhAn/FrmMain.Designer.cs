namespace QuanLyBenhAn
{
    partial class FrmMain
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnLichKham = new System.Windows.Forms.Button();
            this.btnKhamBenh = new System.Windows.Forms.Button();
            this.btnLapToa = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ HỒ SƠ BỆNH ÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSubTitle.Location = new System.Drawing.Point(110, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(180, 16);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Bệnh viện đa khoa quốc tế";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.White;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(40, 100);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(320, 40);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "1. Đăng ký bệnh nhân / Cấp hồ sơ";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnLichKham
            // 
            this.btnLichKham.BackColor = System.Drawing.Color.White;
            this.btnLichKham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichKham.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichKham.Location = new System.Drawing.Point(40, 150);
            this.btnLichKham.Name = "btnLichKham";
            this.btnLichKham.Size = new System.Drawing.Size(320, 40);
            this.btnLichKham.TabIndex = 3;
            this.btnLichKham.Text = "2. Lịch khám định kỳ";
            this.btnLichKham.UseVisualStyleBackColor = false;
            // 
            // btnKhamBenh
            // 
            this.btnKhamBenh.BackColor = System.Drawing.Color.White;
            this.btnKhamBenh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhamBenh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhamBenh.Location = new System.Drawing.Point(40, 200);
            this.btnKhamBenh.Name = "btnKhamBenh";
            this.btnKhamBenh.Size = new System.Drawing.Size(320, 40);
            this.btnKhamBenh.TabIndex = 4;
            this.btnKhamBenh.Text = "3. Khám bệnh / Xét nghiệm";
            this.btnKhamBenh.UseVisualStyleBackColor = false;
            // 
            // btnLapToa
            // 
            this.btnLapToa.BackColor = System.Drawing.Color.White;
            this.btnLapToa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapToa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapToa.Location = new System.Drawing.Point(40, 250);
            this.btnLapToa.Name = "btnLapToa";
            this.btnLapToa.Size = new System.Drawing.Size(320, 40);
            this.btnLapToa.TabIndex = 5;
            this.btnLapToa.Text = "4. Lập toa thuốc";
            this.btnLapToa.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.White;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(40, 300);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(320, 40);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "5. Thanh toán viện phí";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(40, 350);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(320, 40);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(400, 430);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnLapToa);
            this.Controls.Add(this.btnKhamBenh);
            this.Controls.Add(this.btnLichKham);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hồ sơ bệnh án";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnLichKham;
        private System.Windows.Forms.Button btnKhamBenh;
        private System.Windows.Forms.Button btnLapToa;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThoat;
    }
}
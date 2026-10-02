namespace HeThongEShopping
{
    // Kế thừa rõ ràng System.Windows.Forms.Form để đồng bộ với FrmMain.cs
    partial class FrmMain : System.Windows.Forms.Form
    {
        /// 
        /// Required designer variable.
        /// 
        private System.ComponentModel.IContainer components = null;

        /// 
        /// Clean up any resources being used.
        /// 
        /// true if managed resources should be disposed; otherwise, false.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing); // Đoạn này giúp triệt tiêu lỗi CS0115
        }

        #region Windows Form Designer generated code

        /// 
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// 
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmMain";
            this.Text = "Hệ thống Quản lý e-SHOPPING";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HeThongEShopping
{
    // Dùng class bình thường, không dùng partial để tránh bị lỗi tìm file Designer
    public class FrmLogin : Form
    {
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
        private Label lblTitle;

        public FrmLogin()
        {
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            this.Text = "Đăng nhập Khách hàng";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTitle = new Label();
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;

            // Tên đăng nhập
            Label lbl1 = new Label();
            lbl1.Text = "Tên đăng nhập:";
            lbl1.Location = new Point(50, 70);
            lbl1.AutoSize = true;

            txtUser = new TextBox();
            txtUser.Location = new Point(50, 95);
            txtUser.Width = 280;
            txtUser.Font = new Font("Segoe UI", 10);

            // Mật khẩu
            Label lbl2 = new Label();
            lbl2.Text = "Mật khẩu:";
            lbl2.Location = new Point(50, 135);
            lbl2.AutoSize = true;

            txtPass = new TextBox();
            txtPass.Location = new Point(50, 160);
            txtPass.Width = 280;
            txtPass.Font = new Font("Segoe UI", 10);
            txtPass.PasswordChar = '*';

            // Nút đăng nhập
            btnLogin = new Button();
            btnLogin.Text = "Đăng nhập";
            btnLogin.Location = new Point(135, 210);
            btnLogin.Width = 120;
            btnLogin.Height = 35;
            btnLogin.BackColor = Color.LightSteelBlue;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.Click += BtnLogin_Click;

            // Thêm vào Form
            this.Controls.Add(btnLogin);
            this.Controls.Add(txtPass);
            this.Controls.Add(lbl2);
            this.Controls.Add(txtUser);
            this.Controls.Add(lbl1);
            this.Controls.Add(lblTitle);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối Oracle kiểm tra tài khoản
            string conString = "Data Source=192.168.22.51:1521/FREE;User Id=ptttrang;Password=123456;";
            try
            {
                using (OracleConnection con = new OracleConnection(conString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM KhachHang WHERE TenDangNhap = :user AND MatKhau = :pass";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add(":user", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add(":pass", OracleDbType.Varchar2).Value = password;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
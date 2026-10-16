using System;
using System.Windows.Forms;

namespace QuanLyBenhAn
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút "1. Đăng ký bệnh nhân..."
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Mở form Form1 (form chứa danh sách bệnh nhân bạn test lúc nãy)
            Form1 f = new Form1();
            f.Show();
        }

        // Sự kiện khi bấm nút "Thoát"
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
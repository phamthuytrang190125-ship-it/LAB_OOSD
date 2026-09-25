using System;
using System.Windows.Forms;

namespace QuanLyKhachSan.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachSan.FrmDanhMuc();
            frm.ShowDialog();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang phát triển!");
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachSan.FrmDatPhong();
            frm.ShowDialog();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang phát triển!");
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachSan.FrmTraPhong();
            frm.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachSan.FrmThongKe();
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
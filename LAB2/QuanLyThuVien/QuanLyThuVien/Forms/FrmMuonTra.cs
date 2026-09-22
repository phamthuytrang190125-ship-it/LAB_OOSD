using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien
{
    public partial class FrmMuonTra : Form
    {
        MuonTraService service = new MuonTraService();

        DataTable selectedBooks = new DataTable();

        public FrmMuonTra()
        {
            InitializeComponent();
            selectedBooks.Columns.Add("MaDauSach", typeof(string));
        }

        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ds = new List<string>();
            foreach (DataRow r in selectedBooks.Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    ds.Add(Convert.ToString(r["MaDauSach"]));
                }
            }

            string maDocGia = txtMaDocGia.Text;
            string maNhanVien = txtMaNhanVien.Text;

            KetQuaXuLy kq = service.LapPhieuMuon(maDocGia, maNhanVien, ds, dtpNgayMuon.Value, dtpHenTra.Value);

            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (kq.ThanhCong)
            {
                selectedBooks.Rows.Clear();
                // TaiSachCon();      
                // TaiSachDangMuon(); 
                lblTrangThai.Text = "Lập phiếu thành công!";
            }
        }

        private void dtHenTra_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
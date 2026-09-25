using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class FrmPhongTienNghi : Form
    {
        public FrmPhongTienNghi()
        {
            InitializeComponent();
        }

        private void FrmPhongTienNghi_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private void LoadPhong()
        {
            try
            {
                string sql = @"
                    SELECT
                        p.SoPhong AS [Phòng],
                        k.TenKhuVuc AS [Khu],
                        p.SoNguoiToiDa AS [Sức chứa],
                        p.DonGiaNgay AS [Đơn giá],
                        p.TrangThai AS [Trạng thái]
                    FROM Phong p
                    INNER JOIN KhuVuc k
                        ON p.MaKhuVuc = k.MaKhuVuc
                    ORDER BY p.SoPhong";

                DataTable dt = Db.Query(sql);

                dgvPhong.DataSource = dt;

                if (dgvPhong.Columns.Count > 0)
                {
                    dgvPhong.Columns[0].HeaderText = "Phòng";
                    dgvPhong.Columns[1].HeaderText = "Khu";
                    dgvPhong.Columns[2].HeaderText = "Sức chứa";
                    dgvPhong.Columns[3].HeaderText = "Đơn giá";
                    dgvPhong.Columns[4].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách phòng.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvPhong_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

            txtSoPhong.Text = Convert.ToString(row.Cells[0].Value);
            txtKhuVuc.Text = Convert.ToString(row.Cells[1].Value);
            txtSucChua.Text = Convert.ToString(row.Cells[2].Value);
            txtDonGia.Text = Convert.ToString(row.Cells[3].Value);

            txtPhongLapDat.Text = txtSoPhong.Text;
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng thêm phòng sẽ thực hiện ở bước CRUD.",
                "Phòng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCapNhatPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng cập nhật phòng sẽ thực hiện ở bước CRUD.",
                "Phòng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng xóa phòng sẽ thực hiện ở bước CRUD.",
                "Phòng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLamMoiPhong_Click(object sender, EventArgs e)
        {
            txtSoPhong.Clear();
            txtKhuVuc.Clear();
            txtSucChua.Clear();
            txtDonGia.Clear();
            txtPhongLapDat.Clear();

            LoadPhong();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhieuLapDat.Text) ||
                string.IsNullOrWhiteSpace(txtMaTienNghi.Text) ||
                string.IsNullOrWhiteSpace(txtPhongLapDat.Text) ||
                string.IsNullOrWhiteSpace(txtTinhTrang.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin phiếu lắp đặt.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string sql = @"
                    INSERT INTO PhieuLapDat
                    (
                        SoPhieuLapDat,
                        MaTienNghi,
                        SoPhong,
                        NgayLap,
                        TinhTrang,
                        MaNV
                    )
                    VALUES
                    (
                        @SoPhieuLapDat,
                        @MaTienNghi,
                        @SoPhong,
                        CAST(GETDATE() AS date),
                        @TinhTrang,
                        @MaNV
                    )";

                Db.Execute(
                    sql,
                    new SqlParameter("@SoPhieuLapDat", txtSoPhieuLapDat.Text.Trim()),
                    new SqlParameter("@MaTienNghi", txtMaTienNghi.Text.Trim()),
                    new SqlParameter("@SoPhong", txtPhongLapDat.Text.Trim()),
                    new SqlParameter("@TinhTrang", txtTinhTrang.Text.Trim()),
                    new SqlParameter("@MaNV", "NV01")
                );

                MessageBox.Show(
                    "Lập phiếu thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lập phiếu.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
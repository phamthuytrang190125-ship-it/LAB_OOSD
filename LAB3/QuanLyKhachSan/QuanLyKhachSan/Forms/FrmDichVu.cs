using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class FrmDichVu : Form
    {
        public FrmDichVu()
        {
            InitializeComponent();

            dtNgaySuDung.Format = DateTimePickerFormat.Short;

            LoadDichVu();
        }

        private void LoadDichVu()
        {
            try
            {
                using (SqlConnection cn = Db.GetConnection())
                {
                    cn.Open();

                    string sql = @"
                        SELECT
                            dv.MaDV AS MaDichVu,
                            dv.TenDV AS DichVu,
                            dv.DonViTinh AS DonVi,
                            dv.DonGia
                        FROM DichVu dv
                        ORDER BY dv.MaDV";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvDichVu.DataSource = dt;
                    }
                }

                DinhDangGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách dịch vụ:\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DinhDangGrid()
        {
            if (dgvDichVu.Columns.Count == 0)
                return;

            if (dgvDichVu.Columns.Contains("MaDichVu"))
                dgvDichVu.Columns["MaDichVu"].HeaderText = "Mã dịch vụ";

            if (dgvDichVu.Columns.Contains("DichVu"))
                dgvDichVu.Columns["DichVu"].HeaderText = "Dịch vụ";

            if (dgvDichVu.Columns.Contains("DonVi"))
                dgvDichVu.Columns["DonVi"].HeaderText = "Đơn vị";

            if (dgvDichVu.Columns.Contains("DonGia"))
            {
                dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }

            dgvDichVu.ReadOnly = true;
            dgvDichVu.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDichVu.MultiSelect = false;

            dgvDichVu.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            string soPhieuDat = txtPhieuLuuTru.Text.Trim();
            string soPhong = txtPhong.Text.Trim();
            string tenDichVu = txtDichVu.Text.Trim();

            int soLuong;

            if (string.IsNullOrWhiteSpace(soPhieuDat))
            {
                MessageBox.Show(
                    "Vui lòng nhập phiếu lưu trú.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhieuLuuTru.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(soPhong))
            {
                MessageBox.Show(
                    "Vui lòng nhập phòng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhong.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenDichVu))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên dịch vụ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDichVu.Focus();
                return;
            }

            if (!int.TryParse(
                txtSoLuong.Text.Trim(),
                out soLuong) || soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải là số nguyên lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoLuong.Focus();
                return;
            }

            try
            {
                using (SqlConnection cn = Db.GetConnection())
                {
                    cn.Open();

                    using (SqlTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            // Kiểm tra phiếu đặt + phòng
                            string sqlKiemTra = @"
                                SELECT COUNT(*)
                                FROM ChiTietDatPhong
                                WHERE SoPhieuDat = @SoPhieuDat
                                  AND SoPhong = @SoPhong";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlKiemTra,
                                    cn,
                                    tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SoPhieuDat",
                                    soPhieuDat);

                                cmd.Parameters.AddWithValue(
                                    "@SoPhong",
                                    soPhong);

                                int tonTai =
                                    Convert.ToInt32(
                                        cmd.ExecuteScalar());

                                if (tonTai == 0)
                                {
                                    MessageBox.Show(
                                        "Không tìm thấy phòng này trong phiếu đặt.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    tran.Rollback();
                                    return;
                                }
                            }

                            // Tìm dịch vụ theo tên
                            string maDV = "";
                            decimal donGia = 0;

                            string sqlDV = @"
                                SELECT MaDV, DonGia
                                FROM DichVu
                                WHERE TenDV = @TenDV";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlDV,
                                    cn,
                                    tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@TenDV",
                                    tenDichVu);

                                using (SqlDataReader reader =
                                    cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        MessageBox.Show(
                                            "Không tìm thấy dịch vụ: "
                                            + tenDichVu,
                                            "Thông báo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);

                                        return;
                                    }

                                    maDV =
                                        reader["MaDV"].ToString();

                                    donGia =
                                        Convert.ToDecimal(
                                            reader["DonGia"]);
                                }
                            }

                            // Tạo mã phiếu sử dụng dịch vụ
                            string soPhieuSDDV =
                                "SD" +
                                DateTime.Now.ToString(
                                    "yyyyMMddHHmmssfff");

                            // Thêm phiếu sử dụng dịch vụ
                            string sqlPhieu = @"
                                INSERT INTO PhieuSuDungDV
                                (
                                    SoPhieuSDDV,
                                    SoPhieuDat,
                                    SoPhong,
                                    NgaySuDung,
                                    MaNV
                                )
                                VALUES
                                (
                                    @SoPhieuSDDV,
                                    @SoPhieuDat,
                                    @SoPhong,
                                    @NgaySuDung,
                                    @MaNV
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlPhieu,
                                    cn,
                                    tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SoPhieuSDDV",
                                    soPhieuSDDV);

                                cmd.Parameters.AddWithValue(
                                    "@SoPhieuDat",
                                    soPhieuDat);

                                cmd.Parameters.AddWithValue(
                                    "@SoPhong",
                                    soPhong);

                                cmd.Parameters.AddWithValue(
                                    "@NgaySuDung",
                                    dtNgaySuDung.Value.Date);

                                cmd.Parameters.AddWithValue(
                                    "@MaNV",
                                    "NV01");

                                cmd.ExecuteNonQuery();
                            }

                            // Thêm chi tiết dịch vụ
                            string sqlChiTiet = @"
                                INSERT INTO ChiTietPhieuSuDungDV
                                (
                                    SoPhieuSDDV,
                                    MaDV,
                                    SoLuong,
                                    DonGia
                                )
                                VALUES
                                (
                                    @SoPhieuSDDV,
                                    @MaDV,
                                    @SoLuong,
                                    @DonGia
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlChiTiet,
                                    cn,
                                    tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SoPhieuSDDV",
                                    soPhieuSDDV);

                                cmd.Parameters.AddWithValue(
                                    "@MaDV",
                                    maDV);

                                cmd.Parameters.AddWithValue(
                                    "@SoLuong",
                                    soLuong);

                                cmd.Parameters.AddWithValue(
                                    "@DonGia",
                                    donGia);

                                cmd.ExecuteNonQuery();
                            }

                            tran.Commit();

                            MessageBox.Show(
                                "Ghi nhận sử dụng dịch vụ thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadDichVu();
                            XoaNhapLieu();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể ghi nhận dịch vụ:\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void XoaNhapLieu()
        {
            txtPhieuLuuTru.Clear();
            txtPhong.Clear();
            txtDichVu.Clear();

            txtSoLuong.Text = "1";

            dtNgaySuDung.Value = DateTime.Now;
        }
    }
}
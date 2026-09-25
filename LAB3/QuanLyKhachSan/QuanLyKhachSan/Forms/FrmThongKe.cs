using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDen.Value = dtTu.Value.AddMonths(1).AddDays(-1);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            TongHop();
            DichVu();
        }

        private void TongHop()
        {
            int phieuDat = LaySo("SELECT COUNT(*) FROM PhieuDatPhong WHERE NgayLap >= @Tu AND NgayLap <= @Den");
            int dangO = LaySo("SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai = N'Đang ở'");
            int hoaDon = LaySo("SELECT COUNT(*) FROM HoaDon WHERE NgayLap >= @Tu AND NgayLap <= @Den");
            decimal doanhThu = LayTien("SELECT ISNULL(SUM(TienPhong + TienDichVu), 0) FROM HoaDon WHERE NgayLap >= @Tu AND NgayLap <= @Den");
            decimal denBu = LayTien("SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToan WHERE NgayThanhToan >= @Tu AND NgayThanhToan <= @Den");

            DataTable dt = new DataTable();
            dt.Columns.Add("Cot1");
            dt.Columns.Add("Cot2");

            // ĐÃ SỬA CÚ PHÁP: Dùng dấu + truyền thống thay cho dấu $
            dt.Rows.Add("Phiếu đặt: " + phieuDat, "Đang ở: " + dangO);
            dt.Rows.Add("Hóa đơn: " + hoaDon, "Doanh thu HĐ: " + doanhThu.ToString("N0") + " đ");
            dt.Rows.Add("Tổng đền bù: " + denBu.ToString("N0") + " đ", "");

            dgvTongHop.DataSource = dt;
        }

        private void DichVu()
        {
            try
            {
                string sql = @"
                    SELECT 
                        dv.MaDV AS [Mã DV], 
                        dv.TenDV AS [Tên dịch vụ], 
                        SUM(ct.SoLuong) AS [Tổng số lượng], 
                        SUM(ct.ThanhTien) AS [Tổng tiền]
                    FROM ChiTietPhieuSuDungDV ct
                    INNER JOIN DichVu dv ON ct.MaDV = dv.MaDV
                    INNER JOIN PhieuSuDungDV p ON ct.SoPhieuSDDV = p.SoPhieuSDDV
                    WHERE p.NgaySuDung >= @Tu AND p.NgaySuDung <= @Den
                    GROUP BY dv.MaDV, dv.TenDV";

                using (SqlConnection cn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Tu", dtTu.Value.Date);
                    cmd.Parameters.AddWithValue("@Den", dtDen.Value.Date.AddDays(1).AddSeconds(-1));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDV.DataSource = dt;
                    }
                }

                if (dgvDV.Columns.Contains("Tổng tiền"))
                    dgvDV.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dịch vụ:\n" + ex.Message, "Lỗi");
            }
        }

        private int LaySo(string sql)
        {
            try
            {
                using (SqlConnection cn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Tu", dtTu.Value.Date);
                    cmd.Parameters.AddWithValue("@Den", dtDen.Value.Date.AddDays(1).AddSeconds(-1));
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        private decimal LayTien(string sql)
        {
            try
            {
                using (SqlConnection cn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Tu", dtTu.Value.Date);
                    cmd.Parameters.AddWithValue("@Den", dtDen.Value.Date.AddDays(1).AddSeconds(-1));
                    cn.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
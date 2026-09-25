using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class FrmDanhMuc : Form
    {
        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        // =========================================================
        // HÀM TẢI DỮ LIỆU NỀN THEO YÊU CẦU
        // =========================================================
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            Tai(); // Gọi hàm Tai() đúng như bảng thiết kế
        }

        void Tai()
        {
            // Tải dữ liệu cho 5 DataGridView với tên chuẩn
            dgvKhu.DataSource = ThucHienTruyVan("SELECT MaKhuVuc AS [Mã], TenKhuVuc AS [Tên] FROM KhuVuc");
            dgvNV.DataSource = ThucHienTruyVan("SELECT MaNV AS [Mã], HoTen AS [Họ tên], VaiTro AS [Vai trò], SoDienThoai AS [Điện thoại] FROM NhanVien");
            dgvLoaiTN.DataSource = ThucHienTruyVan("SELECT MaLoaiTN AS [Mã], TenLoaiTN AS [Tên] FROM LoaiTienNghi");
            dgvDV.DataSource = ThucHienTruyVan("SELECT MaDV AS [Mã], TenDV AS [Tên], DonViTinh AS [Đơn vị], DonGia AS [Đơn giá] FROM DichVu");
            dgvQD.DataSource = ThucHienTruyVan("SELECT MaQuyDinh AS [Mã], MaLoaiTN AS [Mã loại], MucDoThietHai AS [Mức độ thiệt hại], MucDenBu AS [Mức đền bù] FROM QuyDinhDenBu");

            // Thiết lập ComboBox Quy định đền bù theo đúng ghi chú của đề
            cboQDLoai.DataSource = ThucHienTruyVan("SELECT MaLoaiTN, TenLoaiTN FROM LoaiTienNghi");
            cboQDLoai.DisplayMember = "TenLoaiTN";
            cboQDLoai.ValueMember = "MaLoaiTN";
        }

        // =========================================================
        // HÀM CHẠY SELECT (GIỮ NGUYÊN CỦA BẠN)
        // =========================================================
        private DataTable ThucHienTruyVan(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = Db.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cn.Open();
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            return dt;
        }

        // =========================================================
        // 5 SỰ KIỆN CLICK CHO 5 NÚT THÊM THEO BẢNG YÊU CẦU
        // =========================================================
        private void btnThemKhu_Click(object sender, EventArgs e)
        {
            // Code gọi hàm ThemKhu
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            // Code gọi hàm ThemNhanVien
        }

        private void btnThemLoaiTN_Click(object sender, EventArgs e)
        {
            // Code gọi hàm ThemLoaiTN
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            // Code gọi hàm ThemDichVu
        }

        private void btnThemQD_Click(object sender, EventArgs e)
        {
            // Code gọi hàm ThemQuyDinh
        }
    }
}
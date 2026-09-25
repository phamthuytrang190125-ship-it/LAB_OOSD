using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;
using System.ComponentModel;

namespace QuanLyKhachSan
{
    public partial class FrmDatPhong : Form
    {
        // Khai báo một danh sách tạm để lưu các phòng khách đang chọn
        private BindingList danhSachPhongChon = new BindingList();

        public FrmDatPhong()
        {
            InitializeComponent();
        }

        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Kênh đặt
            cboKenh.Items.Clear();
            cboKenh.Items.Add("Điện thoại");
            cboKenh.Items.Add("Website");
            cboKenh.Items.Add("Trực tiếp");
            cboKenh.SelectedIndex = 1;

            // Gán dữ liệu cho bảng Phòng đã chọn
            dgvChon.DataSource = danhSachPhongChon;

            LoadPhong();
            LoadPhieuDat();
        }

        // =========================================================
        // TẢI DỮ LIỆU
        // =========================================================
        private void LoadPhong()
        {
            try
            {
                string sql = @"
                    SELECT 
                        p.SoPhong AS [Phòng],
                        kv.TenKhuVuc AS [Khu],
                        p.SoNguoiToiDa AS [Sức chứa],
                        p.DonGiaNgay AS [Đơn giá],
                        p.TrangThai AS [Trạng thái]
                    FROM Phong p
                    INNER JOIN KhuVuc kv ON p.MaKhuVuc = kv.MaKhuVuc
                    ORDER BY p.SoPhong";

                dgvPhong.DataSource = Db.Query(sql);
                dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách phòng.\n" + ex.Message, "Lỗi");
            }
        }

        private void LoadPhieuDat()
        {
            try
            {
                string sql = @"
                    SELECT
                        pd.SoPhieuDat AS [Số phiếu],
                        kh.HoTen AS [Khách],
                        pd.NgayNhan AS [Ngày nhận],
                        pd.NgayTraDuKien AS [Ngày trả dự kiến],
                        pd.TienCoc AS [Cọc],
                        pd.KenhDat AS [Kênh],
                        pd.TrangThai AS [Trạng thái]
                    FROM PhieuDatPhong pd
                    INNER JOIN KhachHang kh ON pd.MaKhach = kh.MaKhach
                    ORDER BY pd.NgayLap DESC";

                dgvPhieu.DataSource = Db.Query(sql); // Chú ý: Đổi tên thành dgvPhieu theo đề
                dgvPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được phiếu đặt.\n" + ex.Message, "Lỗi");
            }
        }

        // =========================================================
        // XỬ LÝ SỰ KIỆN THEO BẢNG YÊU CẦU
        // =========================================================

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm khách (ThemKhach) sẽ được xử lý ở bước sau.", "Thông báo");
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có chọn phòng nào trong dgvPhong chưa
            if (dgvPhong.CurrentRow != null)
            {
                string soPhong = dgvPhong.CurrentRow.Cells["Phòng"].Value.ToString();
                decimal donGia = Convert.ToDecimal(dgvPhong.CurrentRow.Cells["Đơn giá"].Value);
                int soNguoi = (int)numSoNguoi.Value; // Lấy từ NumericUpDown theo đề

                // Thêm vào danh sách chọn
                danhSachPhongChon.Add(new PhongDatItem
                {
                    PhongChon = soPhong,
                    SoNguoi = soNguoi,
                    DonGiaNgay = donGia
                });
            }
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhieu.Text))
            {
                MessageBox.Show("Vui lòng nhập số phiếu đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhach.SelectedValue == null) // Sửa theo đề dùng cboKhach
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (danhSachPhongChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sqlPhieu = @"
                    INSERT INTO PhieuDatPhong (SoPhieuDat, MaKhach, MaNVLeTan, NgayLap, NgayNhan, NgayTraDuKien, TienCoc, KenhDat, TrangThai)
                    VALUES (@SoPhieuDat, @MaKhach, 'NV01', GETDATE(), @NgayNhan, @NgayTra, @TienCoc, @KenhDat, N'Đã đặt')";

                Db.Execute(sqlPhieu,
                    new SqlParameter("@SoPhieuDat", txtSoPhieu.Text.Trim()),
                    new SqlParameter("@MaKhach", cboKhach.SelectedValue),
                    new SqlParameter("@NgayNhan", dtNhan.Value.Date),
                    new SqlParameter("@NgayTra", dtTra.Value.Date),
                    new SqlParameter("@TienCoc", numCoc.Value),
                    new SqlParameter("@KenhDat", cboKenh.Text)
                );

                foreach (var item in danhSachPhongChon)
                {
                    string sqlCT = "INSERT INTO ChiTietDatPhong (SoPhieuDat, SoPhong, SoNguoi) VALUES (@SoPhieu, @SoPhong, @SoNguoi)";
                    Db.Execute(sqlCT,
                        new SqlParameter("@SoPhieu", txtSoPhieu.Text.Trim()),
                        new SqlParameter("@SoPhong", item.PhongChon),
                        new SqlParameter("@SoNguoi", item.SoNguoi)
                    );
                }

                MessageBox.Show("Lập phiếu đặt phòng thành công!");
                LoadPhong();
                LoadPhieuDat();
                danhSachPhongChon.Clear(); // Xóa rổ phòng sau khi đặt xong
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lập phiếu đặt.\n\n" + ex.Message, "Lỗi");
            }
        }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            // Hiển thị chi tiết người lưu trú (sẽ hoàn thiện sau)
        }

        private void btnThemNguoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm người lưu trú.", "Thông báo");
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng nhận phòng (Check-in).", "Thông báo");
        }

        private void btnNoShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Khách vắng mặt (No-Show).", "Thông báo");
        }

        private void tabKhachHang_Click(object sender, EventArgs e)
        {

        }
    }

    // Class phụ hỗ trợ lưu trữ dữ liệu cho bảng dgvChon
    public class PhongDatItem
    {
        public string PhongChon { get; set; }
        public int SoNguoi { get; set; }
        public decimal DonGiaNgay { get; set; }

    }
}
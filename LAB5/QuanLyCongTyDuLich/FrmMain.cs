using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCongTyDuLich
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            ThietKeGiaoDien(); // Gọi hàm tự động vẽ giao diện khi form khởi động
        }

        private void ThietKeGiaoDien()
        {
            // 1. Cài đặt thuộc tính cơ bản cho Form chính
            this.Text = "Hệ Thống Quản Lý Công Ty Du Lịch";
            this.WindowState = FormWindowState.Maximized; // Phóng to toàn màn hình
            this.IsMdiContainer = true; // Biến form này thành Form cha để mở các form khác bên trong
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // 2. Tạo thanh Menu chính (MenuStrip)
            MenuStrip menuChinh = new MenuStrip();
            menuChinh.BackColor = Color.LightSteelBlue; // Màu xanh nhạt chuyên nghiệp
            menuChinh.Padding = new Padding(5, 5, 5, 5);

            // --- TẠO CÁC NHÓM MENU CHÍNH ---

            // Nhóm 1: Hệ thống
            ToolStripMenuItem menuHeThong = new ToolStripMenuItem("Hệ Thống");
            ToolStripMenuItem itemDangXuat = new ToolStripMenuItem("Đăng Xuất");
            ToolStripMenuItem itemThoat = new ToolStripMenuItem("Thoát phần mềm", null, (s, e) => Application.Exit());
            menuHeThong.DropDownItems.Add(itemDangXuat);
            menuHeThong.DropDownItems.Add(new ToolStripSeparator()); // Dòng kẻ ngang
            menuHeThong.DropDownItems.Add(itemThoat);

            // Nhóm 2: Quản lý Danh mục
            ToolStripMenuItem menuDanhMuc = new ToolStripMenuItem("Quản Lý Danh Mục");
            ToolStripMenuItem itemTour = new ToolStripMenuItem("Quản lý Tour & Lịch trình");
            ToolStripMenuItem itemNhanVien = new ToolStripMenuItem("Quản lý Nhân viên (HDV)");
            ToolStripMenuItem itemKhachHang = new ToolStripMenuItem("Quản lý Khách hàng");
            menuDanhMuc.DropDownItems.Add(itemTour);
            menuDanhMuc.DropDownItems.Add(itemNhanVien);
            menuDanhMuc.DropDownItems.Add(itemKhachHang);

            // Nhóm 3: Nghiệp vụ
            ToolStripMenuItem menuNghiepVu = new ToolStripMenuItem("Nghiệp Vụ Du Lịch");
            ToolStripMenuItem itemDangKy = new ToolStripMenuItem("Đăng ký Tour (Lập phiếu)");
            ToolStripMenuItem itemPhanCong = new ToolStripMenuItem("Phân công Hướng dẫn viên");
            ToolStripMenuItem itemThanhToan = new ToolStripMenuItem("Thanh toán & Thu tiền");
            menuNghiepVu.DropDownItems.Add(itemDangKy);
            menuNghiepVu.DropDownItems.Add(itemPhanCong);
            menuNghiepVu.DropDownItems.Add(itemThanhToan);

            // Nhóm 4: Thống kê & Chăm sóc
            ToolStripMenuItem menuThongKe = new ToolStripMenuItem("Thống Kê & Báo Cáo");
            ToolStripMenuItem itemKhaoSat = new ToolStripMenuItem("Kết quả Khảo sát KH");
            ToolStripMenuItem itemDoanhThu = new ToolStripMenuItem("Báo cáo Doanh thu");
            menuThongKe.DropDownItems.Add(itemKhaoSat);
            menuThongKe.DropDownItems.Add(itemDoanhThu);

            // 3. Thêm các nhóm vào thanh Menu chính
            menuChinh.Items.Add(menuHeThong);
            menuChinh.Items.Add(menuDanhMuc);
            menuChinh.Items.Add(menuNghiepVu);
            menuChinh.Items.Add(menuThongKe);

            // 4. Gắn Menu vào Form
            this.MainMenuStrip = menuChinh;
            this.Controls.Add(menuChinh);

            // --- GẮN SỰ KIỆN CLICK MẪU ĐỂ GỌI FORM KHÁC ---
            itemTour.Click += ItemTour_Click;
            itemDangKy.Click += ItemDangKy_Click;
        }

        // Sự kiện khi bấm vào "Quản lý Tour & Lịch trình"
        private void ItemTour_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn vừa bấm vào Quản lý Tour. Sau này tạo FrmQuanLyTour xong sẽ gọi ở đây!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /* Code chuẩn để mở Form con sau này:
            FrmQuanLyTour frm = new FrmQuanLyTour();
            frm.MdiParent = this; // Nhét form con vào trong lòng form cha
            frm.Show();
            */
        }

        // Sự kiện khi bấm vào "Đăng ký Tour"
        private void ItemDangKy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình lập phiếu đăng ký đoàn / lẻ.", "Thông báo");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
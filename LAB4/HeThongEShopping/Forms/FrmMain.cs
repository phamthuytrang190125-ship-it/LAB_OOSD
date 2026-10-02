using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HeThongEShopping
{
    // Viết rõ System.Windows.Forms.Form để không bị lỗi nhầm thư mục "Form" nữa
    public partial class FrmMain : System.Windows.Forms.Form
    {
        // Khai báo các thành phần giao diện
        private MenuStrip menuMain;
        private Label lblTitle;
        private DataGridView dgvData;
        private Panel panelBottom;
        private Label lblStatus;

        public FrmMain()
        {
            InitializeComponent(); // Gọi hàm của file Designer trước
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            // 1. CẤU HÌNH CỬA SỔ CHÍNH
            this.Text = "Hệ thống Quản lý e-SHOPPING";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // 2. TẠO THANH MENU ĐIỀU HƯỚNG
            menuMain = new MenuStrip();
            menuMain.BackColor = Color.LightSteelBlue;
            menuMain.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // -- Nhóm Hệ thống
            ToolStripMenuItem mnuHeThong = new ToolStripMenuItem("Hệ thống");
            ToolStripMenuItem mnuDangNhap = new ToolStripMenuItem("Đăng nhập Khách hàng", null, (s, e) => {
                FrmLogin loginForm = new FrmLogin();
                loginForm.ShowDialog();
            });
            ToolStripMenuItem mnuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());
            mnuHeThong.DropDownItems.Add(mnuDangNhap);
            mnuHeThong.DropDownItems.Add(new ToolStripSeparator());
            mnuHeThong.DropDownItems.Add(mnuThoat);

            // -- Nhóm Danh mục 
            ToolStripMenuItem mnuDanhMuc = new ToolStripMenuItem("Danh mục");
            ToolStripMenuItem mnuSanPham = new ToolStripMenuItem("Sản phẩm");
            ToolStripMenuItem mnuNhomSP = new ToolStripMenuItem("Nhóm Sản phẩm");
            ToolStripMenuItem mnuKhachHang = new ToolStripMenuItem("Khách hàng");
            mnuDanhMuc.DropDownItems.Add(mnuSanPham);
            mnuDanhMuc.DropDownItems.Add(mnuNhomSP);
            mnuDanhMuc.DropDownItems.Add(mnuKhachHang);

            // -- Nhóm Nghiệp vụ
            ToolStripMenuItem mnuNghiepVu = new ToolStripMenuItem("Nghiệp vụ");
            ToolStripMenuItem mnuGioHang = new ToolStripMenuItem("Xem Giỏ hàng");
            ToolStripMenuItem mnuDatHang = new ToolStripMenuItem("Tạo Đơn đặt hàng");
            ToolStripMenuItem mnuThanhToan = new ToolStripMenuItem("Thanh toán (Kiểm tra thẻ)");
            mnuNghiepVu.DropDownItems.Add(mnuGioHang);
            mnuNghiepVu.DropDownItems.Add(mnuDatHang);
            mnuNghiepVu.DropDownItems.Add(mnuThanhToan);

            menuMain.Items.Add(mnuHeThong);
            menuMain.Items.Add(mnuDanhMuc);
            menuMain.Items.Add(mnuNghiepVu);

            // 3. TẠO TIÊU ĐỀ
            lblTitle = new Label();
            lblTitle.Text = "BẢNG ĐIỀU KHIỂN";
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;

            // 4. TẠO BẢNG LƯỚI HIỂN THỊ DỮ LIỆU
            dgvData = new DataGridView();
            dgvData.Dock = DockStyle.Fill;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.BackgroundColor = Color.White;
            dgvData.AllowUserToAddRows = false;
            dgvData.BorderStyle = BorderStyle.None;

            // 5. TẠO THANH TRẠNG THÁI
            panelBottom = new Panel();
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 30;
            panelBottom.BackColor = Color.LightGray;

            lblStatus = new Label();
            lblStatus.Text = "Sẵn sàng.";
            lblStatus.Dock = DockStyle.Left;
            lblStatus.Width = 600;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            panelBottom.Controls.Add(lblStatus);

            // 6. RÁP CÁC MẢNH VÀO FORM
            this.Controls.Add(dgvData);
            this.Controls.Add(panelBottom);
            this.Controls.Add(lblTitle);
            this.Controls.Add(menuMain);
            this.MainMenuStrip = menuMain;

            // 7. GẮN SỰ KIỆN GỌI DATABASE CHO NHÓM DANH MỤC
            mnuSanPham.Click += (s, e) => {
                lblTitle.Text = "DANH SÁCH SẢN PHẨM";
                LoadDataToGrid("SELECT * FROM SanPham");
            };

            mnuKhachHang.Click += (s, e) => {
                lblTitle.Text = "DANH SÁCH KHÁCH HÀNG";
                LoadDataToGrid("SELECT * FROM KhachHang");
            };

            mnuNhomSP.Click += (s, e) => {
                lblTitle.Text = "NHÓM SẢN PHẨM";
                LoadDataToGrid("SELECT * FROM NhomSanPham");
            };

            // 8. GẮN SỰ KIỆN GỌI DATABASE CHO NHÓM NGHIỆP VỤ
            mnuGioHang.Click += (s, e) => {
                lblTitle.Text = "CHI TIẾT GIỎ HÀNG";
                LoadDataToGrid("SELECT * FROM ChiTietGioHang");
            };

            mnuDatHang.Click += (s, e) => {
                lblTitle.Text = "DANH SÁCH ĐƠN ĐẶT HÀNG";
                LoadDataToGrid("SELECT * FROM DonHang");
            };

            mnuThanhToan.Click += (s, e) => {
                lblTitle.Text = "THÔNG TIN THẺ TÍN DỤNG";
                LoadDataToGrid("SELECT * FROM TheTinDung");
            };
        }

        // Hàm dùng chung để chạy câu lệnh SQL và đổ dữ liệu lên Grid
        private void LoadDataToGrid(string query)
        {
            string conString = "Data Source=192.168.22.51:1521/FREE;User Id=ptttrang;Password=123456;";
            try
            {
                lblStatus.Text = "Đang kết nối cơ sở dữ liệu Oracle...";
                using (OracleConnection con = new OracleConnection(conString))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvData.DataSource = dt;
                    lblStatus.Text = $"Tải thành công {dt.Rows.Count} dòng dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Oracle: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Trạng thái: Lỗi kết nối!";
            }
        }
    }
}
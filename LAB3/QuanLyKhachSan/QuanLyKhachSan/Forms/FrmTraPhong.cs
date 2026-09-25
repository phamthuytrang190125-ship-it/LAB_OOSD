using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class FrmTraPhong : Form
    {
        // Tạo danh sách tạm để lưu các món tiện nghi bị hư hỏng (chuẩn bị đền bù)
        private BindingList danhSachDenBu = new BindingList();

        public FrmTraPhong()
        {
            InitializeComponent();
        }

        private void FrmTraPhong_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Hình thức thanh toán
            cboHT.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" });
            cboHT.SelectedIndex = 2; // Mặc định chọn 'Thẻ' giống hình thầy

            // Gắn danh sách tạm vào bảng dgvDBChon
            dgvDBChon.DataSource = danhSachDenBu;
        }

        // =========================================================
        // 1. dgvPhong_SelectionChanged -> Nạp tiện nghi phòng
        // =========================================================
        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            // Logic: Nạp danh sách tiện nghi tương ứng với phòng đang chọn để nhân viên kiểm tra
        }

        // =========================================================
        // 2. btnThemDB_Click -> Thêm DenBuItem vào lưới
        // =========================================================
        private void btnThemDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMucDo.Text))
            {
                MessageBox.Show("Vui lòng nhập mức độ hư hỏng!", "Thông báo");
                return;
            }

            danhSachDenBu.Add(new DenBuItem
            {
                MucDo = txtMucDo.Text,
                SoTien = numDenBu.Value
            });

            MessageBox.Show("Đã thêm vào danh sách chờ đền bù.");
        }

        // =========================================================
        // 3. btnLapDB_Click -> LapPhieuDenBu
        // =========================================================
        private void btnLapDB_Click(object sender, EventArgs e)
        {
            if (danhSachDenBu.Count == 0)
            {
                MessageBox.Show("Chưa có mục đền bù nào!", "Cảnh báo");
                return;
            }
            MessageBox.Show("Lập phiếu đền bù thành công cho phiếu: " + txtSoDB.Text);
            danhSachDenBu.Clear();
        }

        // =========================================================
        // 4. btnLapHD_Click -> LapHoaDon
        // =========================================================
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoHD.Text))
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn!", "Cảnh báo");
                return;
            }
            MessageBox.Show("Lập hóa đơn thành công! Số ngày tính tiền: " + numSoNgay.Value.ToString());
        }

        // =========================================================
        // 5. dgvHD_SelectionChanged -> Chọn hóa đơn
        // =========================================================
        private void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
            // Logic: Khi click vào 1 dòng hóa đơn, hiển thị chi tiết số tiền xuống ô numTienTT
        }

        // =========================================================
        // 6. btnThanhToan_Click -> ThanhToan
        // =========================================================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Thanh toán thành công {numTienTT.Value:N0} VNĐ qua {cboHT.Text}!");
        }

        // =========================================================
        // 7. btnTraPhong_Click -> TraPhong
        // =========================================================
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Giải phóng phòng! Hoàn tất trả phòng.", "Thành công");
        }
    }

    // Class phụ hỗ trợ lưu trữ dữ liệu cho bảng dgvDBChon
    public class DenBuItem
    {
        public string MucDo { get; set; }
        public decimal SoTien { get; set; }
    }
}
using System.Data;

namespace QuanLyKhachSan.Services
{
    public class KetQuaXuLy
    {
        public string ThongBao { get; set; } = "Thao tác giả lập thành công!";
        public bool ThanhCong { get; set; } = true;
    }

    public class DanhMucService
    {
        // Tạo dữ liệu giả cho các bảng đỡ báo lỗi
        public DataTable LayKhuVuc() => new DataTable();
        public DataTable LayNhanVien() => new DataTable();
        public DataTable LayLoaiTienNghi() => new DataTable();
        public DataTable LayDichVu() => new DataTable();
        public DataTable LayQuyDinhDenBu() => new DataTable();

        // Các hàm thêm giả lập
        public KetQuaXuLy ThemKhu(string a, string b) => new KetQuaXuLy();
        public KetQuaXuLy ThemNhanVien(string a, string b, string c, string d) => new KetQuaXuLy();
        public KetQuaXuLy ThemLoaiTN(string a, string b) => new KetQuaXuLy();
        public KetQuaXuLy ThemDichVu(string a, string b, string c, decimal d) => new KetQuaXuLy();
        public KetQuaXuLy ThemQuyDinh(string a, string b, string c, decimal d) => new KetQuaXuLy();
    }
}
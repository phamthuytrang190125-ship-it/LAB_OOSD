namespace QuanLyThuVien.Services
{
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }

        public static KetQuaXuLy Ok(string msg = "") { return new KetQuaXuLy { ThanhCong = true, ThongBao = msg }; }
        public static KetQuaXuLy Loi(string msg) { return new KetQuaXuLy { ThanhCong = false, ThongBao = msg }; }
    }
}
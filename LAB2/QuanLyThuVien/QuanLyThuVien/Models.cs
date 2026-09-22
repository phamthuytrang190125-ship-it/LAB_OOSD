using System;

namespace QuanLyThuVien
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class TheLoai
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }

    public class NhaXuatBan
    {
        public string MaNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class DauSach
    {
        public string MaDauSach { get; set; }
        public string TenSach { get; set; }
        public int NamXuatBan { get; set; }
        public int SoLuongHienCo { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNhaXuatBan { get; set; }
    }

    public class DocGia
    {
        public string MaDocGia { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Phai { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Anh { get; set; }
    }

    public class PhieuMuon
    {
        public string MaPhieu { get; set; }
        public string MaDocGia { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HenTra { get; set; }
    }
}
SET DEFINE OFF;

BEGIN
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE TheTinDung CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE ChiTietDonHang CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE DonHang CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE ChiTietGioHang CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE GioHang CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE SanPham CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE NhomSanPham CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE KhachHang CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
END;
/

CREATE TABLE NhomSanPham (
    MaNhom      VARCHAR2(20) PRIMARY KEY,
    TenNhom     VARCHAR2(100) NOT NULL
);

CREATE TABLE KhachHang (
    MaKH            VARCHAR2(20) PRIMARY KEY,
    HoTen           VARCHAR2(100) NOT NULL,
    NgaySinh        DATE,
    CMND_Passport   VARCHAR2(20) UNIQUE,
    DiaChi          VARCHAR2(255),
    DienThoai       VARCHAR2(20),
    TenDangNhap     VARCHAR2(50) UNIQUE NOT NULL,
    MatKhau         VARCHAR2(100) NOT NULL,
    Email           VARCHAR2(100) UNIQUE
);

CREATE TABLE SanPham (
    MaSP            VARCHAR2(20) PRIMARY KEY,
    MaNhom          VARCHAR2(20) NOT NULL,
    TenSP           VARCHAR2(200) NOT NULL,
    NhaSanXuat      VARCHAR2(100),
    HinhAnh         VARCHAR2(255), 
    MoTa            CLOB,          
    ThongSoKyThuat  CLOB,
    GiaBan          NUMBER(18, 2) NOT NULL,
    TinhTrang       VARCHAR2(50),  
    CONSTRAINT FK_SP_Nhom FOREIGN KEY (MaNhom) REFERENCES NhomSanPham(MaNhom)
);

CREATE TABLE GioHang (
    MaGioHang       VARCHAR2(20) PRIMARY KEY,
    MaKH            VARCHAR2(20) UNIQUE NOT NULL,
    CONSTRAINT FK_GH_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietGioHang (
    MaGioHang       VARCHAR2(20),
    MaSP            VARCHAR2(20),
    SoLuong         NUMBER(10) DEFAULT 1 NOT NULL,
    PRIMARY KEY (MaGioHang, MaSP),
    CONSTRAINT FK_CTGH_GH FOREIGN KEY (MaGioHang) REFERENCES GioHang(MaGioHang),
    CONSTRAINT FK_CTGH_SP FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE DonHang (
    SoDDH               VARCHAR2(20) PRIMARY KEY,
    MaKH                VARCHAR2(20) NOT NULL,
    HoTenNguoiNhan      VARCHAR2(100) NOT NULL,
    DiaChiNguoiNhan     VARCHAR2(255) NOT NULL,
    DienThoaiNguoiNhan  VARCHAR2(20) NOT NULL,
    LoaiPhieuDat        VARCHAR2(50), 
    PhiGiaoHang         NUMBER(18, 2) DEFAULT 0,
    TongTien            NUMBER(18, 2) NOT NULL,
    ThoiDiemDat         TIMESTAMP DEFAULT SYSTIMESTAMP,
    CONSTRAINT FK_DH_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietDonHang (
    SoDDH           VARCHAR2(20),
    MaSP            VARCHAR2(20),
    SoLuong         NUMBER(10) NOT NULL,
    DonGia          NUMBER(18, 2) NOT NULL,
    PRIMARY KEY (SoDDH, MaSP),
    CONSTRAINT FK_CTDH_DH FOREIGN KEY (SoDDH) REFERENCES DonHang(SoDDH),
    CONSTRAINT FK_CTDH_SP FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE TheTinDung (
    SoDDH           VARCHAR2(20) PRIMARY KEY, 
    SoThe           VARCHAR2(20) NOT NULL,
    LoaiThe         VARCHAR2(50),             
    NgayHetHan      DATE,
    HoTenChuThe     VARCHAR2(100),
    MaCSV           VARCHAR2(4),              
    CONSTRAINT FK_The_DH FOREIGN KEY (SoDDH) REFERENCES DonHang(SoDDH)
);

INSERT INTO NhomSanPham (MaNhom, TenNhom) VALUES ('N01', 'Laptop & Phụ kiện');
INSERT INTO NhomSanPham (MaNhom, TenNhom) VALUES ('N02', 'Điện thoại & Tablet');
INSERT INTO NhomSanPham (MaNhom, TenNhom) VALUES ('N03', 'Thiết bị Âm thanh');
INSERT INTO NhomSanPham (MaNhom, TenNhom) VALUES ('N04', 'Đồng hồ thông minh');
INSERT INTO NhomSanPham (MaNhom, TenNhom) VALUES ('N05', 'Thiết bị Gia dụng thông minh');

INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CMND_Passport, DiaChi, DienThoai, TenDangNhap, MatKhau, Email) 
VALUES ('KH01', 'Nguyễn Văn An', TO_DATE('1998-03-12', 'YYYY-MM-DD'), '079198001234', '123 Lê Văn Việt, Phường Hiệp Phú, TP. Thủ Đức', '0901234567', 'annguyen', 'pass123', 'an.nguyen@gmail.com');

INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CMND_Passport, DiaChi, DienThoai, TenDangNhap, MatKhau, Email) 
VALUES ('KH02', 'Trần Thị Mỹ Duyên', TO_DATE('2001-07-25', 'YYYY-MM-DD'), '079201005678', '45 Đinh Tiên Hoàng, Phường Bến Nghé, Quận 1', '0918888222', 'duyentran', 'pass456', 'duyen.tran@yahoo.com');

INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CMND_Passport, DiaChi, DienThoai, TenDangNhap, MatKhau, Email) 
VALUES ('KH03', 'Lê Hoàng Long', TO_DATE('1995-11-02', 'YYYY-MM-DD'), '079195009911', '78 Nguyễn Văn Linh, Phường Tân Phong, Quận 7', '0983334444', 'longle', 'pass789', 'long.le@fpt.edu.vn');

INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CMND_Passport, DiaChi, DienThoai, TenDangNhap, MatKhau, Email) 
VALUES ('KH04', 'Phạm Thị Thuỳ Trang', TO_DATE('2002-01-19', 'YYYY-MM-DD'), '079202019012', '12 Nguyễn Văn Bảo, Phường 4, Quận Gò Vấp', '0975556677', 'ptttrang', '123456', 'trang.pham@gmail.com');

INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CMND_Passport, DiaChi, DienThoai, TenDangNhap, MatKhau, Email) 
VALUES ('KH05', 'Đỗ Minh Quân', TO_DATE('1999-09-15', 'YYYY-MM-DD'), '079199003344', '90 Cộng Hòa, Phường 4, Quận Tân Bình', '0939991122', 'quando', 'quan123', 'quan.do@gmail.com');

INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, HinhAnh, MoTa, ThongSoKyThuat, GiaBan, TinhTrang) 
VALUES ('SP01', 'N01', 'MacBook Air M2 2022', 'Apple', 'macbook_m2.jpg', 'Laptop thiết kế siêu mỏng nhẹ, pin sử dụng lên đến 18 tiếng', 'Chip Apple M2, RAM 8GB, SSD 256GB', 24990000, 'Còn hàng');

INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, HinhAnh, MoTa, ThongSoKyThuat, GiaBan, TinhTrang) 
VALUES ('SP02', 'N02', 'iPhone 15 Pro 128GB', 'Apple', 'iphone15pro.jpg', 'Khung máy bằng Titanium bền bỉ, chip A17 Pro hiệu năng cực đỉnh', 'Màn hình 6.1 inch OLED, Camera 48MP', 26990000, 'Còn hàng');

INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, HinhAnh, MoTa, ThongSoKyThuat, GiaBan, TinhTrang) 
VALUES ('SP03', 'N01', 'Laptop ASUS Zenbook 14 OLED', 'ASUS', 'asus_zenbook.jpg', 'Laptop văn phòng cao cấp, màn hình OLED hiển thị màu sắc cực chuẩn', 'Intel Core i5-1340P, RAM 16GB, SSD 512GB', 21500000, 'Còn hàng');

INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, HinhAnh, MoTa, ThongSoKyThuat, GiaBan, TinhTrang) 
VALUES ('SP04', 'N03', 'Tai nghe chống ồn Sony WH-1000XM5', 'Sony', 'sony_xm5.jpg', 'Công nghệ chống ồn chủ động hàng đầu, âm thanh sống động', 'Pin 30 giờ, Sạc nhanh, Chống ồn AI', 7490000, 'Còn hàng');

INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, HinhAnh, MoTa, ThongSoKyThuat, GiaBan, TinhTrang) 
VALUES ('SP05', 'N04', 'Apple Watch Series 9 GPS 41mm', 'Apple', 'aw_s9.jpg', 'Đồng hồ thông minh hỗ trợ theo dõi sức khỏe và thể chất toàn diện', 'Chip S9 SiP, Màn hình sáng 2000 nits', 9990000, 'Còn hàng');

INSERT INTO GioHang (MaGioHang, MaKH) VALUES ('GH01', 'KH01');
INSERT INTO GioHang (MaGioHang, MaKH) VALUES ('GH02', 'KH02');
INSERT INTO GioHang (MaGioHang, MaKH) VALUES ('GH03', 'KH03');
INSERT INTO GioHang (MaGioHang, MaKH) VALUES ('GH04', 'KH04');

INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES ('GH01', 'SP01', 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES ('GH01', 'SP04', 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES ('GH02', 'SP02', 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES ('GH03', 'SP03', 2);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES ('GH04', 'SP05', 1);

INSERT INTO DonHang (SoDDH, MaKH, HoTenNguoiNhan, DiaChiNguoiNhan, DienThoaiNguoiNhan, LoaiPhieuDat, PhiGiaoHang, TongTien, ThoiDiemDat) 
VALUES ('DH01', 'KH01', 'Nguyễn Văn An', '123 Lê Văn Việt, Phường Hiệp Phú, TP. Thủ Đức', '0901234567', 'Giao hàng tiêu chuẩn', 0, 32480000, SYSTIMESTAMP - 3);

INSERT INTO DonHang (SoDDH, MaKH, HoTenNguoiNhan, DiaChiNguoiNhan, DienThoaiNguoiNhan, LoaiPhieuDat, PhiGiaoHang, TongTien, ThoiDiemDat) 
VALUES ('DH02', 'KH02', 'Trần Thị Mỹ Duyên', '45 Đinh Tiên Hoàng, Phường Bến Nghé, Quận 1', '0918888222', 'Giao hỏa tốc 2H', 30000, 27020000, SYSTIMESTAMP - 2);

INSERT INTO DonHang (SoDDH, MaKH, HoTenNguoiNhan, DiaChiNguoiNhan, DienThoaiNguoiNhan, LoaiPhieuDat, PhiGiaoHang, TongTien, ThoiDiemDat) 
VALUES ('DH03', 'KH03', 'Lê Hoàng Long', '78 Nguyễn Văn Linh, Phường Tân Phong, Quận 7', '0983334444', 'Giao hàng tiêu chuẩn', 0, 43000000, SYSTIMESTAMP - 1);

INSERT INTO DonHang (SoDDH, MaKH, HoTenNguoiNhan, DiaChiNguoiNhan, DienThoaiNguoiNhan, LoaiPhieuDat, PhiGiaoHang, TongTien, ThoiDiemDat) 
VALUES ('DH04', 'KH04', 'Phạm Thị Thuỳ Trang', '12 Nguyễn Văn Bảo, Phường 4, Quận Gò Vấp', '0975556677', 'Giao hỏa tốc 2H', 25000, 10015000, SYSTIMESTAMP);

INSERT INTO ChiTietDonHang (SoDDH, MaSP, SoLuong, DonGia) VALUES ('DH01', 'SP01', 1, 24990000);
INSERT INTO ChiTietDonHang (SoDDH, MaSP, SoLuong, DonGia) VALUES ('DH01', 'SP04', 1, 7490000);
INSERT INTO ChiTietDonHang (SoDDH, MaSP, SoLuong, DonGia) VALUES ('DH02', 'SP02', 1, 26990000);
INSERT INTO ChiTietDonHang (SoDDH, MaSP, SoLuong, DonGia) VALUES ('DH03', 'SP03', 1, 21500000);
INSERT INTO ChiTietDonHang (SoDDH, MaSP, SoLuong, DonGia) VALUES ('DH04', 'SP05', 1, 9990000);

INSERT INTO TheTinDung (SoDDH, SoThe, LoaiThe, NgayHetHan, HoTenChuThe, MaCSV) 
VALUES ('DH01', '4222111100001234', 'Visa', TO_DATE('2029-05-31', 'YYYY-MM-DD'), 'NGUYEN VAN AN', '482');

INSERT INTO TheTinDung (SoDDH, SoThe, LoaiThe, NgayHetHan, HoTenChuThe, MaCSV) 
VALUES ('DH02', '5412750000005678', 'MasterCard', TO_DATE('2027-10-31', 'YYYY-MM-DD'), 'TRAN THI MY DUYEN', '911');

INSERT INTO TheTinDung (SoDDH, SoThe, LoaiThe, NgayHetHan, HoTenChuThe, MaCSV) 
VALUES ('DH03', '4332790011119999', 'Visa', TO_DATE('2030-12-31', 'YYYY-MM-DD'), 'LE HOANG LONG', '256');

INSERT INTO TheTinDung (SoDDH, SoThe, LoaiThe, NgayHetHan, HoTenChuThe, MaCSV) 
VALUES ('DH04', '9704060012345678', 'Napas', TO_DATE('2028-08-31', 'YYYY-MM-DD'), 'PHAM THI THUY TRANG', '638');

-- LƯU LẠI DỮ LIỆU VĨNH VIỄN
COMMIT;
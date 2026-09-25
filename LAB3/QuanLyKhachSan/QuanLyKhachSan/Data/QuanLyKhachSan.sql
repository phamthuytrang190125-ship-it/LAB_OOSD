IF DB_ID(N'QuanLyKhachSan') IS NULL CREATE DATABASE QuanLyKhachSan;
GO
USE QuanLyKhachSan;
GO

-- 1.XÓA B?NG C?(N?U CÓ) ?? KHÔNG B? L?I KHI CH?Y L?I
IF OBJECT_ID('ThanhToan','U') IS NOT NULL DROP TABLE ThanhToan;
IF OBJECT_ID('HoaDon','U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('ChiTietPhieuDenBu','U') IS NOT NULL DROP TABLE ChiTietPhieuDenBu;
IF OBJECT_ID('PhieuDenBu','U') IS NOT NULL DROP TABLE PhieuDenBu;
IF OBJECT_ID('QuyDinhDenBu','U') IS NOT NULL DROP TABLE QuyDinhDenBu;
IF OBJECT_ID('ChiTietPhieuSuDungDV','U') IS NOT NULL DROP TABLE ChiTietPhieuSuDungDV;
IF OBJECT_ID('PhieuSuDungDV','U') IS NOT NULL DROP TABLE PhieuSuDungDV;
IF OBJECT_ID('DichVu','U') IS NOT NULL DROP TABLE DichVu;
IF OBJECT_ID('NguoiLuuTru','U') IS NOT NULL DROP TABLE NguoiLuuTru;
IF OBJECT_ID('ChiTietDatPhong','U') IS NOT NULL DROP TABLE ChiTietDatPhong;
IF OBJECT_ID('PhieuDatPhong','U') IS NOT NULL DROP TABLE PhieuDatPhong;
IF OBJECT_ID('KhachHang','U') IS NOT NULL DROP TABLE KhachHang;
IF OBJECT_ID('PhieuLapDat','U') IS NOT NULL DROP TABLE PhieuLapDat;
IF OBJECT_ID('TienNghi','U') IS NOT NULL DROP TABLE TienNghi;
IF OBJECT_ID('LoaiTienNghi','U') IS NOT NULL DROP TABLE LoaiTienNghi;
IF OBJECT_ID('Phong','U') IS NOT NULL DROP TABLE Phong;
IF OBJECT_ID('KhuVuc','U') IS NOT NULL DROP TABLE KhuVuc;
IF OBJECT_ID('NhanVien','U') IS NOT NULL DROP TABLE NhanVien;
GO

-- 2.T?O C?U TRÚC 18 B?NG
CREATE TABLE NhanVien(
    MaNV varchar(20) NOT NULL PRIMARY KEY,
	HoTen nvarchar(120) NOT NULL,
	VaiTro nvarchar(50) NOT NULL,
	SoDienThoai varchar(20) NULL
);

CREATE TABLE KhuVuc(
    MaKhuVuc varchar(20) NOT NULL PRIMARY KEY,
	TenKhuVuc nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE Phong(
    SoPhong varchar(20) NOT NULL PRIMARY KEY,
	MaKhuVuc varchar(20) NOT NULL,
	SoNguoiToiDa int NOT NULL CHECK(SoNguoiToiDa > 0),
	DonGiaNgay decimal(18,2) NOT NULL CHECK(DonGiaNgay >= 0),
	TrangThai nvarchar(30) NOT NULL DEFAULT N'Tr?ng',
	CONSTRAINT CK_Phong_TrangThai CHECK(TrangThai IN (N'Tr?ng', N'?ã ??t', N'?ang ?', N'B?o trì')),
	CONSTRAINT FK_Phong_KhuVuc FOREIGN KEY(MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE LoaiTienNghi(
    MaLoaiTN varchar(20) NOT NULL PRIMARY KEY,
	TenLoaiTN nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE TienNghi(
    MaTienNghi varchar(30) NOT NULL PRIMARY KEY,
	MaLoaiTN varchar(20) NOT NULL,
	SoThuTu int NOT NULL,
	TinhTrangHienTai nvarchar(100) NULL,
	CONSTRAINT UQ_TienNghi_Loai_STT UNIQUE(MaLoaiTN, SoThuTu),
	CONSTRAINT FK_TienNghi_Loai FOREIGN KEY(MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN)
);

CREATE TABLE PhieuLapDat(
    SoPhieuLapDat varchar(30) NOT NULL PRIMARY KEY,
	MaTienNghi varchar(30) NOT NULL,
	SoPhong varchar(20) NOT NULL,
	NgayLap date NOT NULL,
	TinhTrang nvarchar(100) NOT NULL,
	MaNV varchar(20) NOT NULL,
	GhiChu nvarchar(250) NULL,
	CONSTRAINT UQ_PhieuLapDat_ThietBi_Ngay UNIQUE(MaTienNghi, NgayLap),
	CONSTRAINT FK_PhieuLapDat_TienNghi FOREIGN KEY(MaTienNghi) REFERENCES TienNghi(MaTienNghi),
	CONSTRAINT FK_PhieuLapDat_Phong FOREIGN KEY(SoPhong) REFERENCES Phong(SoPhong),
	CONSTRAINT FK_PhieuLapDat_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE KhachHang(
    MaKhach varchar(20) NOT NULL PRIMARY KEY,
	HoTen nvarchar(120) NOT NULL,
	SoCMND varchar(30) NOT NULL UNIQUE,
	QuocTich nvarchar(80) NOT NULL,
	SoDienThoai varchar(20) NULL
);

CREATE TABLE PhieuDatPhong(
    SoPhieuDat varchar(30) NOT NULL PRIMARY KEY,
	MaKhach varchar(20) NOT NULL,
	MaNVLeTan varchar(20) NOT NULL,
	NgayLap datetime NOT NULL,
	NgayNhan date NOT NULL,
	NgayTraDuKien date NOT NULL,
	TienCoc decimal(18,2) NOT NULL DEFAULT 0 CHECK(TienCoc >= 0),
	KenhDat nvarchar(20) NOT NULL,
	TrangThai nvarchar(30) NOT NULL DEFAULT N'?ã ??t',
	NgayNhanThucTe datetime NULL,
	NgayTraThucTe datetime NULL,
	CONSTRAINT CK_PhieuDat_Ngay CHECK(NgayTraDuKien >= NgayNhan),
	CONSTRAINT CK_PhieuDat_Kenh CHECK(KenhDat IN (N'?i?n tho?i', N'Website', N'Tr?c ti?p')),
	CONSTRAINT CK_PhieuDat_TrangThai CHECK(TrangThai IN (N'?ã ??t', N'?ang ?', N'?ã tr?', N'No-show', N'H?y')),
	CONSTRAINT FK_PhieuDat_Khach FOREIGN KEY(MaKhach) REFERENCES KhachHang(MaKhach),
	CONSTRAINT FK_PhieuDat_NV FOREIGN KEY(MaNVLeTan) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietDatPhong(
    SoPhieuDat varchar(30) NOT NULL,
	SoPhong varchar(20) NOT NULL,
	SoNguoi int NOT NULL CHECK(SoNguoi > 0),
	PRIMARY KEY(SoPhieuDat, SoPhong),
	CONSTRAINT FK_CTDat_Phieu FOREIGN KEY(SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
	CONSTRAINT FK_CTDat_Phong FOREIGN KEY(SoPhong) REFERENCES Phong(SoPhong)
);

CREATE TABLE NguoiLuuTru(
    MaNguoiLT int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SoPhieuDat varchar(30) NOT NULL,
	SoPhong varchar(20) NOT NULL,
	HoTen nvarchar(120) NOT NULL,
	SoCMND varchar(30) NOT NULL,
	QuocTich nvarchar(80) NOT NULL,
	CONSTRAINT FK_NguoiLT_CTDat FOREIGN KEY(SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong)
);

CREATE TABLE DichVu(
    MaDV varchar(20) NOT NULL PRIMARY KEY,
	TenDV nvarchar(120) NOT NULL,
	DonViTinh nvarchar(40) NOT NULL,
	DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0)
);

CREATE TABLE PhieuSuDungDV(
    SoPhieuSDDV varchar(30) NOT NULL PRIMARY KEY,
	SoPhieuDat varchar(30) NOT NULL,
	SoPhong varchar(20) NOT NULL,
	NgaySuDung date NOT NULL,
	MaNV varchar(20) NOT NULL,
	CONSTRAINT UQ_PhieuSDDV_PhongNgay UNIQUE(SoPhieuDat, SoPhong, NgaySuDung),
	CONSTRAINT FK_PhieuSDDV_CTDat FOREIGN KEY(SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
	CONSTRAINT FK_PhieuSDDV_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuSuDungDV(
    SoPhieuSDDV varchar(30) NOT NULL,
	MaDV varchar(20) NOT NULL,
	SoLuong int NOT NULL CHECK(SoLuong > 0),
	DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
	ThanhTien AS (CONVERT(decimal(18,2), SoLuong * DonGia)) PERSISTED,
	PRIMARY KEY(SoPhieuSDDV, MaDV),
	CONSTRAINT FK_CTSDDV_Phieu FOREIGN KEY(SoPhieuSDDV) REFERENCES PhieuSuDungDV(SoPhieuSDDV),
	CONSTRAINT FK_CTSDDV_DV FOREIGN KEY(MaDV) REFERENCES DichVu(MaDV)
);

CREATE TABLE QuyDinhDenBu(
    MaQuyDinh varchar(30) NOT NULL PRIMARY KEY,
	MaLoaiTN varchar(20) NOT NULL,
	MucDoThietHai nvarchar(80) NOT NULL,
	MucDenBu decimal(18,2) NOT NULL CHECK(MucDenBu >= 0),
	CONSTRAINT UQ_QDDB_Loai_MucDo UNIQUE(MaLoaiTN, MucDoThietHai),
	CONSTRAINT FK_QDDB_Loai FOREIGN KEY(MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN)
);

CREATE TABLE PhieuDenBu(
    SoPhieuDenBu varchar(30) NOT NULL PRIMARY KEY,
	SoPhieuDat varchar(30) NOT NULL,
	SoPhong varchar(20) NOT NULL,
	NgayLap datetime NOT NULL,
	MaNV varchar(20) NOT NULL,
	TongTien decimal(18,2) NOT NULL DEFAULT 0 CHECK(TongTien >= 0),
	CONSTRAINT FK_PhieuDB_CTDat FOREIGN KEY(SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
	CONSTRAINT FK_PhieuDB_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuDenBu(
    SoPhieuDenBu varchar(30) NOT NULL,
	MaTienNghi varchar(30) NOT NULL,
	MucDoThietHai nvarchar(80) NOT NULL,
	SoTien decimal(18,2) NOT NULL CHECK(SoTien >= 0),
	PRIMARY KEY(SoPhieuDenBu, MaTienNghi),
	CONSTRAINT FK_CTDB_Phieu FOREIGN KEY(SoPhieuDenBu) REFERENCES PhieuDenBu(SoPhieuDenBu),
	CONSTRAINT FK_CTDB_TienNghi FOREIGN KEY(MaTienNghi) REFERENCES TienNghi(MaTienNghi)
);

CREATE TABLE HoaDon(
    SoHoaDon varchar(30) NOT NULL PRIMARY KEY,
	SoPhieuDat varchar(30) NOT NULL UNIQUE,
	NgayLap datetime NOT NULL,
	MaNV varchar(20) NOT NULL,
	SoNgayTinhTien int NOT NULL CHECK(SoNgayTinhTien > 0),
	TienPhong decimal(18,2) NOT NULL CHECK(TienPhong >= 0),
	TienDichVu decimal(18,2) NOT NULL CHECK(TienDichVu >= 0),
	TongTien AS (CONVERT(decimal(18,2), TienPhong + TienDichVu)) PERSISTED,
	TrangThai nvarchar(30) NOT NULL DEFAULT N'Ch?a thanh toán',
	CONSTRAINT CK_HoaDon_TrangThai CHECK(TrangThai IN (N'Ch?a thanh toán', N'?ã thanh toán')),
	CONSTRAINT FK_HoaDon_PhieuDat FOREIGN KEY(SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
	CONSTRAINT FK_HoaDon_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ThanhToan(
    MaThanhToan varchar(30) NOT NULL PRIMARY KEY,
	SoHoaDon varchar(30) NOT NULL,
	NgayThanhToan datetime NOT NULL,
	HinhThuc nvarchar(30) NOT NULL,
	SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
	CONSTRAINT CK_ThanhToan_HinhThuc CHECK(HinhThuc IN (N'Ti?n m?t', N'Chuy?n kho?n', N'Th?', N'Ví ?i?n t?')),
	CONSTRAINT FK_ThanhToan_HoaDon FOREIGN KEY(SoHoaDon) REFERENCES HoaDon(SoHoaDon)
);
GO

-- 3.T?O INDEX
CREATE INDEX IX_PhieuDatPhong_Ngay ON PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);
CREATE INDEX IX_CTDat_Phong ON ChiTietDatPhong(SoPhong, SoPhieuDat);
CREATE INDEX IX_PhieuSDDV_DatPhong ON PhieuSuDungDV(SoPhieuDat, SoPhong, NgaySuDung);
GO

-- ==========================================
--4.INSERT D? LI?U ??Y ?? CHO 18 B?NG
-- ==========================================

-- B?ng 1: Nhân viên
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES
('NV01', N'Nguy?n Thu Hà', N'L? tân','0901000001'),
('NV02', N'Tr?n Minh An', N'Ph?c v? phòng', '0901000002'),
('NV03', N'Lê Hoàng Nam', N'Thanh toán', '0901000003');

--B?ng 2: Khu V?c
INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES 
('A', N'Khu A'),
('B', N'Khu B');

--B?ng 3: Phòng
INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES
('A101','A',2,600000, N'?ã ??t'),
('A102', 'A', 3, 800000, N'Tr?ng'),
('B201', 'B', 4, 1200000, N'Tr?ng');

--B?ng 4: Lo?i Ti?n Nghi
INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES 
('TV', N'Ti vi'),
('TL', N'T? l?nh'),
('DT', N'?i?n tho?i');

--B?ng 5: Ti?n Nghi
INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES
('TV01','TV',1, N'T?t'),
('TV02', 'TV', 2, N'T?t'),
('TL01', 'TL', 1, N'T?t');

--B?ng 6: Phi?u L?p ??t
INSERT INTO PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu) VALUES
('PLD01','TV01','A101','2023-01-10', N'M?i','NV01', N'L?p ??t hoàn thi?n'),
('PLD02', 'TL01', 'A101', '2023-01-10', N'M?i', 'NV01', N'L?p ??t hoàn thi?n');

--B?ng 7: Khách Hàng
INSERT INTO KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai) VALUES
('KH01', N'Tr?n Anh Tu?n','079123456789', N'Vi?t Nam','0909123456'),
('KH02', N'Nguy?n Th? Mai', '079987654321', N'Vi?t Nam', '0988765432');

--B?ng 8: Phi?u ??t Phòng
INSERT INTO PhieuDatPhong(SoPhieuDat, MaKhach, MaNVLeTan, NgayLap, NgayNhan, NgayTraDuKien, TienCoc, KenhDat, TrangThai, NgayNhanThucTe, NgayTraThucTe) VALUES
('PDP01','KH01','NV01','2023-10-01 08:00:00','2023-10-05','2023-10-07',500000, N'?i?n tho?i', N'?ã tr?','2023-10-05 14:00:00','2023-10-07 12:00:00'),
('PDP02', 'KH02', 'NV01', '2023-10-15 09:00:00', '2023-10-20', '2023-10-22', 1000000, N'Website', N'?ã ??t', NULL, NULL);

--B?ng 9: Chi Ti?t ??t Phòng
INSERT INTO ChiTietDatPhong(SoPhieuDat, SoPhong, SoNguoi) VALUES
('PDP01','A101',2),
('PDP02', 'B201', 4);

--B?ng 10: Ng??i L?u Trú
INSERT INTO NguoiLuuTru(SoPhieuDat, SoPhong, HoTen, SoCMND, QuocTich) VALUES
('PDP01','A101', N'Tr?n Anh Tu?n','079123456789', N'Vi?t Nam'),
('PDP01', 'A101', N'Lê Thanh Huy?n', '079123456790', N'Vi?t Nam');

--B?ng 11: D?ch V?
INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES
('DV01', N'?n sáng', N'Su?t',120000),
('DV02', N'T?m h?i', N'L??t', 250000),
('DV03', N'Karaoke', N'Gi?', 300000);

--B?ng 12: Phi?u S? D?ng D?ch V?
INSERT INTO PhieuSuDungDV(SoPhieuSDDV, SoPhieuDat, SoPhong, NgaySuDung, MaNV) VALUES
('SDDV01','PDP01','A101','2023-10-06','NV02');

--B?ng 13: Chi Ti?t Phi?u S? D?ng D?ch V?
INSERT INTO ChiTietPhieuSuDungDV(SoPhieuSDDV, MaDV, SoLuong, DonGia) VALUES
('SDDV01','DV01',2,120000),
('SDDV01', 'DV02', 1, 250000);

--B?ng 14: Quy ??nh ??n Bù
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES
('QD01','TV', N'H? h?ng nh?',500000),
('QD02', 'TV', N'M?t', 5000000),
('QD03', 'TL', N'H? h?ng nh?', 400000),
('QD04', 'TL', N'M?t', 4000000);

--B?ng 15: Phi?u ??n Bù
INSERT INTO PhieuDenBu(SoPhieuDenBu, SoPhieuDat, SoPhong, NgayLap, MaNV, TongTien) VALUES
('PDB01','PDP01','A101','2023-10-07 10:00:00','NV01',500000);

--B?ng 16: Chi Ti?t Phi?u ??n Bù
INSERT INTO ChiTietPhieuDenBu(SoPhieuDenBu, MaTienNghi, MucDoThietHai, SoTien) VALUES
('PDB01','TV01', N'H? h?ng nh?',500000);

--B?ng 17: Hóa ??n
INSERT INTO HoaDon(SoHoaDon, SoPhieuDat, NgayLap, MaNV, SoNgayTinhTien, TienPhong, TienDichVu, TrangThai) VALUES
('HD01','PDP01','2023-10-07 12:00:00','NV03',2,1200000,490000, N'?ã thanh toán');

--B?ng 18: Thanh Toán
INSERT INTO ThanhToan(MaThanhToan, SoHoaDon, NgayThanhToan, HinhThuc, SoTien) VALUES
('TT01','HD01','2023-10-07 12:10:00', N'Chuy?n kho?n',1690000);
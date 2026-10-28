
BEGIN
   FOR t IN (SELECT table_name FROM user_tables WHERE table_name IN (
      'THANHTOAN', 'HOADON', 'CHITIETPHIEUDENBU', 'PHIEUDENBU', 'QUYDINHDENBU',
      'CHITIETPHIEUSUDUNGDV', 'PHIEUSUDUNGDV', 'DICHVU', 'NGUOILUUTRU', 
      'CHITIETDATPHONG', 'PHIEUDATPHONG', 'KHACHHANG', 'PHIEULAPDAT', 
      'TIENNGHI', 'LOAITIENNGHI', 'PHONG', 'KHUVUC', 'NHANVIEN'
   )) LOOP
      EXECUTE IMMEDIATE 'DROP TABLE ' || t.table_name || ' CASCADE CONSTRAINTS';
   END LOOP;
END;
/

--2. TAO BANG MOI VA RANG BUOC
CREATE TABLE NhanVien (
    MaNV VARCHAR2(20) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR2(120) NOT NULL,
    VaiTro NVARCHAR2(50) NOT NULL,
    SoDienThoai VARCHAR2(20)
);

CREATE TABLE KhuVuc (
    MaKhuVuc VARCHAR2(20) NOT NULL PRIMARY KEY,
    TenKhuVuc NVARCHAR2(100) NOT NULL UNIQUE
);

CREATE TABLE Phong (
    SoPhong VARCHAR2(20) NOT NULL PRIMARY KEY,
    MaKhuVuc VARCHAR2(20) NOT NULL,
    SoNguoiToiDa NUMBER(10) NOT NULL,
    DonGiaNgay NUMBER(18,2) NOT NULL,
    TrangThai NVARCHAR2(30) DEFAULT 'Trống' NOT NULL,
    CONSTRAINT CK_Phong_SoNguoi CHECK(SoNguoiToiDa > 0),
    CONSTRAINT CK_Phong_DonGia CHECK(DonGiaNgay >= 0),
    CONSTRAINT CK_Phong_TrangThai CHECK(TrangThai IN ('Trống', 'Đã đặt', 'Đang ở', 'Bảo trì')),
    CONSTRAINT FK_Phong_KhuVuc FOREIGN KEY(MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE LoaiTienNghi (
    MaLoaiTN VARCHAR2(20) NOT NULL PRIMARY KEY,
    TenLoaiTN NVARCHAR2(100) NOT NULL UNIQUE
);

CREATE TABLE TienNghi (
    MaTienNghi VARCHAR2(30) NOT NULL PRIMARY KEY,
    MaLoaiTN VARCHAR2(20) NOT NULL,
    SoThuTu NUMBER(10) NOT NULL,
    TinhTrangHienTai NVARCHAR2(100),
    CONSTRAINT UQ_TienNghi_Loai_STT UNIQUE(MaLoaiTN, SoThuTu),
    CONSTRAINT FK_TienNghi_Loai FOREIGN KEY(MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN)
);

CREATE TABLE PhieuLapDat (
    SoPhieuLapDat VARCHAR2(30) NOT NULL PRIMARY KEY,
    MaTienNghi VARCHAR2(30) NOT NULL,
    SoPhong VARCHAR2(20) NOT NULL,
    NgayLap DATE NOT NULL,
    TinhTrang NVARCHAR2(100) NOT NULL,
    MaNV VARCHAR2(20) NOT NULL,
    GhiChu NVARCHAR2(250),
    CONSTRAINT UQ_PhieuLapDat_ThietBi UNIQUE(MaTienNghi, NgayLap),
    CONSTRAINT FK_PhieuLapDat_TienNghi FOREIGN KEY(MaTienNghi) REFERENCES TienNghi(MaTienNghi),
    CONSTRAINT FK_PhieuLapDat_Phong FOREIGN KEY(SoPhong) REFERENCES Phong(SoPhong),
    CONSTRAINT FK_PhieuLapDat_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE KhachHang (
    MaKhach VARCHAR2(20) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR2(120) NOT NULL,
    SoCMND VARCHAR2(30) NOT NULL UNIQUE,
    QuocTich NVARCHAR2(80) NOT NULL,
    SoDienThoai VARCHAR2(20)
);

CREATE TABLE PhieuDatPhong (
    SoPhieuDat VARCHAR2(30) NOT NULL PRIMARY KEY,
    MaKhach VARCHAR2(20) NOT NULL,
    MaNVLeTan VARCHAR2(20) NOT NULL,
    NgayLap DATE NOT NULL,
    NgayNhan DATE NOT NULL,
    NgayTraDuKien DATE NOT NULL,
    TienCoc NUMBER(18,2) DEFAULT 0 NOT NULL,
    KenhDat NVARCHAR2(20) NOT NULL,
    TrangThai NVARCHAR2(30) DEFAULT 'Đã đặt' NOT NULL,
    NgayNhanThucTe DATE,
    NgayTraThucTe DATE,
    CONSTRAINT CK_PhieuDat_Ngay CHECK(NgayTraDuKien >= NgayNhan),
    CONSTRAINT CK_PhieuDat_Coc CHECK(TienCoc >= 0),
    CONSTRAINT CK_PhieuDat_Kenh CHECK(KenhDat IN ('Điện thoại', 'Website', 'Trực tiếp')),
    CONSTRAINT CK_PhieuDat_TrangThai CHECK (TrangThai IN ('Đã đặt', 'Đang ở', 'Đã trả', 'No-show', 'Hủy')),
    CONSTRAINT FK_PhieuDat_Khach FOREIGN KEY(MaKhach) REFERENCES KhachHang(MaKhach),
    CONSTRAINT FK_PhieuDat_NV FOREIGN KEY (MaNVLeTan) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietDatPhong (
    SoPhieuDat VARCHAR2(30) NOT NULL,
    SoPhong VARCHAR2(20) NOT NULL,
    SoNguoi NUMBER(10) NOT NULL,
    PRIMARY KEY (SoPhieuDat, SoPhong),
    CONSTRAINT CK_CTDat_SoNguoi CHECK(SoNguoi > 0),
    CONSTRAINT FK_CTDat_Phieu FOREIGN KEY (SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
    CONSTRAINT FK_CTDat_Phong FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong)
);

-- Su dung SEQUENCE thay the cho IDENTITY(1,1) trong SQL Server
CREATE SEQUENCE Seq_NguoiLuuTru START WITH 1 INCREMENT BY 1;

CREATE TABLE NguoiLuuTru (
    MaNguoiLT NUMBER(10) DEFAULT Seq_NguoiLuuTru.NEXTVAL NOT NULL PRIMARY KEY,
    SoPhieuDat VARCHAR2(30) NOT NULL,
    SoPhong VARCHAR2(20) NOT NULL,
    HoTen NVARCHAR2(120) NOT NULL,
    SoCMND VARCHAR2(30) NOT NULL,
    QuocTich NVARCHAR2(80) NOT NULL,
    CONSTRAINT FK_NguoiLT_CTDat FOREIGN KEY (SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong (SoPhieuDat, SoPhong)
);

CREATE TABLE DichVu (
    MaDV VARCHAR2(20) NOT NULL PRIMARY KEY,
    TenDV NVARCHAR2(120) NOT NULL,
    DonViTinh NVARCHAR2(40) NOT NULL,
    DonGia NUMBER(18,2) NOT NULL,
    CONSTRAINT CK_DichVu_DonGia CHECK(DonGia >= 0)
);

CREATE TABLE PhieuSuDungDV (
    SoPhieuSDDV VARCHAR2(30) NOT NULL PRIMARY KEY,
    SoPhieuDat VARCHAR2(30) NOT NULL,
    SoPhong VARCHAR2(20) NOT NULL,
    NgaySuDung DATE NOT NULL,
    MaNV VARCHAR2(20) NOT NULL,
    CONSTRAINT UQ_PhieuSDDV_PhongNgay UNIQUE(SoPhieuDat, SoPhong, NgaySuDung),
    CONSTRAINT FK_PhieuSDDV_CTDat FOREIGN KEY (SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
    CONSTRAINT FK_PhieuSDDV_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuSuDungDV (
    SoPhieuSDDV VARCHAR2(30) NOT NULL,
    MaDV VARCHAR2(20) NOT NULL,
    SoLuong NUMBER(10) NOT NULL,
    DonGia NUMBER(18,2) NOT NULL,
    PRIMARY KEY (SoPhieuSDDV, MaDV),
    CONSTRAINT CK_CTSDDV_SoLuong CHECK(SoLuong > 0),
    CONSTRAINT CK_CTSDDV_DonGia CHECK(DonGia >= 0),
    CONSTRAINT FK_CTSDDV_Phieu FOREIGN KEY (SoPhieuSDDV) REFERENCES PhieuSuDungDV(SoPhieuSDDV),
    CONSTRAINT FK_CTSDDV_DV FOREIGN KEY(MaDV) REFERENCES DichVu(MaDV)
);

CREATE TABLE QuyDinhDenBu (
    MaQuyDinh VARCHAR2(30) NOT NULL PRIMARY KEY,
    MaLoaiTN VARCHAR2(20) NOT NULL,
    MucDoThietHai NVARCHAR2(80) NOT NULL,
    MucDenBu NUMBER(18,2) NOT NULL,
    CONSTRAINT CK_QDDB_MucDenBu CHECK(MucDenBu >= 0),
    CONSTRAINT UQ_QDDB_Loai_MucDo UNIQUE(MaLoaiTN, MucDoThietHai),
    CONSTRAINT FK_QDDB_Loai FOREIGN KEY(MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN)
);

CREATE TABLE PhieuDenBu (
    SoPhieuDenBu VARCHAR2(30) NOT NULL PRIMARY KEY,
    SoPhieuDat VARCHAR2(30) NOT NULL,
    SoPhong VARCHAR2(20) NOT NULL,
    NgayLap DATE NOT NULL,
    MaNV VARCHAR2(20) NOT NULL,
    TongTien NUMBER(18,2) DEFAULT 0 NOT NULL,
    CONSTRAINT CK_PhieuDB_TongTien CHECK(TongTien >= 0),
    CONSTRAINT FK_PhieuDB_CTDat FOREIGN KEY(SoPhieuDat, SoPhong) REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
    CONSTRAINT FK_PhieuDB_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuDenBu (
    SoPhieuDenBu VARCHAR2(30) NOT NULL,
    MaTienNghi VARCHAR2(30) NOT NULL,
    MucDoThietHai NVARCHAR2(80) NOT NULL,
    SoTien NUMBER(18,2) NOT NULL,
    PRIMARY KEY (SoPhieuDenBu, MaTienNghi),
    CONSTRAINT CK_CTDB_SoTien CHECK(SoTien >= 0),
    CONSTRAINT FK_CTDB_Phieu FOREIGN KEY(SoPhieuDenBu) REFERENCES PhieuDenBu(SoPhieuDenBu),
    CONSTRAINT FK_CTDB_TienNghi FOREIGN KEY(MaTienNghi) REFERENCES TienNghi(MaTienNghi)
);

CREATE TABLE HoaDon (
    SoHoaDon VARCHAR2(30) NOT NULL PRIMARY KEY,
    SoPhieuDat VARCHAR2(30) NOT NULL UNIQUE,
    NgayLap DATE NOT NULL,
    MaNV VARCHAR2(20) NOT NULL,
    SoNgayTinhTien NUMBER(10) NOT NULL,
    TienPhong NUMBER(18,2) NOT NULL,
    TienDichVu NUMBER(18,2) NOT NULL,
    TrangThai NVARCHAR2(30) DEFAULT 'Chưa thanh toán' NOT NULL,
    CONSTRAINT CK_HoaDon_SoNgay CHECK(SoNgayTinhTien > 0),
    CONSTRAINT CK_HoaDon_TienPhong CHECK(TienPhong >= 0),
    CONSTRAINT CK_HoaDon_TienDichVu CHECK(TienDichVu >= 0),
    CONSTRAINT CK_HoaDon_TrangThai CHECK(TrangThai IN ('Chưa thanh toán', 'Đã thanh toán')),
    CONSTRAINT FK_HoaDon_PhieuDat FOREIGN KEY (SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
    CONSTRAINT FK_HoaDon_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ThanhToan (
    MaThanhToan VARCHAR2(30) NOT NULL PRIMARY KEY,
    SoHoaDon VARCHAR2(30) NOT NULL,
    NgayThanhToan DATE NOT NULL,
    HinhThuc NVARCHAR2(30) NOT NULL,
    SoTien NUMBER(18,2) NOT NULL,
    CONSTRAINT CK_ThanhToan_SoTien CHECK(SoTien > 0),
    CONSTRAINT CK_ThanhToan_HinhThuc CHECK(HinhThuc IN ('Tiền mặt', 'Chuyển khoản', 'Thẻ', 'Ví điện tử')),
    CONSTRAINT FK_ThanhToan_HoaDon FOREIGN KEY (SoHoaDon) REFERENCES HoaDon(SoHoaDon)
);

-- Tao cac chi muc (Index) de tang toc do truy van
CREATE INDEX IX_PhieuDatPhong_Ngay ON PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);
CREATE INDEX IX_CTDat_Phong ON ChiTietDatPhong(SoPhong, SoPhieuDat);
CREATE INDEX IX_PhieuSDDV_DatPhong ON PhieuSuDungDV(SoPhieuDat, SoPhong, NgaySuDung);


--3. NHAP DU LIEU MAU

INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV01', 'Nguyễn Thu Hà', 'Lễ tân', '0901000001');
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV02', 'Trần Minh An', 'Phục vụ phòng', '0901000002');
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV03', 'Lê Hoàng Nam', 'Thanh toán', '0901000003');

INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('A', 'Khu A');
INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('B', 'Khu B');

INSERT INTO Phong (SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A101', 'A', 2, 600000, 'Trống');
INSERT INTO Phong (SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A102', 'A', 3, 800000, 'Trống');
INSERT INTO Phong (SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('B201', 'B', 4, 1200000, 'Trống');

INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TV', 'Ti vi');
INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TL', 'Tủ lạnh');
INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('DT', 'Điện thoại');

INSERT INTO TienNghi (MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV01', 'TV', 1, 'Tốt');
INSERT INTO TienNghi (MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV02', 'TV', 2, 'Tốt');
INSERT INTO TienNghi (MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TL01', 'TL', 1, 'Tốt');

INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV01', 'Ăn sáng', 'Suất', 120000);
INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV02', 'Tắm hơi', 'Lượt', 250000);
INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV03', 'Karaoke', 'Giờ', 300000);

INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD01', 'TV', 'Hư hỏng nhẹ', 500000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD02', 'TV', 'Mất', 5000000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD03', 'TL', 'Hư hỏng nhẹ', 400000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD04', 'TL', 'Mất', 4000000);

COMMIT;
/
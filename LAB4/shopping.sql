-- =======================================================
-- 1. XÓA BẢNG NẾU ĐÃ TỒN TẠI (Đã sửa lỗi ngắt lệnh)
-- =======================================================
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

-- =======================================================
-- 2. TẠO CÁC BẢNG ĐỘC LẬP
-- =======================================================

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

-- =======================================================
-- 3. TẠO CÁC BẢNG CÓ KHÓA NGOẠI
-- =======================================================

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
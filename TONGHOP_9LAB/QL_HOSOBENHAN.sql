ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY';

-- 1. TẠO CÁC BẢNG DỮ LIỆU (TABLES)
-- Bảng Bác Sĩ
CREATE TABLE BAC_SI (
    ID_BacSi VARCHAR2(10) PRIMARY KEY,
    HoTen VARCHAR2(100) NOT NULL,
    KhoaDieuTri VARCHAR2(50),
    ChuyenMon VARCHAR2(50)
);

-- Bảng Bệnh Nhân
CREATE TABLE BENH_NHAN (
    ID_BenhNhan VARCHAR2(10) PRIMARY KEY,
    HoTen VARCHAR2(100) NOT NULL,
    NgaySinh DATE,
    DiaChi VARCHAR2(200),
    DienThoai VARCHAR2(15),
    LePhiHangNam NUMBER(10, 2)
);

-- Bảng Hồ Sơ Bệnh Án
CREATE TABLE HO_SO_BENH_AN (
    ID_HoSo VARCHAR2(10) PRIMARY KEY,
    ID_BenhNhan VARCHAR2(10) NOT NULL,
    NgayLapHoSo DATE,
    CONSTRAINT FK_HSBA_BenhNhan FOREIGN KEY (ID_BenhNhan) REFERENCES BENH_NHAN(ID_BenhNhan)
);

-- Bảng Phiếu Khám Bệnh
CREATE TABLE PHIEU_KHAM_BENH (
    ID_PhieuKham VARCHAR2(10) PRIMARY KEY,
    ID_HoSo VARCHAR2(10) NOT NULL,
    ID_BacSi VARCHAR2(10) NOT NULL,
    NgayGioKham DATE,
    TrieuChung VARCHAR2(200),
    ThanNhiet NUMBER(4,1),
    HuyetAp VARCHAR2(20),
    CONSTRAINT FK_PKB_HoSo FOREIGN KEY (ID_HoSo) REFERENCES HO_SO_BENH_AN(ID_HoSo),
    CONSTRAINT FK_PKB_BacSi FOREIGN KEY (ID_BacSi) REFERENCES BAC_SI(ID_BacSi)
);

CREATE TABLE NHAN_VIEN (
    ID_NhanVien VARCHAR2(10) PRIMARY KEY,
    HoTen VARCHAR2(100) NOT NULL,
    BoPhan VARCHAR2(50)
);

-- Bảng Xét Nghiệm (1 Phiếu khám có thể có nhiều Xét nghiệm)
CREATE TABLE XET_NGHIEM (
    ID_XetNghiem VARCHAR2(10) PRIMARY KEY,
    ID_PhieuKham VARCHAR2(10) NOT NULL,
    TenXetNghiem VARCHAR2(100),
    KetQua VARCHAR2(200),
    NgayThucHien DATE,
    CONSTRAINT FK_XN_PhieuKham FOREIGN KEY (ID_PhieuKham) REFERENCES PHIEU_KHAM_BENH(ID_PhieuKham)
);

-- Bảng Toa Thuốc (1 Phiếu khám sinh ra tối đa 1 Toa thuốc)
CREATE TABLE TOA_THUOC (
    ID_ToaThuoc VARCHAR2(10) PRIMARY KEY,
    ID_PhieuKham VARCHAR2(10) UNIQUE NOT NULL, 
    NgayKeToa DATE,
    GhiChu VARCHAR2(200),
    CONSTRAINT FK_TT_PhieuKham FOREIGN KEY (ID_PhieuKham) REFERENCES PHIEU_KHAM_BENH(ID_PhieuKham)
);

-- Bảng Chi Tiết Toa Thuốc (Mối quan hệ hợp thành với Toa Thuốc)
CREATE TABLE CHI_TIET_TOA_THUOC (
    ID_ToaThuoc VARCHAR2(10) NOT NULL,
    ID_Thuoc VARCHAR2(20) NOT NULL, -- Theo thiết kế Class, tạm lưu Mã/Tên thuốc trực tiếp
    SoLuong NUMBER(5),
    CachDung VARCHAR2(100),
    PRIMARY KEY (ID_ToaThuoc, ID_Thuoc),
    CONSTRAINT FK_CTTT_ToaThuoc FOREIGN KEY (ID_ToaThuoc) REFERENCES TOA_THUOC(ID_ToaThuoc)
);

-- 2. CHÈN DỮ LIỆU MẪU (INSERT DATA)

-- Thêm dữ liệu Bác Sĩ
INSERT INTO BAC_SI VALUES ('BS01', 'Nguyen Van An', 'Noi khoa', 'Kham Tong Quat');
INSERT INTO BAC_SI VALUES ('BS02', 'Tran Thi Binh', 'Nhi khoa', 'Chuyen Khoa Nhi');
INSERT INTO BAC_SI VALUES ('BS03', 'Le Hoang Cuong', 'Ngoai khoa', 'Phau Thuat');

-- Thêm dữ liệu Bệnh Nhân
INSERT INTO BENH_NHAN VALUES ('BN001', 'Pham Thi Thuy Trang', '15-05-2004', 'Q. Tan Binh, TP.HCM', '0901234567', 500000);
INSERT INTO BENH_NHAN VALUES ('BN002', 'Nguyen Thanh Tung', '22-10-1995', 'Q. 10, TP.HCM', '0912345678', 500000);
INSERT INTO BENH_NHAN VALUES ('BN003', 'Le Thi Mai', '05-12-1988', 'Q. Go Vap, TP.HCM', '0987654321', 500000);

-- Thêm dữ liệu Hồ Sơ Bệnh Án
INSERT INTO HO_SO_BENH_AN VALUES ('HS001', 'BN001', '01-10-2026');
INSERT INTO HO_SO_BENH_AN VALUES ('HS002', 'BN002', '05-10-2026');
INSERT INTO HO_SO_BENH_AN VALUES ('HS003', 'BN003', '10-10-2026');

-- Thêm dữ liệu Phiếu Khám Bệnh
INSERT INTO PHIEU_KHAM_BENH VALUES ('PK001', 'HS001', 'BS01', '12-10-2026', 'Dau dau, chong mat', 38.5, '120/80');
INSERT INTO PHIEU_KHAM_BENH VALUES ('PK002', 'HS002', 'BS02', '14-10-2026', 'Ho khan, sot nhe', 37.8, '110/70');
INSERT INTO PHIEU_KHAM_BENH VALUES ('PK003', 'HS003', 'BS03', '16-10-2026', 'Dau da day, buon non', 37.0, '130/85');

-- Dữ liệu Nhân viên
INSERT INTO NHAN_VIEN VALUES ('NV01', 'Hoang Nhat Minh', 'Cham Soc Khach Hang');
INSERT INTO NHAN_VIEN VALUES ('NV02', 'Le Thi Thu', 'Thu Ngan');

-- Dữ liệu Xét nghiệm (Dựa trên các ID_PhieuKham đã tạo ở script trước)
INSERT INTO XET_NGHIEM VALUES ('XN001', 'PK001', 'Xet nghiem Mau', 'Binh thuong, tieu cau hoi thap', '12-10-2026');
INSERT INTO XET_NGHIEM VALUES ('XN002', 'PK003', 'Sieu am Da day', 'Viem loet da day ta trang nhe', '16-10-2026');

-- Dữ liệu Toa thuốc 
INSERT INTO TOA_THUOC VALUES ('TT001', 'PK001', '12-10-2026', 'Uong sau khi an no');
INSERT INTO TOA_THUOC VALUES ('TT002', 'PK002', '14-10-2026', 'Uong nhieu nuoc am');
INSERT INTO TOA_THUOC VALUES ('TT003', 'PK003', '16-10-2026', 'Kieng do chua, cay, nong');

-- Dữ liệu Chi tiết toa thuốc
INSERT INTO CHI_TIET_TOA_THUOC VALUES ('TT001', 'Paracetamol', 10, 'Ngay 2 vien, sang/toi');
INSERT INTO CHI_TIET_TOA_THUOC VALUES ('TT002', 'Siro Ho', 1, 'Ngay 3 lan, moi lan 10ml');
INSERT INTO CHI_TIET_TOA_THUOC VALUES ('TT003', 'Phosphalugel', 20, 'Ngay 2 goi, truoc bua an 30p');

COMMIT;


-- 1. XÓA BẢNG NẾU ĐÃ TỒN TẠI (CHẮC CHẮN XÓA SẠCH)
BEGIN
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE PhieuThuChi CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE PhieuPhuTroi CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE BangChamCong CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE QuyetDinh CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE HopDong CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE NhanVien CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
   BEGIN EXECUTE IMMEDIATE 'DROP TABLE PhongBan CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN NULL; END;
END;
/

-- 2. TẠO CÁC BẢNG (DDL)
-- Bảng Phòng Ban
CREATE TABLE PhongBan (
    ID_PhongBan VARCHAR2(10) PRIMARY KEY,
    TenPhongBan NVARCHAR2(100) NOT NULL
);

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    ID_NhanVien VARCHAR2(10) PRIMARY KEY,
    HoTen NVARCHAR2(100) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR2(200),
    ID_PhongBan VARCHAR2(10),
    CONSTRAINT FK_NhanVien_PhongBan FOREIGN KEY (ID_PhongBan) REFERENCES PhongBan(ID_PhongBan)
);

-- Bảng Hợp Đồng
CREATE TABLE HopDong (
    ID_HopDong VARCHAR2(10) PRIMARY KEY,
    ID_NhanVien VARCHAR2(10) NOT NULL,
    LoaiHopDong NVARCHAR2(50), 
    NgayKy DATE,
    MucDongBaoHiem NUMBER(18,2), 
    CONSTRAINT FK_HopDong_NhanVien FOREIGN KEY (ID_NhanVien) REFERENCES NhanVien(ID_NhanVien)
);

-- Bảng Quyết Định 
CREATE TABLE QuyetDinh (
    ID_QuyetDinh VARCHAR2(10) PRIMARY KEY,
    LoaiQuyetDinh NVARCHAR2(100), 
    ID_NhanVien VARCHAR2(10), 
    ID_PhongBan VARCHAR2(10), 
    NgayKy DATE,
    NoiDung NVARCHAR2(500),
    CONSTRAINT FK_QuyetDinh_NhanVien FOREIGN KEY (ID_NhanVien) REFERENCES NhanVien(ID_NhanVien),
    CONSTRAINT FK_QuyetDinh_PhongBan FOREIGN KEY (ID_PhongBan) REFERENCES PhongBan(ID_PhongBan)
);

-- Bảng Chấm Công
CREATE TABLE BangChamCong (
    ID_ChamCong VARCHAR2(10) PRIMARY KEY,
    ID_NhanVien VARCHAR2(10) NOT NULL,
    ThangNam VARCHAR2(7), 
    SoNgayCong NUMBER(4,1), 
    CONSTRAINT FK_ChamCong_NhanVien FOREIGN KEY (ID_NhanVien) REFERENCES NhanVien(ID_NhanVien)
);

-- Bảng Phiếu Phụ Trội
CREATE TABLE PhieuPhuTroi (
    ID_Phieu VARCHAR2(10) PRIMARY KEY,
    ID_ChamCong VARCHAR2(10) NOT NULL,
    NgayPhuTroi DATE,
    SoGio NUMBER(4,1),
    HinhThuc NVARCHAR2(100), 
    CONSTRAINT FK_PhuTroi_ChamCong FOREIGN KEY (ID_ChamCong) REFERENCES BangChamCong(ID_ChamCong)
);

-- Bảng Phiếu Thu Chi 
CREATE TABLE PhieuThuChi (
    ID_PhieuThuChi VARCHAR2(10) PRIMARY KEY,
    ID_QuyetDinh VARCHAR2(10) NOT NULL,
    LoaiPhieu NVARCHAR2(50), 
    SoTien NUMBER(18,2) NOT NULL,
    NgayLap DATE,
    CONSTRAINT FK_PhieuThuChi_QuyetDinh FOREIGN KEY (ID_QuyetDinh) REFERENCES QuyetDinh(ID_QuyetDinh)
);

-- 3. THÊM DỮ LIỆU MẪU (DML)

INSERT INTO PhongBan (ID_PhongBan, TenPhongBan) VALUES ('PB01', N'Phòng Hành chính - Nhân sự');
INSERT INTO PhongBan (ID_PhongBan, TenPhongBan) VALUES ('PB02', N'Phòng Tài chính - Kế toán');
INSERT INTO PhongBan (ID_PhongBan, TenPhongBan) VALUES ('PB03', N'Phân xưởng Sản xuất');

INSERT INTO NhanVien (ID_NhanVien, HoTen, NgaySinh, DiaChi, ID_PhongBan) 
VALUES ('NV001', N'Phạm Thị Thùy Trang', TO_DATE('2002-05-15', 'YYYY-MM-DD'), N'Quận 1, TP.HCM', 'PB01');
INSERT INTO NhanVien (ID_NhanVien, HoTen, NgaySinh, DiaChi, ID_PhongBan) 
VALUES ('NV002', N'Nguyễn Văn An', TO_DATE('1995-10-20', 'YYYY-MM-DD'), N'Quận 7, TP.HCM', 'PB02');
INSERT INTO NhanVien (ID_NhanVien, HoTen, NgaySinh, DiaChi, ID_PhongBan) 
VALUES ('NV003', N'Trần Bình Trọng', TO_DATE('1998-02-28', 'YYYY-MM-DD'), N'Thủ Đức, TP.HCM', 'PB03');

INSERT INTO HopDong (ID_HopDong, ID_NhanVien, LoaiHopDong, NgayKy, MucDongBaoHiem) 
VALUES ('HD001', 'NV001', N'Dài hạn', TO_DATE('2024-01-01', 'YYYY-MM-DD'), 1500000);
INSERT INTO HopDong (ID_HopDong, ID_NhanVien, LoaiHopDong, NgayKy, MucDongBaoHiem) 
VALUES ('HD002', 'NV002', N'Dài hạn', TO_DATE('2022-06-15', 'YYYY-MM-DD'), 2000000);
INSERT INTO HopDong (ID_HopDong, ID_NhanVien, LoaiHopDong, NgayKy, MucDongBaoHiem) 
VALUES ('HD003', 'NV003', N'Thử việc', TO_DATE('2026-09-01', 'YYYY-MM-DD'), 0);

INSERT INTO QuyetDinh (ID_QuyetDinh, LoaiQuyetDinh, ID_NhanVien, ID_PhongBan, NgayKy, NoiDung) 
VALUES ('QD001', N'Khen thưởng', 'NV001', NULL, TO_DATE('2026-10-10', 'YYYY-MM-DD'), N'Khen thưởng nhân viên xuất sắc tháng 9');
INSERT INTO QuyetDinh (ID_QuyetDinh, LoaiQuyetDinh, ID_NhanVien, ID_PhongBan, NgayKy, NoiDung) 
VALUES ('QD002', N'Kỷ luật', 'NV002', NULL, TO_DATE('2026-10-15', 'YYYY-MM-DD'), N'Phạt vi phạm nội quy công ty');
INSERT INTO QuyetDinh (ID_QuyetDinh, LoaiQuyetDinh, ID_NhanVien, ID_PhongBan, NgayKy, NoiDung) 
VALUES ('QD003', N'Khen thưởng tập thể', NULL, 'PB03', TO_DATE('2026-10-20', 'YYYY-MM-DD'), N'Thưởng vượt chỉ tiêu sản xuất quý 3');

INSERT INTO BangChamCong (ID_ChamCong, ID_NhanVien, ThangNam, SoNgayCong) 
VALUES ('CC1026_01', 'NV001', '10/2026', 22);
INSERT INTO BangChamCong (ID_ChamCong, ID_NhanVien, ThangNam, SoNgayCong) 
VALUES ('CC1026_02', 'NV002', '10/2026', 20.5);

INSERT INTO PhieuPhuTroi (ID_Phieu, ID_ChamCong, NgayPhuTroi, SoGio, HinhThuc) 
VALUES ('PT001', 'CC1026_01', TO_DATE('2026-10-05', 'YYYY-MM-DD'), 4, N'Tăng ca ngày thường (x1.5)');
INSERT INTO PhieuPhuTroi (ID_Phieu, ID_ChamCong, NgayPhuTroi, SoGio, HinhThuc) 
VALUES ('PT002', 'CC1026_02', TO_DATE('2026-10-12', 'YYYY-MM-DD'), 8, N'Làm việc ngày nghỉ (x2.0)');

INSERT INTO PhieuThuChi (ID_PhieuThuChi, ID_QuyetDinh, LoaiPhieu, SoTien, NgayLap) 
VALUES ('PTC001', 'QD001', N'Phiếu Chi', 1000000, TO_DATE('2026-10-11', 'YYYY-MM-DD'));
INSERT INTO PhieuThuChi (ID_PhieuThuChi, ID_QuyetDinh, LoaiPhieu, SoTien, NgayLap) 
VALUES ('PTC002', 'QD002', N'Phiếu Thu', 500000, TO_DATE('2026-10-16', 'YYYY-MM-DD'));
INSERT INTO PhieuThuChi (ID_PhieuThuChi, ID_QuyetDinh, LoaiPhieu, SoTien, NgayLap) 
VALUES ('PTC003', 'QD003', N'Phiếu Chi', 10000000, TO_DATE('2026-10-21', 'YYYY-MM-DD'));

COMMIT;
-- 1. Bảng NHÂN VIÊN (Hướng dẫn viên)
CREATE TABLE NHAN_VIEN (
    MaNV VARCHAR2(20) PRIMARY KEY,
    HoTen VARCHAR2(100) NOT NULL,
    DienThoai VARCHAR2(20),
    LuongCB NUMBER(18,2)
);

-- 2. Bảng TOUR (Thông tin gốc của Tour)
CREATE TABLE TOUR (
    MaTour VARCHAR2(20) PRIMARY KEY,
    TenTour VARCHAR2(200) NOT NULL,
    SoNgay NUMBER(5),
    SoDem NUMBER(5),
    DonGia NUMBER(18,2)
);

-- 3. Bảng CHUYẾN ĐI (Lịch trình cụ thể sinh ra từ Tour)
CREATE TABLE CHUYEN_DI (
    MaChuyen VARCHAR2(20) PRIMARY KEY,
    MaTour VARCHAR2(20) REFERENCES TOUR(MaTour),
    NgayDi DATE,
    NgayVe DATE
);

-- 4. Bảng KHÁCH HÀNG (Gộp chung Khách Đoàn & Khách Lẻ dùng cờ LoaiKhach)
CREATE TABLE KHACH_HANG (
    MaKH VARCHAR2(20) PRIMARY KEY,
    LoaiKhach VARCHAR2(10),       -- Điền 'DOAN' hoặc 'LE'
    HoTen VARCHAR2(100) NOT NULL, -- Tên người đăng ký hoặc người đại diện
    DienThoai VARCHAR2(20),
    DiaChi VARCHAR2(255),
    TenCoQuan VARCHAR2(200),      -- Dành cho khách đoàn
    DiaDiemDon VARCHAR2(200)      -- Dành cho khách đoàn
);

-- 5. Bảng PHIẾU ĐĂNG KÝ (Booking)
CREATE TABLE PHIEU_DANG_KY (
    MaPhieu VARCHAR2(20) PRIMARY KEY,
    MaKH VARCHAR2(20) REFERENCES KHACH_HANG(MaKH),
    MaChuyen VARCHAR2(20) REFERENCES CHUYEN_DI(MaChuyen),
    NgayLap DATE,
    SoNguoi NUMBER(5),
    TienCoc NUMBER(18,2),         -- Khách lẻ = 0, Khách đoàn > 0
    TongTien NUMBER(18,2),
    TrangThai VARCHAR2(50)        -- 'CHUA_THANH_TOAN', 'DA_DAT_COC', 'DA_THANH_TOAN'
);

-- 6. Bảng HÀNH KHÁCH (Danh sách người đi cùng mua bảo hiểm của Khách đoàn)
CREATE TABLE HANH_KHACH (
    MaHK VARCHAR2(20) PRIMARY KEY,
    MaPhieu VARCHAR2(20) REFERENCES PHIEU_DANG_KY(MaPhieu) ON DELETE CASCADE,
    HoTen VARCHAR2(100),
    CMND_CCCD VARCHAR2(20)
);

-- 7. Bảng PHÂN CÔNG (Bảng trung gian N-N giữa Nhân Viên và Chuyến Đi)
CREATE TABLE PHAN_CONG_HDV (
    MaNV VARCHAR2(20) REFERENCES NHAN_VIEN(MaNV),
    MaChuyen VARCHAR2(20) REFERENCES CHUYEN_DI(MaChuyen),
    PRIMARY KEY (MaNV, MaChuyen)
);

-- ==========================================
-- 1. DỮ LIỆU NHÂN VIÊN (Mức lương thực tế)
-- ==========================================
INSERT INTO NHAN_VIEN (MaNV, HoTen, DienThoai, LuongCB) VALUES ('NV01', 'Nguyễn Văn An', '0901112233', 7000000);
INSERT INTO NHAN_VIEN (MaNV, HoTen, DienThoai, LuongCB) VALUES ('NV02', 'Trần Thị Bích', '0912223344', 6500000);
INSERT INTO NHAN_VIEN (MaNV, HoTen, DienThoai, LuongCB) VALUES ('NV03', 'Phạm Minh Tuấn', '0983334455', 8000000);
INSERT INTO NHAN_VIEN (MaNV, HoTen, DienThoai, LuongCB) VALUES ('NV04', 'Lê Hoàng Yến', '0934445566', 6000000);
INSERT INTO NHAN_VIEN (MaNV, HoTen, DienThoai, LuongCB) VALUES ('NV05', 'Đặng Văn Khoa', '0975556677', 7500000);

-- ==========================================
-- 2. DỮ LIỆU TOUR (Mọi tour xuất phát từ TP.HCM theo đề bài)
-- Các tuyến phổ biến với thời gian & giá tiền thực tế
-- ==========================================
INSERT INTO TOUR (MaTour, TenTour, SoNgay, SoDem, DonGia) 
VALUES ('T01', 'TP.HCM - Đà Nẵng - Hội An - Bà Nà Hills', 4, 3, 6200000);
INSERT INTO TOUR (MaTour, TenTour, SoNgay, SoDem, DonGia) 
VALUES ('T02', 'TP.HCM - Hà Nội - Sapa - Chinh phục Fansipan', 5, 4, 8500000);
INSERT INTO TOUR (MaTour, TenTour, SoNgay, SoDem, DonGia) 
VALUES ('T03', 'TP.HCM - Phú Quốc - Vui chơi Grand World', 3, 2, 5500000);
INSERT INTO TOUR (MaTour, TenTour, SoNgay, SoDem, DonGia) 
VALUES ('T04', 'TP.HCM - Cần Thơ - Cà Mau - Điểm cực Nam', 4, 3, 4200000);
INSERT INTO TOUR (MaTour, TenTour, SoNgay, SoDem, DonGia) 
VALUES ('T05', 'TP.HCM - Hồ Trị An - Khám phá rừng Mã Đà', 2, 1, 1800000);

-- ==========================================
-- 3. DỮ LIỆU CHUYẾN ĐI (Lịch trình mùa Thu - Đông 2026)
-- ==========================================
INSERT INTO CHUYEN_DI (MaChuyen, MaTour, NgayDi, NgayVe) 
VALUES ('C01_T01', 'T01', TO_DATE('2026-11-10', 'YYYY-MM-DD'), TO_DATE('2026-11-13', 'YYYY-MM-DD'));
INSERT INTO CHUYEN_DI (MaChuyen, MaTour, NgayDi, NgayVe) 
VALUES ('C02_T02', 'T02', TO_DATE('2026-12-01', 'YYYY-MM-DD'), TO_DATE('2026-12-05', 'YYYY-MM-DD'));
INSERT INTO CHUYEN_DI (MaChuyen, MaTour, NgayDi, NgayVe) 
VALUES ('C03_T03', 'T03', TO_DATE('2026-10-25', 'YYYY-MM-DD'), TO_DATE('2026-10-27', 'YYYY-MM-DD'));
INSERT INTO CHUYEN_DI (MaChuyen, MaTour, NgayDi, NgayVe) 
VALUES ('C04_T05', 'T05', TO_DATE('2026-11-14', 'YYYY-MM-DD'), TO_DATE('2026-11-15', 'YYYY-MM-DD')); -- Tour sinh thái cuối tuần

-- ==========================================
-- 4. DỮ LIỆU KHÁCH HÀNG (Doanh nghiệp thật, địa chỉ thực tế)
-- ==========================================
-- Khách đoàn 1 (Team building công ty phần mềm)
INSERT INTO KHACH_HANG (MaKH, LoaiKhach, HoTen, DienThoai, DiaChi, TenCoQuan, DiaDiemDon) 
VALUES ('KH01', 'DOAN', 'Lê Minh Phước', '0909123123', 'Quận Tân Bình, TP.HCM', 'Công ty TNHH AGARI', 'Trụ sở công ty');

-- Khách đoàn 2 (Du lịch công đoàn Ngân hàng)
INSERT INTO KHACH_HANG (MaKH, LoaiKhach, HoTen, DienThoai, DiaChi, TenCoQuan, DiaDiemDon) 
VALUES ('KH02', 'DOAN', 'Trần Hải Yến', '0918456456', 'Quận 1, TP.HCM', 'Ngân hàng ACB - Chi nhánh Q1', '15 Lê Duẩn, Q1');

-- Khách lẻ (Cá nhân, gia đình nhỏ)
INSERT INTO KHACH_HANG (MaKH, LoaiKhach, HoTen, DienThoai, DiaChi, TenCoQuan, DiaDiemDon) 
VALUES ('KH03', 'LE', 'Vũ Quyết Thắng', '0988789789', '45 Phạm Văn Đồng, Thủ Đức, TP.HCM', NULL, NULL);
INSERT INTO KHACH_HANG (MaKH, LoaiKhach, HoTen, DienThoai, DiaChi, TenCoQuan, DiaDiemDon) 
VALUES ('KH04', 'LE', 'Nguyễn Thị Mai', '0933456789', '88 Võ Văn Ngân, Thủ Đức, TP.HCM', NULL, NULL);

-- ==========================================
-- 5. DỮ LIỆU PHIẾU ĐĂNG KÝ (Logic tính toán tiền chuẩn xác)
-- ==========================================
-- Công ty AGARI book tour sinh thái Hồ Trị An cho 25 nhân viên, cọc 10tr (Tổng: 25 * 1.8m = 45tr)
INSERT INTO PHIEU_DANG_KY (MaPhieu, MaKH, MaChuyen, NgayLap, SoNguoi, TienCoc, TongTien, TrangThai) 
VALUES ('PDK01', 'KH01', 'C04_T05', TO_DATE('2026-10-10', 'YYYY-MM-DD'), 25, 10000000, 45000000, 'DA_DAT_COC');

-- ACB book tour Đà Nẵng cho 40 nhân sự, cọc 50tr (Tổng: 40 * 6.2m = 248tr)
INSERT INTO PHIEU_DANG_KY (MaPhieu, MaKH, MaChuyen, NgayLap, SoNguoi, TienCoc, TongTien, TrangThai) 
VALUES ('PDK02', 'KH02', 'C01_T01', TO_DATE('2026-10-11', 'YYYY-MM-DD'), 40, 50000000, 248000000, 'DA_DAT_COC');

-- 2 khách lẻ đi Phú Quốc (Cặp đôi), đã thanh toán đủ tiền vé (2 * 5.5m = 11tr)
INSERT INTO PHIEU_DANG_KY (MaPhieu, MaKH, MaChuyen, NgayLap, SoNguoi, TienCoc, TongTien, TrangThai) 
VALUES ('PDK03', 'KH03', 'C03_T03', TO_DATE('2026-10-12', 'YYYY-MM-DD'), 2, 0, 11000000, 'DA_THANH_TOAN');

-- 1 khách lẻ đi Phú Quốc nhưng chưa thanh toán
INSERT INTO PHIEU_DANG_KY (MaPhieu, MaKH, MaChuyen, NgayLap, SoNguoi, TienCoc, TongTien, TrangThai) 
VALUES ('PDK04', 'KH04', 'C03_T03', TO_DATE('2026-10-12', 'YYYY-MM-DD'), 1, 0, 5500000, 'CHUA_THANH_TOAN');

-- ==========================================
-- 6. DỮ LIỆU HÀNH KHÁCH (CCCD thực tế 12 số)
-- Trích xuất danh sách mua bảo hiểm cho đoàn AGARI (PDK01)
-- ==========================================
INSERT INTO HANH_KHACH (MaHK, MaPhieu, HoTen, CMND_CCCD) VALUES ('HK01', 'PDK01', 'Lê Minh Phước', '079099001122');
INSERT INTO HANH_KHACH (MaHK, MaPhieu, HoTen, CMND_CCCD) VALUES ('HK02', 'PDK01', 'Trần Khắc Nhu', '079099001133');
INSERT INTO HANH_KHACH (MaHK, MaPhieu, HoTen, CMND_CCCD) VALUES ('HK03', 'PDK01', 'Phạm Quỳnh Như', '079099001144');
INSERT INTO HANH_KHACH (MaHK, MaPhieu, HoTen, CMND_CCCD) VALUES ('HK04', 'PDK01', 'Vương Đình Đạt', '079099001155');

-- ==========================================
-- 7. DỮ LIỆU PHÂN CÔNG HƯỚNG DẪN VIÊN
-- ==========================================
-- Tour Trị An ngắn ngày phân công 1 HDV
INSERT INTO PHAN_CONG_HDV (MaNV, MaChuyen) VALUES ('NV05', 'C04_T05');

-- Tour Đà Nẵng đông người (40 pax) bắt buộc phân công 2 HDV để quản lý
INSERT INTO PHAN_CONG_HDV (MaNV, MaChuyen) VALUES ('NV01', 'C01_T01');
INSERT INTO PHAN_CONG_HDV (MaNV, MaChuyen) VALUES ('NV02', 'C01_T01');

-- Tour Phú Quốc cho khách lẻ ghép đoàn
INSERT INTO PHAN_CONG_HDV (MaNV, MaChuyen) VALUES ('NV03', 'C03_T03');

-- ==========================================
-- BẮT BUỘC LƯU DỮ LIỆU TRONG ORACLE
-- ==========================================
COMMIT;
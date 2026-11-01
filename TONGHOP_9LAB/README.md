# Tổng hợp Bài tập Môn Phương pháp phát triển phần mềm hướng đối tượng

Repository này lưu trữ toàn bộ các bài tập trên lớp, mô hình UML, file CSDL SQL Server và source code đồ án nhỏ được giao trong quá trình học môn **Phương pháp phát triển phần mềm hướng đối tượng**.

---

## Thông tin sinh viên

- **Họ và tên:** Phạm Thị Thùy Trang
- **MSSV:** 1250080207
- **Lớp:** 12_ĐH_CNPM2
- **Khoá:** 2023 – 2027
- **Môn học:** Phương pháp phát triển phần mềm hướng đối tượng
- **Giảng viên hướng dẫn:** ThS Phạm Trọng Huynh

---

## Công nghệ & Công cụ sử dụng

- **Lập trình:** C# WinForms (.NET Framework 4.7.2), Java
- **Cơ sở dữ liệu:** SQL Server / Oracle Database
- **Kiến trúc:** 3 lớp (UI → Service / Adapter → Data → SQL Server)
- **Vẽ mô hình:** PlantUML, StarUML (Use Case, Class, Activity, Sequence, ERD, State Machine...)
- **Công cụ:** Visual Studio 2022, SQL Server Management Studio (SSMS), IntelliJ IDEA, Draw.io, Git/GitHub trên macOS

---

## Danh sách các bài tập (Folder LAB)

| Bài | Tên đề tài / Chủ đề | Nội dung đã thực hiện |
| :---: | :--- | :--- |
| **LAB 0** | Cài đặt & Kiểm tra môi trường | Cài đặt JDK 21, Maven 3.9, Git trên macOS; cấu hình `JAVA_HOME` & `MAVEN_HOME`; cài plugin PlantUML; chạy starter project OOP và thực hiện commit Git đầu tiên. |
| **LAB 1** | Đặc tả Yêu cầu Use Case | Khảo sát nghiệp vụ và lập đặc tả Use Case chi tiết cho 2 hệ thống: **Bài 1 - Thư viện trực tuyến** và **Bài 2 - Cửa hàng Nước giải khát** (Kèm Use Case, Class, Activity, Sequence Diagram). |
| **LAB 2** | Hệ thống Quản lý Thư viện | Phân tích bài toán Quản lý thư viện: thiết kế CSDL SQL Server, vẽ bộ sơ đồ UML toàn diện, phác thảo giao diện và hiện thực code C# WinForms chuẩn 3 lớp. |
| **LAB 3** | Hệ thống Quản lý Khách sạn | Khảo sát nghiệp vụ lưu trú, tra cứu, tính toán; vẽ UML; thiết kế CSDL và giao diện cho các chức năng: Đặt/Nhận phòng, Tiện nghi, Dịch vụ, Trả phòng & Thanh toán. |
| **LAB 4** | Hệ thống e-SHOPPING | Phân tích hệ thống bán hàng online kết nối API thanh toán bên thứ ba: xây dựng mô hình UML, ERD, CSDL Oracle và thiết kế prototype WinForms. |
| **LAB 5** | Quản lý Công ty Du lịch | Phân tích nghiệp vụ điều hành tour: quản lý chuyến đi, đăng ký khách lẻ/đoàn, phân công hướng dẫn viên chống trùng lịch, tính lương và làm khảo sát. |
| **LAB 6** | Quản lý Hồ sơ Bệnh án | Phân tích quy trình tiếp nhận bệnh nhân, hồ sơ bệnh án, lịch khám định kỳ, xét nghiệm, kê toa thuốc và thanh toán viện phí; thiết kế CSDL có transaction chặt chẽ. |
| **LAB 7** | Quản lý Nhân sự | Phân tích nghiệp vụ tuyển dụng, hợp đồng, hồ sơ BHXH/BHYT, chấm công, giờ phụ trội, khen thưởng/kỷ luật và tổng hợp tính lương tháng cho công ty Sơn Đông Á. |
| **LAB 8** | Quản lý Cửa hàng Nước Giải Khát | Phân tích toàn diện quy trình mua bán NGK: nhà cung ứng, đơn đặt hàng, bán hàng kiểm tra tồn kho, phiếu hẹn nhiều đợt và phiếu ghi nợ; hiện thực WinForms. |

---

## Cấu trúc lưu trữ Repository

```text
LAB_OOSD/
├── LAB0/         # Báo cáo cài đặt môi trường Java, Maven, Git, IntelliJ & file starter project
├── LAB1/         # File đặc tả yêu cầu Use Case (Thư viện trực tuyến & Cửa hàng Nước giải khát)
├── LAB2/         # Bài tập Hệ thống Quản lý Thư viện (Báo cáo, UML, CSDL, WinForms)
├── LAB3/         # Bài tập Hệ thống Quản lý Khách sạn (Báo cáo, UML, CSDL, WinForms)
├── LAB4/         # Bài tập Hệ thống e-SHOPPING (Mô hình UML, CSDL, Prototype WinForms)
├── LAB5/         # Bài tập Quản lý Du lịch Văn Hóa Việt (Báo cáo, UML, CSDL)
├── LAB6/         # Bài tập Quản lý Hồ sơ Bệnh án & Khám chữa bệnh (Báo cáo, UML, CSDL)
├── LAB7/         # Bài tập Quản lý Nhân sự Công ty Sơn Đông Á (Báo cáo, UML, CSDL)
└── LAB8/         # Bài tập Quản lý Cửa hàng Nước Giải Khát (Báo cáo, Script SQL, Source C#, README)

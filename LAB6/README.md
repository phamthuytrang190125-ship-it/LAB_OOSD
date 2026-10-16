# Hệ Thống Quản Lý Công Ty Du Lịch
## Công Nghệ & Công Cụ Sử Dụng
*   **Ngôn ngữ lập trình:** C#
*   **Giao diện:** Windows Forms (WinForms)
*   **Cơ sở dữ liệu:** Oracle Database (hoạt động trên macOS qua UTM Virtual Machine - IP: 192.168.22.51)
*   **Thư viện kết nối:** `Oracle.ManagedDataAccess` (Cài đặt qua NuGet Package)
*   **Phân tích thiết kế:** Draw.io kết hợp mã code PlantUML (Class, Use Case, Activity, Sequence Diagram)
*   **Môi trường lập trình:** Visual Studio 2022 trên Windows 11 VM

## Các Chức Năng & Tiến Độ (Đã hoàn thiện)
*   **Phân tích & Thiết kế (UML):** Hoàn thiện bộ hồ sơ thiết kế chuẩn xác bao gồm Class Diagram (12 lớp đối tượng), Use Case Diagram (3 Actor chính), Activity Diagram (Swimlanes đăng ký & thanh toán), và Sequence Diagram (tạo Phiếu đăng ký).
*   **Thiết kế Cơ sở dữ liệu:** Xây dựng mô hình quan hệ gồm 7 bảng cốt lõi (`NHAN_VIEN`, `TOUR`, `CHUYEN_DI`, `KHACH_HANG`, `PHIEU_DANG_KY`, `HANH_KHACH`, `PHAN_CONG_HDV`) kèm dữ liệu mẫu thực tế chuẩn xác.
*   **Giao diện Điều hướng (FrmMain):** Xây dựng bộ khung giao diện phần mềm quản trị (Form Cha MDI) với `MenuStrip` và `StatusStrip`, chia 4 nhóm menu (Hệ thống, Quản lý Danh mục, Nghiệp vụ Du lịch, Thống kê & Báo cáo).
*   **Lớp Kết Nối An Toàn:** Khởi tạo class `KetNoiDB.cs` chuyên biệt để quản lý kết nối CSDL chuẩn mô hình 3 lớp.

## Hướng Dẫn Cài Đặt & Chạy Dự Án

### 1. Thiết lập Cơ sở dữ liệu (Oracle)
1. Đảm bảo Oracle Database trên máy Mac đang hoạt động và mạng nội bộ giữa máy ảo Windows và Mac đã thông suốt (ping thành công IP `192.168.22.51`).
2. Mở Oracle SQL Developer (hoặc SQL*Plus), copy và Run toàn bộ script SQL để khởi tạo 7 bảng và chèn dữ liệu mẫu (Tour, Nhân viên, Khách hàng).

### 2. Thiết lập Project (Visual Studio)
1. Khởi động Visual Studio trên Windows và mở solution `QuanLyCongTyDuLich.sln`.
2. Mở file `KetNoiDB.cs` và cập nhật lại chuỗi kết nối (`strKetNoi`) để trỏ đúng vào máy chủ Oracle:
   ```csharp
   // Đảm bảo trỏ đúng IP 192.168.22.51 và User ID/Password của Oracle
   private string strKetNoi = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.22.51)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREE)));User Id=system;Password=MatKhauCuaBan;";


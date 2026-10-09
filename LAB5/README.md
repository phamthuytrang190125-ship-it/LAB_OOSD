# BÁO CÁO BÀI 6: HỆ THỐNG QUẢN LÝ CÔNG TY DU LỊCH (UML & C# WinForms)

**1. Thông tin sinh viên**
- **Họ và tên:** Phạm Thị Thuỳ Trang
- **MSSV:** 1250080207
- **Tên bài / Đồ án:** Bài 6 - Phân tích, thiết kế và xây dựng Hệ thống Quản lý Công ty Du lịch (UML, Oracle & C# WinForms)

**2. Môi trường và Phiên bản công nghệ (Environment / Version)**
- **Hệ điều hành Host (Máy chủ Database):** macOS (chạy Oracle Database Free qua UTM Virtual Machine).
- **Địa chỉ IP cơ sở dữ liệu:** 192.168.22.51 (Cổng: 1521, Service Name: FREE).
- **Hệ điều hành Client (Môi trường lập trình):** Windows 11 VM (chạy trên UTM).
- **Công cụ phát triển:** Visual Studio 2022 (C# .NET Windows Forms).
- **Thư viện kết nối C# - Oracle:** `Oracle.ManagedDataAccess` (Cài đặt qua NuGet Package).
- **Công cụ thiết kế UML:** Draw.io kết hợp mã code PlantUML.

**3. Nội dung đã thực hiện**
Hoàn thành toàn bộ quy trình từ phân tích, thiết kế hệ thống đến lập trình giao diện cơ bản, bao gồm:
- **Phân tích & Thiết kế hệ thống (UML):**
  * Vẽ **Class Diagram**: Xác định 12 lớp đối tượng (Tour, ChuyenDi, KhachDoan, KhachLe, PhieuDangKy...) kèm các mối quan hệ kế thừa, tập hợp.
  * Vẽ **Use Case Diagram**: Tổng quát hóa chức năng cho 3 Actor chính (Khách hàng, Nhân viên điều hành, Hướng dẫn viên). Phân rã chi tiết Use Case cho quy trình "Đăng ký tour".
  * Vẽ **Activity Diagram**: Mô phỏng luồng nghiệp vụ đăng ký và thanh toán theo dạng Swimlanes (phân làn).
  * Vẽ **Sequence Diagram**: Mô tả tuần tự tương tác tạo Phiếu đăng ký tour đoàn.
- **Thiết kế Cơ sở dữ liệu (Oracle):** Xây dựng mô hình quan hệ gồm 7 bảng cốt lõi: `NHAN_VIEN`, `TOUR`, `CHUYEN_DI`, `KHACH_HANG`, `PHIEU_DANG_KY`, `HANH_KHACH`, `PHAN_CONG_HDV`. Tiến hành chèn dữ liệu mẫu thực tế chuẩn xác.
- **Phát triển Giao diện & Điều hướng (C# WinForms):**
  * Khởi tạo class `KetNoiDB.cs` chuyên biệt để quản lý kết nối CSDL chuẩn mô hình 3 lớp.
  * Xây dựng **FrmMain (MDI Container)**: Thiết kế giao diện Dashboard chuyên nghiệp với `MenuStrip` và `StatusStrip`. Thanh menu chia làm 4 nhóm: Hệ thống, Quản lý Danh mục, Nghiệp vụ Du lịch, Thống kê & Báo cáo.

**4. Kết quả đạt được**
- Hoàn thiện bộ hồ sơ thiết kế UML chuẩn xác theo đúng quy tắc nghiệp vụ (đăng ký đoàn/lẻ, tính lương, phân công).
- Kết nối thành công mạng giữa máy ảo Windows (Visual Studio) và Oracle Database trên máy Mac.
- Xây dựng thành công bộ khung giao diện phần mềm quản trị (Form Cha MDI), sẵn sàng cho việc tích hợp các module quản lý (Form Con) tiếp theo.

**5. Các lỗi gặp phải và Cách khắc phục**
Trong quá trình phát triển trên máy Mac (Apple Silicon M-chip qua UTM) và cài đặt NuGet, đã gặp một số vấn đề và được xử lý triệt để:
- **Lỗi CS1061: 'FrmMain' does not contain a definition for 'FrmMain_Load'**
  * *Nguyên nhân:* Xung đột code do vô tình click đúp tạo sự kiện `Load` trên giao diện Design, nhưng sau đó dán code mới chép đè làm mất hàm này ở file `FrmMain.cs`.
  * *Cách khắc phục:* Click trực tiếp vào thông báo lỗi để mở file ẩn `FrmMain.Designer.cs`, xóa dòng code rác gọi sự kiện (delegate) bị lỗi và lưu lại.
- **Lỗi Failed to update binding redirects khi cài ODP.NET**
  * *Nguyên nhân:* Visual Studio gặp sự cố nhỏ khi cập nhật file cấu hình dự án lúc cài thư viện `Oracle.ManagedDataAccess` qua NuGet.
  * *Cách khắc phục:* Đây chỉ là cảnh báo (Warning), các gói dependency thực tế đã cài đặt thành công ("Successfully installed..."). Có thể bỏ qua và sử dụng thư viện bình thường bằng từ khóa `using Oracle.ManagedDataAccess.Client;`.

**6. Hướng dẫn kiểm tra và chạy lại chương trình**
 * **Bước 1 (Khởi động CSDL):** Đảm bảo Oracle Database trên máy Mac đang hoạt động và mạng nội bộ giữa máy ảo Windows và Mac đã thông suốt (ping thành công IP `192.168.22.51`).
 * **Bước 2 (Chạy Script DB):** Nếu đây là lần chạy đầu tiên, hãy mở Oracle SQL Developer, copy và Run toàn bộ script SQL để tạo 7 bảng và chèn dữ liệu mẫu (Tour, Nhân viên, Khách hàng).
 * **Bước 3 (Mở Project):** Khởi động Visual Studio trên Windows và mở solution `QuanLyCongTyDuLich.sln`.
 * **Bước 4 (Cấu hình IP):** Mở file `KetNoiDB.cs`, kiểm tra biến `strKetNoi` đảm bảo đã trỏ đúng IP `192.168.22.51` và User ID/Password của Oracle.
 * **Bước 5 (Chạy ứng dụng):** Nhấn nút Start (F5).
 * **Bước 6 (Thao tác kiểm tra):** Giao diện chính `FrmMain` xuất hiện ở chế độ toàn màn hình. Click thử vào các menu thả xuống trên thanh điều hướng (VD: *Quản Lý Danh Mục > Quản lý Tour & Lịch trình*) để kiểm tra các sự kiện mở form hoặc popup thông báo đã hoạt động.

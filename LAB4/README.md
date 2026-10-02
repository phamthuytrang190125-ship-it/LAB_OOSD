# BÁO CÁO LAB 4: HỆ THỐNG PHẦN MỀM CỦA HÀNG ONLINE "E-SHOPPINHG" (C# WinForms)

1. Thông tin sinh viên
* Họ và tên:Phạm Thị Thuỳ Trang
* MSSV: 1250080207
* Tên bài Lab:Lab 4 - Hệ thống phần mềm của hàng online e-shopping (WinForms & C#)

2. Môi trường và Phiên bản công nghệ (Environment / Version)
* Hệ điều hành Host (Máy chủ Database): macOS (chạy Oracle Database Free qua UTM Virtual Machine).
* Địa chỉ IP cơ sở dữ liệu: 192.168.22.51 (Cổng: 1521, Service Name: FREE).
* Hệ điều hành Client (Môi trường lập trình): Windows VM (chạy trên Parallels/UTM).
* Công cụ phát triển: Visual Studio (C# .NET Windows Forms).
* Thư viện kết nối C# - Oracle: Oracle.ManagedDataAccess (NuGet Package).
  
3. Nội dung đã thực hiện
Xây dựng thành công ứng dụng quản lý khách sạn hoàn chỉnh gồm các chức năng chính:
* Thiết kế Cơ sở dữ liệu (Oracle): Xây dựng mô hình quan hệ gồm 8 bảng cốt lõi: NhomSanPham, KhachHang, SanPham, GioHang, ChiTietGioHang, DonHang, ChiTietDonHang, TheTinDung. Tiến hành chèn dữ liệu mẫu thực tế (mỗi bảng từ 4-5 bản ghi phong phú).
* Phát triển Giao diện & Điều hướng (FrmMain):
  * Xây dựng thanh menu trực quan gồm 3 nhóm chính: Hệ thống, Danh mục (Sản phẩm, Nhóm sản phẩm, Khách hàng) và Nghiệp vụ (Xem giỏ hàng, Tạo đơn đặt hàng, Thanh toán thẻ tín dụng).
  * Sử dụng DataGridView kết hợp OracleDataAdapter để đổ dữ liệu động từ Oracle lên giao diện theo thời gian thực.
* Mở rộng tính năng tương tác:
  * Xây dựng FrmLogin: Cho phép khách hàng đăng nhập hệ thống bằng tài khoản được lưu trong bảng KhachHang.
  * Xây dựng FrmThemSanPham: Cho phép thực thi câu lệnh INSERT để thêm mới sản phẩm trực tiếp từ giao diện Windows Forms xuống CSDL Oracle.

4. Kết quả đạt được
* Kết nối thành công mạng giữa máy ảo Windows và Oracle Database trên máy Mac.
* Ứng dụng chạy mượt mà, thực hiện đầy đủ các chức năng xem dữ liệu, đăng nhập và thêm mới sản phẩm thành công 100%.

5. Các lỗi gặp phải và Cách khắc phục
Trong quá trình phát triển trên máy Mac (Apple Silicon M-chip qua UTM), đã gặp một số vấn đề và được xử lý triệt để:
* Lỗi ORA-50000 / ORA-50201 (Connection request timed out / Failed to connect)
  * *Nguyên nhân:* Mạng Wi-Fi thay đổi động làm địa chỉ IP của máy Mac thay đổi, hoặc chuỗi kết nối sai Service Name (FREE thay vì orcl).
  * *Cách khắc phục:* Kiểm tra IP hiện tại của Mac trong Network Settings, cập nhật lại chuỗi kết nối (Data Source=IP_MỚI:1521/FREE) và cấu hình đúng chuẩn EZConnect.
* Lỗi Lỗi xung đột file .Designer.cs khi tạo form bằng code thuần
  * *Nguyên nhân:* Visual Studio tự sinh file Designer và bắt buộc tìm các hàm sự kiện mặc định (*_Load, Dispose).
  * *Cách khắc phục:* Xóa các file Designer phụ không cần thiết, đồng thời cấu hình lớp ở dạng class thuần hoặc đồng bộ đầy đủ các phương thức partial.
* Lỗi font chữ tiếng Việt khi hiển thị dữ liệu
  * *Nguyên nhân:* Mã hóa ký tự giữa Client và Server Oracle chưa khớp.
  * *Cách khắc phục:* Thêm lệnh SET DEFINE OFF; trước khi chạy script SQL và đảm bảo cơ sở dữ liệu sử dụng bảng mã chuẩn UTF-8.

6. Hướng dẫn kiểm tra và chạy lại chương trình
1. Khởi động Cơ sở dữ liệu: Đảm bảo Oracle Database trên máy Mac đang hoạt động và mạng nội bộ giữa máy ảo Windows và Mac đã thông suốt (có thể ping thấy địa chỉ IP 192.168.22.51).
2. Mở Project: Khởi động Visual Studio trên Windows và mở solution HeThongEShopping.sln.
3. Kiểm tra Chuỗi kết nối: Mở các file FrmMain.cs, FrmLogin.cs, và FrmThemSanPham.cs, kiểm tra đoạn conString đảm bảo trỏ đúng IP 192.168.22.51 và mật khẩu Oracle của bạn.
4. Chạy ứng dụng: Nhấn nút Start (F5) trên thanh công cụ của Visual Studio.
5. Thao tác kiểm tra:
   * Vào Danh mục > Sản phẩm để xem danh sách sản phẩm đổ từ Oracle lên lưới.
   * Vào Hệ thống > Đăng nhập Khách hàng để thử nghiệm tính năng đăng nhập (Tài khoản mẫu: ptttrang / 123456 hoặc annguyen / pass123).
   * Sử dụng form thêm sản phẩm để kiểm tra chức năng ghi dữ liệu xuống CSDL.

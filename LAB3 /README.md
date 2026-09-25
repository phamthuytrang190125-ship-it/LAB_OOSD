# BÁO CÁO LAB 3: ĐỒ ÁN QUẢN LÝ KHÁCH SẠN (C# WinForms)

## 1. Thông tin sinh viên
Họ và tên:Phạm Thị Thuỳ Trang
Mã số sinh viên (MSSV):** [Điền MSSV của bạn vào đây]
* **Tên bài Lab:** Lab 3 - Xây dựng ứng dụng Quản lý Khách sạn (WinForms & SQL Server)

## 2. Môi trường & Công nghệ sử dụng
* **Ngôn ngữ lập trình:** C# (.NET Framework / .NET Core)
* **Giao diện:** Windows Forms (WinForms)
* **IDE:** Visual Studio 2019 / 2022
* **Hệ quản trị CSDL:** SQL Server
* **Môi trường đặc biệt:** Chạy trên máy ảo UTM (kiến trúc ARM Apple Silicon M-chip của macOS giả lập Windows).

## 3. Nội dung đã thực hiện
Xây dựng thành công ứng dụng quản lý khách sạn hoàn chỉnh gồm các chức năng chính:
* **Màn hình chính (`FormMain`):** Điều hướng trung tâm đến toàn bộ các phân hệ của hệ thống.
* **Quản lý danh mục (`FrmDanhMuc`):** 
  * Thiết kế giao diện theo dạng `TabControl` gồm 5 tab: Khu vực, Nhân viên, Loại tiện nghi, Dịch vụ, Quy định đền bù.
  * Tự động nạp dữ liệu từ cơ sở dữ liệu lên bảng (`DataGridView`).
* **Đặt / Nhận phòng (`FrmDatPhong`):**
  * Quản lý thông tin khách hàng, kênh đặt phòng, tiền cọc.
  * Thêm phòng vào danh sách chọn, kiểm tra sức chứa và lập phiếu đặt phòng.
* **Trả phòng & Thanh toán (`FrmTraPhong`):**
  * Kiểm tra tiện nghi phòng, ghi nhận mức độ hư hỏng và lập phiếu đền bù.
  * Tính tiền phòng, tiền dịch vụ, lập hóa đơn và thực hiện giao dịch thanh toán, giải phóng phòng.
* **Thống kê (`FrmThongKe`):**
  * Thống kê tổng hợp số lượng phiếu đặt, phòng đang ở, hóa đơn, doanh thu và tổng tiền đền bù theo khoảng thời gian tùy chọn (`DateTimePicker`).
  * Thống kê chi tiết dịch vụ sử dụng.

## 4. Kết quả đạt được
* Hoàn thành 100% các form giao diện trực quan theo đúng hướng dẫn của bài thực hành.
* Các sự kiện tương tác (`Click`, `SelectionChanged`, `Load`) và câu lệnh truy vấn SQL tương tác cơ sở dữ liệu hoạt động mượt mà, không phát sinh lỗi biên dịch.

## 5. Các lỗi gặp phải và Cách khắc phục
Trong quá trình phát triển (đặc biệt chạy trên môi trường giả lập máy ảo ARM Mac), đã gặp một số vấn đề và được xử lý triệt để:
* **Lỗi thiếu file cấu hình (`AssemblyInfo.cs`, `Settings.Designer.cs`):** 
  * *Nguyên nhân:* Do xung đột đường dẫn hoặc vô tình xóa nhầm file thành phần trong thư mục `Properties`.
  * *Cách khắc phục:* Dọn dẹp lại cấu trúc dự án trong Solution Explorer, loại bỏ (`Exclude`) các file tham chiếu hỏng và chuẩn hóa lại mã nguồn thiết kế.
* **Lỗi không tương thích kiến trúc phần cứng (LocalDB trên Apple Silicon):**
  * *Nguyên nhân:* Giới hạn của chip ARM khi chạy trực tiếp các dịch vụ SQL Server LocalDB mặc định.
  * *Cách khắc phục:* Xây dựng lớp hỗ trợ kết nối (`DatabaseHelper`/`Db.cs`) linh hoạt, sử dụng chuỗi kết nối chuẩn và cấu hình bảng dữ liệu rõ ràng để truy vấn an toàn.
* **Lỗi kiểu dữ liệu Generic (`BindingList`) và định dạng chuỗi:**
  * *Nguyên nhân:* Thiếu tham số kiểu dữ liệu khi khai báo danh sách tạm cho các bảng chọn hoặc dùng sai cú pháp chuỗi đời mới.
  * *Cách khắc phục:* Bổ sung đầy đủ tham số kiểu (``, ``) và chuẩn hóa lại cú pháp nối chuỗi tương thích mọi phiên bản .NET.

## 6. Hướng dẫn kiểm tra và chạy lại chương trình
1. **Chuẩn bị CSDL:** Mở SQL Server Management Studio (SSMS), chạy tập lệnh tạo cơ sở dữ liệu của bài học để nạp dữ liệu mẫu (Khu vực, Phòng, Khách hàng, Dịch vụ...).
2. **Mở dự án:** Khởi động phần mềm **Visual Studio**, chọn *Open a project or solution* và dẫn tới file chứa đồ án (`QuanLyKhachSan.sln`).
3. **Cấu hình khởi động:** Đảm bảo file `Program.cs` đang gọi điểm bắt đầu là `Application.Run(new FormMain());`.
4. **Chạy ứng dụng:** Nhấn nút **Start** (màu xanh lá ở thanh công cụ trên cùng) hoặc phím tắt `F5` để biên dịch và trải nghiệm các chức năng.

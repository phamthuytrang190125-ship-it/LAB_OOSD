# BÁO CÁO LAB 3: ĐỒ ÁN QUẢN LÝ KHÁCH SẠN (C# WinForms)

1. Thông tin sinh viên
* Họ và tên:Phạm Thị Thuỳ Trang
* MSSV: 1250080207
* Tên bài Lab:Lab 3 - Xây dựng ứng dụng Quản lý Khách sạn (WinForms & C#)

## 2. Môi trường & Công nghệ sử dụng
* **Ngôn ngữ lập trình:** C# (.NET Framework / .NET Core)
* **Giao diện:** Windows Forms (WinForms)
* **IDE:** Visual Studio 2019 / 2022
* **Môi trường đặc biệt:** Phát triển trên môi trường Windows ảo hóa bằng phần mềm **UTM** chạy trên máy Mac kiến trúc ARM (Apple Silicon M-chip). Do hạn chế phần cứng, dự án sử dụng các chiến lược kết nối giả lập/dữ liệu bộ nhớ (`BindingList`, `DataTable` nội bộ) để tối ưu hóa hiệu năng.

## 3. Nội dung đã thực hiện
Xây dựng thành công ứng dụng quản lý khách sạn hoàn chỉnh gồm các chức năng chính:
* **Màn hình chính (`FormMain`):** Điều hướng trung tâm đến toàn bộ các phân hệ của hệ thống.
* **Quản lý danh mục (`FrmDanhMuc`):** 
  * Thiết kế giao diện theo dạng `TabControl` gồm 5 tab: Khu vực, Nhân viên, Loại tiện nghi, Dịch vụ, Quy định đền bù.
  * Quản lý và nạp dữ liệu giao diện trực quan.
* **Đặt / Nhận phòng (`FrmDatPhong`):**
  * Quản lý thông tin khách hàng, kênh đặt phòng, tiền cọc.
  * Thêm phòng vào danh sách chọn thông qua bảng tạm, kiểm tra sức chứa và lập phiếu đặt phòng.
* **Trả phòng & Thanh toán (`FrmTraPhong`):**
  * Kiểm tra tiện nghi phòng, ghi nhận mức độ hư hỏng và lập phiếu đền bù.
  * Tính tiền phòng, tiền dịch vụ, lập hóa đơn và thực hiện giao dịch thanh toán, giải phóng phòng.
* **Thống kê (`FrmThongKe`):**
  * Thống kê tổng hợp số lượng phiếu đặt, phòng đang ở, hóa đơn, doanh thu và tổng tiền đền bù theo khoảng thời gian tùy chọn (`DateTimePicker`).
  * Thống kê chi tiết dịch vụ sử dụng.

## 4. Kết quả đạt được
* Hoàn thành 100% các form giao diện trực quan theo đúng hướng dẫn của bài thực hành.
* Các sự kiện tương tác (`Click`, `SelectionChanged`, `Load`) hoạt động mượt mà, không phát sinh lỗi biên dịch, giao diện bố trí đúng chuẩn yêu cầu học tập.

## 5. Các lỗi gặp phải và Cách khắc phục
Trong quá trình phát triển trên máy Mac (Apple Silicon M-chip qua UTM), đã gặp một số vấn đề và được xử lý triệt để:
* **Lỗi thiếu file cấu hình (`AssemblyInfo.cs`, `Settings.Designer.cs`):** 
  * *Nguyên nhân:* Do xung đột đường dẫn hoặc vô tình xóa nhầm file thành phần trong thư mục `Properties`.
  * *Cách khắc phục:* Dọn dẹp lại cấu trúc dự án trong Solution Explorer, loại bỏ (`Exclude`) các file tham chiếu hỏng và chuẩn hóa lại mã nguồn thiết kế.
* **Lỗi không tương thích phần cứng (Hạn chế cài đặt LocalDB đầy đủ):**
  * *Nguyên nhân:* Môi trường máy ảo ARM gặp khó khăn khi khởi chạy các dịch vụ hệ thống nặng của cơ sở dữ liệu truyền thống.
  * *Cách khắc phục:* Chuyển hướng sang sử dụng các mô hình cấu trúc dữ liệu nhẹ, danh sách liên kết (`BindingList`) và bảng dữ liệu nội bộ (`DataTable`) để giả lập giao diện và logic mượt mà.
* **Lỗi kiểu dữ liệu Generic (`BindingList`) và định dạng chuỗi:**
  * *Nguyên nhân:* Thiếu tham số kiểu dữ liệu khi khai báo danh sách tạm cho các bảng chọn hoặc dùng sai cú pháp chuỗi đời mới.
  * *Cách khắc phục:* Bổ sung đầy đủ tham số kiểu (``, ``) và chuẩn hóa lại cú pháp nối chuỗi tương thích mọi phiên bản .NET.

## 6. Hướng dẫn kiểm tra và chạy lại chương trình
1. **Mở dự án:** Khởi động phần mềm **Visual Studio** trong máy ảo Windows, chọn *Open a project or solution* và dẫn tới file chứa đồ án (`QuanLyKhachSan.sln`).
2. **Cấu hình khởi động:** Đảm bảo file `Program.cs` đang gọi điểm bắt đầu là `Application.Run(new FormMain());`.
3. **Chạy ứng dụng:** Nhấn nút **Start** (màu xanh lá ở thanh công cụ trên cùng) hoặc phím tắt `F5` để biên dịch. Màn hình điều hướng `FormMain` sẽ xuất hiện, giảng viên có thể bấm trực tiếp vào các nút chức năng để kiểm tra từng form con.

package com.example.baocaosuco.entity; // Lưu ý: Sửa lại tên package này cho khớp với đường dẫn thực tế trên máy bạn nếu VS Code báo đỏ dòng này.

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Data;
import java.time.LocalDateTime;

@Data // Annotation của Lombok tự động sinh Getter/Setter
@Entity
@Table(name = "SU_CO")
public class SuCo {

    @Id
    @Column(name = "MaSuCo", length = 20)
    private String maSuCo;

    @Column(name = "NgayBaoCao")
    private LocalDateTime ngayBaoCao;

    @Column(name = "HoTenNguoiBao", length = 100)
    private String hoTenNguoiBao;

    @Column(name = "SoDienThoaiNguoiBao", length = 20)
    private String soDienThoaiNguoiBao;

    @Column(name = "DiaChi", length = 255)
    private String diaChi;

    @Column(name = "MoTaChiTiet", length = 500)
    private String moTaChiTiet;

    @Column(name = "TrangThai", length = 50)
    private String trangThai;
    
    // Tạm thời ẩn các khóa ngoại (MaLoai, NguoiDuyet) để test luồng Insert cơ bản trước
}
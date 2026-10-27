package com.example.baocaosuco.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.example.baocaosuco.entity.SuCo;
import com.example.baocaosuco.repository.SuCoRepository;

import java.time.LocalDateTime;
import java.util.UUID;

@Controller
public class SuCoController {

    @Autowired
    private SuCoRepository suCoRepository;

    // 1. Hiển thị Trang chủ (Landing Page)
    @GetMapping("/")
    public String showIndex() {
        return "index";
    }

    // 2. Hiển thị Form lập báo cáo sự cố
    @GetMapping("/baocao")
    public String showBaoCaoForm(Model model) {
        model.addAttribute("suCo", new SuCo());
        return "baocao";
    }

    // 3. Xử lý lưu dữ liệu vào Oracle khi người dân bấm Gửi báo cáo
    @PostMapping("/submit-bao-cao")
    public String submitBaoCao(SuCo suCo, Model model) {
        suCo.setMaSuCo("SC-" + UUID.randomUUID().toString().substring(0, 5).toUpperCase());
        suCo.setNgayBaoCao(LocalDateTime.now());
        suCo.setTrangThai("Chờ duyệt");
        
        suCoRepository.save(suCo);
        
        model.addAttribute("message", "Gửi báo cáo thành công! Mã tra cứu của bạn là: " + suCo.getMaSuCo());
        model.addAttribute("suCo", new SuCo());
        
        return "baocao"; 
    }

    // 4. Trang Đăng nhập nội bộ
    @GetMapping("/login")
    public String showLogin() {
        return "login"; 
    }

    // 5. // Xử lý phân quyền thông minh dựa theo đúng Use Case của từng Actor
    @GetMapping("/admin")
    public String showAdmin(@RequestParam(name = "username", defaultValue = "admin") String username, Model model) {
        
        // 1. Nếu là Quản trị viên -> Điều hướng sang trang Quản lý tài khoản / Danh mục hệ thống
        if ("admin".equals(username)) {
            return "redirect:/taikhoan";
        } 
        
        // 2. Nếu là Điều phối viên -> Ở lại trang Quản lý sự cố & Phân công
        if ("dieuphoi1".equals(username)) {
            model.addAttribute("hoTen", "Trần Minh Trí");
            model.addAttribute("quyenHan", "Điều phối viên");
            return "admin";
        } 
        
        // 3. Nếu là Nhân viên hiện trường -> Đá thẳng sang trang Nhiệm vụ của tôi
        if ("nhanvien1".equals(username) || "nhanvien2".equals(username)) {
            return "redirect:/nhiemvu?username=" + username;
        }
        
        return "redirect:/login";
    }

    // 6. Trang nhiệm vụ dành riêng cho Nhân viên hiện trường
    @GetMapping("/nhiemvu")
    public String showNhiemVu(@RequestParam(name = "username", defaultValue = "nhanvien1") String username, Model model) {
        String hoTen = "Lê Diệu Tường";
        String quyenHan = "Nhân viên hiện trường (Đội Phản Ứng Nhanh)";
        
        if ("nhanvien2".equals(username)) {
            hoTen = "Phạm Bảo Khang";
            quyenHan = "Nhân viên hiện trường (Đội Xử Lý Nước Thải)";
        }
        
        model.addAttribute("hoTen", hoTen);
        model.addAttribute("quyenHan", quyenHan);
        return "nhiemvu";
    }

    // 7. Trang Tra cứu trạng thái sự cố
    @GetMapping("/tracuu")
    public String showTraCuu() {
        return "tracuu"; 
    }

    // 8. Trang Báo cáo thống kê
    @GetMapping("/thongke")
    public String showThongKe() {
        return "thongke";
    }

    // 9. Trang Quản lý danh mục
    @GetMapping("/danhmuc")
    public String showDanhMuc() {
        return "danhmuc";
    }

    // 10. Trang Quản lý tài khoản nội bộ
    @GetMapping("/taikhoan")
    public String showTaiKhoan() {
        return "taikhoan";
    }

    // 11. Trang Hồ sơ cá nhân
    @GetMapping("/hoso")
    public String showHoSo() {
        return "hoso";
    }
}
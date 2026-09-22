using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class MuonTraService
    {
        public KetQuaXuLy KiemTraDieuKienMuon(string maDocGia, int soSachMuonMoi)
        {
            if (string.IsNullOrWhiteSpace(maDocGia)) return KetQuaXuLy.Loi("Vui lòng chọn độc giả.");
            if (soSachMuonMoi < 1) return KetQuaXuLy.Loi("Phải chọn ít nhất 1 đầu sách.");
            if (soSachMuonMoi > 3) return KetQuaXuLy.Loi("Một lần lập phiếu chỉ được chọn tối đa 3 đầu sách khác nhau.");

            DataTable the = Db.Query(@"SELECT TOP 1 MaThe,HanSuDung,DaDongLePhi,TrangThai 
                                       FROM TheDocGia WHERE MaDocGia=@Ma AND TrangThai=1 
                                       ORDER BY HanSuDung DESC", new SqlParameter("@Ma", maDocGia));
            if (the.Rows.Count == 0) return KetQuaXuLy.Loi("Độc giả chưa có thẻ thư viện đang hoạt động.");

            DateTime han = Convert.ToDateTime(the.Rows[0]["HanSuDung"]);
            bool lePhi = Convert.ToBoolean(the.Rows[0]["DaDongLePhi"]);
            if (han.Date < DateTime.Today) return KetQuaXuLy.Loi("Thẻ thư viện đã hết hạn.");
            if (!lePhi) return KetQuaXuLy.Loi("Độc giả chưa đóng lệ phí năm nên thẻ chưa có giá trị.");

            int quaHan = Convert.ToInt32(Db.Query(@"SELECT COUNT(*) 
                                     FROM PhieuMuon pm 
                                     JOIN ChiTietPhieuMuon ct ON ct.MaPhieuMuon=pm.MaPhieuMuon 
                                     WHERE pm.MaDocGia=@Ma AND ct.NgayTraThucTe IS NULL 
                                     AND pm.NgayHenTra < CAST(GETDATE() AS date)").Rows[0][0]);
            if (quaHan > 0) return KetQuaXuLy.Loi("Độc giả còn sách quá hạn chưa trả nên không được mượn thêm.");

            int dangMuon = Convert.ToInt32(Db.Query(@"SELECT COUNT(*) 
                                       FROM PhieuMuon pm 
                                       JOIN ChiTietPhieuMuon ct ON ct.MaPhieuMuon=pm.MaPhieuMuon 
                                       WHERE pm.MaDocGia=@Ma AND ct.NgayTraThucTe IS NULL").Rows[0][0]);
            if (dangMuon + soSachMuonMoi > 3)
                return KetQuaXuLy.Loi("Tổng số sách đang mượn và sắp mượn không được vượt quá 3 cuốn.");

            return KetQuaXuLy.Ok("Độc giả đủ điều kiện mượn sách.");
        }

        public KetQuaXuLy LapPhieuMuon(string maDocGia, string maNhanVien, List<string> maDauSach, DateTime ngayMuon, DateTime ngayHenTra)
        {
            if (maDauSach == null) return KetQuaXuLy.Loi("Danh sách mượn không hợp lệ.");
            HashSet<string> unique = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string ma in maDauSach)
                if (!string.IsNullOrWhiteSpace(ma)) unique.Add(ma.Trim());

            KetQuaXuLy kq = KiemTraDieuKienMuon(maDocGia, unique.Count);
            if (!kq.ThanhCong) return kq;
            if (string.IsNullOrWhiteSpace(maNhanVien)) return KetQuaXuLy.Loi("Vui lòng chọn nhân viên lập phiếu.");
            if (ngayHenTra.Date < ngayMuon.Date) return KetQuaXuLy.Loi("Ngày hẹn trả không được trước ngày mượn.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    foreach (string maSach in unique)
                    {
                        using (SqlCommand check = new SqlCommand("SELECT SoLuongHienCo FROM DauSach WITH (UPDLOCK,HOLDLOCK) WHERE MaDauSach=@Ma", cn, tx))
                        {
                            check.Parameters.AddWithValue("@Ma", maSach);
                            object o = check.ExecuteScalar();
                            if (o == null) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy đầu sách " + maSach + "."); }
                            if (Convert.ToInt32(o) <= 0) { tx.Rollback(); return KetQuaXuLy.Loi("Đầu sách " + maSach + " đã hết trong kho."); }
                        }
                    }

                    string maPM = "PM" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    using (SqlCommand insPm = new SqlCommand(@"INSERT INTO PhieuMuon(MaPhieuMuon,MaDocGia,MaNhanVien,NgayMuon,NgayHenTra) 
                                                               VALUES(@MaPM,@MaDG,@MaNV,@NgayMuon,@HenTra)", cn, tx))
                    {
                        insPm.Parameters.AddWithValue("@MaPM", maPM);
                        insPm.Parameters.AddWithValue("@MaDG", maDocGia);
                        insPm.Parameters.AddWithValue("@MaNV", maNhanVien);
                        insPm.Parameters.AddWithValue("@NgayMuon", ngayMuon.Date);
                        insPm.Parameters.AddWithValue("@HenTra", ngayHenTra.Date);
                        insPm.ExecuteNonQuery();
                    }

                    int i = 1;
                    foreach (string maSach in unique)
                    {
                        string maCT = maPM + "_" + i.ToString("00");

                        using (SqlCommand insCt = new SqlCommand(@"INSERT INTO ChiTietPhieuMuon(MaChiTiet,MaPhieuMuon,MaDauSach) 
                                                                   VALUES(@MaCT,@MaPM,@MaSach)", cn, tx))
                        {
                            insCt.Parameters.AddWithValue("@MaCT", maCT);
                            insCt.Parameters.AddWithValue("@MaPM", maPM);
                            insCt.Parameters.AddWithValue("@MaSach", maSach);
                            insCt.ExecuteNonQuery();
                        }

                        using (SqlCommand upd = new SqlCommand("UPDATE DauSach SET SoLuongHienCo = SoLuongHienCo - 1 WHERE MaDauSach=@MaSach", cn, tx))
                        {
                            upd.Parameters.AddWithValue("@MaSach", maSach);
                            upd.ExecuteNonQuery();
                        }
                        i++;
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Lập phiếu mượn thành công!");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return KetQuaXuLy.Loi("Lỗi hệ thống: " + ex.Message);
                }
            }
        }

        public KetQuaXuLy TraSach(string maChiTiet, string maNhanVien, DateTime ngayTra, string tinhTrang, decimal phiPhat)
        {
            if (string.IsNullOrWhiteSpace(maChiTiet)) return KetQuaXuLy.Loi("Vui lòng chọn sách cần trả.");
            if (string.IsNullOrWhiteSpace(maNhanVien)) return KetQuaXuLy.Loi("Vui lòng chọn nhân viên nhận trả.");
            if (string.IsNullOrWhiteSpace(tinhTrang)) return KetQuaXuLy.Loi("Vui lòng chọn tình trạng sách.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    string maSach;
                    DateTime ngayMuon;
                    DateTime ngayHenTra;

                    using (SqlCommand cmd = new SqlCommand(@"SELECT ct.MaDauSach,ct.NgayTraThucTe,pm.NgayMuon,pm.NgayHenTra 
                                                             FROM ChiTietPhieuMuon ct 
                                                             JOIN PhieuMuon pm ON pm.MaPhieuMuon=ct.MaPhieuMuon 
                                                             WHERE ct.MaChiTiet=@MaCT", cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@MaCT", maChiTiet);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read()) return KetQuaXuLy.Loi("Không tìm thấy chi tiết mượn.");
                            if (!rd.IsDBNull(1)) return KetQuaXuLy.Loi("Sách này đã được trả trước đó.");
                            maSach = rd.GetString(0);
                            ngayMuon = rd.GetDateTime(2);
                            ngayHenTra = rd.GetDateTime(3);
                        }
                    }

                    if (ngayTra.Date < ngayMuon.Date) return KetQuaXuLy.Loi("Ngày trả không thể trước ngày mượn.");

                    bool quaHan = ngayTra.Date > ngayHenTra.Date;
                    string tt = tinhTrang.Trim();
                    bool mat = tt.Equals("Mất", StringComparison.OrdinalIgnoreCase) || tt.Equals("Mat", StringComparison.OrdinalIgnoreCase);
                    bool huHong = tt.IndexOf("Rách", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  tt.IndexOf("Hư", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  tt.IndexOf("Hu", StringComparison.OrdinalIgnoreCase) >= 0;

                    bool canPhat = quaHan || mat || huHong;
                    if (canPhat && phiPhat <= 0)
                        return KetQuaXuLy.Loi("Trường hợp trả trễ/mất/hư hỏng phải nhập phí phạt cụ thể lớn hơn 0.");

                    using (SqlCommand up = new SqlCommand(@"UPDATE ChiTietPhieuMuon 
                                                            SET NgayTraThucTe=@NgayTra, TinhTrangTra=@TinhTrang 
                                                            WHERE MaChiTiet=@MaCT AND NgayTraThucTe IS NULL", cn, tx))
                    {
                        up.Parameters.AddWithValue("@NgayTra", ngayTra.Date);
                        up.Parameters.AddWithValue("@TinhTrang", tt);
                        up.Parameters.AddWithValue("@MaCT", maChiTiet);
                        if (up.ExecuteNonQuery() != 1) throw new InvalidOperationException("Không cập nhật được trạng thái trả sách.");
                    }

                    if (!mat && !huHong)
                    {
                        using (SqlCommand upd = new SqlCommand("UPDATE DauSach SET SoLuongHienCo = SoLuongHienCo + 1 WHERE MaDauSach=@MaSach", cn, tx))
                        {
                            upd.Parameters.AddWithValue("@MaSach", maSach);
                            upd.ExecuteNonQuery();
                        }
                    }

                    if (canPhat)
                    {
                        string maPhieuPhat = "PP" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        using (SqlCommand insPhieuPhat = new SqlCommand(@"INSERT INTO PhieuPhat(MaPhieuPhat, MaChiTiet, SoTienPhat, LyDo) 
                                                                          VALUES(@MaPP, @MaCT, @TienPhat, @LyDo)", cn, tx))
                        {
                            insPhieuPhat.Parameters.AddWithValue("@MaPP", maPhieuPhat);
                            insPhieuPhat.Parameters.AddWithValue("@MaCT", maChiTiet);
                            insPhieuPhat.Parameters.AddWithValue("@TienPhat", phiPhat);

                            string lyDo = "";
                            if (quaHan) lyDo += "Trễ hạn. ";
                            if (mat) lyDo += "Mất sách. ";
                            if (huHong) lyDo += "Hư hỏng sách. ";

                            insPhieuPhat.Parameters.AddWithValue("@LyDo", lyDo.Trim());
                            insPhieuPhat.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Trả sách thành công!");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return KetQuaXuLy.Loi("Lỗi hệ thống: " + ex.Message);
                }
            }
        }
    }
}
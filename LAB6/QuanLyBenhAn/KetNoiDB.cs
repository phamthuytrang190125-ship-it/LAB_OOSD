using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // Nhớ dòng này nha, nó gọi cái gói bạn vừa tải á

namespace QuanLyBenhAn
{
    public class KetNoiDB
    {
        // CHÚ Ý: Chỗ "MatKhauCuaBan" bạn hãy thay bằng mật khẩu đăng nhập vào tài khoản SYSTEM trên Oracle của bạn nha!
        // Còn cái HOST=192.168.22.51 là địa chỉ IP máy Mac của bạn rồi đó.
        private string strKetNoi = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.22.51)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREE)));User Id=system;Password=MatKhauCuaBan;";

        private OracleConnection conn;

        // Hàm 1: Dùng để MỞ kết nối với Oracle
        public OracleConnection MoKetNoi()
        {
            try
            {
                conn = new OracleConnection(strKetNoi);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // Lỗi một phát là hiện bảng thông báo liền cho dễ bắt lỗi
                MessageBox.Show("Chết dở! Lỗi kết nối CSDL rồi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Hàm 2: Dùng để ĐÓNG kết nối sau khi xài xong (rất quan trọng để không bị đứng máy)
        public void DongKetNoi()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
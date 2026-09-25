using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyKhachSan
{
    public class DatabaseHelper
    {
        // Tự động lấy chuỗi kết nối từ file App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSan.Data
{
    public static class Db
    {
        private static readonly string connectionString =
            "Server=DESKTOP-CQGMJPS;" +
            "Database=QuanLyKhachSan;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";

        // Lấy kết nối SQL Server
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Thực hiện câu SELECT và trả về DataTable
        public static DataTable Query(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                DataTable dt = new DataTable();

                cn.Open();
                da.Fill(dt);

                return dt;
            }
        }

        // Thực hiện INSERT / UPDATE / DELETE
        public static int Execute(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                cn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        // Thực hiện câu lệnh trả về một giá trị
        public static object Scalar(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                cn.Open();

                return cmd.ExecuteScalar();
            }
        }
    }
}
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace QuanLyCongTyDuLich
{
    public class KetNoiDB
    {
        // Thay đổi HOST (IP máy thật của bạn), User Id và Password cho đúng với máy bạn
        private static string strKetNoi = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.251.189.146)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=FREE)));User Id=ptttrang;Password=123456;";

        public static DataTable LayDuLieu(string cauTruyVan)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection conn = new OracleConnection(strKetNoi))
                {
                    conn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cauTruyVan, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối DB: " + ex.Message);
            }
            return dt;
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HeThongEShopping
{
    public partial class FrmThemSanPham : System.Windows.Forms.Form
    {
        private TextBox txtMaSP, txtMaNhom, txtTenSP, txtNhaSX, txtGia, txtTinhTrang;
        private Button btnLuu;

        public FrmThemSanPham()
        {
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            this.Text = "Thêm Sản Phẩm Mới";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblTitle = new Label() { Text = "THÊM SẢN PHẨM MỚI", Dock = DockStyle.Top, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };

            // Các trường nhập liệu
            int startY = 60;
            AddLabelAndTextBox("Mã Sản Phẩm (VD: SP06):", ref txtMaSP, ref startY);
            AddLabelAndTextBox("Mã Nhóm (VD: N01):", ref txtMaNhom, ref startY);
            AddLabelAndTextBox("Tên Sản Phẩm:", ref txtTenSP, ref startY);
            AddLabelAndTextBox("Nhà Sản Xuất:", ref txtNhaSX, ref startY);
            AddLabelAndTextBox("Giá Bán:", ref txtGia, ref startY);
            AddLabelAndTextBox("Tình Trạng (Còn hàng/Hết hàng):", ref txtTinhTrang, ref startY);

            // Nút Lưu
            btnLuu = new Button() { Text = "Lưu Sản Phẩm", Location = new Point(150, startY + 15), Width = 130, Height = 35, BackColor = Color.LightGreen, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
        btnLuum_Click: // Nhãn định danh (nếu cần)
            btnLuu.Click += BtnLuu_Click;

            this.Controls.Add(btnLuu);
            this.Controls.Add(lblTitle);
        }

        private void AddLabelAndTextBox(string labelText, ref TextBox txtBox, ref int y)
        {
            Label lbl = new Label() { Text = labelText, Location = new Point(30, y), AutoSize = true };
            txtBox = new TextBox() { Location = new Point(200, y - 2), Width = 200 };
            this.Controls.Add(lbl);
            this.Controls.Add(txtBox);
            y += 40;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng cơ bản
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtMaNhom.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin bắt buộc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string conString = "Data Source=192.168.22.51:1521/FREE;User Id=ptttrang;Password=123456;";
            try
            {
                using (OracleConnection con = new OracleConnection(conString))
                {
                    con.Open();
                    string query = "INSERT INTO SanPham (MaSP, MaNhom, TenSP, NhaSanXuat, GiaBan, TinhTrang) VALUES (:masp, :manhom, :tensp, :nhasx, :giaban, :tinhtrang)";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add(":masp", OracleDbType.Varchar2).Value = txtMaSP.Text.Trim();
                        cmd.Parameters.Add(":manhom", OracleDbType.Varchar2).Value = txtMaNhom.Text.Trim();
                        cmd.Parameters.Add(":tensp", OracleDbType.Varchar2).Value = txtTenSP.Text.Trim();
                        cmd.Parameters.Add(":nhasx", OracleDbType.Varchar2).Value = txtNhaSX.Text.Trim();
                        cmd.Parameters.Add(":giaban", OracleDbType.Decimal).Value = Convert.ToDecimal(txtGia.Text.Trim());
                        cmd.Parameters.Add(":tinhtrang", OracleDbType.Varchar2).Value = txtTinhTrang.Text.Trim();

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sản phẩm thành công xuống Oracle!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
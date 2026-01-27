using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopQuanAo.Data;

namespace QLShopQuanAo.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();

                // Lấy MaTK và VaiTro
                string sql = @"SELECT MaTK, VaiTro 
                               FROM TaiKhoan 
                               WHERE TenDangNhap=@user 
                               AND MatKhau=@pass 
                               AND TrangThai=1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string maTK = reader["MaTK"].ToString();
                        string vaiTro = reader["VaiTro"].ToString();
                        reader.Close(); // Đóng reader để thực hiện Insert

                        // Ghi lịch sử đăng nhập
                        string logSql = "INSERT INTO LichSuDangNhap(MaTK, ThoiGianDangNhap, TrangThai) VALUES(@MaTK, GETDATE(), N'Thành công')";
                        SqlCommand logCmd = new SqlCommand(logSql, conn);
                        logCmd.Parameters.AddWithValue("@MaTK", maTK);
                        logCmd.ExecuteNonQuery();

                        FrmMain main = new FrmMain(vaiTro);
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    }
                }
            }
        }
    }
}

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

            SqlConnection conn = DBConnect.GetConnection();
            conn.Open();

            string sql = @"SELECT VaiTro 
                   FROM TaiKhoan 
                   WHERE TenDangNhap=@user 
                   AND MatKhau=@pass 
                   AND TrangThai=1";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string vaiTro = result.ToString();

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLShopQuanAo.Data;

namespace QLShopQuanAo.Forms
{
    public partial class FrmTaiKhoang : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;

        public FrmTaiKhoang()
        {
            InitializeComponent();
            conn = DBConnect.GetConnection();
        }

        private void FrmTaiKhoang_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM TaiKhoan");
        }

        private void LoadData(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                adapter = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvTaiKhoan.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string sql = $"SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE N'%{keyword}%' OR HoTen LIKE N'%{keyword}%'";
            LoadData(sql);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData("SELECT * FROM TaiKhoan");
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem lịch sử!");
                return;
            }

            string maTK = dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value.ToString();
            FrmLichSuTaiKhoan f = new FrmLichSuTaiKhoan(maTK);
            f.ShowDialog();
        }
    }
}

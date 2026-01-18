using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLShopQuanAo.Forms
{
    public partial class frmLoaiKhach : Form
    {
        // KẾT NỐI
        string strConn = @"Data Source=HUYTRUONG\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;

        public frmLoaiKhach() { InitializeComponent(); }

        private void frmLoaiKhach_Load(object sender, EventArgs e)
        {
            try { conn = new SqlConnection(strConn); conn.Open(); LoadData(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void LoadData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM LoaiKhach", conn);
            dt = new DataTable(); adapter.Fill(dt);
            dgvLoai.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == "") return;
            string sql = "INSERT INTO LoaiKhach(TenLoai) VALUES (N'" + txtTenLoai.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            LoadData(); txtTenLoai.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoai.CurrentRow == null) return;
            // Lấy ID dòng đang chọn
            string id = dgvLoai.CurrentRow.Cells["MaLoai"].Value.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM LoaiKhach WHERE MaLoai=" + id, conn);
                cmd.ExecuteNonQuery(); LoadData();
            }
            catch { MessageBox.Show("Loại này đang có khách sử dụng, không xóa được!"); }
        }

        private void dgvLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) txtTenLoai.Text = dgvLoai.Rows[e.RowIndex].Cells["TenLoai"].Value.ToString();
        }
    }
}
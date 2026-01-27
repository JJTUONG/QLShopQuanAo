using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLShopQuanAo.Forms.KhachHang

{
    public partial class frmGhiChu : Form
    {
        string maKH_DangChon;
        string strConn = @"Data Source=DESKTOP-17KIRAF\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";
        SqlConnection conn;

        // Constructor nhận Mã và Tên từ Form Chính
        public frmGhiChu(string maKH, string tenKH)
        {
            InitializeComponent();
            maKH_DangChon = maKH;
            lblTenKhach.Text = "Khách hàng: " + tenKH;

            conn = new SqlConnection(strConn);
            conn.Open();
            LoadGhiChu();
        }

        void LoadGhiChu()
        {
            // Chỉ hiện ghi chú của đúng ông khách này
            string sql = "SELECT NoiDung, NgayGhi FROM GhiChuKhachHang WHERE MaKH = '" + maKH_DangChon + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvGhiChu.DataSource = dt;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtNoiDung.Text == "") return;

            string sql = "INSERT INTO GhiChuKhachHang(NoiDung, MaKH) VALUES (N'" + txtNoiDung.Text + "', '" + maKH_DangChon + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Đã lưu ghi chú!");
            txtNoiDung.Clear();
            LoadGhiChu();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {

        }

        private void dgvGhiChu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLShopQuanAo.Forms
{
    public partial class FrmKhachHang : Form
    {
        // KẾT NỐI
        string strConn = @"Data Source=HUYTRUONG\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;

        public FrmKhachHang() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConn); conn.Open();
                LoadLoaiKhach(); LoadData(); ResetButtons();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message); }
        }

        void LoadLoaiKhach()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LoaiKhach", conn);
            DataTable dtLoai = new DataTable(); da.Fill(dtLoai);
            cboLoaiKH.DataSource = dtLoai;
            cboLoaiKH.DisplayMember = "TenLoai"; cboLoaiKH.ValueMember = "MaLoai";
            cboLoaiKH.SelectedIndex = -1;
        }

        void LoadData()
        {
            string sql = "SELECT k.MaKH, k.TenKH, k.SDT, k.DiaChi, l.TenLoai, k.MaLoai FROM KhachHang k LEFT JOIN LoaiKhach l ON k.MaLoai = l.MaLoai";
            adapter = new SqlDataAdapter(sql, conn);
            dt = new DataTable(); adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaKH"].HeaderText = "Mã KH";
            dataGridView1.Columns["TenKH"].HeaderText = "Họ Tên";
            dataGridView1.Columns["SDT"].HeaderText = "SĐT";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["TenLoai"].HeaderText = "Loại Khách";
            if (dataGridView1.Columns["MaLoai"] != null) dataGridView1.Columns["MaLoai"].Visible = false;
        }

        void ResetButtons() { btnThem.Enabled = true; btnSua.Enabled = false; btnXoa.Enabled = false; btnGhiChu.Enabled = false; }
        void ResetValues() { txtMaKH.Clear(); txtTenKH.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); cboLoaiKH.SelectedIndex = -1; txtMaKH.Enabled = true; }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "") return;
            try
            {
                string maLoai = (cboLoaiKH.SelectedValue != null) ? cboLoaiKH.SelectedValue.ToString() : "1";
                string sql = "INSERT INTO KhachHang(MaKH, TenKH, SDT, DiaChi, MaLoai) VALUES (N'" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', '" + txtSDT.Text + "', N'" + txtDiaChi.Text + "', " + maLoai + ")";
                SqlCommand cmd = new SqlCommand(sql, conn); cmd.ExecuteNonQuery();
                LoadData(); ResetValues(); MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = (cboLoaiKH.SelectedValue != null) ? cboLoaiKH.SelectedValue.ToString() : "1";
                string sql = "UPDATE KhachHang SET TenKH=N'" + txtTenKH.Text + "', SDT='" + txtSDT.Text + "', DiaChi=N'" + txtDiaChi.Text + "', MaLoai=" + maLoai + " WHERE MaKH='" + txtMaKH.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn); cmd.ExecuteNonQuery();
                LoadData(); ResetValues(); ResetButtons(); MessageBox.Show("Đã sửa!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khách này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    new SqlCommand("DELETE FROM GhiChuKhachHang WHERE MaKH='" + txtMaKH.Text + "'", conn).ExecuteNonQuery();
                    new SqlCommand("DELETE FROM KhachHang WHERE MaKH='" + txtMaKH.Text + "'", conn).ExecuteNonQuery();
                    LoadData(); ResetValues(); ResetButtons();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                if (row.Cells["MaLoai"].Value != DBNull.Value) cboLoaiKH.SelectedValue = row.Cells["MaLoai"].Value;

                txtMaKH.Enabled = false; btnThem.Enabled = false; btnSua.Enabled = true; btnXoa.Enabled = true; btnGhiChu.Enabled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT k.MaKH, k.TenKH, k.SDT, k.DiaChi, l.TenLoai, k.MaLoai FROM KhachHang k LEFT JOIN LoaiKhach l ON k.MaLoai = l.MaLoai WHERE k.SDT LIKE '%" + txtTimKiem.Text + "%'";
            adapter = new SqlDataAdapter(sql, conn); dt = new DataTable(); adapter.Fill(dt); dataGridView1.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetValues(); ResetButtons(); LoadData(); txtTimKiem.Clear(); }

        private void btnLoaiKhach_Click(object sender, EventArgs e)
        {
            frmLoaiKhach f = new frmLoaiKhach(); f.ShowDialog(); LoadLoaiKhach();
        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "") { frmGhiChu f = new frmGhiChu(txtMaKH.Text, txtTenKH.Text); f.ShowDialog(); }
        }
    }
}
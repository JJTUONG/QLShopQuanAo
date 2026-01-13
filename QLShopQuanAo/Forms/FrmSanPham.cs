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
using Microsoft.SqlServer.Server;

namespace QLShopQuanAo.Forms
{
    public partial class FrmSanPham : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;
        DataSet ds;
        string _vaiTro;

        public FrmSanPham(string vaiTro)
        {
            InitializeComponent();
            _vaiTro = vaiTro;
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            lblVaiTro.Text = "Vai trò: " + _vaiTro;

            if (_vaiTro == "NhanVien")
            {
                btnThemSP.Enabled = false;
                btnSuaSP.Enabled = false;
                btnXoaSP.Enabled = false;
            }

            conn = new SqlConnection();
            conn = new SqlConnection(
                @"Data Source=DESKTOP-17KIRAF\SQLEXPRESS;
                  Initial Catalog=dbQLShopQuanAo;
                  Integrated Security=True");
            string sql = "SELECT * FROM SanPham";
            LoadSanPham(sql);
        }

        private void LoadSanPham(string sql)
        {
            try
            {
                adapter = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0]; // Lưu DataTable để sử dụng cho lọc

                dgvSanPham.AutoGenerateColumns = true;
                dgvSanPham.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load SP: " + ex.Message);
            }
        }


        private void SaveProduct()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHangSP.Text) ||
                    string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                    string.IsNullOrWhiteSpace(txtGiaSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                    return;
                }

                if (!decimal.TryParse(txtGiaSP.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phải là số!");
                    return;
                }

                string query = @"INSERT INTO SanPham(MaSP, TenSP, Loai, Size, Gia)
                        VALUES(@MaSP, @TenSP, @Loai, @Size, @Gia)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSP", txtMaHangSP.Text);
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("@Loai", txtLoaiSP.Text);
                    cmd.Parameters.AddWithValue("@Size", txtSizeSP.Text);
                    cmd.Parameters.AddWithValue("@Gia", gia);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        private void FilterDataGridView()
        {
            if (dt == null) return;

            StringBuilder filter = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(txtMaHangSP.Text))
                filter.Append($"MaHang LIKE '%{txtMaHangSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtTenSP.Text))
                filter.Append($"TenSP LIKE '%{txtTenSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtLoaiSP.Text))
                filter.Append($"LoaiSP LIKE '%{txtLoaiSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtSizeSP.Text))
                filter.Append($"SizeSP LIKE '%{txtSizeSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtGiaSP.Text))
            {
                if (!decimal.TryParse(txtGiaSP.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phải là số!");
                    return;
                }
                filter.Append($"GiaSP = {gia} AND ");
            }

            if (filter.Length > 0)
                filter.Remove(filter.Length - 5, 5); // xóa AND

            DataView dv = dt.DefaultView;
            dv.RowFilter = filter.ToString();
            dgvSanPham.DataSource = dv;
        }




        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị dữ liệu lên các TextBox khi chọn dòng trong DataGridView
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaHangSP.Text = row.Cells["MaHang"].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                txtLoaiSP.Text = row.Cells["LoaiSP"].Value?.ToString() ?? "";
                txtSizeSP.Text = row.Cells["SizeSP"].Value?.ToString() ?? "";
                txtGiaSP.Text = row.Cells["GiaSP"].Value?.ToString() ?? "";
            }
        }


        



        private void bntBanHang_Click(object sender, EventArgs e)
        {
            FrmBangHang f = new FrmBangHang();
            f.ShowDialog();
        }

        private void btnSuaSP_Click_1(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maHang = txtMaHangSP.Text;
                string query = @"UPDATE SanPham 
                                SET TenSP = @TenSP, 
                                    LoaiSP = @LoaiSP, 
                                    SizeSP = @SizeSP, 
                                    GiaSP = @GiaSP 
                                WHERE MaHang = @MaHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.Parameters.AddWithValue("@MaHang", maHang);
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("@LoaiSP", txtLoaiSP.Text ?? "");
                    cmd.Parameters.AddWithValue("@SizeSP", txtSizeSP.Text ?? "");
                    cmd.Parameters.AddWithValue("@GiaSP", decimal.Parse(txtGiaSP.Text));

                    cmd.ExecuteNonQuery();
                }

                // Tải lại dữ liệu và lọc
                string sql = "SELECT * FROM SanPham";
                LoadSanPham(sql);
                FilterDataGridView();

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void btnXoaTrang_Click_1(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            txtMaHangSP.Clear();
            txtTenSP.Clear();
            txtLoaiSP.Clear();
            txtSizeSP.Clear();
            txtGiaSP.Clear();

            // Hiển thị toàn bộ dữ liệu khi xóa trắng
            if (dt != null)
            {
                dgvSanPham.DataSource = dt;
            }
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lưu sản phẩm mới vào database
                SaveProduct();

                // 2. Tải lại dữ liệu
                string sql = "SELECT * FROM SanPham";
                LoadSanPham(sql);

                // 3. Lọc DataGridView theo các giá trị đã nhập
                FilterDataGridView();

                MessageBox.Show("Lưu sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSP_Click_1(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string maHang = txtMaHangSP.Text;
                    string query = "DELETE FROM SanPham WHERE MaHang = @MaHang";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        cmd.Parameters.AddWithValue("@MaHang", maHang);
                        cmd.ExecuteNonQuery();
                    }

                    // Tải lại dữ liệu
                    string sql = "SELECT * FROM SanPham";
                    LoadSanPham(sql);

                    // Xóa trắng các ô nhập liệu
                    btnXoaTrang_Click_1(sender, e);

                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemSP_Click_1(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu để thêm mới
            SaveProduct();
            btnXoaTrang_Click_1(sender, e);
        }
    }
}
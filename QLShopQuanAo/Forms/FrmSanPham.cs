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

<<<<<<<< HEAD:QLShopQuanAo/Forms/SanPham/FrmSanPham.cs
namespace QLShopQuanAo.Forms.SanPham 
========
namespace QLShopQuanAo.Forms
>>>>>>>> origin/LamChiDinh:QLShopQuanAo/Forms/FrmSanPham.cs
{
    using QLShopQuanAo.Data;
    public partial class FrmSanPham : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;
        string _vaiTro;
        DataSet ds;
        

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
            conn = DBConnect.GetConnection();
            string sql = "SELECT * FROM SanPham";
            LoadSanPham(sql);
        }

        private void LoadSanPham(string sql)
        {
            try
            {
                adapter = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                adapter.Fill(dt);

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
            if (txtMaHangSP.Text == "" || txtTenSP.Text == "" || txtGiaSP.Text == "")
            {
                MessageBox.Show("Nhập thiếu dữ liệu!");
                return;
            }

            if (
            !decimal.TryParse(txtGiaSP.Text, out decimal gia) ||
            !decimal.TryParse(txtSoLuongSP.Text, out decimal soLuong))
                    {
                        MessageBox.Show("Giá và số lượng phải là số!");
                        return;
                    }

            string sql = @"INSERT INTO SanPham(MaSP, TenSP, Loai, Size, Gia, SoLuong)
                           VALUES(@MaSP,@TenSP,@Loai,@Size,@Gia, @SoLuong)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSP", txtMaHangSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Loai", txtLoaiSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Size", txtSizeSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gia", gia);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void FilterDataGridView()
        {
            if (dt == null) return;

            StringBuilder filter = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(txtMaHangSP.Text))
                filter.Append($"MaSP LIKE '%{txtMaHangSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtTenSP.Text))
                filter.Append($"TenSP LIKE '%{txtTenSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtLoaiSP.Text))
                filter.Append($"Loai LIKE '%{txtLoaiSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtSizeSP.Text))
                filter.Append($"Size LIKE '%{txtSizeSP.Text}%' AND ");

            if (!string.IsNullOrWhiteSpace(txtGiaSP.Text))
            {
                if (!decimal.TryParse(txtGiaSP.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phải là số!");
                    return;
                }
                filter.Append($"Gia = {gia} AND ");
            }
            if (!string.IsNullOrWhiteSpace(txtSoLuongSP.Text))
            {
                if (!decimal.TryParse(txtSoLuongSP.Text, out decimal soLuong))
                {
                    MessageBox.Show("Giá phải là số!");
                    return;
                }
                filter.Append($" So Luong = {soLuong}  ");
            }

            if (filter.Length > 0)
                filter.Remove(filter.Length - 6, 6); // xóa AND

            DataView dv = dt.DefaultView;
            dv.RowFilter = filter.ToString();
            dgvSanPham.DataSource = dv;
        }




        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị dữ liệu lên các TextBox khi chọn dòng trong DataGridView
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            txtMaHangSP.Text = row.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
            txtLoaiSP.Text = row.Cells["Loai"].Value.ToString();
            txtSizeSP.Text = row.Cells["Size"].Value.ToString();
            txtGiaSP.Text = row.Cells["Gia"].Value.ToString();
            txtGiaSP.Text = row.Cells["SoLuong"].Value.ToString();
        }


        



        private void bntBanHang_Click(object sender, EventArgs e)
        {
            //FrmBangHang f = new FrmBangHang();
            //f.ShowDialog();
        }

        private void btnSuaSP_Click_1(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            string sql = @"UPDATE SanPham 
                           SET TenSP=@TenSP, Loai=@Loai, Size=@Size, Gia=@Gia, SoLuong = @SoLuong
                           WHERE MaSP=@MaSP";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSP", txtMaHangSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Loai", txtLoaiSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Size", txtSizeSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGiaSP.Text));
                    cmd.Parameters.AddWithValue("@SoLuong", decimal.Parse(txtSoLuongSP.Text));
                    cmd.ExecuteNonQuery();
                }

                LoadSanPham("SELECT * FROM SanPham");
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (dt == null) return;
            dt.DefaultView.RowFilter =
                $"MaSP LIKE '%{txtMaHangSP.Text}%' OR TenSP LIKE '%{txtTenSP.Text}%'";
        }

        private void btnXoaTrang_Click_1(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            txtMaHangSP.Clear();
            txtTenSP.Clear();
            txtLoaiSP.Clear();
            txtSizeSP.Clear();
            txtGiaSP.Clear();
            txtSoLuongSP.Clear();

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
                //Lưu sản phẩm mới vào database
                SaveProduct();

                //  Tải lại dữ liệu
                string sql = "SELECT * FROM SanPham";
                LoadSanPham(sql);

                //  Lọc DataGridView theo các giá trị đã nhập
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
                MessageBox.Show("Chọn sản phẩm cần xóa!");
                return;
            }

            string maSP = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();

            if (MessageBox.Show($"Xóa sản phẩm {maSP} ?", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (SqlCommand cmd =
                    new SqlCommand("DELETE FROM SanPham WHERE MaSP=@MaSP", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.ExecuteNonQuery();
                }

                LoadSanPham("SELECT * FROM SanPham");
                btnXoaTrang_Click_1(sender, e);
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnThemSP_Click_1(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu để thêm mới
            SaveProduct();
            LoadSanPham("SELECT * FROM SanPham");
            btnXoaTrang_Click_1(sender, e);
        }

        private void lblTaiKhoang_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuongSP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
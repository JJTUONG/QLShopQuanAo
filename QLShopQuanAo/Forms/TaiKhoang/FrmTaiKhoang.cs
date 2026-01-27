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

namespace QLShopQuanAo.Forms.TaiKhoang
{
    public partial class FrmTaiKhoang : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;
        bool isAdding = false; // Biến cờ để biết đang Thêm hay Sửa

        public FrmTaiKhoang()
        {
            InitializeComponent();
            conn = DBConnect.GetConnection();
        }

        private void FrmTaiKhoang_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM TaiKhoan");
            ResetControl(true); // true = chế độ xem (khóa input)
        }

        private void ResetControl(bool isViewMode)
        {
            // Nếu ViewMode = true: Khóa input, Hiện nút Thêm/Sửa/Xóa
            // Nếu ViewMode = false: Mở input, Hiện Lưu/Bỏ qua

            btnThem.Visible = isViewMode;
            btnSua.Visible = isViewMode;
            btnXoa.Visible = isViewMode;
            btnLamMoi.Enabled = isViewMode;
            btnXemLichSu.Enabled = isViewMode;

            btnLuu.Visible = !isViewMode;
            btnBoQua.Visible = !isViewMode;

            txtMaTK.Enabled = !isViewMode && isAdding; // Chỉ cho nhập mã khi thêm mới
            txtTenDangNhap.Enabled = !isViewMode;
            txtMatKhau.Enabled = !isViewMode;
            txtHoTen.Enabled = !isViewMode;
            cboVaiTro.Enabled = !isViewMode;
            chkTrangThai.Enabled = !isViewMode;

            dgvTaiKhoan.Enabled = isViewMode;
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

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

            txtMaTK.Text = row.Cells["MaTK"].Value.ToString();
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            // Xử lý cột HoTen có thể null hoặc không có trong grid cũ
            txtHoTen.Text = row.Cells["HoTen"].Value != DBNull.Value ? row.Cells["HoTen"].Value.ToString() : "";
            cboVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
            
            // Xử lý CheckBox (bit)
            if (row.Cells["TrangThai"].Value != DBNull.Value)
            {
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ResetControl(false);
            
            // Xóa trắng input
            txtMaTK.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cboVaiTro.SelectedIndex = 1; // Default NhanVien
            chkTrangThai.Checked = true;
            txtMaTK.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                return;
            }
            isAdding = false; // Đang sửa
            ResetControl(false);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetControl(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTK.Text) || 
                string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || 
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            // Chỉ cho phép role QuanLy hoặc NhanVien
            if (cboVaiTro.Text != "QuanLy" && cboVaiTro.Text != "NhanVien")
            {
                MessageBox.Show("Vai trò không hợp lệ!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (isAdding)
                {
                    // Check trùng mã
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE MaTK=@MaTK OR TenDangNhap=@User", conn);
                    checkCmd.Parameters.AddWithValue("@MaTK", txtMaTK.Text);
                    checkCmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Mã TK hoặc Tên Đăng Nhập đã tồn tại!");
                        return;
                    }

                    cmd.CommandText = "INSERT INTO TaiKhoan(MaTK, TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai, NgayTao) VALUES(@MaTK, @User, @Pass, @HoTen, @Role, @Status, GETDATE())";
                }
                else
                {
                    cmd.CommandText = "UPDATE TaiKhoan SET TenDangNhap=@User, MatKhau=@Pass, HoTen=@HoTen, VaiTro=@Role, TrangThai=@Status WHERE MaTK=@MaTK";
                }

                cmd.Parameters.AddWithValue("@MaTK", txtMaTK.Text);
                cmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                cmd.Parameters.AddWithValue("@Pass", txtMatKhau.Text); // Nên mã hóa sau này
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@Role", cboVaiTro.Text);
                cmd.Parameters.AddWithValue("@Status", chkTrangThai.Checked);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!");
                
                ResetControl(true);
                LoadData("SELECT * FROM TaiKhoan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

             if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
             {
                 try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    // Kiểm tra ràng buộc
                    // (Thường không xóa cứng nếu đã có HoaDon, ở đây làm đơn giản hoặc cần try-catch constraint)
                    SqlCommand cmd = new SqlCommand("DELETE FROM TaiKhoan WHERE MaTK=@MaTK", conn);
                    cmd.Parameters.AddWithValue("@MaTK", txtMaTK.Text);
                    cmd.ExecuteNonQuery();
                    LoadData("SELECT * FROM TaiKhoan");
                    MessageBox.Show("Xóa thành công!");
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547) // Foreign Key Constraint
                        MessageBox.Show("Không thể xóa tài khoản này vì đã có dữ liệu Hóa Đơn hoặc Lịch sử!");
                    else
                        MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
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

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
    public partial class FrmLichSuTaiKhoan : Form
    {
        string _maTK;
        SqlConnection conn;

        public FrmLichSuTaiKhoan(string maTK)
        {
            InitializeComponent();
            _maTK = maTK;
            conn = DBConnect.GetConnection();
        }

        private void FrmLichSuTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadThongTin();
            LoadThongKe();
        }

        private void LoadThongTin()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenDangNhap FROM TaiKhoan WHERE MaTK = @MaTK", conn);
                cmd.Parameters.AddWithValue("@MaTK", _maTK);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lblTenDangNhap.Text = "Tài khoản: " + result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void LoadThongKe()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // 1. Số lần đăng nhập & Ngày gần nhất
                string sqlLogin = "SELECT COUNT(*), MAX(ThoiGianDangNhap) FROM LichSuDangNhap WHERE MaTK = @MaTK";
                SqlCommand cmdLogin = new SqlCommand(sqlLogin, conn);
                cmdLogin.Parameters.AddWithValue("@MaTK", _maTK);
                
                using (SqlDataReader reader = cmdLogin.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblSoLanDangNhap.Text = reader[0].ToString();
                        lblNgayDangNhapCuoi.Text = reader[1] != DBNull.Value ? DateTime.Parse(reader[1].ToString()).ToString("dd/MM/yyyy HH:mm") : "Chưa đăng nhập";
                    }
                }

                // 2. Số đơn bán & Tổng tiền
                string sqlOrder = "SELECT COUNT(*), SUM(TongTien) FROM HoaDon WHERE MaTK = @MaTK";
                SqlCommand cmdOrder = new SqlCommand(sqlOrder, conn);
                cmdOrder.Parameters.AddWithValue("@MaTK", _maTK);

                using (SqlDataReader reader = cmdOrder.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblSoDonBan.Text = reader[0].ToString();
                        lblTongTien.Text = reader[1] != DBNull.Value ? decimal.Parse(reader[1].ToString()).ToString("N0") + " VND" : "0 VND";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXemChiTietBanHang_Click(object sender, EventArgs e)
        {
            FrmChiTietBanHangTheoTaiKhoan f = new FrmChiTietBanHangTheoTaiKhoan(_maTK);
            f.ShowDialog();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

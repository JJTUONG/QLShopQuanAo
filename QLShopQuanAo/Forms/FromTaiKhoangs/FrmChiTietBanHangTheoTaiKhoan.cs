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
    public partial class FrmChiTietBanHangTheoTaiKhoan : Form
    {
        string _maTK;
        SqlConnection conn;
        DataTable dt;

        public FrmChiTietBanHangTheoTaiKhoan(string maTK)
        {
            InitializeComponent();
            _maTK = maTK;
            conn = DBConnect.GetConnection();
        }

        private void FrmChiTietBanHangTheoTaiKhoan_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string sql = @"
                    SELECT 
                        h.MaHD, 
                        h.NgayLap, 
                        s.TenSP, 
                        ct.SoLuong, 
                        ct.DonGia, 
                        (ct.SoLuong * ct.DonGia) AS ThanhTien
                    FROM HoaDon h
                    JOIN CTHoaDon ct ON h.MaHD = ct.MaHD
                    JOIN SanPham s ON ct.MaSP = s.MaSP
                    WHERE h.MaTK = @MaTK
                    AND h.NgayLap >= @TuNgay AND h.NgayLap <= @DenNgay
                ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTK", _maTK);
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1)); // End of day

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvChiTiet.DataSource = dt;

                // Tính tổng
                decimal tong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tong += Convert.ToDecimal(row["ThanhTien"]);
                }
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tong:N0} VND";

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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopQuanAo.Forms.FrmSanPham;


namespace QLShopQuanAo.Forms
{
    public partial class FrmMain : Form
    {
       
        string _vaiTro;

        
        public FrmMain(string vaiTro)
        {
            InitializeComponent();
            _vaiTro = vaiTro;

            lblVaiTro.Text = "Vai trò: " + _vaiTro;

            if (_vaiTro == "NhanVien")
            {
                btnTaiKhoan.Visible = false;
                btnThongKe.Visible = false;

            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblVaiTro_Click(object sender, EventArgs e)
        {

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            FrmSanPham f = new FrmSanPham(_vaiTro);
            f.ShowDialog();
        }

        private void bntBanHang_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang f = new FrmKhachHang();
            f.ShowDialog();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (_vaiTro != "QuanLy")
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }

            FrmTaiKhoang f = new FrmTaiKhoang();
            f.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (_vaiTro != "QuanLy")
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }

            FrmThongKe f = new FrmThongKe();
            f.ShowDialog();
        }
    }
}

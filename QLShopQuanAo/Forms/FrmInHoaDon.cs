using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using QLShopQuanAo.Data;

// [QUAN TRỌNG] Dòng này để gọi thư viện Excel nè
using Excel = Microsoft.Office.Interop.Excel;

namespace QLShopQuanAo.Forms
{
    public partial class FrmInHoaDon : Form
    {
        private int _maHD;

        // Khai báo các control
        private Label lblTieuDe, lblMaHD, lblNgay, lblKhachHang, lblTongTien;
        private DataGridView dgvChiTiet;
        private Button btnDong, btnInExcel; // Thêm nút In Excel

        public FrmInHoaDon(int maHD)
        {
            InitializeComponent();
            this._maHD = maHD;
            VeGiaoDien();
            LoadThongTinHoaDon();
        }

        private void VeGiaoDien()
        {
            this.Text = "Xem Chi Tiết & In Hóa Đơn";
            this.Size = new Size(600, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Header
            lblTieuDe = new Label() { Text = "HÓA ĐƠN THANH TOÁN", Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.Navy, AutoSize = true, Location = new Point(160, 20) };

            lblMaHD = new Label() { Location = new Point(30, 70), AutoSize = true, Font = new Font("Arial", 11, FontStyle.Bold) };
            lblNgay = new Label() { Location = new Point(30, 100), AutoSize = true, Font = new Font("Arial", 10) };
            lblKhachHang = new Label() { Location = new Point(30, 130), AutoSize = true, Font = new Font("Arial", 10) };

            // GridView
            dgvChiTiet = new DataGridView();
            dgvChiTiet.Location = new Point(20, 170);
            dgvChiTiet.Size = new Size(540, 350);
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.FixedSingle;

            dgvChiTiet.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvChiTiet.Columns.Add("SoLuong", "SL");
            dgvChiTiet.Columns.Add("DonGia", "Đơn Giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành Tiền");

            dgvChiTiet.Columns[0].Width = 220;
            dgvChiTiet.Columns[1].Width = 50;
            dgvChiTiet.Columns[2].Width = 110;
            dgvChiTiet.Columns[3].Width = 140;

            // Footer
            lblTongTien = new Label() { Text = "TỔNG CỘNG: 0 VNĐ", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Red, AutoSize = true, Location = new Point(280, 550) };

            // --- NÚT BẤM ---
            // 1. Nút In Excel (Màu xanh lá)
            btnInExcel = new Button() { Text = "Xuất Excel", Location = new Point(100, 600), Size = new Size(180, 50), BackColor = Color.LightGreen, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnInExcel.Click += BtnInExcel_Click; // Gán sự kiện click

            // 2. Nút Đóng (Màu xám)
            btnDong = new Button() { Text = "Đóng", Location = new Point(300, 600), Size = new Size(180, 50), BackColor = Color.LightGray, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnDong.Click += (s, e) => { this.Close(); };

            // Add Controls
            this.Controls.Add(lblTieuDe);
            this.Controls.Add(lblMaHD); this.Controls.Add(lblNgay); this.Controls.Add(lblKhachHang);
            this.Controls.Add(dgvChiTiet);
            this.Controls.Add(lblTongTien);
            this.Controls.Add(btnInExcel); // Add nút Excel
            this.Controls.Add(btnDong);
        }

        private void LoadThongTinHoaDon()
        {
            try
            {
                // Load Header
                string sqlHead = $@"SELECT h.MaHD, h.NgayLap, k.TenKH, h.TongTien 
                                    FROM HoaDon h 
                                    LEFT JOIN KhachHang k ON h.MaKH = k.MaKH 
                                    WHERE h.MaHD = {_maHD}";

                DataTable dtHead = DBConnect.TruyVan(sqlHead);
                if (dtHead.Rows.Count > 0)
                {
                    DataRow r = dtHead.Rows[0];
                    lblMaHD.Text = "Mã hóa đơn: #" + r["MaHD"].ToString();
                    lblNgay.Text = "Ngày lập: " + Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy HH:mm");
                    lblKhachHang.Text = "Khách hàng: " + r["TenKH"].ToString();

                    decimal tong = 0;
                    if (r["TongTien"] != DBNull.Value) tong = Convert.ToDecimal(r["TongTien"]);
                    lblTongTien.Text = "TỔNG CỘNG: " + tong.ToString("N0") + " VNĐ";
                }

                // Load Chi Tiet
                string sqlChiTiet = $@"SELECT s.TenSP, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) as ThanhTien
                                       FROM CTHoaDon c
                                       JOIN SanPham s ON c.MaSP = s.MaSP
                                       WHERE c.MaHD = {_maHD}";

                DataTable dtChiTiet = DBConnect.TruyVan(sqlChiTiet);
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    dgvChiTiet.Rows.Add(
                        row["TenSP"],
                        row["SoLuong"],
                        Convert.ToDecimal(row["DonGia"]).ToString("N0"),
                        Convert.ToDecimal(row["ThanhTien"]).ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // --- HÀM XUẤT EXCEL ---
        private void BtnInExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Khởi tạo Excel
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                // 2. Định dạng chung
                Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1];
                tenCuaHang.Font.Size = 12;
                tenCuaHang.Font.Bold = true;
                tenCuaHang.Value = "CỬA HÀNG QUẦN ÁO THỜI TRANG";

                Excel.Range header = (Excel.Range)exSheet.Cells[3, 2];
                exSheet.get_Range("B3:E3").Merge(true);
                header.Font.Size = 16;
                header.Font.Bold = true;
                header.Value = "HÓA ĐƠN THANH TOÁN";

                // 3. Ghi thông tin chung (Lấy từ các Label trên Form)
                exSheet.Cells[5, 2] = lblMaHD.Text;
                exSheet.Cells[6, 2] = lblNgay.Text;
                exSheet.Cells[7, 2] = lblKhachHang.Text;

                // 4. Vẽ tiêu đề bảng (Dòng 9)
                exSheet.Cells[9, 1] = "STT";
                exSheet.Cells[9, 2] = "Tên Sản Phẩm";
                exSheet.Cells[9, 3] = "Số Lượng";
                exSheet.Cells[9, 4] = "Đơn Giá";
                exSheet.Cells[9, 5] = "Thành Tiền";

                // Tô đậm tiêu đề bảng
                exSheet.get_Range("A9:E9").Font.Bold = true;
                exSheet.get_Range("A9:E9").ColumnWidth = 12;
                exSheet.get_Range("B9").ColumnWidth = 30; // Cột tên rộng hơn xíu

                // 5. Đổ dữ liệu từ DataGridView vào Excel
                int dongBatDau = 10;
                for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                {
                    exSheet.Cells[dongBatDau + i, 1] = (i + 1).ToString(); // STT
                    exSheet.Cells[dongBatDau + i, 2] = dgvChiTiet.Rows[i].Cells["TenSP"].Value.ToString();
                    exSheet.Cells[dongBatDau + i, 3] = dgvChiTiet.Rows[i].Cells["SoLuong"].Value.ToString();
                    exSheet.Cells[dongBatDau + i, 4] = dgvChiTiet.Rows[i].Cells["DonGia"].Value.ToString();
                    exSheet.Cells[dongBatDau + i, 5] = dgvChiTiet.Rows[i].Cells["ThanhTien"].Value.ToString();
                }

                // 6. Ghi tổng tiền ở dòng cuối cùng
                int dongCuoi = dongBatDau + dgvChiTiet.Rows.Count;
                exSheet.Cells[dongCuoi + 1, 4] = "TỔNG TIỀN:";
                exSheet.Cells[dongCuoi + 1, 5] = lblTongTien.Text.Replace("TỔNG CỘNG: ", "");
                exSheet.get_Range($"D{dongCuoi + 1}:E{dongCuoi + 1}").Font.Bold = true;
                exSheet.get_Range($"D{dongCuoi + 1}:E{dongCuoi + 1}").Font.Color = Color.Red;

                // 7. Hiển thị Excel lên
                exApp.Visible = true;

                // Giải phóng bộ nhớ (Quan trọng)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message + "\n(Máy bạn đã cài Microsoft Excel chưa?)");
            }
        }
    }
}
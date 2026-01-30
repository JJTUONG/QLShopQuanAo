using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using QLShopQuanAo.Data; // Gọi thư viện kết nối Data

namespace QLShopQuanAo.Forms
{
    public partial class FrmBanHang : Form
    {
        // --- KHAI BÁO CÁC CONTROL ---
        private GroupBox grpThongTin, grpSanPham, grpGioHang;
        private Label lblKhach, lblNgay, lblSP, lblGia, lblSL, lblTongTienHienThi;
        private ComboBox cboKhachHang, cboSanPham;
        private DateTimePicker dtpNgayLap;
        private TextBox txtDonGia;
        private NumericUpDown nudSoLuong;
        private Button btnThem, btnThanhToan, btnHuy;
        private DataGridView dgvChiTiet;
        private Panel pnlTongTien;
        private Button btnXoa;

        // Biến toàn cục lưu tổng tiền tạm tính
        private decimal tongTienCaDon = 0;

        public FrmBanHang()
        {
            InitializeComponent();
            VeGiaoDien();
            GanSuKien();
            LoadDuLieu();
        }

        // --- PHẦN 1: VẼ GIAO DIỆN ---
        private void VeGiaoDien()
        {
            this.Text = "Quản Lý Bán Hàng - Chức năng Tạo Hóa Đơn";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Thông tin chung
            grpThongTin = new GroupBox() { Text = "Thông tin chung", Location = new Point(10, 10), Size = new Size(350, 120) };
            lblKhach = new Label() { Text = "Khách hàng:", Location = new Point(10, 30), AutoSize = true };
            cboKhachHang = new ComboBox() { Name = "cboKhachHang", Location = new Point(100, 25), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            lblNgay = new Label() { Text = "Ngày lập:", Location = new Point(10, 70), AutoSize = true };
            dtpNgayLap = new DateTimePicker() { Name = "dtpNgayLap", Location = new Point(100, 65), Width = 230, Format = DateTimePickerFormat.Short };
            grpThongTin.Controls.Add(lblKhach); grpThongTin.Controls.Add(cboKhachHang);
            grpThongTin.Controls.Add(lblNgay); grpThongTin.Controls.Add(dtpNgayLap);

            // 2. Chọn sản phẩm
            grpSanPham = new GroupBox() { Text = "Chọn Sản Phẩm", Location = new Point(10, 140), Size = new Size(350, 300) };
            lblSP = new Label() { Text = "Sản phẩm:", Location = new Point(10, 40), AutoSize = true };
            cboSanPham = new ComboBox() { Name = "cboSanPham", Location = new Point(100, 35), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            lblGia = new Label() { Text = "Đơn giá:", Location = new Point(10, 80), AutoSize = true };
            txtDonGia = new TextBox() { Name = "txtDonGia", Location = new Point(100, 75), Width = 230, ReadOnly = true, BackColor = Color.WhiteSmoke, Text = "0" };
            lblSL = new Label() { Text = "Số lượng:", Location = new Point(10, 120), AutoSize = true };
            nudSoLuong = new NumericUpDown() { Name = "nudSoLuong", Location = new Point(100, 115), Width = 100, Minimum = 1, Maximum = 9999, Value = 1 };
            btnThem = new Button() { Name = "btnThem", Text = "THÊM VÀO GIỎ", Location = new Point(100, 160), Size = new Size(230, 40), BackColor = Color.LightGreen, Font = new Font("Arial", 10, FontStyle.Bold) };

            grpSanPham.Controls.Add(lblSP); grpSanPham.Controls.Add(cboSanPham);
            grpSanPham.Controls.Add(lblGia); grpSanPham.Controls.Add(txtDonGia);
            grpSanPham.Controls.Add(lblSL); grpSanPham.Controls.Add(nudSoLuong);
            grpSanPham.Controls.Add(btnThem);

            // 3. Giỏ hàng (Grid)
            grpGioHang = new GroupBox() { Text = "Chi tiết hóa đơn", Location = new Point(380, 10), Size = new Size(680, 500) };
            dgvChiTiet = new DataGridView() { Name = "dgvChiTiet", Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvChiTiet.Columns.Add("MaSP", "Mã SP");
            dgvChiTiet.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvChiTiet.Columns.Add("SoLuong", "SL");
            dgvChiTiet.Columns.Add("DonGia", "Đơn Giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành Tiền");
            grpGioHang.Controls.Add(dgvChiTiet);

            // 4. Tổng tiền & Chốt đơn
            pnlTongTien = new Panel() { Location = new Point(380, 520), Size = new Size(680, 120), BorderStyle = BorderStyle.FixedSingle };

            Label lblTieuDeTong = new Label() { Text = "TỔNG THANH TOÁN:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            lblTongTienHienThi = new Label() { Name = "lblTongTien", Text = "0 VNĐ", Location = new Point(20, 50), AutoSize = true, Font = new Font("Arial", 18, FontStyle.Bold), ForeColor = Color.Red };

            // --- [MỚI] Nút Xóa (Màu hồng) - Đặt ở vị trí 260 ---
            btnXoa = new Button() { Text = "Xóa", Location = new Point(260, 20), Size = new Size(90, 80), BackColor = Color.LightPink, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnXoa.Click += BtnXoa_Click; // Gắn sự kiện luôn tại đây

            // Nút Hủy (Màu xám) - Dời sang 360
            btnHuy = new Button() { Text = "Hủy", Location = new Point(360, 20), Size = new Size(80, 80), BackColor = Color.LightGray, Font = new Font("Arial", 10, FontStyle.Bold) };
            btnHuy.Click += (s, e) => { dgvChiTiet.Rows.Clear(); tongTienCaDon = 0; lblTongTienHienThi.Text = "0 VNĐ"; };

            // Nút Thanh Toán (Màu cam) - Dời sang 450
            btnThanhToan = new Button() { Name = "btnThanhToan", Text = "THANH TOÁN & LƯU", Location = new Point(450, 20), Size = new Size(200, 80), BackColor = Color.Orange, Font = new Font("Arial", 11, FontStyle.Bold) };
            btnThanhToan.Click += BtnThanhToan_Click;

            // Thêm các nút vào Panel
            pnlTongTien.Controls.Add(lblTieuDeTong);
            pnlTongTien.Controls.Add(lblTongTienHienThi);
            pnlTongTien.Controls.Add(btnXoa);      // <--- Nhớ thêm btnXoa vào đây
            pnlTongTien.Controls.Add(btnHuy);
            pnlTongTien.Controls.Add(btnThanhToan);

            this.Controls.Add(grpThongTin); this.Controls.Add(grpSanPham);
            this.Controls.Add(grpGioHang); this.Controls.Add(pnlTongTien);
        }

        // --- PHẦN 2: GÁN SỰ KIỆN ---
        private void GanSuKien()
        {
            // Khi chọn sản phẩm thì tự động cập nhật giá
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;

            // Nút Thêm vào giỏ
            btnThem.Click += BtnThem_Click;

            // Nút Thanh Toán
            btnThanhToan.Click += BtnThanhToan_Click;

            // Nút Hủy (Reset form)
            btnHuy.Click += (s, e) => { dgvChiTiet.Rows.Clear(); tongTienCaDon = 0; lblTongTienHienThi.Text = "0 VNĐ"; };
        }

        // --- PHẦN 3: LOGIC XỬ LÝ ---

        private void LoadDuLieu()
        {
            try
            {
                // --- TEST SẢN PHẨM ---
                DataTable dtSP = DBConnect.TruyVan("SELECT MaSP, TenSP, Gia FROM SanPham");

                // [QUAN TRỌNG] Kiểm tra xem lấy được bao nhiêu dòng
                if (dtSP.Rows.Count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + dtSP.Rows.Count + " sản phẩm! (Đang đổ vào ComboBox...)");

                    // Sửa lại thứ tự gán để đảm bảo ăn dữ liệu
                    cboSanPham.DisplayMember = "TenSP";
                    cboSanPham.ValueMember = "MaSP";
                    cboSanPham.DataSource = dtSP; // Gán nguồn dữ liệu cuối cùng
                }
                else
                {
                    MessageBox.Show("Kết nối thành công nhưng bảng SanPham đang TRỐNG!");
                }

                // --- TEST KHÁCH HÀNG ---
                DataTable dtKhach = DBConnect.TruyVan("SELECT MaKH, TenKH FROM KhachHang");
                if (dtKhach.Rows.Count > 0)
                {
                    cboKhachHang.DisplayMember = "TenKH";
                    cboKhachHang.ValueMember = "MaKH";
                    cboKhachHang.DataSource = dtKhach;
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi kết nối, nó sẽ hiện nguyên nhân ra đây
                MessageBox.Show("TOANG RỒI! Lỗi chi tiết: " + ex.Message);
            }
        }

        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có đang chọn cái gì không
            if (cboSanPham.SelectedValue != null)
            {
                // 2. Lấy dòng dữ liệu đang chọn (Khai báo biến row ở đây nè)
                System.Data.DataRowView row = cboSanPham.SelectedItem as System.Data.DataRowView;

                // 3. Nếu lấy được dòng đó thì mới bóc giá ra
                if (row != null)
                {
                    txtDonGia.Text = row["Gia"].ToString();
                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin từ giao diện
            string maSP = cboSanPham.SelectedValue.ToString();
            string tenSP = cboSanPham.Text;
            decimal donGia = decimal.Parse(txtDonGia.Text);
            int soLuong = (int)nudSoLuong.Value;
            decimal thanhTien = donGia * soLuong;

            // 2. Thêm vào lưới (DataGridView)
            // Kiểm tra xem sản phẩm đã có trong lưới chưa, nếu có thì cộng dồn số lượng
            bool daCo = false;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells["MaSP"].Value.ToString() == maSP)
                {
                    row.Cells["SoLuong"].Value = (int)row.Cells["SoLuong"].Value + soLuong;
                    row.Cells["ThanhTien"].Value = (decimal)row.Cells["DonGia"].Value * (int)row.Cells["SoLuong"].Value;
                    daCo = true;
                    break;
                }
            }

            if (!daCo)
            {
                dgvChiTiet.Rows.Add(maSP, tenSP, soLuong, donGia, thanhTien);
            }

            // 3. Cập nhật tổng tiền hiển thị
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            tongTienCaDon = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                tongTienCaDon += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTienHienThi.Text = tongTienCaDon.ToString("N0") + " VNĐ";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra giỏ hàng
            if (dgvChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng chọn sản phẩm.");
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // --- 1. LƯU BẢNG HOADON VÀ LẤY ID MỚI ---
                    string ngayLap = dtpNgayLap.Value.ToString("yyyy-MM-dd");
                    string maKH = cboKhachHang.SelectedValue.ToString();

                    // Câu lệnh INSERT và lấy luôn ID vừa sinh ra
                    string sqlHoaDon = $"INSERT INTO HoaDon(NgayLap, MaKH, TongTien) VALUES ('{ngayLap}', '{maKH}', {tongTienCaDon}); SELECT SCOPE_IDENTITY();";

                    // Lấy Mã Hóa Đơn vừa tạo
                    int maHDMoi = DBConnect.LayMotGiaTri(sqlHoaDon);

                    // --- 2. LƯU BẢNG CTHOADON ---
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {
                        string maSP = row.Cells["MaSP"].Value.ToString();
                        int sl = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal gia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                        string sqlChiTiet = $"INSERT INTO CTHoaDon(MaHD, MaSP, SoLuong, DonGia) VALUES ({maHDMoi}, '{maSP}', {sl}, {gia})";
                        DBConnect.ThucThi(sqlChiTiet);
                    }

                    // --- 3. [MỚI] HIỆN FORM HÓA ĐƠN ---
                    FrmInHoaDon frmBill = new FrmInHoaDon(maHDMoi);
                    frmBill.ShowDialog();

                    dgvChiTiet.Rows.Clear();
                    tongTienCaDon = 0;
                    lblTongTienHienThi.Text = "0 VNĐ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
                }
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn dòng nào không
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                // 2. Hỏi xác nhận cho chắc ăn
                if (MessageBox.Show("Bạn chắc chắn muốn xóa món này khỏi giỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 3. Duyệt qua các dòng đang chọn để xóa
                    foreach (DataGridViewRow row in dgvChiTiet.SelectedRows)
                    {
                        if (!row.IsNewRow) // Chỉ xóa dòng dữ liệu thật
                        {
                            dgvChiTiet.Rows.Remove(row);
                        }
                    }

                    // 4. Quan trọng: Tính lại tổng tiền sau khi xóa
                    TinhTongTien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn vào món cần xóa trên bảng!", "Chưa chọn món");
            }
        }
    }
}

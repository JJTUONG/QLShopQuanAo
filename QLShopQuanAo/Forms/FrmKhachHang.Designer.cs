namespace QLShopQuanAo.Forms
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboLoaiKH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLoaiKhach = new System.Windows.Forms.Button();
            this.btnGhiChu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // GroupBox1 - Thông tin
            this.groupBox1.Controls.Add(this.cboLoaiKH); this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiaChi); this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSDT); this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenKH); this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaKH); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(776, 150);
            this.groupBox1.Text = "Thông tin khách hàng";

            // Các Label và TextBox
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 33); this.label1.Text = "Mã KH:";
            this.txtMaKH.Location = new System.Drawing.Point(130, 30); this.txtMaKH.Size = new System.Drawing.Size(230, 22);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 73); this.label2.Text = "Tên KH:";
            this.txtTenKH.Location = new System.Drawing.Point(130, 70); this.txtTenKH.Size = new System.Drawing.Size(230, 22);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 113); this.label3.Text = "SĐT:";
            this.txtSDT.Location = new System.Drawing.Point(130, 110); this.txtSDT.Size = new System.Drawing.Size(230, 22);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(420, 73); this.label4.Text = "Địa chỉ:";
            this.txtDiaChi.Location = new System.Drawing.Point(520, 70); this.txtDiaChi.Multiline = true; this.txtDiaChi.Size = new System.Drawing.Size(230, 60);

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(420, 33); this.label5.Text = "Loại Khách:";
            this.cboLoaiKH.Location = new System.Drawing.Point(520, 30); this.cboLoaiKH.Size = new System.Drawing.Size(230, 24); this.cboLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // GroupBox2 - Danh sách & Tìm kiếm
            this.groupBox2.Controls.Add(this.txtTimKiem); this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Size = new System.Drawing.Size(776, 208);
            this.groupBox2.Text = "Danh sách khách hàng";

            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(20, 28); this.label6.Text = "Tìm kiếm SĐT:";
            this.txtTimKiem.Location = new System.Drawing.Point(130, 25); this.txtTimKiem.Size = new System.Drawing.Size(230, 22);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.dataGridView1.Location = new System.Drawing.Point(6, 60);
            this.dataGridView1.Size = new System.Drawing.Size(764, 142);
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // Các nút bấm (Buttons)
            this.btnThem.Location = new System.Drawing.Point(35, 180); this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.Text = "Thêm"; this.btnThem.BackColor = System.Drawing.Color.LightGreen;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(145, 180); this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.Text = "Sửa"; this.btnSua.BackColor = System.Drawing.Color.LightYellow;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(255, 180); this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.Text = "Xóa"; this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(365, 180); this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.btnLoaiKhach.Location = new System.Drawing.Point(520, 180); this.btnLoaiKhach.Size = new System.Drawing.Size(120, 35);
            this.btnLoaiKhach.Text = "QL Loại Khách"; this.btnLoaiKhach.BackColor = System.Drawing.Color.LightCyan;
            this.btnLoaiKhach.Click += new System.EventHandler(this.btnLoaiKhach_Click);

            this.btnGhiChu.Location = new System.Drawing.Point(650, 180); this.btnGhiChu.Size = new System.Drawing.Size(120, 35);
            this.btnGhiChu.Text = "Xem Ghi Chú"; this.btnGhiChu.BackColor = System.Drawing.Color.LightCyan;
            this.btnGhiChu.Click += new System.EventHandler(this.btnGhiChu_Click);

            // Form Main Properties
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGhiChu); this.Controls.Add(this.btnLoaiKhach);
            this.Controls.Add(this.btnLamMoi); this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua); this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2); this.Controls.Add(this.groupBox1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Hàng";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false); this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtSDT; private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKH; private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaChi; private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLoaiKH; private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTimKiem; private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThem; private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa; private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLoaiKhach; private System.Windows.Forms.Button btnGhiChu;
    }
}
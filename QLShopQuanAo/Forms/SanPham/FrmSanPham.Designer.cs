namespace QLShopQuanAo.Forms.SanPham
{
    partial class FrmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnLuuSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.txtGiaSP = new System.Windows.Forms.TextBox();
            this.lblGia = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.bntBanHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.lblTaiKhoang = new System.Windows.Forms.Label();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.txtLoaiSP = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.txtSizeSP = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtMaHangSP = new System.Windows.Forms.TextBox();
            this.lblMaHang = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.dbQLShopQuanAoDataSet = new QLShopQuanAo.dbQLShopQuanAoDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dbQLShopQuanAoDataSet1 = new QLShopQuanAo.dbQLShopQuanAoDataSet1();
            this.btnXoaTrang = new System.Windows.Forms.Button();
            this.btnTimSP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuongSP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbQLShopQuanAoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbQLShopQuanAoDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.Location = new System.Drawing.Point(890, 72);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(88, 29);
            this.btnSuaSP.TabIndex = 46;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = true;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click_1);
            // 
            // btnLuuSP
            // 
            this.btnLuuSP.Location = new System.Drawing.Point(890, 158);
            this.btnLuuSP.Name = "btnLuuSP";
            this.btnLuuSP.Size = new System.Drawing.Size(88, 26);
            this.btnLuuSP.TabIndex = 45;
            this.btnLuuSP.Text = "Lưu";
            this.btnLuuSP.UseVisualStyleBackColor = true;
            this.btnLuuSP.Click += new System.EventHandler(this.btnLuuSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(796, 116);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(88, 27);
            this.btnXoaSP.TabIndex = 44;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = true;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click_1);
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(796, 72);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(88, 29);
            this.btnThemSP.TabIndex = 43;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click_1);
            // 
            // txtGiaSP
            // 
            this.txtGiaSP.Location = new System.Drawing.Point(633, 79);
            this.txtGiaSP.Name = "txtGiaSP";
            this.txtGiaSP.Size = new System.Drawing.Size(144, 22);
            this.txtGiaSP.TabIndex = 42;
            // 
            // lblGia
            // 
            this.lblGia.Location = new System.Drawing.Point(532, 78);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(95, 20);
            this.lblGia.TabIndex = 41;
            this.lblGia.Text = "Gía Sản Phẩm";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(237, 208);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(741, 240);
            this.dgvSanPham.TabIndex = 40;
            this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
            // 
            // bntBanHang
            // 
            this.bntBanHang.Location = new System.Drawing.Point(17, 141);
            this.bntBanHang.Name = "bntBanHang";
            this.bntBanHang.Size = new System.Drawing.Size(176, 43);
            this.bntBanHang.TabIndex = 39;
            this.bntBanHang.Text = "Bán Hàng";
            this.bntBanHang.UseVisualStyleBackColor = true;
            this.bntBanHang.Click += new System.EventHandler(this.bntBanHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(17, 208);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(176, 43);
            this.btnHoaDon.TabIndex = 38;
            this.btnHoaDon.Text = "Hóa Đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(17, 272);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(176, 43);
            this.btnKhachHang.TabIndex = 37;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            // 
            // lblTaiKhoang
            // 
            this.lblTaiKhoang.Location = new System.Drawing.Point(770, 9);
            this.lblTaiKhoang.Name = "lblTaiKhoang";
            this.lblTaiKhoang.Size = new System.Drawing.Size(79, 44);
            this.lblTaiKhoang.TabIndex = 36;
            this.lblTaiKhoang.Text = "Tài Khoảng";
            this.lblTaiKhoang.Click += new System.EventHandler(this.lblTaiKhoang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSanPham.Location = new System.Drawing.Point(17, 69);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(176, 43);
            this.btnSanPham.TabIndex = 35;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.UseVisualStyleBackColor = false;
            // 
            // txtLoaiSP
            // 
            this.txtLoaiSP.Location = new System.Drawing.Point(362, 141);
            this.txtLoaiSP.Name = "txtLoaiSP";
            this.txtLoaiSP.Size = new System.Drawing.Size(153, 22);
            this.txtLoaiSP.TabIndex = 34;
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(234, 141);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(98, 16);
            this.lblLoaiSP.TabIndex = 33;
            this.lblLoaiSP.Text = "Loại Sản Phẩm";
            // 
            // txtSizeSP
            // 
            this.txtSizeSP.Location = new System.Drawing.Point(362, 169);
            this.txtSizeSP.Name = "txtSizeSP";
            this.txtSizeSP.Size = new System.Drawing.Size(153, 22);
            this.txtSizeSP.TabIndex = 32;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(297, 172);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(33, 16);
            this.lblSize.TabIndex = 31;
            this.lblSize.Text = "Size";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(362, 109);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(153, 22);
            this.txtTenSP.TabIndex = 30;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(234, 109);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(96, 16);
            this.lblTenSP.TabIndex = 29;
            this.lblTenSP.Text = "Tên Sản Phẩm";
            // 
            // txtMaHangSP
            // 
            this.txtMaHangSP.Location = new System.Drawing.Point(362, 72);
            this.txtMaHangSP.Name = "txtMaHangSP";
            this.txtMaHangSP.Size = new System.Drawing.Size(153, 22);
            this.txtMaHangSP.TabIndex = 28;
            // 
            // lblMaHang
            // 
            this.lblMaHang.Location = new System.Drawing.Point(268, 75);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(62, 20);
            this.lblMaHang.TabIndex = 27;
            this.lblMaHang.Text = "Mã Hàng";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(17, 392);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(176, 43);
            this.btnThongKe.TabIndex = 26;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(17, 331);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(176, 43);
            this.btnTaiKhoan.TabIndex = 25;
            this.btnTaiKhoan.Text = "Tài Khoảng";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Location = new System.Drawing.Point(855, 9);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(113, 29);
            this.lblVaiTro.TabIndex = 47;
            // 
            // dbQLShopQuanAoDataSet
            // 
            this.dbQLShopQuanAoDataSet.DataSetName = "dbQLShopQuanAoDataSet";
            this.dbQLShopQuanAoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.dbQLShopQuanAoDataSet1;
            this.bindingSource1.Position = 0;
            // 
            // dbQLShopQuanAoDataSet1
            // 
            this.dbQLShopQuanAoDataSet1.DataSetName = "dbQLShopQuanAoDataSet1";
            this.dbQLShopQuanAoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnXoaTrang
            // 
            this.btnXoaTrang.Location = new System.Drawing.Point(890, 116);
            this.btnXoaTrang.Name = "btnXoaTrang";
            this.btnXoaTrang.Size = new System.Drawing.Size(88, 27);
            this.btnXoaTrang.TabIndex = 49;
            this.btnXoaTrang.Text = "Xoa Trang";
            this.btnXoaTrang.UseVisualStyleBackColor = true;
            this.btnXoaTrang.Click += new System.EventHandler(this.btnXoaTrang_Click_1);
            // 
            // btnTimSP
            // 
            this.btnTimSP.Location = new System.Drawing.Point(796, 158);
            this.btnTimSP.Name = "btnTimSP";
            this.btnTimSP.Size = new System.Drawing.Size(88, 25);
            this.btnTimSP.TabIndex = 48;
            this.btnTimSP.Text = "Tìm";
            this.btnTimSP.UseVisualStyleBackColor = true;
            this.btnTimSP.Click += new System.EventHandler(this.btnTimSP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Số Lượng";
            // 
            // txtSoLuongSP
            // 
            this.txtSoLuongSP.Location = new System.Drawing.Point(633, 115);
            this.txtSoLuongSP.Name = "txtSoLuongSP";
            this.txtSoLuongSP.Size = new System.Drawing.Size(144, 22);
            this.txtSoLuongSP.TabIndex = 51;
            this.txtSoLuongSP.TextChanged += new System.EventHandler(this.txtSoLuongSP_TextChanged);
            // 
            // FrmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 498);
            this.Controls.Add(this.txtSoLuongSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaTrang);
            this.Controls.Add(this.btnTimSP);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.btnSuaSP);
            this.Controls.Add(this.btnLuuSP);
            this.Controls.Add(this.btnXoaSP);
            this.Controls.Add(this.btnThemSP);
            this.Controls.Add(this.txtGiaSP);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.bntBanHang);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.lblTaiKhoang);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.txtLoaiSP);
            this.Controls.Add(this.lblLoaiSP);
            this.Controls.Add(this.txtSizeSP);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.txtMaHangSP);
            this.Controls.Add(this.lblMaHang);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnTaiKhoan);
            this.Name = "FrmSanPham";
            this.Text = "FrmSanPham";
            this.Load += new System.EventHandler(this.FrmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbQLShopQuanAoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbQLShopQuanAoDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnLuuSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.TextBox txtGiaSP;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button bntBanHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Label lblTaiKhoang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.TextBox txtLoaiSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.TextBox txtSizeSP;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtMaHangSP;
        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Label lblVaiTro;
        private dbQLShopQuanAoDataSet dbQLShopQuanAoDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private dbQLShopQuanAoDataSet1 dbQLShopQuanAoDataSet1;
        private System.Windows.Forms.Button btnXoaTrang;
        private System.Windows.Forms.Button btnTimSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuongSP;
    }
}
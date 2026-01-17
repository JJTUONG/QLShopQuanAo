namespace QLShopQuanAo.Forms
{
    partial class FrmMain
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
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblTaiKhoang = new System.Windows.Forms.Label();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.bntBanHang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(12, 321);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(176, 43);
            this.btnTaiKhoan.TabIndex = 1;
            this.btnTaiKhoan.Text = "Tài Khoảng";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(12, 382);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(176, 43);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.Color.White;
            this.btnSanPham.Location = new System.Drawing.Point(12, 59);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(176, 43);
            this.btnSanPham.TabIndex = 11;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnHeThong_Click);
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Location = new System.Drawing.Point(849, 9);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(124, 25);
            this.lblVaiTro.TabIndex = 12;
            this.lblVaiTro.Click += new System.EventHandler(this.lblVaiTro_Click);
            // 
            // lblTaiKhoang
            // 
            this.lblTaiKhoang.Location = new System.Drawing.Point(780, 9);
            this.lblTaiKhoang.Name = "lblTaiKhoang";
            this.lblTaiKhoang.Size = new System.Drawing.Size(79, 44);
            this.lblTaiKhoang.TabIndex = 13;
            this.lblTaiKhoang.Text = "Tài Khoảng";
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(12, 262);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(176, 43);
            this.btnKhachHang.TabIndex = 14;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(12, 198);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(176, 43);
            this.btnHoaDon.TabIndex = 15;
            this.btnHoaDon.Text = "Hóa Đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // bntBanHang
            // 
            this.bntBanHang.Location = new System.Drawing.Point(12, 131);
            this.bntBanHang.Name = "bntBanHang";
            this.bntBanHang.Size = new System.Drawing.Size(176, 43);
            this.bntBanHang.TabIndex = 16;
            this.bntBanHang.Text = "Bán Hàng";
            this.bntBanHang.UseVisualStyleBackColor = true;
            this.bntBanHang.Click += new System.EventHandler(this.bntBanHang_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.bntBanHang);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.lblTaiKhoang);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnTaiKhoan);
            this.Name = "FrmMain";
            this.Text = "Quản Lý Shop Quần Aó";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblTaiKhoang;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button bntBanHang;
    }
}
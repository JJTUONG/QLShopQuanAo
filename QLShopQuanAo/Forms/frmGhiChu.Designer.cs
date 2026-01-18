namespace QLShopQuanAo.Forms
{
    partial class frmGhiChu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvGhiChu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.AutoSize = true;
            this.lblTenKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenKhach.Location = new System.Drawing.Point(20, 20);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(140, 20);
            this.lblTenKhach.Text = "Đang ghi chú...";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(20, 50);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(440, 60);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightBlue;
            this.btnLuu.Location = new System.Drawing.Point(360, 120);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 35);
            this.btnLuu.Text = "Lưu Note";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvGhiChu
            // 
            this.dgvGhiChu.AllowUserToAddRows = false;
            this.dgvGhiChu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGhiChu.Location = new System.Drawing.Point(20, 170);
            this.dgvGhiChu.Name = "dgvGhiChu";
            this.dgvGhiChu.ReadOnly = true;
            this.dgvGhiChu.Size = new System.Drawing.Size(440, 200);
            // 
            // frmGhiChu
            // 
            this.ClientSize = new System.Drawing.Size(484, 400);
            this.Controls.Add(this.dgvGhiChu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.lblTenKhach);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ghi Chú Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvGhiChu;
    }
}
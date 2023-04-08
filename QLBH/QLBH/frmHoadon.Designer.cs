namespace QLBH
{
    partial class frmHoadon
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Danhmucnhanvien = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.mskNgaymua = new System.Windows.Forms.DateTimePicker();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtTongTienThanhToan = new System.Windows.Forms.TextBox();
            this.cbbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cbbMaKhachHang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày mua:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã hóa đơn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền:";
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.Location = new System.Drawing.Point(57, 19);
            this.btnThemHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(161, 22);
            this.btnThemHoaDon.TabIndex = 4;
            this.btnThemHoaDon.Text = "Thêm hóa đơn chi tiết";
            this.btnThemHoaDon.UseVisualStyleBackColor = true;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tổng tiền thanh toán:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã nhân viên:";
            // 
            // Danhmucnhanvien
            // 
            this.Danhmucnhanvien.AutoSize = true;
            this.Danhmucnhanvien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Danhmucnhanvien.Location = new System.Drawing.Point(347, 18);
            this.Danhmucnhanvien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Danhmucnhanvien.Name = "Danhmucnhanvien";
            this.Danhmucnhanvien.Size = new System.Drawing.Size(189, 24);
            this.Danhmucnhanvien.TabIndex = 9;
            this.Danhmucnhanvien.Text = "Danh Mục Hóa Đơn";
            this.Danhmucnhanvien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(162, 115);
            this.txtMaHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(198, 23);
            this.txtMaHoaDon.TabIndex = 11;
            // 
            // mskNgaymua
            // 
            this.mskNgaymua.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mskNgaymua.Location = new System.Drawing.Point(162, 155);
            this.mskNgaymua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskNgaymua.Name = "mskNgaymua";
            this.mskNgaymua.Size = new System.Drawing.Size(198, 23);
            this.mskNgaymua.TabIndex = 12;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(659, 69);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(198, 23);
            this.txtTongTien.TabIndex = 13;
            // 
            // txtTongTienThanhToan
            // 
            this.txtTongTienThanhToan.Location = new System.Drawing.Point(659, 148);
            this.txtTongTienThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTienThanhToan.Name = "txtTongTienThanhToan";
            this.txtTongTienThanhToan.Size = new System.Drawing.Size(198, 23);
            this.txtTongTienThanhToan.TabIndex = 14;
            // 
            // cbbMaNhanVien
            // 
            this.cbbMaNhanVien.FormattingEnabled = true;
            this.cbbMaNhanVien.Location = new System.Drawing.Point(162, 192);
            this.cbbMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMaNhanVien.Name = "cbbMaNhanVien";
            this.cbbMaNhanVien.Size = new System.Drawing.Size(198, 23);
            this.cbbMaNhanVien.TabIndex = 15;
            // 
            // cbbMaKhachHang
            // 
            this.cbbMaKhachHang.FormattingEnabled = true;
            this.cbbMaKhachHang.Location = new System.Drawing.Point(162, 68);
            this.cbbMaKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMaKhachHang.Name = "cbbMaKhachHang";
            this.cbbMaKhachHang.Size = new System.Drawing.Size(198, 23);
            this.cbbMaKhachHang.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "VAT:";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(659, 112);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(198, 23);
            this.txtVAT.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBoQua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThemHoaDon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 54);
            this.panel1.TabIndex = 23;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(820, 14);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(70, 26);
            this.btnBoQua.TabIndex = 20;
            this.btnBoQua.Text = "Bỏ qua ";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(730, 14);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(70, 26);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(643, 14);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(70, 26);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 249);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 25;
            this.dgvHoaDon.Size = new System.Drawing.Size(903, 190);
            this.dgvHoaDon.TabIndex = 24;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // frmHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 493);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbMaKhachHang);
            this.Controls.Add(this.cbbMaNhanVien);
            this.Controls.Add(this.txtTongTienThanhToan);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.mskNgaymua);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.Danhmucnhanvien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHoadon";
            this.Text = "frmHoadon";
            this.Load += new System.EventHandler(this.frmHoadon_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnThemHoaDon;
        private Label label5;
        private Label label6;
        private Label Danhmucnhanvien;
        private TextBox txtMaHoaDon;
        private DateTimePicker mskNgaymua;
        private TextBox txtTongTien;
        private TextBox txtTongTienThanhToan;
        private ComboBox cbbMaNhanVien;
        private ComboBox cbbMaKhachHang;
        private Label label7;
        private TextBox txtVAT;
        private Panel panel1;
        private Button btnBoQua;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvHoaDon;
    }
}
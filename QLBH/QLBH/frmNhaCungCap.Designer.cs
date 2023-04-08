namespace QLBH
{
    partial class frmNhaCungCap
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
            this.Danhmucnhanvien = new System.Windows.Forms.Label();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbTracuu = new System.Windows.Forms.ComboBox();
            this.btnTracuu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbSoDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenCungCap = new System.Windows.Forms.TextBox();
            this.txtMaCungCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvNhaCungCap = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // Danhmucnhanvien
            // 
            this.Danhmucnhanvien.AutoSize = true;
            this.Danhmucnhanvien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Danhmucnhanvien.Location = new System.Drawing.Point(425, 35);
            this.Danhmucnhanvien.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Danhmucnhanvien.Name = "Danhmucnhanvien";
            this.Danhmucnhanvien.Size = new System.Drawing.Size(319, 31);
            this.Danhmucnhanvien.TabIndex = 60;
            this.Danhmucnhanvien.Text = "Danh Mục Nhà Cung Cấp";
            this.Danhmucnhanvien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtSTK
            // 
            this.txtSTK.Location = new System.Drawing.Point(167, 222);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(249, 27);
            this.txtSTK.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 58;
            this.label8.Text = "STK ngân hàng:";
            // 
            // cbbTracuu
            // 
            this.cbbTracuu.FormattingEnabled = true;
            this.cbbTracuu.Location = new System.Drawing.Point(826, 220);
            this.cbbTracuu.Name = "cbbTracuu";
            this.cbbTracuu.Size = new System.Drawing.Size(249, 28);
            this.cbbTracuu.TabIndex = 57;
            // 
            // btnTracuu
            // 
            this.btnTracuu.Location = new System.Drawing.Point(995, 265);
            this.btnTracuu.Name = "btnTracuu";
            this.btnTracuu.Size = new System.Drawing.Size(80, 35);
            this.btnTracuu.TabIndex = 56;
            this.btnTracuu.Text = "Tra cứu";
            this.btnTracuu.UseVisualStyleBackColor = true;
            this.btnTracuu.Click += new System.EventHandler(this.btnTracuu_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Tra cứu mã nhà cung cấp:";
            // 
            // mtbSoDT
            // 
            this.mtbSoDT.Location = new System.Drawing.Point(826, 170);
            this.mtbSoDT.Margin = new System.Windows.Forms.Padding(5);
            this.mtbSoDT.Name = "mtbSoDT";
            this.mtbSoDT.Size = new System.Drawing.Size(249, 27);
            this.mtbSoDT.TabIndex = 55;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(826, 110);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(5);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(249, 27);
            this.txtDiaChi.TabIndex = 54;
            // 
            // txtTenCungCap
            // 
            this.txtTenCungCap.Location = new System.Drawing.Point(167, 163);
            this.txtTenCungCap.Margin = new System.Windows.Forms.Padding(5);
            this.txtTenCungCap.Name = "txtTenCungCap";
            this.txtTenCungCap.Size = new System.Drawing.Size(249, 27);
            this.txtTenCungCap.TabIndex = 53;
            // 
            // txtMaCungCap
            // 
            this.txtMaCungCap.Location = new System.Drawing.Point(167, 103);
            this.txtMaCungCap.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaCungCap.Name = "txtMaCungCap";
            this.txtMaCungCap.Size = new System.Drawing.Size(249, 27);
            this.txtMaCungCap.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(635, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Địa chỉ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Tên nhà cung cấp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Mã nhà cung cấp:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnBoQua);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 549);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 71);
            this.panel1.TabIndex = 61;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(387, 30);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(87, 29);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click_1);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(178, 31);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(203, 27);
            this.txtTimKiem.TabIndex = 15;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(975, 27);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(5);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(80, 35);
            this.btnBoQua.TabIndex = 4;
            this.btnBoQua.Text = "Bỏ qua ";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(875, 27);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(776, 27);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nhập tên nhà cung cấp:";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(676, 27);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 35);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(575, 27);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvNhaCungCap
            // 
            this.dgvNhaCungCap.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhaCungCap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhaCungCap.Location = new System.Drawing.Point(0, 315);
            this.dgvNhaCungCap.Name = "dgvNhaCungCap";
            this.dgvNhaCungCap.RowHeadersWidth = 51;
            this.dgvNhaCungCap.RowTemplate.Height = 29;
            this.dgvNhaCungCap.Size = new System.Drawing.Size(1108, 234);
            this.dgvNhaCungCap.TabIndex = 62;
            this.dgvNhaCungCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhaCungCap_CellClick_1);
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 620);
            this.Controls.Add(this.dgvNhaCungCap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Danhmucnhanvien);
            this.Controls.Add(this.txtSTK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbTracuu);
            this.Controls.Add(this.btnTracuu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbSoDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenCungCap);
            this.Controls.Add(this.txtMaCungCap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmNhaCungCap";
            this.Text = "frmNhaCungCap";
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Danhmucnhanvien;
        private TextBox txtSTK;
        private Label label8;
        private ComboBox cbbTracuu;
        private Button btnTracuu;
        private Label label4;
        private TextBox mtbSoDT;
        private TextBox txtDiaChi;
        private TextBox txtTenCungCap;
        private TextBox txtMaCungCap;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnBoQua;
        private Button btnLuu;
        private Button btnXoa;
        private Label label7;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvNhaCungCap;
    }
}
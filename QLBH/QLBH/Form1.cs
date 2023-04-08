using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;


namespace QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnNhanvien_Click_1(object sender, EventArgs e)
        {
            frmDMNhanvien frmnv = new frmDMNhanvien();
            frmnv.Show();
        }

        private void btnLoaihang_Click_1(object sender, EventArgs e)
        {
            frmDMLoaiHang frmlh = new frmDMLoaiHang();
            
            frmlh.Show();
        }

        private void btnKhachhang_Click_1(object sender, EventArgs e)
        {
            frmDMKhachHang frmkh = new frmDMKhachHang();
            
            frmkh.Show();
        }

        private void btnHang_Click(object sender, EventArgs e)
        {
            frmHang frmh = new frmHang();
            frmh.Show();
        }

        private void btnHoadon_Click(object sender, EventArgs e)
        {
            frmHoadon frmhd = new frmHoadon();
            frmhd.Show();
        }

        private void btnNhacungcap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frmncc = new frmNhaCungCap();
            frmncc.Show();
        }

        private void btnPhieunhap_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frmpn = new frmPhieuNhap();
            frmpn.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap fdn = new frmDangNhap();
            fdn.Show();
            this.Close();
        }
    }
}
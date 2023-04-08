using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmDangNhap : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click_1(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(sCon);
           con.Open();
             //chưa phòng chống sql injection
            //var query = "select * from DANGNHAP where TAIKHOAN='"+txtTK.Text+"' and MATKHAU='"+txtMatkhau.Text+"'";


            // đã phòng sql injection
           var query = "select * from DANGNHAP where TAIKHOAN=@TAIKHOAN and MATKHAU=@MATKHAU";
            var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("TAIKHOAN", txtTK.Text);
            cmd.Parameters.AddWithValue("MATKHAU", txtMatkhau.Text);
            var dr = cmd.ExecuteReader();
            if (dr.Read()==true)
            {                     
                //C1:
                Form1 a =new Form1();
                a.Show();
                this.Hide();
                //C2:
                //Form1 a = new Form1();
                //a.ShowDialog();
                //this.Show();
            }

            else 
            { 
                MessageBox.Show("Lỗi đăng nhập!", "Thông báo");
            }    
            con.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;

            txtTaikhoan.Parent = pictureBox2;
            txtTaikhoan.BackColor = Color.Transparent;

            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtMatkhau.PasswordChar == '*')
            {
                pictureBox5.BringToFront();
                txtMatkhau.PasswordChar = '\0';
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (txtMatkhau.PasswordChar == '\0')
            {
                pictureBox4.BringToFront();
                txtMatkhau.PasswordChar = '*';
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
            
        

        
    


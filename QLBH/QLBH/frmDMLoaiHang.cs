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
    public partial class frmDMLoaiHang : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmDMLoaiHang()
        {
            InitializeComponent();
        }

        private void frmDMLoaiHang_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi kết nối DB");
            }


            //lay du lieu ve
            string sQuery = "select *from LOAIHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LOAIHANG");
            dgvLoaiHang.DataSource = ds.Tables["LOAIHANG"];


            //Chinh do dai columns
            dgvLoaiHang.Columns["MaLH"].Width = 80;
            dgvLoaiHang.Columns["TenLH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            //Lay du lieu cbbMaLoaiHang
            string sQuery1 = "select MaLH, TenLH from LOAIHANG";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery, con);
            DataSet dsLH = new DataSet();
            adapter.Fill(dsLH, "LH");
            cbbTraCuu.DataSource = dsLH.Tables["LH"];
            cbbTraCuu.ValueMember = "MaLH";
            cbbTraCuu.DisplayMember = "TenLH";
            con.Close();
        }
        //Luu
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi kết nối DB");
            }
            if (txtMaLoaiHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHang.Focus();
                return;
            }
            if (txtTenLoaiHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiHang.Focus();
                return;
            }



            string sMALOAIHANG = txtMaLoaiHang.Text;
            string sTENLOAIHANG = txtTenLoaiHang.Text;



            string sQuery = "insert into LOAIHANG values(@MaLH,@TenLH)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaLH", sMALOAIHANG);
            cmd.Parameters.AddWithValue("@TenLH", sTENLOAIHANG);



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi quá trình thêm mới!");
            }
            con.Close();
        }
        //Hien DB
        private void dgvLoaiHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoaiHang.Text = dgvLoaiHang.Rows[e.RowIndex].Cells["MaLH"].Value.ToString();
            txtTenLoaiHang.Text = dgvLoaiHang.Rows[e.RowIndex].Cells["TenLH"].Value.ToString();
            txtMaLoaiHang.Enabled = false;
        }
        //Sua
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi kết nối DB");
            }

            string sMALOAIHANG = txtMaLoaiHang.Text;
            string sTENLOAIHANG = txtTenLoaiHang.Text;


            string sQuery = "update LOAIHANG set TenLH=@TenLH" + " where MaLH=@MaLH";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaLH", sMALOAIHANG);
            cmd.Parameters.AddWithValue("@TenLH", sTENLOAIHANG);


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi quá trình cập nhật!");
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }
        //Xoa
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(sCon);
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi kết nối DB");
                }

                string sMALOAIHANG = txtMaLoaiHang.Text;

                string sQuery = "delete LOAIHANG where MaLH=@MaLH";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaLH", sMALOAIHANG);


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi quá trình xóa!");
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //Them
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaLoaiHang.Enabled = true;
            txtMaLoaiHang.Focus();
        }
        //Bo qua
        private void btnBoQua_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            clear();
            void clear()
            {
                txtMaLoaiHang.Clear();
                txtTenLoaiHang.Clear();
                txtMaLoaiHang.Focus();
            }
        }
        //Tab   
        private void txtMaLoaiHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        //TimKiem
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi kết nối DB");
            }

            string sQuery = "select *from LOAIHANG where TenLH like N'%" + txtTimkiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "LOAIHANG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvLoaiHang.DataSource = ds.Tables["LOAIHANG"];


            con.Close();

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {

            MessageBox.Show(cbbTraCuu.SelectedValue.ToString(), "Mã loaị hàng");
        }
    }
}

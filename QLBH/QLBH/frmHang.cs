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
    public partial class frmHang : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmHang()
        {
            InitializeComponent();
        }

        private void frmHang_Load(object sender, EventArgs e)
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
            string sQuery = "select *from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dgvHang.DataSource = ds.Tables["HANG"];
            con.Close();


            //do du lieu vao combobox
            string sQuery1 = "select MaHang, TenHang from HANG";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery, con);
            DataSet ds3 = new DataSet();
            adapter.Fill(ds3, "hang");
            cbbTracuu.DataSource = ds3.Tables["hang"];
            cbbTracuu.ValueMember = "MaHang";
            cbbTracuu.DisplayMember = "TenHang";
            con.Close();


            //Chinh do dai columns
            dgvHang.Columns["MaHang"].Width = 100;
            dgvHang.Columns["TenHang"].Width = 350;
            dgvHang.Columns["Donvi"].Width = 100;
            dgvHang.Columns["DonGia"].Width = 150;
            dgvHang.Columns["SoLuongTk"].Width = 100;
            dgvHang.Columns["MaLH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         

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
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }

            if (txtDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string sMAHANG = txtMaHang.Text;
            string sTENHANG = txtTenHang.Text;
            string sDONVI = txtDonVi.Text;
            string sDONGIA = txtDonGia.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sMALH = txtMaLoaiHang.Text;

            string sQuery = "insert into HANG values(@MaHang,@TenHang,@DonVi,@DonGia,@SoLuongTk,@MaLH)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHang", sMAHANG);
            cmd.Parameters.AddWithValue("@TenHang", sTENHANG);
            cmd.Parameters.AddWithValue("@DonVi", sDONVI);
            cmd.Parameters.AddWithValue("@DonGia", sDONGIA);
            cmd.Parameters.AddWithValue("@SoLuongTk", sSOLUONG);
            cmd.Parameters.AddWithValue("MaLH", sMALH);



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi quá trình thêm mới!");
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaHang.Text = dgvHang.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dgvHang.Rows[e.RowIndex].Cells["TenHang"].Value.ToString();
            txtDonVi.Text = dgvHang.Rows[e.RowIndex].Cells["DonVi"].Value.ToString();

            txtDonGia.Text = dgvHang.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();

            txtSoLuong.Text = dgvHang.Rows[e.RowIndex].Cells["SoLuongTk"].Value.ToString();

            txtMaLoaiHang.Text = dgvHang.Rows[e.RowIndex].Cells["MaLH"].Value.ToString();
            txtMaHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
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

            string sMAHANG = txtMaHang.Text;
            string sTENHANG = txtTenHang.Text;
            string sDONVI = txtDonVi.Text;
            string sDONGIA = txtDonGia.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sMALH = txtMaLoaiHang.Text;



            string sQuery = "update HANG "+ "set tenhang=@TenHang, donvi=@DonVi, dongia=@DonGia, soluongtk=@SoLuongTk, malh=@MaLH" + " where mahang=@MaHang;";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHang", sMAHANG);
            cmd.Parameters.AddWithValue("@TenHang", sTENHANG);
            cmd.Parameters.AddWithValue("@DonVi", sDONVI);
            cmd.Parameters.AddWithValue("@DonGia", sDONGIA);
            cmd.Parameters.AddWithValue("@SoLuongTk", sSOLUONG);
            cmd.Parameters.AddWithValue("MaLH", sMALH);

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

        private void btnXoa_Click(object sender, EventArgs e)
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

                string sMAHANG = txtMaHang.Text;

                string sQuery = "delete HANG where mahang='" + sMAHANG + "'";
                SqlCommand cmd = new SqlCommand(sQuery, con);
               


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

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            clear();
            void clear()
            {
                txtMaHang.Clear();
                txtTenHang.Clear();
                txtDonVi.Clear();
                txtDonGia.Clear();
                txtSoLuong.Clear();
                txtMaLoaiHang.Clear();

                txtMaHang.Focus();
            }
        }

        //Tra cuu Ma Hang
        private void btnTracuu_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show(cbbTracuu.SelectedValue.ToString(), "Mã hàng");

        }

        //Tim kiem
        private void btnTimkiem_Click_1(object sender, EventArgs e)
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

            string sQuery = "select *from HANG where TenHang like N'%" + txtTimkiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "HANG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvHang.DataSource = ds.Tables["HANG"];


            con.Close();

        }

     
    }
}

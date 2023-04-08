using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
namespace QLBH
{
    public partial class frmDMKhachHang : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmDMKhachHang()
        {
            InitializeComponent();
        }


 

        private void frmDMKhachHang_Load_1(object sender, EventArgs e)
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
                string sQuery = "select *from KHACHHANG";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "KHACHHANG");
                dgvKhachHang.DataSource = ds.Tables["KHACHHANG"];
        
            con.Close();


            //do du lieu vao combobox
             string sQuery2 = "select MaKH, TenKH from KHACHHANG";
             SqlDataAdapter adapter2 = new SqlDataAdapter(sQuery, con);
             DataSet ds2 = new DataSet();
             adapter.Fill(ds2, "KH");
             cbbTracuu.DataSource = ds2.Tables["KH"];
             cbbTracuu.ValueMember = "MaKH";
             cbbTracuu.DisplayMember = "TenKH";
             con.Close();

            //Chinh do dai columns
            dgvKhachHang.Columns["MaKH"].Width = 100;
            dgvKhachHang.Columns["TenKH"].Width = 200;
            dgvKhachHang.Columns["DiaChi"].Width = 500;
            dgvKhachHang.Columns["SDT"].Width = 100;
            dgvKhachHang.Columns["NgaySinh"].Width = 150;
            dgvKhachHang.Columns["STK"].Width = 100;
        }
        //Luu

        private void btnLuu_Click(object sender, EventArgs e)
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
            if (txtMaKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return;
            }
            if (txtTenKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbSoDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDT.Focus();
                return;
            }
            if (txtSTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSTK.Focus();
                return;
            }

            string sMAKHACHHANG = txtMaKhachHang.Text;
            string sTENKHACHHANG = txtTenKhachHang.Text;
            string sDIACHI = txtDiaChi.Text;
            string sSDT = mtbSoDT.Text;
            string sNGAYSINH = mskNgaySinh.Value.ToString("yyyy-MM-dd");
            string sSTK = txtSTK.Text;


            string sQuery = "insert into KHACHHANG values(@MaKH,@TenKH,@DiaChi,@SDT,@NgaySinh,@STK)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaKH", sMAKHACHHANG);
            cmd.Parameters.AddWithValue("@TenKH", sTENKHACHHANG);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@SDT", sSDT);
            cmd.Parameters.AddWithValue("@NgaySinh", sNGAYSINH);
            cmd.Parameters.AddWithValue("@STK", sSTK);




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
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhachHang.Text = dgvKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            txtTenKhachHang.Text = dgvKhachHang.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            mtbSoDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            mskNgaySinh.Value = Convert.ToDateTime(dgvKhachHang.Rows[e.RowIndex].Cells["NgaySinh"].Value);
            txtSTK.Text = dgvKhachHang.Rows[e.RowIndex].Cells["STK"].Value.ToString();
            txtMaKhachHang.Enabled = false;
        }
        //Sua
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

            string sMAKHACHHANG = txtMaKhachHang.Text;
            string sTENKHACHHANG = txtTenKhachHang.Text;
            string sDIACHI = txtDiaChi.Text;
            string sSDT = mtbSoDT.Text;
            string sNGAYSINH = mskNgaySinh.Value.ToString("yyyy-MM-dd");
            string sSTK = txtSTK.Text;

            string sQuery = "update KHACHHANG set TenKH=@TenKH, diachi=@DiaChi," +
                "sdt=@SDT,ngaysinh=@NgaySinh " + "stk=@STK" + " where MaKH=@MaKH";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaKH", sMAKHACHHANG);
            cmd.Parameters.AddWithValue("@TenKH", sTENKHACHHANG);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@SDT", sSDT);
            cmd.Parameters.AddWithValue("@NgaySinh", sNGAYSINH);
            cmd.Parameters.AddWithValue("@STK", sSTK);


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

                string sMAKHACHHANG = txtMaKhachHang.Text;

                string sQuery = "delete KHACHHANG where MaKH=@MaKH";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaKH", sMAKHACHHANG);


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
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaKhachHang.Enabled = true;
            txtMaKhachHang.Focus();
        }
        //Bo qua
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
                txtMaKhachHang.Clear();
                txtTenKhachHang.Clear();
                txtDiaChi.Clear();
                txtSTK.Clear();
                mtbSoDT.Clear();
                txtMaKhachHang.Focus();
            }
        }
        //Tab   
        private void txtMaKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        //Tra cuu Ma KH 
        private void btnTracuu_Click(object sender, EventArgs e)
        {

            MessageBox.Show(cbbTracuu.SelectedValue.ToString(), "Mã khách hàng");

        }
        //Tim kiem
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

            string sQuery = "select *from KHACHHANG where TenKH like N'%" + txtTimkiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "KHACHHANG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvKhachHang.DataSource = ds.Tables["KHACHHANG"];


            con.Close();

        }

      

       
    }
}

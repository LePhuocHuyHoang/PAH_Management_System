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
    public partial class frmNhaCungCap : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
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
            string sQuery = "select *from NHACUNGCAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACUNGCAP");
            dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];

            con.Close();


            //do du lieu vao combobox
            string sQuery2 = "select MaNCC, TenNCC from NHACUNGCAP";
            SqlDataAdapter adapter2 = new SqlDataAdapter(sQuery, con);
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2, "NCC");
            cbbTracuu.DataSource = ds2.Tables["NCC"];
            cbbTracuu.ValueMember = "MaNCC";
            cbbTracuu.DisplayMember = "TenNCC";
            con.Close();

            //Chinh do dai columns
            dgvNhaCungCap.Columns["MaNCC"].Width = 100;
            dgvNhaCungCap.Columns["TenNCC"].Width = 250;
            dgvNhaCungCap.Columns["DiaChi"].Width = 600;
            dgvNhaCungCap.Columns["SDT"].Width = 100;
            dgvNhaCungCap.Columns["STK"].Width = 500;
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
            if (txtMaCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCungCap.Focus();
                return;
            }
            if (txtTenCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCungCap.Focus();
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

            string sMANHACUNGCAP = txtMaCungCap.Text;
            string sTENNHACUNGCAP = txtTenCungCap.Text;
            string sDIACHI = txtDiaChi.Text;
            string sSDT = mtbSoDT.Text;
            string sSTK = txtSTK.Text;


            string sQuery = "insert into NHACUNGCAP values(@MaNCC,@TenNCC,@DiaChi,@SDT,@STK)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMANHACUNGCAP);
            cmd.Parameters.AddWithValue("@TenNCC", sTENNHACUNGCAP);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@SDT", sSDT);
            cmd.Parameters.AddWithValue("@STK", sSTK);




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
        //Hien DB
        private void dgvNhaCungCap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCungCap.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            txtTenCungCap.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            mtbSoDT.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            txtSTK.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["STK"].Value.ToString();
            txtMaCungCap.Enabled = false;
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

            string sMANHACUNGCAP = txtMaCungCap.Text;
            string sTENNHACUNGCAP = txtTenCungCap.Text;
            string sDIACHI = txtDiaChi.Text;
            string sSDT = mtbSoDT.Text;

            string sSTK = txtSTK.Text;

            string sQuery = "update NHACUNGCAP set TenNCC=@TenNCC, diachi=@DiaChi," +
                "sdt=@SDT,stk=@STK"+ " where MaNCC=@MaNCC";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMANHACUNGCAP);
            cmd.Parameters.AddWithValue("@TenNCC", sTENNHACUNGCAP);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@SDT", sSDT);
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

                string sMANHACUNGCAP = txtMaCungCap.Text;

                string sQuery = "delete NHACUNGCAP where MaNCC=@MaNCC";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaNCC", sMANHACUNGCAP);


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
            txtMaCungCap.Enabled = true;
            txtMaCungCap.Focus();
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
                txtMaCungCap.Clear();
                txtTenCungCap.Clear();
                txtDiaChi.Clear();
                txtSTK.Clear();
                mtbSoDT.Clear();
                txtMaCungCap.Focus();
            }
        }
        //Tab   
        private void txtMaCungCap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        //Tra cuu Ma NCC 
        private void btnTracuu_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show(cbbTracuu.SelectedValue.ToString(), "Mã nhà cung cấp");

        }
        //Tim kiem
        private void btnTimKiem_Click_1(object sender, EventArgs e)
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

            string sQuery = "select *from NHACUNGCAP where TenNCC like N'%" + txtTimKiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds, "NHACUNGCAP");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];


            con.Close();

        }

    
    }
}

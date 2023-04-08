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
    public partial class frmDMNhanvien : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmDMNhanvien()
        {
            InitializeComponent();
        }


        private void frmDMNhanvien_Load(object sender, EventArgs e)
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
            string sQuery = "select *from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            dgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
            con.Close();

            //do du lieu vao combobox
            string sQuery1 = "select MaNV, TenNV from NHANVIEN";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery, con);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "NV");
            cbbTracuu.DataSource = ds1.Tables["NV"];
            cbbTracuu.ValueMember = "MaNV";
            cbbTracuu.DisplayMember = "TenNV";
            con.Close();

            //Chinh do dai columns
            dgvNhanVien.Columns["MaNV"].Width = 100;
            dgvNhanVien.Columns["TenNV"].Width = 200;
            dgvNhanVien.Columns["DiaChi"].Width = 500;
            dgvNhanVien.Columns["NgaySinh"].Width = 150;
            dgvNhanVien.Columns["SDT"].Width = 100;

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
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
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
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDT.Focus();
                return;
            }

            string sMANHANVIEN = txtMaNhanVien.Text;
            string sTENNHANVIEN = txtTenNhanVien.Text;
            string sDIACHI = txtDiaChi.Text;
            string sNGAYSINH = mskNgaySinh.Value.ToString("yyyy-MM-dd");
            string sSDT = mtbSoDT.Text;

            string sQuery = "insert into NHANVIEN values(@MaNV,@TenNV,@DiaChi,@NgaySinh,@SDT)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNV", sMANHANVIEN);
            cmd.Parameters.AddWithValue("@TenNV", sTENNHANVIEN);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@NgaySinh", sNGAYSINH);
            cmd.Parameters.AddWithValue("@SDT", sSDT);



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
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            txtMaNhanVien.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            mskNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NgaySinh"].Value);
            mtbSoDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            txtMaNhanVien.Enabled = false;
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

            string sMANHANVIEN = txtMaNhanVien.Text;
            string sTENNHANVIEN = txtTenNhanVien.Text;
            string sDIACHI = txtDiaChi.Text;
            string sNGAYSINH = mskNgaySinh.Value.ToString("yyyy-MM-dd");
            string sSDT = mtbSoDT.Text;

            string sQuery = "update NHANVIEN set tennv=@TenNV, diachi=@DiaChi," +
                "ngaysinh=@NgaySinh, sdt=@SDT" + " where manv=@MaNV";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaNV", sMANHANVIEN);
            cmd.Parameters.AddWithValue("@TenNV", sTENNHANVIEN);
            cmd.Parameters.AddWithValue("@DiaChi", sDIACHI);
            cmd.Parameters.AddWithValue("@NgaySinh", sNGAYSINH);
            cmd.Parameters.AddWithValue("@SDT", sSDT);

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

                string sMANHANVIEN = txtMaNhanVien.Text;

                string sQuery = "delete NHANVIEN where manv='" + sMANHANVIEN+"'";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                //cmd.Parameters.AddWithValue("@MaNV", sMANHANVIEN);


                try
                {
                    cmd.ExecuteScalar();
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
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Focus();
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
                txtMaNhanVien.Clear();
                txtTenNhanVien.Clear();
                txtDiaChi.Clear();

                mtbSoDT.Clear();
                txtMaNhanVien.Focus();
            }
        }
        //Tab   
        private void txtMaNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        //Tra cuu Ma NV 
        private void btnTracuu_Click(object sender, EventArgs e)
        {

            MessageBox.Show(cbbTracuu.SelectedValue.ToString(),"Mã nhân viên");
       
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

            string sQuery = "select *from NHANVIEN where TenNV like N'%" + txtTimkiem.Text+ "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            try {
                adapter.Fill(ds, "NHANVIEN");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvNhanVien.DataSource = ds.Tables["NHANVIEN"];


            con.Close();

        }

     
    }

}

       
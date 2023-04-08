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
    public partial class frmHoaDonChiTiet : Form
    {


        SqlConnection con = new SqlConnection("Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022");
        SqlCommand cmd;
        SqlDataReader dr;

        public frmHoaDonChiTiet()
        {
            InitializeComponent();
        }
        public string temp;
        private void frmHoaDonChiTiet_Load(object sender, EventArgs e)
        {



            txtMaHoaDon.Text = temp;

            //  txtVAT.Enabled = false;
            txtDonGia.Enabled = false;
            txtThanhTien.Enabled = false;
            // txtTongTienSauThue.Enabled = false;


            //do du lieu vao combobox MaHang
            string sql = "select * from HANG";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbMaHang.Items.Add(dr["MaHang"]);
            }


            con.Close();

            //lay du lieu ve
            con.Open();
            string sQuery = "select *from HOADONCHITIET";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "HOADONCHITIET");
            dgvHoaDonChiTiet.DataSource = ds.Tables["HOADONCHITIET"];

            con.Close();

            dgvHoaDonChiTiet.Columns["MaHDCT"].Width = 200;
            dgvHoaDonChiTiet.Columns["SoLuongBan"].Width = 200;
            dgvHoaDonChiTiet.Columns["ThanhTien"].Width = 200;
    
            dgvHoaDonChiTiet.Columns["MaHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void cbbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select *from HANG where MaHang=@MaHang", con);
            cmd.Parameters.AddWithValue("@MaHang", cbbMaHang.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string DonGia = dr["DonGia"].ToString();
                txtDonGia.Text = DonGia;
            }
            con.Close();


        }



    
        private void txtSoLuong_TextChanged_1(object sender, EventArgs e)
        {
            if (cbbMaHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn loại hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaHang.Focus();
                return;
            }

            if (txtSoLuong.Text != "")
            {
                decimal fSoLuong = decimal.Parse(txtSoLuong.Text);
                decimal fDonGia = decimal.Parse(txtDonGia.Text);
                decimal fThanhTien;
                fThanhTien = fSoLuong * fDonGia;
              
                txtThanhTien.Text = fThanhTien.ToString();
              
            }
            else
            {
                txtDonGia.Text = "0";
                txtThanhTien.Text = "0";
             
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            con.Open();

            string sMAHOADONCT = txtMaHoaDon.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sTHANHTIEN = txtThanhTien.Text;
            string sMAHANG = cbbMaHang.Text;

            string sQuery = "update HOADONCHITIET " + "set mahdct=@MaHDCT, soluongban=@SoLuongBan, thanhtien=@ThanhTien, mahang=@MaHang" + " where mahdct=@MaHDCT;";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHDCT", sMAHOADONCT);
            cmd.Parameters.AddWithValue("@SoLuongBan", sSOLUONG);
            cmd.Parameters.AddWithValue("@ThanhTien", sTHANHTIEN);
            cmd.Parameters.AddWithValue("@MaHang", sMAHANG);


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

                con.Open();
                string sMAHOADONCT = txtMaHoaDon.Text;
                string sQuery = "delete HOADONCHITIET where mahdct=@MaHDCT";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaHDCT", sMAHOADONCT);


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

        private void dgvHoaDonChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            txtMaHoaDon.Text = dgvHoaDonChiTiet.Rows[e.RowIndex].Cells["MaHDCT"].Value.ToString();
            txtSoLuong.Text = dgvHoaDonChiTiet.Rows[e.RowIndex].Cells["SoLuongBan"].Value.ToString();
            txtThanhTien.Text = dgvHoaDonChiTiet.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            cbbMaHang.Text = dgvHoaDonChiTiet.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            clear();
            void clear()
            {
  
     
               txtDonGia.Clear();
                txtSoLuong.Clear();
                txtMaHoaDon.Focus();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            con.Open();  
            
         
            if (txtMaHoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHoaDon.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string sMAHOADONCT = txtMaHoaDon.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sTHANHTIEN = txtThanhTien.Text;
            string sMAHANG = cbbMaHang.Text;
          

            string sQuery = "insert into HOADONCHITIET values(@MaHDCT,@SoLuongBan,@ThanhTien,@MaHang)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHDCT", sMAHOADONCT);
            cmd.Parameters.AddWithValue("@SoLuongBan", sSOLUONG);
            cmd.Parameters.AddWithValue("@ThanhTien", sTHANHTIEN);
            cmd.Parameters.AddWithValue("@MaHang", sMAHANG);
          

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
    }
}
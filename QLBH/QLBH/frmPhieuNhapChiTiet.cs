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
    public partial class frmPhieuNhapChiTiet : Form
    {
        SqlConnection con = new SqlConnection("Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022");
        SqlCommand cmd;
        SqlDataReader dr;

        public frmPhieuNhapChiTiet()
        {
            InitializeComponent();
        }
        public string temp;
        private void frmPhieuNhapChiTiet_Load(object sender, EventArgs e)
        {

            txtMaPhieuNhap.Text = temp;

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
            string sQuery = "select *from PHIEUNHAPCHITIET";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "PHIEUNHAPCHITIET");
            dgvPhieuNhapChiTiet.DataSource = ds.Tables["PHIEUNHAPCHITIET"];

            con.Close();

            dgvPhieuNhapChiTiet.Columns["MaPNCT"].Width = 200;
            dgvPhieuNhapChiTiet.Columns["SoLuongNhap"].Width = 200;
            dgvPhieuNhapChiTiet.Columns["ThanhTien"].Width = 200;

            dgvPhieuNhapChiTiet.Columns["MaHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void cbbMaHang_SelectedIndexChanged_1(object sender, EventArgs e)
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



 

        private void txtSoLuong_TextChanged_2(object sender, EventArgs e)
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
                fThanhTien = fSoLuong * (fDonGia-50000);
              
                txtThanhTien.Text = fThanhTien.ToString();
        
            }
            else
            {
                txtDonGia.Text = "0";
                txtThanhTien.Text = "0";
        
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            con.Open();

            string sMAHOADONCT = txtMaPhieuNhap.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sTHANHTIEN = txtThanhTien.Text;
            string sMAHANG = cbbMaHang.Text;

            string sQuery = "update PHIEUNHAPCHITIET " + "set mapnct=@MaPNCT, soluongnhap=@SoLuongNhap, thanhtien=@ThanhTien, mahang=@MaHang" + " where mapnct=@MaPNCT;";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaPNCT", sMAHOADONCT);
            cmd.Parameters.AddWithValue("@SoLuongNhap", sSOLUONG);
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {

                con.Open();
                string sMAHOADONCT = txtMaPhieuNhap.Text;
                string sQuery = "delete PHIEUNHAPCHITIET where mapnct=@MaPNCT";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaPNCT", sMAHOADONCT);


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

        private void dgvPhieuNhapChiTiet_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtMaPhieuNhap.Text = dgvPhieuNhapChiTiet.Rows[e.RowIndex].Cells["MaPNCT"].Value.ToString();
            txtSoLuong.Text = dgvPhieuNhapChiTiet.Rows[e.RowIndex].Cells["SoLuongNhap"].Value.ToString();
            txtThanhTien.Text = dgvPhieuNhapChiTiet.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            cbbMaHang.Text = dgvPhieuNhapChiTiet.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
        }

        private void btnTroLai_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnBoQua_Click_1(object sender, EventArgs e)
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
                txtMaPhieuNhap.Focus();

            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {


            con.Open();


            if (txtMaPhieuNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phiếu nhập chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhieuNhap.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string sMAHOADONCT = txtMaPhieuNhap.Text;
            string sSOLUONG = txtSoLuong.Text;
            string sTHANHTIEN = txtThanhTien.Text;
            string sMAHANG = cbbMaHang.Text;


            string sQuery = "insert into PHIEUNHAPCHITIET values(@MaPNCT,@SoLuongNhap,@ThanhTien,@MaHang)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaPNCT", sMAHOADONCT);
            cmd.Parameters.AddWithValue("@SoLuongNhap", sSOLUONG);
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

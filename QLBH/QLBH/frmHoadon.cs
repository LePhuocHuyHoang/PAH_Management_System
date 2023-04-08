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
   
    public partial class frmHoadon : Form
    {
        
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmHoadon()
        {
            InitializeComponent();
        }
        
      

        private void frmHoadon_Load(object sender, EventArgs e)
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
            string sQuery = "select *from HOADON";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet dshoadon = new DataSet();
            adapter.Fill(dshoadon, "HOADON");
            dgvHoaDon.DataSource = dshoadon.Tables["HOADON"];

          //  txtVAT.Enabled = false;
           // txtTongTien.Enabled = false;
          //  txtTongTienSauThue.Enabled = false;
          

            //do du lieu vao combobox MaNV
            string sQuery1 = "select MaNV from NHANVIEN";
            SqlDataAdapter adapternew = new SqlDataAdapter(sQuery1, con);
            DataSet dsnew = new DataSet();
            adapternew.Fill(dsnew, "nv");
            cbbMaNhanVien.DataSource = dsnew.Tables["nv"];
            cbbMaNhanVien.ValueMember = "MaNV";

            //do du lieu vao combobox MaKH
            string sQuery2 = "select MaKH from KHACHHANG";
            SqlDataAdapter adapterneww = new SqlDataAdapter(sQuery2, con);
            DataSet dsneww = new DataSet();
            adapterneww.Fill(dsneww, "kh");
            cbbMaKhachHang.DataSource = dsneww.Tables["kh"];
            cbbMaKhachHang.ValueMember = "MaKH";

            con.Close();

            dgvHoaDon.Columns["MaNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        //truyen du lieu sang form khac
        public void GETVALUE(string value)
        {

        }

        //cellclick dgv
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaHoaDon.Text = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            mskNgaymua.Text = dgvHoaDon.Rows[e.RowIndex].Cells["ThoiGian"].Value.ToString();
            txtTongTien.Text = dgvHoaDon.Rows[e.RowIndex].Cells["TongTienHang"].Value.ToString();
            txtVAT.Text = dgvHoaDon.Rows[e.RowIndex].Cells["VAT"].Value.ToString();
            txtTongTienThanhToan.Text = dgvHoaDon.Rows[e.RowIndex].Cells["TongTienTT"].Value.ToString();
            cbbMaKhachHang.Text = dgvHoaDon.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            cbbMaNhanVien.Text = dgvHoaDon.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();

            txtMaHoaDon.Enabled = false;
        }

        //sua
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

            string sMAHOADON = txtMaHoaDon.Text;
            string sTHOIGIAN = mskNgaymua.Value.ToString("yyyy-MM-dd");
            string sTONGTIENHANG = txtTongTien.Text;
            string sVAT = txtVAT.Text;
            string sTONGTIENTT = txtTongTienThanhToan.Text;
            string sMAKH = cbbMaKhachHang.Text;
            string sMANV = cbbMaNhanVien.Text;

            string sQuery = "update HOADON " + "set thoigian=@ThoiGian, tongtienhang=@TongTienHang, vat=@VAT, tongtientt=@TongTienTT , makh=@MaKH, manv=@MaNV" + " where mahd=@MaHD;";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHD", sMAHOADON);
            cmd.Parameters.AddWithValue("@ThoiGian", sTHOIGIAN);
            cmd.Parameters.AddWithValue("@TongTienHang", sTONGTIENHANG);
            cmd.Parameters.AddWithValue("@VAT", sVAT);
            cmd.Parameters.AddWithValue("@TongTienTT", sTONGTIENTT);
            cmd.Parameters.AddWithValue("@MaKH", sMAKH);
            cmd.Parameters.AddWithValue("@MaNV", sMANV);

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

                string sMAHOADON = txtMaHoaDon.Text;

                string sQuery = "delete HOADON where mahd=@MaHD";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaHD", sMAHOADON);


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

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
           
            btnThemHoaDon.Enabled = true;
            txtMaHoaDon.Enabled = true;
            clear();
            void clear()
            {
                txtMaHoaDon.Clear();
               
                txtTongTien.Clear();
                txtVAT.Clear();
                txtTongTienThanhToan.Clear();
                txtMaHoaDon.Focus();
              
            }
        }

        private void btnThemHoaDon_Click_1(object sender, EventArgs e)
        {
            frmHoaDonChiTiet f = new frmHoaDonChiTiet();
            f.temp = txtMaHoaDon.Text;
            f.Show();
        }
    }

      
}


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
    public partial class frmPhieuNhap : Form
    {
        string sCon = "Data Source=database-1.cynulcntzgpn.ap-southeast-1.rds.amazonaws.com;Initial Catalog=QLBH;User ID=admin;Password=csdl.2022";
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
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
            string sQuery = "select *from PHIEUNHAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet dsphieunhap = new DataSet();
            adapter.Fill(dsphieunhap, "PHIEUNHAP");
            dgvPhieuNhap.DataSource = dsphieunhap.Tables["PHIEUNHAP"];

            //  txtVAT.Enabled = false;
            // txtTongTien.Enabled = false;
            //  txtTongTienSauThue.Enabled = false;


            //do du lieu vao combobox MaNV
            string sQuery1 = "select MaNV from NHANVIEN";
            SqlDataAdapter adapternew = new SqlDataAdapter(sQuery1, con);
            DataSet dsnew1 = new DataSet();
            adapternew.Fill(dsnew1, "nv");
            cbbMaNhanVien.DataSource = dsnew1.Tables["nv"];
            cbbMaNhanVien.ValueMember = "MaNV";

            //do du lieu vao combobox MaNCC
            string sQuery2 = "select MaNCC from NHACUNGCAP";
            SqlDataAdapter adapterneww = new SqlDataAdapter(sQuery2, con);
            DataSet dsnew2 = new DataSet();
            adapterneww.Fill(dsnew2, "ncc");
            cbbMaCungCap.DataSource = dsnew2.Tables["ncc"];
            cbbMaCungCap.ValueMember = "MaNCC";

            con.Close();

            dgvPhieuNhap.Columns["MaNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        //truyen du lieu sang form khac
        public void GETVALUE(string value)
        {

        }

        //cellclick dgv
        private void dgvPhieuNhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtMaPhieuNhap.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPN"].Value.ToString();
            mskNgaynhap.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["NgayNhap"].Value.ToString();
            txtTongTien.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["TongTienHang"].Value.ToString();
            txtVAT.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["VAT"].Value.ToString();
            txtTongTienThanhToan.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["TongTienTT"].Value.ToString();
            cbbMaCungCap.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            cbbMaNhanVien.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();

            txtMaPhieuNhap.Enabled = false;
        }

        //sua
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

            string sMAPHIEUNHAP = txtMaPhieuNhap.Text;
            string sTHOIGIAN = mskNgaynhap.Value.ToString("yyyy-MM-dd");
            string sTONGTIENHANG = txtTongTien.Text;
            string sVAT = txtVAT.Text;
            string sTONGTIENTT = txtTongTienThanhToan.Text;
            string sMAKH = cbbMaCungCap.Text;
            string sMANV = cbbMaNhanVien.Text;

            string sQuery = "update PHIEUNHAP " + "set ngaynhap=@NgayNhap, tongtienhang=@TongTienHang, vat=@VAT, tongtientt=@TongTienTT , mancc=@MaNCC, manv=@MaNV" + " where mapn=@MaPN;";


            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaPN", sMAPHIEUNHAP);
            cmd.Parameters.AddWithValue("@NgayNhap", sTHOIGIAN);
            cmd.Parameters.AddWithValue("@TongTienHang", sTONGTIENHANG);
            cmd.Parameters.AddWithValue("@VAT", sVAT);
            cmd.Parameters.AddWithValue("@TongTienTT", sTONGTIENTT);
            cmd.Parameters.AddWithValue("@MaNCC", sMAKH);
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

                string sMAPHIEUNHAP = txtMaPhieuNhap.Text;

                string sQuery = "delete PHIEUNHAP where mapn=@MaPN";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaPN", sMAPHIEUNHAP);


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
           
            btnThemPhieuNhap.Enabled = true;
            txtMaPhieuNhap.Enabled = true;
            clear();
            void clear()
            {
                txtMaPhieuNhap.Clear();

                txtTongTien.Clear();
                txtVAT.Clear();
                txtTongTienThanhToan.Clear();
                txtMaPhieuNhap.Focus();

            }
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            frmPhieuNhapChiTiet f = new frmPhieuNhapChiTiet();
            f.temp = txtMaPhieuNhap.Text;
            f.Show();
        }


     

        private void btnBoQua_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
           
            btnThemPhieuNhap.Enabled = true;
            txtMaPhieuNhap.Enabled = true;
            clear();
            void clear()
            {
                txtMaPhieuNhap.Clear();

                txtTongTien.Clear();
                txtVAT.Clear();
                txtTongTienThanhToan.Clear();
                txtMaPhieuNhap.Focus();

            }
        }

   
    }

}
    

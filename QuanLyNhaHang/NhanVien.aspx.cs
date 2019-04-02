using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QuanLyNhaHang
{
    public partial class NhanVien : System.Web.UI.Page
    {
        int LuuMaNV;
        DataSet1TableAdapters.NhanVienTableAdapter nv = new DataSet1TableAdapters.NhanVienTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNgayThangNam();
                LoadData();
            }
        }
        #region Load Gridview
        public void LoadData()
        {
            GridView1.DataSource = nv.GetData();
            GridView1.DataBind();
        }
        #endregion
        #region load ngày tháng năm cơ bản
        public void LoadNgayThangNam()
        {
            ddlNgay.Items.Clear();
            //ddlNgay.Items.Add("-Ngày-");
            for (int i = 1; i <= 31; i++)
            {
                ddlNgay.Items.Add(i.ToString());
            }
            ddlThang.Items.Clear();
            //ddlThang.Items.Add("-Tháng-");
            for (int i = 1; i <= 12; i++)
            {
                ddlThang.Items.Add(i.ToString());
            }
            ddlNam.Items.Clear();
            //ddlNam.Items.Add("-Năm-");
            for (int i = 1980; i <= DateTime.Now.Year; i++)
            {
                ddlNam.Items.Add(i.ToString());
            }
        }
        #endregion
        #region xử lý ngày tạm bỏ cái này nha, nếu muốn dùng thì tắt chú thích đi :))
        protected void ddlThang_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    int ngay;
        //    int thang = int.Parse(ddlThang.SelectedItem.Value);
        //    switch (thang)
        //    {
        //        case 2:

        //            if (ddlNam.SelectedIndex != 0)
        //            {
        //                ddlNgay.Items.Clear();
        //                int nam = int.Parse(ddlNam.SelectedItem.Value);
        //                //if ((nam % 4 == 0) && ((nam % 100 != 0) || (nam % 400 == 0)))
        //                if (nam % 4 == 0)
        //                {
        //                    ngay = 29;
        //                }
        //                else
        //                {
        //                    ngay = 28;
        //                }
        //                //ddlNgay.Items.Add("-Ngày-");
        //                for (int i = 1; i <= ngay; i++)
        //                {
        //                    ddlNgay.Items.Add(i.ToString());
        //                }
        //            }
        //            else
        //            {
        //                ddlNgay.Items.Clear();
        //                //ddlNgay.Items.Add("-Ngày-");
        //            }
        //            break;
        //        case 1:
        //        case 3:
        //        case 5:
        //        case 7:
        //        case 8:
        //        case 10:
        //        case 12:
        //            ddlNgay.Items.Clear();
        //            //ddlNgay.Items.Add("-Ngày-");
        //            for (int i = 1; i <= 31; i++)
        //            {
        //                ddlNgay.Items.Add(i.ToString());
        //            }
        //            break;
        //        case 4:
        //        case 6:
        //        case 9:
        //        case 11:
        //            ddlNgay.Items.Clear();
        //            //ddlNgay.Items.Add("-Ngày-");
        //            for (int i = 1; i <= 30; i++)
        //            {
        //                ddlNgay.Items.Add(i.ToString());
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        }
        #endregion
        #region thêm nhân viên
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (rbGioiTinh.SelectedValue == "Nam")
            {
                gt = rbGioiTinh.SelectedValue.ToString();
            }
            else
            {
                gt = rbGioiTinh.SelectedValue.ToString();
            }
            string layngay = ddlNgay.SelectedItem.Value;
            string laythang = ddlThang.SelectedItem.Value;
            string laynam = ddlNam.SelectedItem.Value;
            string date = laythang + "/" + layngay + "/" + laynam;
            // Thêm NV
            if (btnThem.Text == "Thêm")
            {
                if (txtMaNV.Text == "" || txtUser.Text == "" || txtPass.Text == ""
                    || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
                {
                    lblTBLoi.Text = "Vui lòng nhập đầy đủ thông tin";
                }
                else
                    if (txtMaNV.Text.Length < 6)
                    {
                        lblTBLoi.Text = "Mã nhân viên phải đủ 6 số trở lên";
                    }
                    else
                        if (txtSDT.Text.Length < 9)
                        {
                            lblTBLoi.Text = "Số điện thoại phải đủ 10 số!";
                        }
                        else
                            if (kiemtramanv())
                            {
                                lblTBLoi.Text = "Mã nhân viên đã tồn tại";
                            }
                            else
                                if (kiemtrauser())
                                {
                                    lblTBLoi.Text = "Tài khoản đã tồn tại";
                                }
                                else
                                    if (kiemtraSDT())
                                    {
                                        lblTBLoi.Text = "Trùng số điện thoại";
                                    }
                                    else
                                        {
                                            try
                                            {
                                                nv.ThemNV(Int32.Parse(txtMaNV.Text), txtUser.Text,
                                                    txtPass.Text, txtHoTen.Text, date, gt,
                                                    txtDiaChi.Text, Int32.Parse(txtSDT.Text));
                                                lblTBLoi.Text = "Thêm nhân viên thành công";
                                                LoadData();
                                                KhoaTruong();
                                            }
                                            catch
                                            {
                                                lblTBLoi.Text = "Mã nhân viên không hợp lệ";
                                            }
                                        }
            }
            // Cập Nhật NV
            if (btnThem.Text == "Cập Nhật")
            {
                if (txtUser.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
                {
                    lblTBLoi.Text = "Vui lòng nhập đầy đủ thông tin";
                }
                else
                    if (txtSDT.Text.Length < 9)
                    {
                        lblTBLoi.Text = "Số điện thoại phải đủ 10 số!";
                    }
                    else
                        {
                            try
                            {
                                nv.CNThongTinNV(txtUser.Text, txtHoTen.Text, date, gt, txtDiaChi.Text,
                                    Int32.Parse(txtSDT.Text), Int32.Parse(txtMaNV.Text));
                                lblTBLoi.Text = "Cập nhật thành công";
                                LoadData();
                                KhoaTruong();
                                txtMaNV.Enabled = true;
                                txtPass.Enabled = true;
                                btnHuy.Text = "Hủy";
                                btnThem.Text = "Thêm";
                                lblTieuDe.Text = "Quản Lý Nhân Viên";
                            }
                            catch
                            {
                                lblTBLoi.Text = "Số điện thoại không hợp lệ";
                            }
                        }
            }
        }
        #endregion
        #region load gridview
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                nv.XoaNV(int.Parse(GridView1.Rows[RemoveAt].Cells[0].Text));
                LoadData();
            }
            if (e.CommandName == "sua")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                LuuMaNV = int.Parse(GridView1.Rows[RemoveAt].Cells[0].Text);
                txtMaNV.Text = LuuMaNV.ToString();
                txtUser.Text = nv.LayUserCN(LuuMaNV);
                txtHoTen.Text = nv.LayHoTenCN(LuuMaNV);
                TachNgay();

                if (nv.LayGioiTinhCN(LuuMaNV) == "Nữ")
                {
                    rbGioiTinh.SelectedValue = "Nữ";
                }
                else
                {
                    rbGioiTinh.SelectedValue = "Nam";
                }
                txtDiaChi.Text = nv.LayDiaChiCN(LuuMaNV);
                txtSDT.Text = nv.LaySDTCN(LuuMaNV).ToString();
                lblTBLoi.Text = "";
                lblTieuDe.Text = "Cập Nhật Thông Tin Nhân Viên";
                btnThem.Text = "Cập Nhật";
                btnHuy.Text = "Hủy Cập Nhật";
                txtMaNV.Enabled = false;
                txtPass.Enabled = false;
            }
        }
        #endregion
        #region nút Hủy
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnHuy.Text == "Hủy")
            {
                Response.Redirect("TrangChu.aspx");
            }
            else
                if (btnHuy.Text == "Hủy Cập Nhật")
                {
                    KhoaTruong();
                    txtMaNV.Enabled = true;
                    txtPass.Enabled = true;
                    btnThem.Text = "Thêm";
                    btnHuy.Text = "Hủy";
                    lblTieuDe.Text = "Quản Lý Nhân Viên";
                }
        }
        #endregion
        #region khóa trường lại
        public void KhoaTruong()
        {
            txtMaNV.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtHoTen.Text = "";
            LoadNgayThangNam();
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        #endregion
        #region Tìm Kiếm theo Mã nhân viên hoặc UserName hoặc Họ tên
        protected void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=PHU\WOI;Initial Catalog=QLNhaHang;Integrated Security=True");
            string query = "select * from NhanVien where MaNV Like '%"+txtTimKiem.Text+"%'or UserName Like N'%" + txtTimKiem.Text + "%'or HoTen Like N'%" + txtTimKiem.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cnn.Close();
            GridView1.DataBind();
        }
        #endregion
        #region Tách ngày tháng năm
        public void TachNgay()
        {
            string ngaysinh = nv.LayNgaySinhCN(LuuMaNV).ToString();
            string pattern = "/";
            Regex myRegex = new Regex(pattern);
            string[] ketqua = myRegex.Split(ngaysinh);
            ddlThang.Text = ketqua[0].ToString();
            ddlNgay.Text = ketqua[1].ToString();
            //ddlNam.Text = ketqua[2].ToString();
            if (ngaysinh.Length == 22)
            {
                ddlNam.Text = ngaysinh.Substring(6, 4);
            }
            if (ngaysinh.Length == 20)
            {
                ddlNam.Text = ngaysinh.Substring(4, 4);
            }
            if (ngaysinh.Length == 21)
            {
                ddlNam.Text = ngaysinh.Substring(5, 4);
            }
        }
        #endregion
        #region Kiểm tra trùng Mã nhân viên
        public bool kiemtramanv()
        {
            bool tatkt = false;
            string manv = txtMaNV.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNhaHangConnectionString"].ConnectionString);
            con.Open();

            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from NhanVien where MaNV='" + manv + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                tatkt = true;
            }
            da_kiemtra.Dispose();
            return tatkt;
        }
        #endregion
        #region Kiểm tra trùng user
        public bool kiemtrauser()
        {
            bool tatkt = false;
            string user = txtUser.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNhaHangConnectionString"].ConnectionString);
            con.Open();

            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from NhanVien where UserName='" + user + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                tatkt = true;
            }
            da_kiemtra.Dispose();
            return tatkt;
        }
        #endregion
        #region Kiểm tra trùng số điện thoại
        public bool kiemtraSDT()
        {
            bool tatkt = false;
            int sdt = Int32.Parse(txtSDT.Text);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNhaHangConnectionString"].ConnectionString);
            con.Open();

            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from NhanVien where SDT='" + sdt + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                tatkt = true;
            }
            da_kiemtra.Dispose();
            return tatkt;
        }
        #endregion
    }
}
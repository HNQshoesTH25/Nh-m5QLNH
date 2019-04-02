using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyNhaHang
{
    public partial class DangNhap : System.Web.UI.Page
    {
        //DataSet1TableAdapters.NhanVienTableAdapter nv = new DataSet1TableAdapters.NhanVienTableAdapter();
        DataSet1TableAdapters.TaiKhoanTableAdapter tkql = new DataSet1TableAdapters.TaiKhoanTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null)
                    txtUser.Text = Request.Cookies["username"].Value;

                if (Request.Cookies["password"] != null)
                    txtPass.Attributes.Add("value", Request.Cookies["username"].Value);
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                    cbNhoMK.Checked = true;
            } 
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            int LuuID = Int32.Parse(tkql.LayID(txtUser.Text).ToString());
            bool dangNhapOk = false;
            if (txtUser.Text == "" && txtPass.Text == "")
            {
                lblTBLoi.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
                if (txtUser.Text != tkql.LayUser(LuuID) && txtPass.Text != tkql.LayPass(LuuID))
                {
                    lblTBLoi.Text = "Tài khoản và mật khẩu không đúng, vui lòng nhập lại";
                }
                else
                    if (txtUser.Text != tkql.LayUser(LuuID))
                    {
                        lblTBLoi.Text = "Tài khoản không đúng";
                    }
                    else
                        if (txtUser.Text == tkql.LayUser(LuuID) && txtPass.Text != tkql.LayPass(LuuID))
                        {
                            lblTBLoi.Text = "Sai mật khẩu";
                        }
                        else
                        {
                            Session["UserName"] = txtUser.Text.Trim();
                            dangNhapOk = true;
                            if (cbNhoMK.Checked == true)
                            {
                                Response.Cookies["username"].Value = txtUser.Text;
                                Response.Cookies["password"].Value = txtPass.Text;
                                Response.Cookies["username"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(15);
                            }
                            else
                            {
                                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                            }
                            Response.Redirect("TrangChu.aspx");
                        }
            if (dangNhapOk == false)
            {
                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
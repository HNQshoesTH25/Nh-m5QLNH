using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhaHang
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                lblTen.Visible = false;
                NavigationMenu.Enabled = false;
            }
            else
            {
                lblTen.Visible = true;
                lblTen.Text = "Xin Chào " + Session["UserName"];
                linkbtn.Text = "Đăng Xuất";
                NavigationMenu.Enabled = true;
            }
        }

        protected void linkbtn_Click(object sender, EventArgs e)
        {
            if (linkbtn.Text == "Đăng Xuất")
            {
                Session.Abandon();
                Response.Redirect("DangNhap.aspx");
            }
            if (linkbtn.Text == "Đăng Nhập")
            {
                Response.Redirect("DangNhap.aspx");
            }
            
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
        }
    }
}
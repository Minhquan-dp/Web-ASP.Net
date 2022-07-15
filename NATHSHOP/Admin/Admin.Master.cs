using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TrangThai"] == null) Response.Redirect("~/Admin/Login.aspx");
            if (Session["TenAdmin"] != null)
            {
                if (bool.Parse(Session["TrangThai"].ToString()) == true)
                {
                    lblTenDangNhap.Text = "Welcome, <strong>" + Session["TenAdmin"] + "</strong>";
                }
            }

        }

    }
}
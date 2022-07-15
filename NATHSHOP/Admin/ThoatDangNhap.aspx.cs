using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class ThoatDangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TenDanNhap"] = null;
            Session["MatKhau"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}
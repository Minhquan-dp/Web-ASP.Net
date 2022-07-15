using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class Login : System.Web.UI.Page
    {

        string conStr = "Data Source=.\\;Initial Catalog=SPORTDATA;Trusted_Connection=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TrangThai"] != null && (bool)Session["TrangThai"] == true)
            {
                Response.Redirect("~/Admin/default.aspx");
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(conStr);
            string sql = "Select * From Admin Where  TenDangNhap=@User and MatKhau=@Pass AND TrangThai=1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("User", txtEmail.Text);
            cmd.Parameters.AddWithValue("Pass", txtPass.Text);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                Session["MaAdmin"] = rd["MaAdmin"].ToString();
                Session["TenAdmin"] = rd["TenAdmin"].ToString(); // lưu session cột name
                Session["TrangThai"] = true;
                Response.Redirect("~/Admin/default.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Email or password incorrect!";
            }
            conn.Close();
            conn.Dispose();
        }
    }
}
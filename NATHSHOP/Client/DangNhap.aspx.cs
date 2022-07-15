using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Client
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void bttDN_Click(object sender, EventArgs e)
        {
            DAL_KetNoi dn = new DAL_KetNoi();
            string sql = "Select * From KhachHang Where  TenDangNhap=@User and MatKhau=@Pass ";
            SqlCommand cmd = new SqlCommand(sql, dn.cnn);
            cmd.Parameters.AddWithValue("User", txtTendangnhap.Text);
            cmd.Parameters.AddWithValue("Pass", txtMatkhau.Text);
            dn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                Session["MaKH"] = rd["MaKH"].ToString();
                Session["HoTen"] = rd["HoTen"].ToString();
                //Session["MatKhau"] = rd["MatKhau"].ToString();
                Session["TenDangNhap"] = rd["TenDangNhap"].ToString();
                // lưu session cột name
                //Session["TrangThai"] = true;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblThongbao.Visible = true;
                lblThongbao.Text = "Email or password incorrect!";
            }
            dn.Close();

        }
        protected void kt()
        {
            Label lblDangNhap = (Label)this.Master.FindControl("lblDangNhap");
            Panel pnlchuadangnhap = (Panel)this.Master.FindControl("pnlchuadangnhap");
            Panel pnldadangnhap = (Panel)this.Master.FindControl("pnldadangnhap");
            if (Session["TenDangNhap"] != null)//Da dang nhap
            {
                lblDangNhap.Text = Session["TenDangNhap"].ToString();
                UpdatePanel1.Visible = false;
                pnldadangnhap.Visible = true;
                pnlchuadangnhap.Visible = false;
                Response.Redirect("Default.aspx");
            }

        }
    }
}
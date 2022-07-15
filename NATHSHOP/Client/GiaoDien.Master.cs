using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Client
{
    public partial class GiaoDien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HienThiGioHang();
            if (Session["TenDangNhap"] != null)//Da dang nhap
            {
                lblDangNhap.Text = "Chao," + Session["TenDangNhap"].ToString();
                pnldadangnhap.Visible = true;
                pnlchuadangnhap.Visible = false;
            }

            Session["lastUrl"] = Request.RawUrl.ToString();
        }
        public void HienThiGioHang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("Ten");
            dt.Columns.Add("SL");

            int SoLuong = 0; double TongTien = 0;

            if (Session["GioHang"] != null)
            {
                ArrayList giohang = (ArrayList)Session["GioHang"];
                DAL_KetNoi dalsp = new DAL_KetNoi();
                foreach (Gio sp in giohang)
                {


                    DataRow dr = dt.NewRow();
                    dr["MaSP"] = sp.MaSP;
                    dr["Ten"] = sp.TenSP;
                    dr["SL"] = sp.SoLuong;
                    SoLuong += sp.SoLuong;
                    TongTien += (sp.SoLuong * sp.GiaBan);
                    dt.Rows.Add(dr);

                }
                Session["TongSL"] = SoLuong;
                Session["TongTien"] = TongTien;
                lblSL.Text = SoLuong.ToString();
                lblTongTien.Text =  TongTien.ToString();
            }
        }
        protected void btnTK_Click(object sender, EventArgs e)
        {
            if (txtTK.Text != "")
            {
                string sKey = txtTK.Text;
                Response.Redirect("TimKiem.aspx?TenSanPham=" + sKey);
            }
            else
            {
                string lastURL = Session["lastUrl"].ToString();
                Response.Write("<script type='text/javascript'>"
                    + "alert('Yêu cầu nhập thông tin vào ô tìm kiếm');"
                    + "window.location.href = \"" + lastURL + "\";"
                    + "</script>");
            }
        }

        protected void hplLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["GioHang"] = null;
                Session["TenDangNhap"] = null;
                if (Session["TenDangNhap"] == null && Session["GioHang"] == null)
                {
                    pnlchuadangnhap.Visible = true;
                    pnldadangnhap.Visible = false;
                    Response.Redirect(Request.RawUrl, true);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
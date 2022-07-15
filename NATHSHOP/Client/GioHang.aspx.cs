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
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["GioHang"] == null)
                {
                    Response.Redirect("~/Client/Default.aspx");
                    return;
                }

                LoadGioHang();
                Session["MaSP"] = "xemgio";

            }
        }

        private void LoadGioHang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("HinhAnh");
            dt.Columns.Add("Size");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("GiaBan");


            if (Session["GioHang"] != null)
            {
                ArrayList giohang = (ArrayList)Session["GioHang"];
                DAL_KetNoi bus_sp = new DAL_KetNoi();
                Label lblTT = (Label)this.Master.FindControl("lblTongTien");
                double TongTien = 0;
                foreach (Gio sp in giohang)
                {
                    DataRow dr = dt.NewRow();
                    dr["MaSP"] = sp.MaSP;
                    dr["TenSanPham"] = sp.TenSP;
                    dr["HinhAnh"] = sp.HinhAnh;
                    switch (sp.Masize)
                    {
                        case "38":
                            dr["Size"] = "38";
                            break;
                        case "39":
                            dr["Size"] = "39";
                            break;
                        case "40":
                            dr["Size"] = "40";
                            break;
                        case "41":
                            dr["Size"] = "41";
                            break;
                        case "42":
                            dr["Size"] = "42";
                            break;

                    }
                    dr["SoLuong"] = sp.SoLuong;
                    dr["GiaBan"] = sp.GiaBan;
                    TongTien += (sp.SoLuong * sp.GiaBan);
                    dt.Rows.Add(dr);

                }
                gvGioHang.DataSource = dt.DefaultView;
                gvGioHang.DataBind();
                Session["TongTien"] = TongTien;
                lblTT.Text = TongTien.ToString();
                if (Session["TongTien"] != null)
                    lblTongCong.Text = "Tổng Tiền: " + Session["TongTien"].ToString() + "VNĐ";
            }
        }

        protected void gvGioHang_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvGioHang.EditIndex = -1;
            LoadGioHang();
        }

        protected void gvGioHang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGioHang.EditIndex = e.NewEditIndex;
            LoadGioHang();
        }

        protected void gvGioHang_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int masp = int.Parse(gvGioHang.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = gvGioHang.Rows[e.RowIndex];
            TextBox tsl = row.FindControl("txtSL") as TextBox;
            string t = tsl.Text;
            ArrayList giohang = (ArrayList)Session["GioHang"];
            foreach (Gio sp in giohang)
            {
                if (sp.MaSP == masp)
                {
                    sp.SoLuong = int.Parse(t);
                    break;

                }
            }
            Session["GioHang"] = giohang;
            gvGioHang.EditIndex = -1;
            LoadGioHang();
            Response.Redirect("GioHang.aspx?url=xemgio");
        }

        protected void gvGioHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int masp = int.Parse(gvGioHang.DataKeys[e.RowIndex].Value.ToString());
            ArrayList giohang = (ArrayList)Session["GioHang"];
            foreach (Gio sp in giohang)
            {
                if (sp.MaSP == masp)
                {
                    giohang.Remove(sp);
                    break;

                }
            }
            Session["GioHang"] = giohang;
            LoadGioHang();
            if (Session["TongTien"] != null)
                lblTongCong.Text = "Tổng Tiền: " + Session["TongTien"].ToString() + "VNĐ";
            Response.Redirect("GioHang.aspx?url=xemgio");
        }

        protected void gvGioHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDatHang_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client/DatHang.aspx");
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Session["GioHang"] = null;
                Session["TongTien"] = 0;
                Session["TongSL"] = 0;
                Label lblSL = (Label)this.Master.FindControl("lblSL");
                Label lblTT = (Label)this.Master.FindControl("lblTongTien");
                lblSL.Text = Session["TongSL"].ToString();
                lblTT.Text = Session["TongTien"].ToString();
                gvGioHang.DataSource = (DataTable)Session["GioHang"];
                gvGioHang.DataBind();
                if (Session["TongTien"] != null)
                    lblTongCong.Text = "Tổng Tiền: " + Session["TongTien"].ToString() + "VNĐ";
                btnDatHang.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnmuatiep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client/SanPham.aspx");
        }




    }
}
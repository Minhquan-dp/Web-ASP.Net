using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class QuanLyUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdmin();
            }

        }

        private void LoadAdmin()
        {
            BUS_User busad = new BUS_User();
            gvAdmin.DataSource = busad.DanhsachAd();
            gvAdmin.DataBind();
        }

        protected void gvAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdmin.EditIndex = -1;
        }

        protected void gvAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAdmin.EditIndex = e.NewEditIndex;
            LoadAdmin();
        }

        protected void gvAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int maadmin = int.Parse(gvAdmin.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = gvAdmin.Rows[e.RowIndex];

            TextBox txtHoTen = row.FindControl("txtHoTen") as TextBox;
            string hoten = txtHoTen.Text.Trim();

            TextBox txtTenDangNhap = row.FindControl("txtTenDangNhap") as TextBox;
            string tendangnhap = txtTenDangNhap.Text.Trim();

            TextBox txtMatkhau = row.FindControl("txtMatKhau") as TextBox;
            string matkhau = txtMatkhau.Text.Trim();

            TextBox txtDiaChi = row.FindControl("txtDiaChi") as TextBox;
            string diachi = txtDiaChi.Text.Trim();


            DropDownList ddlIsAdmin = row.FindControl("ddlIsAdmin") as DropDownList;
            bool isAdmin = bool.Parse(ddlIsAdmin.SelectedValue);

            User ad = new User();
            ad.MAADMIN = maadmin;
            ad.TENDANGNHAP = tendangnhap;
            ad.MATKHAU = matkhau;
            ad.HOTEN = hoten;
            ad.DIACHI = diachi;
            ad.TRANGTHAI = isAdmin;

            BUS_User busKH = new BUS_User();
            busKH.CapNhatAdmin(ad);

            gvAdmin.EditIndex = -1;
            LoadAdmin();

        }

        protected void gvAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}
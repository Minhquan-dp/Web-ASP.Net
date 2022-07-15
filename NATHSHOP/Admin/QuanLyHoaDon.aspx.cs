using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class QuanLyHoaDon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDSSP(false);
            Session["cthdPage"] = 0;
            Session["hdPage"] = 0;
        }

        public void LoadDSSP(bool TrangThai)
        {
            BUS_HoaDon bus = new BUS_HoaDon();
            DataTable dt = new DataTable();
            dt = bus.LoadDSHD(TrangThai);
            gvHoaDon.DataSource = dt.DefaultView;
            gvHoaDon.DataBind();
        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
            LoadDSSP(trangthai);
        }

        protected void gvHoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //load hoa don
            bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
            Session["hdPage"] = e.NewPageIndex;
            BUS_HoaDon bus = new BUS_HoaDon();
            DataTable dt = new DataTable();
            dt = bus.LoadDSHD(trangthai);
            gvHoaDon.DataSource = dt.DefaultView;
            gvHoaDon.PageIndex = e.NewPageIndex;
            gvHoaDon.DataBind();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Session["MaHD"] != null)
            {
                BUS_HoaDon bus = new BUS_HoaDon();

                int mahd = int.Parse(Session["MaHD"].ToString());
                HoaDon hd = new HoaDon();
                hd.MAHD = mahd;
                hd.DIACHIGIAOHANG = txtDiaChi.Text;
                hd.TRANGTHAI = bool.Parse(ddlTrangThai.SelectedValue);

                bus.CapNhatHD(hd);
                if (hd.TRANGTHAI.Equals(true))
                {
                    foreach (GridViewRow row in gvCTHD.Rows)
                    {
                        int masp = int.Parse(row.Cells[1].Text);
                        bus.CapNhatSoLuong(masp);

                    }

                }
                lblThongBao.Text = "";



                bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
                int page = int.Parse(Session["hdPage"].ToString());
                DataTable dt = new DataTable();
                dt = bus.LoadDSHD(trangthai);
                gvHoaDon.DataSource = dt.DefaultView;
                gvHoaDon.PageIndex = page;
                gvHoaDon.DataBind();
                Session["MaHD"] = null;

            }
            else
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
            }
        }

        protected void gvCTHD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //load chi tiet hoa don
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            int mahd = int.Parse(Session["MaHD"].ToString());
            Session["cthdPage"] = e.NewPageIndex;
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = e.NewPageIndex;
            gvCTHD.DataBind();
        }

        protected void gvCTHD_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCTHD.EditIndex = e.NewEditIndex;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            int mahd = int.Parse(Session["MaHD"].ToString());
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();
        }

        protected void gvCTHD_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int mahd = int.Parse(Session["MaHD"].ToString());
            GridViewRow row = gvCTHD.Rows[e.RowIndex];
            BUS_SanPham busSp = new BUS_SanPham();
            int masp = int.Parse(row.Cells[1].Text);
            int masize = 0;
            string s = row.Cells[3].Text;
            switch (row.Cells[3].Text)
            {
                case "38":
                    masize = 0;
                    break;
                case "39":
                    masize = 1;
                    break;
                case "40":
                    masize = 2;
                    break;
                case "41 ":
                    masize = 3;
                    break;
                case "42":
                    masize = 4;
                    break;
            }
            TextBox txtSoLuong = row.FindControl("txtSoLuong") as TextBox;
            string soluong = txtSoLuong.Text.Trim();

            CTHD ct = new CTHD();
            ct.MAHD = mahd;
            ct.MASP = masp;
            ct.MASIZE = masize;
            ct.SOLUONG = int.Parse(soluong);

            BUS_CTHD bus = new BUS_CTHD();
            bus.CapNhatCTHD(ct);



            gvCTHD.EditIndex = -1;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();

        }

        protected void gvCTHD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCTHD.EditIndex = -1;
            int mahd = int.Parse(Session["MaHD"].ToString());
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();
        }

        protected void gvCTHD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int mahd = int.Parse(gvCTHD.DataKeys[e.RowIndex].Value.ToString());
            BUS_CTHD bus = new BUS_CTHD();
            bus.XoaCTHD(mahd);

            gvCTHD.EditIndex = -1;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();
        }

        protected void gvHoaDon_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int mahd = int.Parse(gvHoaDon.DataKeys[e.NewSelectedIndex].Value.ToString());
            Session["MaHD"] = mahd;
            HoaDon hd = new HoaDon();
            BUS_HoaDon bus = new BUS_HoaDon();
            hd = bus.LayThongTinHD(mahd);

            txtMaHD.Text = hd.MAHD.ToString();
            txtTenKH.Text = hd.HOTEN;
            txtNgayLapHD.Text = hd.NGAYLAPHD;
            txtNgayGiaoHang.Text = hd.NGAYGIAOHANG;
            txtDiaChi.Text = hd.DIACHIGIAOHANG;
            ddlTrangThai.SelectedValue = hd.TRANGTHAI.ToString();

            //load chi tiet hoa don
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();

            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.DataBind();

            lblThongBao.Text = "";
        }


    }
}
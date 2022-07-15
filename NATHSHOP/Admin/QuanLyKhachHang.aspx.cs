using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class QuanLyKhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadKH();
            }

        }
        public void LoadKH()
        {
            BUS_KhachHang busKH = new BUS_KhachHang();
            gvKhachHang.DataSource = busKH.DanhSachKhachHang();
            gvKhachHang.DataBind();
        }

        protected void gvKhachHang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvKhachHang.EditIndex = e.NewEditIndex;
            LoadKH();
        }

        protected void gvKhachHang_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvKhachHang.EditIndex = -1;
            LoadKH();
        }

        protected void gvKhachHang_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //lay thong khach hang can cap nhat
            int makh = int.Parse(gvKhachHang.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = gvKhachHang.Rows[e.RowIndex];

            TextBox txtTenDangNhap = row.FindControl("txtTenDangNhap") as TextBox;
            string tendangnhap = txtTenDangNhap.Text.Trim();

            TextBox txtMatkhau = row.FindControl("txtMatKhau") as TextBox;
            string matkhau = txtMatkhau.Text.Trim();

            TextBox txtHoTen = row.FindControl("txtHoTen") as TextBox;
            string hoten = txtHoTen.Text.Trim();

            DropDownList ddlGioiTinh = row.FindControl("ddlGioiTinh") as DropDownList;
            bool gioitinh = bool.Parse(ddlGioiTinh.SelectedValue);

            TextBox txtDiaChi = row.FindControl("txtDiaChi") as TextBox;
            string diachi = txtDiaChi.Text.Trim();

            TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
            string email = txtEmail.Text.Trim();

            TextBox txtDienThoai = row.FindControl("txtDT") as TextBox;
            string dienthoai = txtDienThoai.Text.Trim();

            KhachHang kh = new KhachHang();
            kh.MAKH = makh;
            kh.TENDANGNHAP = tendangnhap;
            kh.MATKHAU = matkhau;
            kh.HOTEN = hoten;
            kh.GIOITINH = gioitinh;
            kh.DIACHI = diachi;
            kh.EMAIL = email;
            kh.SODIENTHOAI = dienthoai;

            BUS_KhachHang busKH = new BUS_KhachHang();
            busKH.CapNhatKhachHang(kh);

            gvKhachHang.EditIndex = -1;
            LoadKH();



        }

        protected void gvKhachHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int makh = int.Parse(gvKhachHang.DataKeys[e.RowIndex].Value.ToString());
            BUS_KhachHang busKH = new BUS_KhachHang();
            busKH.XoaKhachHang(makh);
            LoadKH();
        }

    }
}
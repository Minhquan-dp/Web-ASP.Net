using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Admin
{
    public partial class QuanLySan_Pham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSP(0);
                DienDuLieu();
            }

        }
        public void LoadSP(int loaisp)
        {
            BUS_SanPham busSP = new BUS_SanPham();
            DataTable dt = new DataTable();
            dt = busSP.LoadSPTheoLoai(loaisp);

            gvDSSP.DataSource = dt.DefaultView;
            gvDSSP.DataBind();

        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            int loaisp = int.Parse(ddlLoaiSP.SelectedValue);
            LoadSP(loaisp);


        }

        protected void gvDSSP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int masp = int.Parse(gvDSSP.DataKeys[e.RowIndex].Value.ToString());
            BUS_SanPham busSP = new BUS_SanPham();
            busSP.XoaSP(masp);
            int loaisp = int.Parse(ddlLoaiSP.SelectedValue);
            if (ddlLoaiSP.SelectedValue.Equals("MaSP"))
            {
                LoadSP(loaisp);
            }

        }
        protected void btnThemSP_Click(object sender, EventArgs e)
        {
            if (btnThemSP.Text.Equals("Cập nhật"))
            {
                SanPham sp = new SanPham();

                BUS_SanPham bus = new BUS_SanPham();

                sp.MaSP = int.Parse(txtMaSP.Text);
                sp.TenSP = txtTenSP.Text;
                sp.GiaMua = int.Parse(txtGiaMua.Text);
                sp.GiaBan = int.Parse(txtGiaBan.Text);
                sp.Masize = Session["Size"].ToString();
                if (sp.Masize == "38")
                {
                        sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                }
                else if(sp.Masize == "39")
                {  sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                }
                else if(sp.Masize == "40"){
                        sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                }
                else if(sp.Masize == "41"){
                        sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                }
                 else if(sp.Masize == "42"){
                        sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                }
                sp.LoaiSP = int.Parse(ddlLoai.SelectedValue);
                sp.ThongTin = txtThongTin.Text;
                sp.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
                sp.HinhAnh = txtHinhAnh.Text;
                bus.CapNhatSP(sp);
                DienDuLieu();
                lblThongBao.Text = "Cập nhật sản phẩm thành công !";

            }
            if (btnThemSP.Text.Equals("Thêm"))
            {

                SanPham sp = new SanPham();

                BUS_SanPham busSP = new BUS_SanPham();
                sp.MaSP = int.Parse(txtMaSP.Text);

                if (busSP.LaTrungMaSP(sp.MaSP) == 1)
                {
                    lblMaSP1.Text = "Trùng mã sản phẩm !";
                    return;
                }
                sp.TenSP = txtTenSP.Text;
                sp.GiaMua = int.Parse(txtGiaMua.Text);
                sp.GiaBan = int.Parse(txtGiaBan.Text);
                sp.LoaiSP = int.Parse(ddlLoai.SelectedValue);
                sp.ThongTin = txtThongTin.Text;
                sp.NgayNhap = DateTime.Parse(txtNgayNhap.Text);
                sp.HinhAnh = txtHinhAnh.Text;
                busSP.ThemSP(sp);
                //them size 38
                if (sp.Masize == "38")
                {
                    sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                    busSP.ThemSoLuongSanPham(sp);
                }
                //them size 39
                else if (sp.Masize == "39")
                {
                    sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                    busSP.ThemSoLuongSanPham(sp);
                }
                //them size 40
                else if (sp.Masize == "40")
                {
                    sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                    busSP.ThemSoLuongSanPham(sp);
                }
                //them size 41
                else if (sp.Masize == "41")
                {
                    sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                    busSP.ThemSoLuongSanPham(sp);
                }
                //them size 42
                else if (sp.Masize == "42") { 
                sp.SoLuong = int.Parse(txtSoluong.Text.Trim());
                busSP.ThemSoLuongSanPham(sp);
                    }

                lblThongBao.Text = "Thêm sản phẩm thành công !";
                DienDuLieu();

            }
        }

        private void DienDuLieu()
        {
            txtTenSP.Text = "";
            txtGiaMua.Text = "";
            txtGiaBan.Text = "";
            ddlLoai.SelectedIndex = 0;
            txtThongTin.Text = "";
            txtNgayNhap.Text = "";
            txtHinhAnh.Text = "";
        }

        protected void gvDSSP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("capnhatSP"))
            {
                txtSoluong.Enabled = false;
                rfvSoLuong.Visible = false;

                int id = int.Parse(e.CommandArgument.ToString());
                int masp = int.Parse(gvDSSP.DataKeys[id].Value.ToString());

                SanPham sp = new SanPham();

                BUS_SanPham bus = new BUS_SanPham();

                sp = bus.LayThongTinSanPham(masp);

                Label2.Text = "Cập nhật sản phẩm";
                btnThemSP.Text = "Cập nhật";
                txtMaSP.Enabled = false;
                txtMaSP.Text = sp.MaSP.ToString();
                txtTenSP.Text = sp.TenSP;
                txtGiaMua.Text = sp.GiaMua.ToString();
                txtGiaBan.Text = sp.GiaBan.ToString();
                switch (sp.Masize)
                {
                    case "38":
                        txtSoluong.Text = sp.SoLuong.ToString();
                        txtSoluong.Enabled = true;
                        Session["MaSize"] = 0;
                        rfvSoLuong.Visible = true;
                        break;
                    case "39":
                        txtSoluong.Text = sp.SoLuong.ToString();
                        txtSoluong.Enabled = true;
                        Session["MaSize"] = 1;
                        rfvSoLuong.Visible = true;
                        break;
                    case "40":
                        txtSoluong.Text = sp.SoLuong.ToString();
                        txtSoluong.Enabled = true;
                        Session["MaSize"] = 2;
                        rfvSoLuong.Visible = true;
                        break;
                    case "41":
                        txtSoluong.Text = sp.SoLuong.ToString();
                        txtSoluong.Enabled = true;
                        Session["MaSize"] = 3;
                        rfvSoLuong.Visible = true;
                        break;
                    case "42":
                        txtSoluong.Text = sp.SoLuong.ToString();
                        txtSoluong.Enabled = true;
                        Session["MaSize"] = 4;
                        rfvSoLuong.Visible = true;
                        break;
                }
                ddlLoai.SelectedIndex = sp.LoaiSP;
                txtThongTin.Text = sp.ThongTin;
                txtNgayNhap.Text = sp.NgayNhap.ToShortDateString();
                txtHinhAnh.Text = sp.HinhAnh;
            }
        }
    }
}
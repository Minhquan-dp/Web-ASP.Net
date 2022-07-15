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
    public partial class DatHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] == null)
                {
                    Response.Redirect("Client/Default.aspx");
                    return;
                }
                Session["LoaiSP"] = "thanhtoan";
                LoadGioHang();
                LoadThongTinKH();
            }
        }

        public void LoadThongTinKH()
        {
            if (Session["TenDangNhap"] != null)
            {
                string uname = (string)Session["TenDangNhap"];
                DAL_KetNoi dal = new DAL_KetNoi();

                KhachHang kh = dal.LayThongTinKhachHang(uname);

                txtTenKH.Text = kh.HOTEN;
                txtDiaChi.Text = kh.DIACHI;
                txtEmail.Text = kh.EMAIL;
                txtSoDT.Text = kh.SODIENTHOAI;
            }
        }

        public void LoadGioHang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("Size");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("GiaBan");

            if (Session["GioHang"] != null)
            {
                ArrayList giohang = (ArrayList)Session["GioHang"];
                DAL_KetNoi dal = new DAL_KetNoi();
                foreach (Gio sp in giohang)
                {
                    DataRow dr = dt.NewRow();
                    dr["MaSP"] = sp.MaSP;
                    dr["TenSanPham"] = sp.TenSP;
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
                    dt.Rows.Add(dr);

                }
                gvDSSP.DataSource = dt.DefaultView;
                gvDSSP.DataBind();

            }
        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (DateTime.Now.CompareTo(DateTime.Parse(txtNgayGiao.Text.Trim())) > 0)
                {
                    lblNgayGiaoHang.Text = "Ngày giao hàng nhỏ hơn ngày hiện tại !";
                    return;
                }
                if (Session["TenDangNhap"] != null && Session["GioHang"] != null)
                {
                    string uname = (string)Session["TenDangNhap"];
                    DAL_KetNoi dal = new DAL_KetNoi();


                    int MaKH = dal.LayMaKH(uname);
                    string ngaylaphd = DateTime.Now.ToShortDateString();
                    string ngaygiaohang = txtNgayGiao.Text.Trim();
                    string dc = txtDCNhan.Text.Trim();

                    // them hoa don
                    DAL_KetNoi dalhd = new DAL_KetNoi();
                    HoaDon hd = new HoaDon();
                    hd.MAHD = int.Parse(DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString());
                    hd.NGAYLAPHD = ngaylaphd;
                    hd.NGAYGIAOHANG = ngaygiaohang;
                    hd.MAKH = MaKH;
                    hd.DIACHIGIAOHANG = dc;
                    dalhd.ThemHD(hd);
                    //them chi tiet hoa don
                    DAL_KetNoi dalCTHD = new DAL_KetNoi();
                    ArrayList giohang = (ArrayList)Session["GioHang"];
                    ArrayList chitietHD = new ArrayList();
                    foreach (Gio sp in giohang)
                    {
                        CTHD cthd = new CTHD();
                        cthd.MAHD = hd.MAHD;
                        cthd.MASP = sp.MaSP;
                        cthd.MASIZE = sp.Masize;
                        cthd.SOLUONG = sp.SoLuong;
                        cthd.DONGIA = sp.GiaBan;
                        dalCTHD.ThemCTHD(cthd);
                        chitietHD.Add(cthd);
                    }
                    Session["ChiTietHoaDon"] = chitietHD;
                    Session["GioHang"] = null;
                    Response.Redirect("thanhcong.html");


                }
            }
        }
    }
}
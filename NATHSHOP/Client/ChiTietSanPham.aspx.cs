using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Client
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LayThongTinSanPham();
            ThemSP_GioHang();
        }
        public void LayThongTinSanPham()
        {

            if (Request.QueryString["action"] == "chitiet")
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                Session["MaSP"] = id;
                DAL_KetNoi dao = new DAL_KetNoi();
                SqlDataAdapter da = new SqlDataAdapter("select  *  from SanPham s, LoaiHang si where s.MaLoai = si.MaLoai  and MaSP = " + id, dao.cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "*");
                Repeater1.DataSource = ds.Tables["*"];
                Repeater1.DataBind();
                ibtnmua.PostBackUrl = "ChiTietSanPham.aspx?action=add&id=" + id + "&url=chitiet";
            }

        }
        public void ThemSP_GioHang()
        {
               if (Request.QueryString["action"] == "add" && Session["TenDangNhap"] == null)
            {
               
                Response.Write("<Script>alert(\"Vui lòng đăng nhập , để sử dụng chức năng này .\")</Script>");
                
                return ;
                
            }
              
            if (Request.QueryString["action"] == "add")
            {
                int id = int.Parse(Request.QueryString["id"]);
                Session["MaSP"] = id;
                if (Session["GioHang"] == null)
                {
                    ArrayList giohang = new ArrayList();

                    // tạo mới món hàng
                    DAL_KetNoi dao = new DAL_KetNoi();
                    Gio sp = dao.LayThongTinSanPham(id); // thêm vào slg 1
                    sp.SoLuong = 1;
                    // thêm vào giỏ hàng
                    giohang.Add(sp);
                    // lưu trong session
                    Session["GioHang"] = giohang;

                }
                else
                {

                    ArrayList giohang = (ArrayList)Session["GioHang"];
                    bool flag = false;
                    foreach (Gio sp in giohang)
                    {
                        if (sp.MaSP == id)
                        {
                            sp.SoLuong += 1;
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        // tạo mới món hàng
                        DAL_KetNoi dao = new DAL_KetNoi();
                        Gio sp = dao.LayThongTinSanPham(id); // thêm vào slg 1
                        sp.SoLuong = 1;
                        // thêm vào giỏ hàng
                        giohang.Add(sp);
                    }
                }

                Response.Redirect("~/SanPham.aspx");

            }
        }


    }
}
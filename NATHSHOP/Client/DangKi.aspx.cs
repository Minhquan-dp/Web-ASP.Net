using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NATHSHOP.Client
{
    public partial class DangKi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DAL_KetNoi dao = new DAL_KetNoi();
                int flagEmail = dao.LaTrungEmail(txtEmail.Text.Trim());
                int flagUsername = dao.LaTrungTenDangNhap(txtTendangnhap.Text.Trim());

                if (flagUsername == 1 && flagEmail == 1)
                {
                    lblUsername.Text = "Tên đăng nhập này đã có người sử dụng!";
                    lblEmail.Text = "Địa chỉ Email này đã có người sử dụng!";
                    lblThongBao.Text = "Đăng kí không thành công !";


                }
                else
                    if (flagEmail == 1)
                    {
                        lblEmail.Text = "Địa chỉ Email này đã có người sử dụng!";
                        lblThongBao.Text = "Đăng kí không thành công !";

                    }
                    else
                        if (flagUsername == 1)
                        {
                            lblUsername.Text = "Tên đăng nhập này đã có người sử dụng!";
                            lblThongBao.Text = "Đăng kí không thành công !";
                        }
                        else
                        {

                            KhachHang kh = new KhachHang();
                            kh.MAKH = int.Parse(DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString());
                            kh.TENDANGNHAP = txtTendangnhap.Text;
                            kh.MATKHAU = txtMatkhau.Text;
                            kh.HOTEN = txtHoten.Text;
                            if (rblGioitinh.SelectedItem.Text.Equals("Nam"))
                            {
                                kh.GIOITINH = true;
                            }
                            else
                            {
                                kh.GIOITINH = false;
                            }
                            kh.DIACHI = txtDiachi.Text;
                            kh.EMAIL = txtEmail.Text;
                            kh.SODIENTHOAI = txtDienthoai.Text;
                            dao.GhiThongTinKhach(kh);
                            lblThongBao.Text = kh.TENDANGNHAP + " ! Đăng kí thành công .";
                            Response.Redirect("~/Client/Default.aspx");

                        }
            }
        }
    }
}
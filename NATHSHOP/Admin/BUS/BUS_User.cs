using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class BUS_User
    {
        public void GhiThongTinAdmin(User ad)
        {
            DAO_User dao = new DAO_User();
            dao.GhithongtinAdmin(ad);
        }
        public int LaDangNhapThanhCong(string Username, string Password)
        {
            DAO_User dao = new DAO_User();
            return dao.LaDangNhapThanhCong(Username, Password);
        }
        public DataTable DanhsachAd()
        {
            DAO_User dao = new DAO_User();
            return dao.DanhsachAd();
        }
        public void CapNhatAdmin(User ad)
        {
            DAO_User dao = new DAO_User();
            dao.CapNhatAdmin(ad);
        }
        public void XoaAdmin(int MaAdmin)
        {
            DAO_User dao = new DAO_User();
            dao.XoaAdmin(MaAdmin);
        }
        public void CapNhatThongTinAD(User ad)
        {
            DAO_User dao = new DAO_User();
            dao.CapNhatThongTinAD(ad);
        }
    }
}

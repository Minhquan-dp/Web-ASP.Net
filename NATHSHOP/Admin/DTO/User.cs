using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class User
    {
        private int MaAdmin;

        public int MAADMIN
        {
            get { return MaAdmin; }
            set { MaAdmin = value; }
        }
        private string TenDangNhap;

        public string TENDANGNHAP
        {
            get { return TenDangNhap; }
            set { TenDangNhap = value; }
        }
        private string MatKhau;

        public string MATKHAU
        {
            get { return MatKhau; }
            set { MatKhau = value; }
        }
        private string HoTen;

        public string HOTEN
        {
            get { return HoTen; }
            set { HoTen = value; }
        }
        private bool TrangThai;

        public bool TRANGTHAI
        {
            get { return TrangThai; }
            set { TrangThai = value; }
        }

        public string DiaChi;
        public string DIACHI
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }
    }
}

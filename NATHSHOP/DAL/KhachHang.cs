using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NATHSHOP.Client
{
    class KhachHang
    {
        private int MaKH;

        public int MAKH
        {
            get { return MaKH; }
            set { MaKH = value; }
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
        private bool GioiTinh;

        public bool GIOITINH
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }
        private string DiaChi;

        public string DIACHI
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }
        private string Email;

        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }
        private string SoDienThoai;

        public string SODIENTHOAI
        {
            get { return SoDienThoai; }
            set { SoDienThoai = value; }
        }

        private string _Newpass;

        public string Newpass
        {
            get { return _Newpass; }
            set { _Newpass = value; }
        }
    }
}

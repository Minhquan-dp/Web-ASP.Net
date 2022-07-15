using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class SanPham
    {
        private int maSP;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        private float giaMua;

        public float GiaMua
        {
            get { return giaMua; }
            set { giaMua = value; }
        }
        private float giaBan;

        public float GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        private int loaiSP;

        public int LoaiSP
        {
            get { return loaiSP; }
            set { loaiSP = value; }
        }
        private string Size;

        public string Masize
        {
            get { return Size; }
            set { Size = value; }
        }
        private string thongTin;

        public string ThongTin
        {
            get { return thongTin; }
            set { thongTin = value; }
        }

        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private string hinhAnh;

        public string HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }
    }
}

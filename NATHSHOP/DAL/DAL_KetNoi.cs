using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Client
{
    class DAL_KetNoi : Connect
    {
        public DataTable LoadSPTheoLoai(int MaLoai)
        {
            DataTable dt = new DataTable();
            DAL_KetNoi sp = new DAL_KetNoi();
            sp.Open();
            string qry = "select * from SanPham a, LoaiHang b where a.MaLoai = b.MaLoai and a.MaLoai = " + MaLoai;
            SqlCommand cmd = new SqlCommand(qry, sp.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            sp.Close();
            return dt;
        }
        public DataTable LoadSanPham(string TenSP)
        {
            DataTable ds = new DataTable();
            DAL_KetNoi Size = new DAL_KetNoi();
            Size.Open();
            string qry = "SELECT * FROM SanPham WHERE TenSanPham =" + TenSP;
            SqlCommand cmd = new SqlCommand(qry, Size.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            ds.Load(reader);
            Size.Close();
            return ds;
        }

        public Gio LayThongTinSanPham(int ID)
        {
            DAL_KetNoi dao_sp = new DAL_KetNoi();
            dao_sp.Open();
            string qry = "select  *  from SanPham s, LoaiHang si where s.MaLoai = si.MaLoai  and MaSP = " + ID;
            SqlCommand cmd = new SqlCommand(qry, dao_sp.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Gio g = new Gio();
            g.MaSP = int.Parse(reader["MaSP"].ToString());
            g.TenSP = reader["TenSanPham"].ToString();
            g.GiaMua = float.Parse(reader["GiaMua"].ToString());
            g.GiaBan = float.Parse(reader["GiaBan"].ToString());
            g.Masize = reader["Size"].ToString();
            g.SoLuong = int.Parse(reader["SoLuong"].ToString());
            g.ThongTin = reader["ThongTin"].ToString();
            g.NgayNhap = DateTime.Parse(reader["NgayNhapHang"].ToString());
            g.HinhAnh = reader["HinhAnh"].ToString();



            return g;
        }

        public int LaTrungTenDangNhap(string TenDangNhap)
        {
            DAL_KetNoi dao = new DAL_KetNoi();
            dao.Open();
            string qry = "SELECT * FROM KhachHang where TenDangNhap = '" + TenDangNhap + "'";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return 1;
            }
            return 0;
        }
        public int LaTrungEmail(string Email)
        {
            int flag = 0;
            DAL_KetNoi dao = new DAL_KetNoi();
            dao.Open();
            string qry = "SELECT * FROM KhachHang WHERE Email = '" + Email + "'";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                flag = 1;
            }
            cmd.Dispose();
            reader.Dispose();
            dao.Close();
            return flag;
        }
        internal void GhiThongTinKhach(KhachHang kh)
        {
            DAL_KetNoi dao = new DAL_KetNoi();
            dao.Open();

            string qry = "insert into KhachHang values("+kh.MAKH+",'" + kh.TENDANGNHAP + "','" + kh.MATKHAU + "','" + kh.HOTEN + "','true','" + kh.DIACHI + "','" + kh.EMAIL + "','" + kh.SODIENTHOAI + "')";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dao.Close();
        }
        public KhachHang LayThongTinKhachHang(string uname)
        {
            DAL_KetNoi daoKH = new DAL_KetNoi();
            daoKH.Open();
            string qry = "select * from KhachHang where TenDangNhap = '" + uname + "'";
            SqlCommand cmd = new SqlCommand(qry, daoKH.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            KhachHang kh = new KhachHang();
            if (reader.HasRows)
            {
                reader.Read();
                kh.MAKH = reader.GetInt32(0);
                kh.TENDANGNHAP = uname;
                kh.HOTEN = reader.GetValue(3).ToString();
                kh.GIOITINH = (bool)reader.GetValue(4);
                kh.DIACHI = reader.GetValue(5).ToString();
                kh.EMAIL = reader.GetValue(6).ToString();
                kh.SODIENTHOAI = reader.GetValue(7).ToString();
            }


            reader.Dispose();
            cmd.Dispose();
            daoKH.Close();

            return kh;
        }

        public int LayMaKH(string username)
        {
            DAL_KetNoi dal = new DAL_KetNoi();
            dal.Open();
            string qry = "SELECT MaKH FROM KhachHang WHERE TenDangNhap = '" + username + "'";
            SqlCommand cmd = new SqlCommand(qry, dal.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int makh = int.Parse(reader.GetValue(0).ToString());
                cmd.Dispose();
                reader.Dispose();
                dal.Close();
                return makh;
            }
            else
            {
                cmd.Dispose();
                reader.Dispose();
                dal.Close();
                return -1;
            }

        }
        public void ThemHD(HoaDon hd)
        {
            DAL_KetNoi dalHD = new DAL_KetNoi();
            dalHD.Open();
            string qry = "insert into HoaDon values(" + hd.MAHD + "," + hd.MAKH + ",'" + hd.NGAYLAPHD + "','" + hd.NGAYGIAOHANG + "','" + hd.DIACHIGIAOHANG + "','True')";
            SqlCommand cmd = new SqlCommand(qry, dalHD.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dalHD.Close();
        }

        public void ThemCTHD(CTHD cthd)
        {
            DAL_KetNoi daoCTHD = new DAL_KetNoi();
            daoCTHD.Open();
            string qry = "insert into ChiTietHoaDon(MaHD,MaSP,Size,SoLuong,DonGia,TinhTrang) values(" + cthd.MAHD + "," + cthd.MASP + ",'" + cthd.MASIZE + "'," + cthd.SOLUONG + "," + cthd.DONGIA + ",'false')";
            SqlCommand cmd = new SqlCommand(qry, daoCTHD.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            daoCTHD.Close();
        }
        public static void DoiMatKhau(KhachHang kh)
        {
            string qry = "UPDATE KhachHang SET MatKhau='" + kh.Newpass + "'WHERE TenDangNhap='" + kh.TENDANGNHAP + "'";
            DAL_KetNoi dal = new DAL_KetNoi();
            dal.Open();
            SqlCommand cmd = new SqlCommand(qry, dal.cnn);
            cmd.Dispose();
            dal.Close();

        }

        public static int LayMaHoaDon()
        {
            DAL_KetNoi dao = new DAL_KetNoi();
            dao.Open();
            string qry = "select top 1 MaHD from HoaDon order by MaHD desc";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            HoaDon hd = new HoaDon();
            if (reader.HasRows)
            {
                reader.Read();
                hd.MAHD = reader.GetInt32(0);
            }
            reader.Dispose();
            cmd.Dispose();
            dao.Close();
            return hd.MAHD;

        }
    }
}

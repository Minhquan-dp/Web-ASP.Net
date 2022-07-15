using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class DAO_SanPham: QuanLyKetNoi
    {
        public DataTable LoadSPTheoLoai(int LoaiSP)
        {
            DAO_SanPham dao_sp = new DAO_SanPham();
            dao_sp.Open();
            string qry = "select *  from SanPham s , LoaiHang si where s.MaLoai = Si.MaLoai and s.MaLoai = " + LoaiSP;
            SqlCommand cmd = new SqlCommand(qry, dao_sp.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);

            cmd.Dispose();
            reader.Dispose();

            dao_sp.Close();

            return dt;

        }

        public SanPham LayThongTinSanPham(int ID)
        {
            DAO_SanPham dao_sp = new DAO_SanPham();
            dao_sp.Open();
            string qry = "select  MaSP,s.LoaiSP,TenSP ,GiaMua, GiaBan,Size,SoLuong,ThongTin, NgayNhapHang,HinhAnh  from SanPham s, LoaiHang si where s.MaLoai = si.MaLoai  and MaSP = " + ID;
            SqlCommand cmd = new SqlCommand(qry, dao_sp.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            SanPham sp = new SanPham();
            sp.MaSP = ID;
            sp.TenSP = reader.GetString(1);
            sp.GiaBan = float.Parse(reader["GiaBan"].ToString());
            sp.GiaMua = float.Parse(reader["GiaMua"].ToString());
            sp.LoaiSP = int.Parse(reader["LoaiSP"].ToString());
            sp.ThongTin = reader["ThongTin"].ToString();
            sp.NgayNhap = DateTime.Parse(reader["NgayNhapHang"].ToString());
            sp.HinhAnh = reader["HinhAnh"].ToString();
            sp.Masize = reader["Size"].ToString();
            sp.SoLuong = int.Parse(reader["SoLuong"].ToString());

            return sp;
        }
        public DataTable TimKiemSanPham(string TenSP)
        {
            DataTable dt = new DataTable();

            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            string qry = "SELECT * FROM SanPham WHERE TenSP LIKE '%" + TenSP + "%'";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();

            dao.Close();

            return dt;
        }
        public DataTable LayKichThuocSanPham()
        {
            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            String qry = "SELECT Size FROM   SanPham WHERE  SoLuong > 0 ";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Dispose();
            reader.Dispose();

            dao.Close();

            return dt;

        }
        public void XoaSP(int MaSP)
        {
            DAO_SanPham daoSP = new DAO_SanPham();
            daoSP.Open();
            string qry = "XOASP";
            SqlCommand cmd = new SqlCommand(qry, daoSP.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = MaSP;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            daoSP.Close();
        }
        public void ThemSP(SanPham sp)
        {
            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            string qry = "insert into SanPham(MaSP,MaLoai,TenSanPham,GiaMua,GiaBan,ThongTin,NgayNhapHang,HinhAnh) values(" + sp.MaSP + "," + sp.LoaiSP + ",'" + sp.TenSP + "'," + sp.GiaMua + "," + sp.GiaBan + ",'" + sp.ThongTin + "'," + sp.NgayNhap + ",'" + sp.HinhAnh + "')";

            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            dao.Close();

        }
        public void ThemSoLuongSanPham(SanPham sp)
        {
            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            string qry = "insert into SanPham(MaSP,Size,SoLuong) values(" + sp.MaSP + "," + sp.Masize + "," + sp.SoLuong + ")";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.ExecuteNonQuery();
            dao.Close();
        }
        public void CapNhatSP(SanPham sp)
        {
            DAO_SanPham daoSP = new DAO_SanPham();
            daoSP.Open();
            string qry = "SUASP";
            SqlCommand cmd = new SqlCommand(qry, daoSP.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", SqlDbType.Text).Value = sp.MaSP;
            cmd.Parameters.Add("@MaLoai", SqlDbType.Text).Value = sp.LoaiSP;
            cmd.Parameters.Add("@TenSanPham", SqlDbType.Text).Value = sp.TenSP;
            cmd.Parameters.Add("@GiaMua", SqlDbType.Float).Value = sp.GiaMua;
            cmd.Parameters.Add("@GiaBan", SqlDbType.Float).Value = sp.GiaBan;
            cmd.Parameters.Add("@Size", SqlDbType.Text).Value = sp.Masize;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = sp.SoLuong;
            cmd.Parameters.Add("@ThongTin", SqlDbType.Text).Value = sp.ThongTin;
            cmd.Parameters.Add("@NgayNhapHang", SqlDbType.Date).Value = sp.NgayNhap;
            cmd.Parameters.Add("@HinhAnh", SqlDbType.Text).Value = sp.HinhAnh;


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            daoSP.Close();


        }
        public int LayMaSP()
        {
            DAO_SanPham daoSP = new DAO_SanPham();
            daoSP.Open();
            string qry = "select top 1 MaSP from SanPham order by MaSP desc";
            SqlCommand cmd = new SqlCommand(qry, daoSP.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int Masp = reader.GetInt32(0);
            reader.Dispose();
            daoSP.Close();

            return Masp + 1;
        }
        public DataTable TopSanPham(int num)
        {
            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            string qry = "select top " + num + " with ties B.TenSanPham , B.GiaMua,B.GiaBan,SUM(A.SoLuong)as SoLuong from ChiTietHoaDon as A , SanPham B where A.MASP = B.MASP group by A.MASP ,B.TenSanPham, B.GiaMua,B.GiaBan order by SUM(A.SoLuong) desc";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            reader.Dispose();
            cmd.Dispose();

            dao.Close();
            return dt;
        }
        public int LaTrungMaSP(int MaSP)
        {
            int flag = 0;
            DAO_SanPham dao = new DAO_SanPham();
            dao.Open();
            string qry = "select * from SanPham where MaSP = " + MaSP;
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
      
    }
}

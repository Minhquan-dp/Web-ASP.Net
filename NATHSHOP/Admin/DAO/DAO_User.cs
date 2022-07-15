using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class DAO_User:QuanLyKetNoi
    {
        public void GhithongtinAdmin(User ad)
        {
            DAO_User dao = new DAO_User();
            dao.Open();
            string qry = "insert into Admin(MaAdmin,TenAdmin,TenDangNhap,MatKhau,DiaChi,TrangThai) values('" + ad.MAADMIN + "','" + ad.HOTEN + "','" + ad.TENDANGNHAP + "','" +ad.MATKHAU + "','" + ad.DIACHI + "','False')";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dao.Close();
        }
        public int LaDangNhapThanhCong(string username, string password)
        {
            int flag = -1;
            DAO_KhachHang dao = new DAO_KhachHang();
            dao.Open();
            string qry = "SELECT * FROM Admin WHERE TenDangNhap = '" + username + "' AND MatKhau ='" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                bool isAdmin = reader.GetBoolean(8);
                if (isAdmin == true)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            cmd.Dispose();
            reader.Dispose();
            dao.Close();
            return flag;
        }

        public DataTable DanhsachAd()
        {
            DataTable ds = new DataTable();
            DAO_User daoAd = new DAO_User();
            daoAd.Open();
            string qry = "SELECT * FROM Admin";
            SqlCommand cmd = new SqlCommand(qry, daoAd.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            ds.Load(reader);
            daoAd.Close();
            return ds;
        }
        public void CapNhatAdmin(User ad)
        {
            DAO_User daoAd = new DAO_User();
            daoAd.Open();
            string qry = "Update Admin set TenDangNhap ='" + ad.TENDANGNHAP +"', TenAdmin = '" + ad.HOTEN + "', MatKhau = '" + ad.MATKHAU + "', DiaChi = '" + ad.DIACHI + "', TrangThai= '" + ad.TRANGTHAI + "'" +
             "where MaAdmin = " + ad.MAADMIN;
            SqlCommand cmd = new SqlCommand(qry, daoAd.cnn);
            cmd.ExecuteNonQuery();
            daoAd.Close();

        }
        public void XoaAdmin(int MaAdmin)
        {
            DAO_User daoAd = new DAO_User();
            daoAd.Open();
            string qry = "XOAAD";
            SqlCommand cmd = new SqlCommand(qry, daoAd.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaAdmin", SqlDbType.Int).Value = MaAdmin;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            daoAd.Close();
        }
        public void CapNhatThongTinAD(User ad)
        {
            DAO_User daoAd = new DAO_User();
            daoAd.Open();
            string qry = "Update Admin set TenAdmin = '" + ad.HOTEN + "', DiaChi = '" + ad.DIACHI + "'" +
             "where MaAdmin = " + ad.MAADMIN;
            SqlCommand cmd = new SqlCommand(qry, daoAd.cnn);
            cmd.ExecuteNonQuery();
            daoAd.Close();
        }
    }
}

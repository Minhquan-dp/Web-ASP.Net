﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class DAO_CTHD : QuanLyKetNoi
    {
        public void ThemCTHD(CTHD cthd)
        {
            DAO_CTHD daoCTHD = new DAO_CTHD();

            daoCTHD.Open();

            string qry = "CapNhatSoLuong";
            SqlCommand cmd = new SqlCommand(qry, daoCTHD.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = cthd.MAHD;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = cthd.MASP;
            cmd.Parameters.Add("@MaSize", SqlDbType.Int).Value = cthd.MASIZE;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = cthd.SOLUONG;
            cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = cthd.DONGIA;
            cmd.Parameters.Add("@flag", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            daoCTHD.Close();
        }
        public DataTable LoadCTHD(int MaHD)
        {
            DataTable dt = new DataTable();
            DAO_CTHD dao = new DAO_CTHD();
            dao.Open();
            string qry = "select * from ChiTietHoaDon c , SanPham s KhachHang k where c.MaSP = s.MaSP and c.MaKH = k.MaKH and c.MaHD = " + MaHD;
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dao.Close();
            return dt;
        }
        public void XoaCTHD(int MaHD)
        {
            DAO_CTHD dao = new DAO_CTHD();
            dao.Open();
            string qry = "delete from ChiTietHoaDon where MaHD = " + MaHD;
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dao.Close();

        }
        public void CapNhatCTHD(CTHD cthd)
        {
            DAO_CTHD dao = new DAO_CTHD();
            dao.Open();
            string qry = "CapNhatSoLuong";
            SqlCommand cmd = new SqlCommand(qry, dao.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = cthd.MAHD;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = cthd.MASP;
            cmd.Parameters.Add("@MaSize", SqlDbType.Int).Value = cthd.MASIZE;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = cthd.SOLUONG;
            cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = cthd.DONGIA;
            cmd.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
            cmd.ExecuteNonQuery();
            dao.Close();
            cmd.Dispose();
        }
    }
}

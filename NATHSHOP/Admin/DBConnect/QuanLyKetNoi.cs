using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Admin
{
    class QuanLyKetNoi
    {
        public SqlConnection cnn;
        public QuanLyKetNoi()
        {

            string strcnn = "Data Source=.\\MINHQUAN ;Initial Catalog=SPORTDATA;user id=sa;password=123;Trusted_Connection=True;";
            cnn = new SqlConnection(strcnn);
        }
        public void Open()
        {
            cnn.Open();
        }
        public void Close()
        {
            cnn.Close();
        }
    }
}

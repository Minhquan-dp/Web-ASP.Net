using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NATHSHOP.Client
{
    class Connect
    {
        public SqlConnection cnn;
        public Connect()
        {

            string strcnn = "Data Source=.\\;Initial Catalog=SPORTDATA;" +
                "Trusted_Connection=True;";
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

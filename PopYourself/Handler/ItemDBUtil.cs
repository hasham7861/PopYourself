using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PopYourself.Handler
{
    public class ItemDBUtil
    {
        static string connectionString = null;
        static SqlConnection cnn;
        private static SqlCommand command;

        private static void OpenConnection()
        {
            if (cnn == null)
            {
                connectionString = "Data Source=DESKTOP-QQS5JKR\\SQLEXPRESSWEBAPP;" +
                                   "" +
                                   "Initial Catalog=pop_cul_db;" +
                                   "Integrated Security=SSPI;Persist Security Info=false";
                cnn = new SqlConnection(connectionString);
            }

            if (cnn.State == ConnectionState.Open)
                return;
            else
            {
                cnn.Open();
            }

        }

        private static void CloseConnection()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }


    }
}
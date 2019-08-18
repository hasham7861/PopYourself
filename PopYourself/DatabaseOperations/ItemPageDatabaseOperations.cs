using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal class ItemPageDatabaseOperations
    {
        private static SqlCommand _command;

        internal static string GetAccountEmailOfPost(string accountId)
        {
            string postEmail = "";

            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand("SELECT a.email " +
                                          "FROM dbo.item i inner join dbo.account a on i.account_id = a.account_id " +
                                          "WHERE a.account_id=@id", PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@id", accountId);

                SqlDataReader reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    postEmail = reader["email"].ToString();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Can't find customer: " + ex.Message);
            }
            finally
            {
                PopCulDatabaseUtil.CloseConnection();
            }

            return postEmail;
        
    }
}
}
using System.Data.SqlClient;
using System.Diagnostics;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal static class MyAdsDatabaseOperations
    {
        private static SqlCommand _command;

        internal static SqlDataAdapter GetMyAds(string accountId)
        {
         
            PopCulDatabaseUtil.OpenConnection();
            string query = $"SELECT * FROM ad_post WHERE account_id = '{accountId}'";
            SqlDataAdapter sda = new SqlDataAdapter(query, PopCulDatabaseUtil.cnn);

            return sda;
        }


        internal static string GetAccountNameOfPosts(string accountId)
        {
            string accountName = "";

            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand("SELECT a.first_name, a.last_name " +
                                          "FROM dbo.item i inner join dbo.account a on i.account_id = a.account_id " +
                                          "WHERE a.account_id=@id", PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@id", accountId);

                SqlDataReader reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    accountName = reader["first_name"].ToString() + " " + reader["last_name"].ToString();
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

            return accountName;

        }
    }
}
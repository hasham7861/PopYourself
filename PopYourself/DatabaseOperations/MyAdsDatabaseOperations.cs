using System.Data.SqlClient;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal static class MyAdsDatabaseOperations
    {
        internal static SqlDataAdapter GetMyAds(string accountId)
        {
         
            PopCulDatabaseUtil.OpenConnection();
            string query = $"SELECT * FROM ad_post WHERE account_id = '{accountId}'";
            SqlDataAdapter sda = new SqlDataAdapter(query, PopCulDatabaseUtil.cnn);

            return sda;
        }
    }
}
using System.Data;
using System.Data.SqlClient;


namespace PopYourself.Util
{
    internal class PopCulDatabaseUtil
    {
        internal static string connectionString = null;
        internal static SqlConnection cnn;


        internal static void OpenConnection()
        {
            if (cnn == null)
            {
                connectionString = "Data Source=LAPTOP-B5DGGLB7\\SQLEXPRESS;" +
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

        internal static void CloseConnection()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

        }
    }
}
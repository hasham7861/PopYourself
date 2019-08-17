using System.Data.SqlClient;
using System.Diagnostics;
using PopYourself.Model;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal class AccountDatabaseUtil
    {

        private static SqlCommand _command;

        internal static bool RegisterCustomer(Account account)
        {
            bool validRegister = false;


            // Assuming all the customer data is valid after the validations
            try
            {
                // Grab customer's info if it exists otherwise insert
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand("INSERT INTO " +
                                         "dbo.account(username,password,first_name," +
                                         "last_name,city,province,postal_code," +
                                         "phone,email) " +
                                         "VALUES(@username,@password,@first_name," +
                                         "@last_name,@city,@province," +
                                         "@postal_code,@phone,@email)", PopCulDatabaseUtil.cnn);

                _command.Parameters.AddWithValue("@username", account.UserName);
                _command.Parameters.AddWithValue("@password",account.Password);
                _command.Parameters.AddWithValue("@first_name", account.FirstName);
                _command.Parameters.AddWithValue("@last_name", account.LastName);
                _command.Parameters.AddWithValue("@city", account.City);
                _command.Parameters.AddWithValue("@postal_code", account.PostalCode);
                _command.Parameters.AddWithValue("@phone", account.Phone);
                _command.Parameters.AddWithValue("@province", account.Province);
                _command.Parameters.AddWithValue("@email", account.Email);

                int rowsAffected = _command.ExecuteNonQuery();

                if (rowsAffected == 1)
                    validRegister = true;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("InsertCustomerError: " + ex.Message);
            }
            finally
            {
                PopCulDatabaseUtil.CloseConnection();
            }

            return validRegister;
        }

        internal static string ValidateLogin(string custEmail, string custPassword)
        {
            string accountId = "";

            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand("SELECT * " +
                                         "FROM dbo.account " +
                                         "WHERE email=@email and password=@password", PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@email", custEmail);
                _command.Parameters.AddWithValue("@password", custPassword);
                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    accountId = reader["account_id"].ToString();
                }
                else
                {
                    accountId = "";
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

            return accountId;

        }

        internal static bool AccountExist(string custEmail)
        {
            bool validLogin = false;

            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand("SELECT * " +
                                         "FROM dbo.account " +
                                         "WHERE email=@email", PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@email", custEmail);
               
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    validLogin = true;
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

            return validLogin;

        }
    }
}
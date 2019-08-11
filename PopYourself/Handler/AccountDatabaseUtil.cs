using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Hasham_991498453_Assignment_3
{
    public class AccountDatabaseUtil
    {
        static string connectionString = null;
        static SqlConnection cnn;
        private static SqlCommand command;

        private static void OpenConnection()
        {
            if (cnn == null)
            {
                connectionString = @"Data Source=LAPTOP-B5DGGLB7\SQLEXPRESS;" +
                                   "" +
                                   "Initial Catalog=master;" +
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

        public static bool RegisterCustomer(Account account)
        {
            bool validRegister = false;


            // Assuming all the customer data is valid after the validations
            try
            {
                // Grab customer's info if it exists otherwise insert
                OpenConnection();
                command = new SqlCommand("INSERT INTO " +
                                         "dbo.account(username,password,first_name," +
                                         "last_name,city,province,postal_code," +
                                         "phone,email) " +
                                         "VALUES(@username,@password,@first_name," +
                                         "@last_name,@city,@province," +
                                         "@postal_code,@phone,@email)", cnn);

                command.Parameters.AddWithValue("@username", account.UserName);
                command.Parameters.AddWithValue("@password",account.Password);
                command.Parameters.AddWithValue("@first_name", account.FirstName);
                command.Parameters.AddWithValue("@last_name", account.LastName);
                command.Parameters.AddWithValue("@city", account.City);
                command.Parameters.AddWithValue("@postal_code", account.PostalCode);
                command.Parameters.AddWithValue("@phone", account.Phone);
                command.Parameters.AddWithValue("@province", account.Province);
                command.Parameters.AddWithValue("@email", account.Email);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1)
                    validRegister = true;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("InsertCustomerError: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return validRegister;
        }

        public static string ValidateLogin(string custEmail, string custPassword)
        {
            string accountId = "";

            try
            {
                OpenConnection();
                command = new SqlCommand("SELECT * " +
                                         "FROM dbo.account " +
                                         "WHERE email=@email and password=@password", cnn);
                command.Parameters.AddWithValue("@email", custEmail);
                command.Parameters.AddWithValue("@password", custPassword);
                SqlDataReader reader = command.ExecuteReader();

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
                CloseConnection();
            }

            return accountId;

        }

        public static bool AccountExist(string custEmail)
        {
            bool validLogin = false;

            try
            {
                OpenConnection();
                command = new SqlCommand("SELECT * " +
                                         "FROM dbo.account " +
                                         "WHERE email=@email", cnn);
                command.Parameters.AddWithValue("@email", custEmail);
               
                SqlDataReader reader = command.ExecuteReader();
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
                CloseConnection();
            }

            return validLogin;

        }
    }
}
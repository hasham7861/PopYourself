/*
 * Author-Name: Hasham Alam
 * Student-No: 991498453
 * Date: 7/23/2019
 */
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Hasham_991498453_Assignment_3
{
    public class DatabaseUtil
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

        public static void RegisterCustomer(Customer customer)
        {

            //if (customer == null)
            //    return;
            //// Assuming all the customer data is valid after the validations
            //try
            //{
            //    // Grab customer's info if it exists otherwise insert
            //    OpenConnection();
            //    command = new SqlCommand("INSERT INTO " +
            //                             "dbo.account(custName,custUsername,custAddress," +
            //                             "custPostalCode,custPhoneNumber,custEmail," +
            //                             "custPassword) " +
            //                             "VALUES(@custName,@custUsername,@custAddress," +
            //                             "@custPostalCode,@custPhoneNumber,@custEmail," +
            //                             "@custPassword)", cnn);
            //    command.Parameters.AddWithValue("@custName", customer.Name);
            //    command.Parameters.AddWithValue("@custUsername", customer.UserName);
            //    command.Parameters.AddWithValue("@custAddress", customer.Address);
            //    command.Parameters.AddWithValue("@custPostalCode", customer.PostalCode);
            //    command.Parameters.AddWithValue("@custPhoneNumber", customer.PhoneNumber);
            //    command.Parameters.AddWithValue("@custEmail", customer.Email);
            //    command.Parameters.AddWithValue("@custPassword", customer.Password);

            //    int rowsAffected = command.ExecuteNonQuery();

            //}
            //catch (SqlException ex)
            //{
            //    Debug.WriteLine("InsertCustomerError: " + ex.Message);
            //}
            //finally
            //{
            //    CloseConnection();
            //}
        }

        public static Customer GetCustomer(string custUsername)
        {

            Customer customer = null;
            //try
            //{
            //    OpenConnection();
            //    command = new SqlCommand("SELECT * " +
            //                             "FROM dbo.account " +
            //                             "WHERE custUsername=@username", cnn);
            //    command.Parameters.AddWithValue("@username",
            //        custUsername);
            //    SqlDataReader reader = command.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        customer = new Customer()
            //        {
            //            Name = reader["custName"].ToString(),
            //            UserName = reader["custUsername"].ToString(),
            //            Address = reader["custAddress"].ToString(),
            //            PostalCode = reader["custPostalCode"].ToString(),
            //            PhoneNumber = reader["custPhoneNumber"].ToString(),
            //            Email = reader["custEmail"].ToString(),
            //            Password = reader["custPassword"].ToString()
            //        };

            //    }
            //}
            //catch (SqlException ex)
            //{
            //    Debug.WriteLine("Can't find customer: " + ex.Message);
            //}
            //finally
            //{
            //    CloseConnection();
            //}

            return customer;
        }

        public static bool ValidateLogin(string custEmail, string custPassword)
        {
            bool validLogin = false;

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
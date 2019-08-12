using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PopYourself.Handler
{
    public class BrowsePageDBUtil
    {
        string connectionString = null;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        private void OpenConnection()
        {
            if (sqlConnection == null)
            {
                connectionString = @"Data Source=RB-PC\\SQLEXPRESS;" +
                                    "" +
                                    "Initial Catalog=master;" +
                                    "Integrated Security=SSPI;Persist Security Info=false";

                sqlConnection = new SqlConnection(connectionString);
            }

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        private void RetrieveSearchItems(string searchKey)
        {
            //try
            //{
            //    string query = $"SELECT * FROM dbo.customers WHERE cust_username = '{(string)Session["username"]}'";

            //    Connect.Open();
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connect);
            //    DataTable dataTable = new DataTable();
            //    sqlDataAdapter.Fill(dataTable);

            //    if (dataTable.Rows.Count == 1)
            //    {
            //        SqlCommand command = new SqlCommand(query, Connect);
            //        SqlDataReader reader = command.ExecuteReader();
            //        string customerName = "";

            //        while (reader.Read())
            //        {
            //            customerName = reader["cust_name"].ToString();
            //            lblGetName.Text = reader["cust_name"].ToString();
            //            lblGetAddress.Text = reader["cust_address"].ToString();
            //            lblGetPostal.Text = reader["cust_postal"].ToString();
            //            lblGetPhone.Text = reader["cust_pnumber"].ToString();
            //            lblGetEmail.Text = reader["cust_email"].ToString();
            //            lblGetUsername.Text = reader["cust_username"].ToString();
            //        }
            //        lblWelcome.Text = $"Welcome, {customerName} to profile page!";
            //    }
            //    else
            //    {
            //        Response.Write("<h3 style='text-align:center;'>Error: Returned rows not equal to one</h3>");
            //    }
            //}
            //catch (Exception error)
            //{
            //    Response.Write($"<h3 style='text-align:center;'>Error: {error.Message}</h3>");
            //}
            //finally
            //{
            //    if (Connect.State == ConnectionState.Open)
            //        Connect.Close();
            //}
        } 
    }
}
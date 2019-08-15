using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//Author: Robert Sarmiento
//ID: 991471234
namespace PopYourself.Handler
{
    public class BrowsePageDBUtil
    {
        string connectionString = null;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        List<Item> itemList = new List<Item>();
        public List<Item> GetItemList { get { return itemList; } set { } }
        public string Message { get; set; }

        private void OpenConnection()
        {
            if (sqlConnection == null)
            {
                connectionString = "Data Source=RB-PC\\SQLEXPRESS;" +
                                    "" +
                                    "Initial Catalog=pop_cul_db;" +
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

        //Retrieve the search results from the DB
        //Display the results in browse.aspx
        public void GetDBItem(string searchKey)
        {
            Message = "";

            try
            {
                string query = $"SELECT * FROM dbo.item WHERE item_name LIKE '%{searchKey}%'";

                OpenConnection();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Item item = new Item
                        {
                            Id = reader["item_id"].ToString(),
                            Name = reader["item_name"].ToString(),
                            Category = reader["item_category"].ToString(),
                            Description = reader["item_desc"].ToString(),
                            Image = reader["item_img"].ToString(),
                            City = reader["item_city"].ToString(),
                            Phone = reader["item_phone"].ToString(),
                            Price = decimal.Parse(reader["item_price"].ToString())
                        };
                        itemList.Add(item);
                    }
                }
                else
                {
                    Message = "No matching items";
                }
            }
            catch (Exception error)
            {
                Message = error.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        //Get the item by item ID
        public Item GetItem(string id)
        {
            Item item = null;
            Message = "";
            try
            {
                string query = $"SELECT * FROM dbo.item WHERE item_id = '{id}'";

                OpenConnection();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    { 
                        item = new Item
                        {
                            Id = reader["item_id"].ToString(),
                            Name = reader["item_name"].ToString(),
                            Category = reader["item_category"].ToString(),
                            Description = reader["item_desc"].ToString(),
                            Image = reader["item_img"].ToString(),
                            City = reader["item_city"].ToString(),
                            Phone = reader["item_phone"].ToString(),
                            Price = decimal.Parse(reader["item_price"].ToString())
                        };
                    }
                }
                else
                {
                    Message = "No matching items";
                }
            }
            catch (Exception error)
            {
                Message = error.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return item;
        }
    }
}
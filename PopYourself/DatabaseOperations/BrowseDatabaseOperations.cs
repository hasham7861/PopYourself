using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal static class BrowseDatabaseOperations
    {

        private static SqlCommand _command;
        private static List<Item> itemList = new List<Item>();
       
        internal static string Message { get; set; }

        //Retrieve the search results from the DB
        //Display the results in browse.aspx
        internal static List<Item> GetAllItems(string searchKey)
        {
            Message = "";

            try
            {
                string query = $"SELECT * FROM dbo.item WHERE item_name LIKE '%{searchKey}%'";

                PopCulDatabaseUtil.OpenConnection();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, PopCulDatabaseUtil.cnn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    _command = new SqlCommand(query, PopCulDatabaseUtil.cnn);
                    SqlDataReader reader = _command.ExecuteReader();

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
                PopCulDatabaseUtil.CloseConnection();
            }

            return itemList;
        }

        //Get the item by item ID
        internal static Item GetItem(string id)
        {
            Item item = null;
            Message = "";
            try
            {
                string query = $"SELECT * FROM dbo.item WHERE item_id = '{id}'";

                PopCulDatabaseUtil.OpenConnection();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, PopCulDatabaseUtil.cnn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    _command = new SqlCommand(query, PopCulDatabaseUtil.cnn);
                    SqlDataReader reader = _command.ExecuteReader();

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
                PopCulDatabaseUtil.CloseConnection();
            }
            return item;
        }
    }
}
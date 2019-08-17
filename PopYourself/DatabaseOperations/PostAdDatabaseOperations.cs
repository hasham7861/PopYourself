using System;
using System.Data;
using System.Data.SqlClient;
using PopYourself.Model;
using PopYourself.Util;

namespace PopYourself.DatabaseOperations
{
    internal static class PostAdDatabaseOperations
    {
       
        private static SqlCommand _command;
        internal static readonly string accountId = (string)System.Web.HttpContext.Current.Session["account_id"];

        internal static bool CreateItem(Item item)
        {
            bool validItem = false;
            
            string insertItem = "insert into item values (@account_id,@item_name,@item_category,@item_desc,@item_img," +
                    "@item_city,@item_phone,@item_price)";
            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand(insertItem, PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@account_id", accountId);
                _command.Parameters.AddWithValue("@item_name", item.Name);
                _command.Parameters.AddWithValue("@item_category", item.Category);
                _command.Parameters.AddWithValue("@item_price", item.Price);
                _command.Parameters.AddWithValue("@item_city", item.City);
                _command.Parameters.AddWithValue("@item_phone", item.Phone);
                _command.Parameters.AddWithValue("@item_desc", item.Description);
                _command.Parameters.AddWithValue("@item_img", item.Image);
                int rowsInserted = _command.ExecuteNonQuery();

                if (rowsInserted == 1 && AdPost(item))
                    validItem = true;
            }
            catch (SqlException ex)
            {
                
                System.Diagnostics.Debug.WriteLine(item.Price.GetType());
                System.Diagnostics.Debug.WriteLine("Error in SQL!" + ex.Message);
            }
            finally
            {
                PopCulDatabaseUtil.CloseConnection();
            }

            return validItem;
        }

        internal static void ItemDetails (out string itemId, out string itemName, Item item)
        {
            itemId = "";
            itemName = "";
            string itemIDQuery = $"select item_id, item_name from item where item_name = '{item.Name}'";
            try
            {
                PopCulDatabaseUtil.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(itemIDQuery, PopCulDatabaseUtil.cnn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    SqlCommand command = new SqlCommand(itemIDQuery, PopCulDatabaseUtil.cnn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        itemId = reader["item_id"].ToString();
                        itemName = reader["item_name"].ToString();
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No matching item_name");
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in SQL! " + ex.Message);
            }
            finally
            {
                PopCulDatabaseUtil.CloseConnection();
            }
        }

        internal static bool AdPost(Item item)
        {
            bool validPost = false;
            string itemId;
            string itemName;
            var currDate = DateTime.Now;
            var expiryDate = currDate.AddDays(10);

            ItemDetails(out itemId, out itemName, item);

            string insertPost = "insert into ad_post values (@account_id,@item_id,@post_title,@post_date,@post_expiry)";

            try
            {
                PopCulDatabaseUtil.OpenConnection();
                _command = new SqlCommand(insertPost, PopCulDatabaseUtil.cnn);
                _command.Parameters.AddWithValue("@account_id", accountId);
                _command.Parameters.AddWithValue("@item_id", itemId);
                _command.Parameters.AddWithValue("@post_title", itemName);
                _command.Parameters.AddWithValue("@post_date", currDate);
                _command.Parameters.AddWithValue("@post_expiry", expiryDate);
                int rowInserted = _command.ExecuteNonQuery();
                if (rowInserted == 1)
                    validPost = true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in SQL!" + ex.Message);
            }
            finally
            {
                PopCulDatabaseUtil.CloseConnection();
            }

            return validPost;
        }
    }
}
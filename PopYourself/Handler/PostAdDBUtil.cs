//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: August 11, 2019
using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PopYourself.Handler
{
    public class PostAdDBUtil
    {
        static string connectionString = null;
        static SqlConnection cnn;
        private static SqlCommand command;
        static readonly string accountId = (string)System.Web.HttpContext.Current.Session["account_id"];

        private static void OpenConnection()
        {
            if (cnn == null)
            {
                connectionString = "Data Source=DESKTOP-QQS5JKR\\SQLEXPRESSWEBAPP;" +
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

        private static void CloseConnection()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }

        public static bool CreateItem(Item item)
        {
            bool validItem = false;
            
            string insertItem = "insert into item values (@account_id,@item_name,@item_category,@item_desc,@item_img," +
                    "@item_city,@item_phone,@item_price)";
            try
            {
                OpenConnection();
                command = new SqlCommand(insertItem, cnn);
                command.Parameters.AddWithValue("@account_id", accountId);
                command.Parameters.AddWithValue("@item_name", item.Name);
                command.Parameters.AddWithValue("@item_category", item.Category);
                command.Parameters.AddWithValue("@item_price", item.Price);
                command.Parameters.AddWithValue("@item_city", item.City);
                command.Parameters.AddWithValue("@item_phone", item.Phone);
                command.Parameters.AddWithValue("@item_desc", item.Description);
                command.Parameters.AddWithValue("@item_img", item.Image);
                int rowsInserted = command.ExecuteNonQuery();

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
                CloseConnection();
            }

            return validItem;
        }

        public static void ItemDetails (out string itemId, out string itemName, Item item)
        {
            itemId = "";
            itemName = "";
            string itemIDQuery = $"select item_id, item_name from item where item_name = '{item.Name}'";
            try
            {
                OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(itemIDQuery, cnn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    SqlCommand command = new SqlCommand(itemIDQuery, cnn);
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
                System.Diagnostics.Debug.WriteLine("Error in ItemDetails function");
                System.Diagnostics.Debug.WriteLine("Error in SQL! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static bool AdPost(Item item)
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
                OpenConnection();
                command = new SqlCommand(insertPost, cnn);
                command.Parameters.AddWithValue("@account_id", accountId);
                command.Parameters.AddWithValue("@item_id", itemId);
                command.Parameters.AddWithValue("@post_title", itemName);
                command.Parameters.AddWithValue("@post_date", currDate);
                command.Parameters.AddWithValue("@post_expiry", expiryDate);
                int rowInserted = command.ExecuteNonQuery();
                if (rowInserted == 1)
                    validPost = true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in AdPost function");
                System.Diagnostics.Debug.WriteLine("Error in SQL!" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return validPost;
        }
    }
}
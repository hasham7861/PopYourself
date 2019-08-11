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
        static string accountId = (string)System.Web.HttpContext.Current.Session["account_id"];

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
            
            string insertItem = "insert into item values (@account_id,@item_name,@item_category,@item_price," +
                    "@item_city,@item_phone,@item_desc,@item_img)";
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

                if (rowsInserted == 1 && AdPost())
                    validItem = true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(accountId);
                System.Diagnostics.Debug.WriteLine("Error in SQL!" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return validItem;
        }

        public static void ItemDetails (out string itemId, out string itemName)
        {
            itemId = "";
            itemName = "";
            string itemIDQuery = $"select item_id, item_name from item where username = '{accountId}'"; 

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
                    System.Diagnostics.Debug.WriteLine("No matching account_id");
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in SQL! " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static bool AdPost()
        {
            bool validPost = false;
            string itemId;
            string itemName;
            var currDate = DateTime.Now;
            var expiryDate = currDate.AddDays(10);

            ItemDetails(out itemId, out itemName);

            string insertPost = "insert into ad_post (@account_id,@item_id,@post_title,@post_date,@post_expiry)";

            try
            {
                OpenConnection();
                command = new SqlCommand(insertPost, cnn);
                command.Parameters.AddWithValue("@account_id", accountId);
                command.Parameters.AddWithValue("@item_id", itemId);
                command.Parameters.AddWithValue("@post_title", itemName);
                command.Parameters.AddWithValue("@post_date", currDate);
                command.Parameters.AddWithValue("@post_expiry", expiryDate);
            }
            catch (SqlException ex)
            {
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
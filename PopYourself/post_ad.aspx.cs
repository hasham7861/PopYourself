//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: July 17, 2019
using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PopYourself
{
    public partial class post_ad : System.Web.UI.Page
    {
        private string connectionString = null;
        private SqlConnection connect;
        private SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void postAdbtn_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload1.HasFile)
            {
                try
                {
                    fileName = FileUpload1.FileName.ToLower();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\ad_image_uploads\\") + fileName);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            Item item = new Item()
            {
                Name = itemNameBox.Text,
                Category = categoryDlist.Text,
                Description = descBox.Text,
                Image = fileName,
                City = cityBox.Text,
                Phone = pNumBox.Text,
                Price = decimal.Parse(priceBox.Text)
            };

            if (Page.IsValid)
            {
                connect = new SqlConnection(connectionString);
                

                string accountIdStr = "";
                string accountIDQuery = $"select account_id from account where username = '{(string)Session["username"]}'"; // might not be required -- session created for account_id

                try
                {
                    connect.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(accountIDQuery, connect);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
                    {
                        SqlCommand command = new SqlCommand(accountIDQuery, connect);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            accountIdStr = reader["account_id"].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("No matching account_id");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL! " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }

                string insertItem = "insert into item values (@account_id,@item_name,@item_category,@item_price," +
                    "@item_city,@item_phone,@item_desc,@item_img)";
                try
                {
                    connect.Open();
                    command = new SqlCommand(insertItem, connect);
                    command.Parameters.AddWithValue("@account_id", accountIdStr);
                    command.Parameters.AddWithValue("@item_name", itemNameBox.Text);
                    command.Parameters.AddWithValue("@item_category", categoryDlist.Text);
                    command.Parameters.AddWithValue("@item_price", decimal.Parse(priceBox.Text));
                    command.Parameters.AddWithValue("@item_city", cityBox.Text);
                    command.Parameters.AddWithValue("@item_phone", pNumBox.Text);
                    command.Parameters.AddWithValue("@item_desc", descBox.Text);
                    command.Parameters.AddWithValue("@item_img", fileName);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$alert('New ad posted'); window.location = 'MyAds.aspx';", true);
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!" + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }

                string itemIdStr = "";
                string itemNameStr = "";
                string itemIDQuery = $"select item_id, item_name from item where username = '{accountIdStr}'"; // might not be required -- session created for account_id

                try
                {
                    connect.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(itemIDQuery, connect);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
                    {
                        SqlCommand command = new SqlCommand(itemIDQuery, connect);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            itemIdStr = reader["item_id"].ToString();
                            itemNameStr = reader["item_name"].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("No matching account_id");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL! " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }

                string insertPost = "insert into ad_post (@account_id,@item_id,@post_title,@post_date,@post_expiry)";

                var currDate = DateTime.Now;
                var expiryDate = currDate.AddDays(10);

                try
                {
                    connect.Open();
                    command = new SqlCommand(insertPost, connect);
                    command.Parameters.AddWithValue("@account_id", accountIdStr);
                    command.Parameters.AddWithValue("@item_id", itemIdStr);
                    command.Parameters.AddWithValue("@post_title", itemNameStr);
                    command.Parameters.AddWithValue("@post_date", currDate);
                    command.Parameters.AddWithValue("@post_expiry", expiryDate);
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!" + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }
            }
            else
            {
                Response.Write("An Error occured.");
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            // -- remove uploaded images if pressed cancel
            Response.Redirect("INSERT PAGE HERE");
        }

        protected void itemAdValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (itemNameBox.Text == "" || categoryDlist.SelectedIndex == 0 || double.Parse(priceBox.Text) < 0 || double.Parse(priceBox.Text) > 150000 || cityBox.Text == "" ||
                pNumBox.Text == "" || descBox.Text == "" || pNumBox.Text == @"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$")
            {
                itemAdValidator.ErrorMessage = "Please verify form with the following criteria: <br/>" +
                    " - Name of item must not be empty.<br/>" +
                    " - Must select a category for item.<br/>" +
                    " - Price must be between $0.00 and $15000.<br/>" +
                    " - Must provide the city location of the item.<br/>" +
                    " - Must provide contact information(valid) for buyer.<br/>" +
                    " - Must provide a brief description about the item.<br/>";
                args.IsValid = false;
            }

            string extension = System.IO.Path.GetExtension(FileUpload1.FileName.ToLower());

            if (extension == ".jpg" || extension == ".png" || extension == ".gif")
            {
                args.IsValid = true;
            }
            else if (extension == "^[a-zA-Z0-9_]+$")
            {
                statusLbl.Text = "Cannot upload file with filename that contains special characters";
                args.IsValid = false;
            }
            else
            {
                statusLbl.Text = "Incorrect file extension";
                args.IsValid = false;
            }
        }
    }
}
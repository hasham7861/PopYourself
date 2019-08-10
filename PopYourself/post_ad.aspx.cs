//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: July 17, 2019
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
            connectionString = "Data Source=DESKTOP-QQS5JKR\\SQLEXPRESSWEBAPP;" +
                               "" + "Initial Catalog=pop_cul_db;" +
                               "Integrated Security=SSPI;Persist Security Info=false";
            connect = new SqlConnection(connectionString);
        }

        protected void postAdbtn_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Page.IsValid)
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        fileName = FileUpload1.FileName.ToLower();

                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\ad_image_uploads\\") + fileName);
                        uploadedImg.ImageUrl = "/ad_image_uploads/" + fileName;

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }

                string insertData = "insert into item values (@item_name,@item_category,@item_price," +
                    "@item_city,@item_phone,@item_desc,@item_img)";
                try
                {
                    connect.Open();
                    command = new SqlCommand(insertData, connect);
                    command.Parameters.AddWithValue("@item_name", itemNameBox.Text);
                    command.Parameters.AddWithValue("@item_category", categoryDlist.Text);
                    command.Parameters.AddWithValue("@item_price", decimal.Parse(priceBox.Text));
                    command.Parameters.AddWithValue("@item_city", cityBox.Text);
                    command.Parameters.AddWithValue("@item_phone", pNumBox.Text);
                    command.Parameters.AddWithValue("@item_desc", descBox.Text);
                    command.Parameters.AddWithValue("@item_img", fileName);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$alert('New ad posted'); window.location = 'INSERT PAGE HERE';", true);
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!" + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                // -- validation error here
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
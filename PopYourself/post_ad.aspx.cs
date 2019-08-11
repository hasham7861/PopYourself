//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: August 10, 2019
using PopYourself.Handler;
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

            bool validItem = PostAdDBUtil.CreateItem(item);

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
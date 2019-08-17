using PopYourself.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PopYourself.DatabaseOperations;


namespace PopYourself
{
    public partial class post_ad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string) Session["account_id"] == "")
                Response.Redirect("Default.aspx");
        }

        protected void postAdbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
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

                bool validItem = PostAdDatabaseOperations.CreateItem(item);
                if (validItem)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('New ad posted!'); window.location = 'MyAds.aspx';", true);
                else
                    Response.Write($"Ooops, something went wrong! {(string)Session["account_id"]}");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "An Error Occured.", true);
            }

        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            // -- remove uploaded images if pressed cancel
            Response.Redirect("Browse.aspx");
        }

        protected void itemAdValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (itemNameBox.Text == "" || categoryDlist.SelectedIndex == 0 || decimal.Parse(priceBox.Text) < 0 || decimal.Parse(priceBox.Text) > 150000 || cityBox.Text == "" ||
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

            if (FileUpload1.HasFile)
            {
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
}
using PopYourself.Model;
using System;
using PopYourself.DatabaseOperations;

namespace PopYourself
{
    public partial class ItemPage : System.Web.UI.Page
    {
        //pass in the item information from the browse.aspx page
        //display the result to itempage
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if ((string)Session["account_id"] == "")
                Response.Redirect("Default.aspx");


            string id = (string)Request.Params.Get("id");
            Item item = BrowseDatabaseOperations.GetItem(id);

            if (id == "" || item == null)
                Response.Redirect("Browse.aspx");



            image.ImageUrl = "Content/images/ads/" + item.Image;

            name.Text = item.Name;
            
            btnContactSeller.HRef = "mailto:" + 
                                    ItemPageDatabaseOperations.GetAccountEmailOfPost((string)Session["account_id"]);
            price.Text = "$" + item.Price;
            desc.Text = item.Description;

            
           
        }
    }
}
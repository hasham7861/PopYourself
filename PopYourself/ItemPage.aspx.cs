using PopYourself.Handler;
using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Author: Robert Sarmiento
//ID: 991471234
namespace PopYourself
{
    public partial class ItemPage : System.Web.UI.Page
    {
        //pass in the item information from the browse.aspx page
        //display the result to itempage
        protected void Page_Load(object sender, EventArgs e)
        {   

            BrowsePageDBUtil db = new BrowsePageDBUtil();

            string id = (string)Request.Params.Get("id");
            Item item = db.GetItem(id);

            name.Text = item.Name;
            
            price.Text = "$"+item.Price;
            desc.Text = item.Description;
        }
    }
}
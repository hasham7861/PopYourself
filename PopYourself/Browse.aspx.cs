using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PopYourself.DatabaseOperations;

namespace PopYourself
{
    public partial class About : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if((string)Session["account_id"] == "")
                Response.Redirect("Default.aspx");
        }

        //Start searching the database when user clicks on the button
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblSearch.Text = "Searching for: " + txtItemSearch.Text;
            RetrieveSearchItem();
        }

        //retrieve the search results from the database
        public void RetrieveSearchItem()
        {
            if (lblSearch.Text != "") //when searchbox is not empty
            {

                List<Item> itemList = BrowseDatabaseOperations.GetAllItems(txtItemSearch.Text);

                if (BrowseDatabaseOperations.Message != "")
                {
                    lblSearch.Text = BrowseDatabaseOperations.Message;
                }
                else
                {
                    HtmlTableRow row = new HtmlTableRow();
                    

                    int length = itemList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        PopulateItemIntoView(i, itemList, row);
                    }
                    Table1.Controls.Add(row);
                }
            }
        }

        
        public void PopulateItemIntoView(int i, List<Item> itemList, HtmlTableRow row)
        {

            HtmlTableCell cell = new HtmlTableCell();
            string itemId = itemList[i].ToString();
            ImageButton image = new ImageButton
            {
                ID = $"item{i}",
                ImageUrl = File.Exists(itemList[i].Image) ? itemList[i].Image : "Content/images/defaultPostImage.png",
                Height = 150,
                Width = 130,
                CssClass = "imageStyle"
            };
            image.PostBackUrl = $"ItemPage.aspx/?id={itemId}";
            cell.Controls.Add(image);

 
            LinkButton hp = new LinkButton
            {
                Text = itemList[i].Name,

            };
            hp.PostBackUrl = $"ItemPage.aspx/?id={itemId}";
            cell.Controls.Add(hp);

            row.Controls.Add(cell);
        }

        
    }
}
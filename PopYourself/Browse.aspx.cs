using PopYourself.Handler;
using PopYourself.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

//Author: Robert Sarmiento
//ID: 991471234
namespace PopYourself
{
    public partial class About : Page
    {
        ContentPlaceHolder cphItemContent;
        BrowsePageDBUtil browsePageDBUtil = new BrowsePageDBUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            //initialize the placeholder to be invisible on page load
            cphItemContent = (ContentPlaceHolder)this.Page.Master.FindControl("SearchContent");
            cphItemContent.Visible = false;
        }

        //Start searching the database when user clicks on the button
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchKeyword(); 
            RetrieveSearchItem();
        }

        //display the search keyword
        public void SearchKeyword()
        {
            lblSearch.Text = "Searching for: " + txtItemSearch.Text;
        }

        //retrieve the search results from the database
        public void RetrieveSearchItem()
        {
            string htmlString = "<br>";

            if (lblSearch.Text != "") //when searchbox is not empty
            {
                if (!cphItemContent.Visible) //show contentplaceholder when not visible
                    cphItemContent.Visible = true;

                browsePageDBUtil.GetDBItem(txtItemSearch.Text);

                if (browsePageDBUtil.Message != "")
                {
                    lblSearch.Text = browsePageDBUtil.Message;
                }
                else
                {
                    HtmlTableRow row = new HtmlTableRow();
                    

                    int length = browsePageDBUtil.GetItemList.Count;
                    for (int i = 1; i <= length; i++)
                    {
                        string itemID = browsePageDBUtil.GetItemList.ElementAt(i - 1).Id;
                        CreateItemHolder(i, itemID, row);
                    }
                    Table1.Controls.Add(row);
                }
            }
        }

        //Create images dynamically
        public void CreateItemHolder(int i, string Id, HtmlTableRow row)
        {
            HtmlTableCell cell = new HtmlTableCell();
            ImageButton image = new ImageButton
            {
                ID = $"image{i}",
                ImageUrl = browsePageDBUtil.GetItemList.ElementAt(i - 1).Image,
                Height = 150,
                Width = 130,
                CssClass = "imageStyle"
            };
            image.PostBackUrl = $"ItemPage.aspx/?id={Id}";
            cell.Controls.Add(image);

            Item item = browsePageDBUtil.GetItem(Id);
            LinkButton hp = new LinkButton
            {
                Text = item.Name,

            };
            hp.PostBackUrl = $"ItemPage.aspx/?id={Id}";
            cell.Controls.Add(hp);

            row.Controls.Add(cell);
        }

        //Redirect to another page
        public void NewPage(string id)
        {
            Response.Redirect($"ItemPage.aspx/?id={id}");
        }
    }
}
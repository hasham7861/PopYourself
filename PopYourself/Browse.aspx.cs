using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PopYourself
{
    public partial class About : Page
    {
        ContentPlaceHolder cphItemContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            cphItemContent = (ContentPlaceHolder)this.Page.Master.FindControl("ItemContent");
            cphItemContent.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSuggest();
            RetrieveSearchItem();
        }

        public void SearchSuggest()
        {
            lblSearch.Text = txtItemSearch.Text;
        }

        public void RetrieveSearchItem()
        {
            if (item1.ImageUrl == "" || item2.ImageUrl == "" || item3.ImageUrl == "" || item4.ImageUrl == "" || item5.ImageUrl == "" || item6.ImageUrl == "")
            {
                lblSearch.Text = "No Matching Items!";
                return;
            }
            else
            {
                if (!cphItemContent.Visible)
                    cphItemContent.Visible = true;
            }
        }
    }
}
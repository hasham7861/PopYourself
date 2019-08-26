using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Web.UI;
using PopYourself.DatabaseOperations;

namespace PopYourself
{
    public partial class Contact : Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string) Session["account_id"] == "")
                Response.Redirect("Default.aspx");

            string accountId = (string) Session["account_id"];
            lbl_username.Text = MyAdsDatabaseOperations.GetAccountNameOfPosts(accountId) + " Ads";
            SqlDataAdapter sda = MyAdsDatabaseOperations.GetMyAds(accountId);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            userAdGrid.DataSource = dtbl;
            DataBind();
        }

        protected void postNewAd_Click(object sender, EventArgs e)
        {
            Response.Redirect("post_ad.aspx");
        }

        protected void userAdGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
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

            SqlDataAdapter sda = MyAdsDatabaseOperations.GetMyAds((string) Session["account_id"]);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            userAdGrid.DataSource = dtbl;
            DataBind();
        }

        protected void postNewAd_Click(object sender, EventArgs e)
        {
            Response.Redirect("post_ad.aspx");
        }
    }
}
//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: August 10, 2019
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
    public partial class Contact : Page
    {
        private string connectionString = null;
        private SqlConnection connect;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=DESKTOP-QQS5JKR\\SQLEXPRESSWEBAPP;" +
                               "" + "Initial Catalog=pop_cul_db;" +
                               "Integrated Security=SSPI;Persist Security Info=false";
            connect = new SqlConnection(connectionString);
            string query = $"SELECT * FROM ad_post WHERE account_id = (select account_id from account where username = '{(string)Session["username"]}')";
            SqlDataAdapter sda = new SqlDataAdapter(query, connect);
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
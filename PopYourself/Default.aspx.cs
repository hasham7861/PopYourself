using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hasham_991498453_Assignment_3;

namespace PopYourself
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (loginEmail.Text == "" || loginPassword.Text == "") return;


            String accountId = AccountDatabaseUtil.ValidateLogin(loginEmail.Text,loginPassword.Text);

            if (accountId != "")
            {
                Session["account_id"] = accountId;
                Response.Redirect("Browse.aspx");
            }
            else
            {
                lbl_error.Text = "Invalid login! Please Try Again!";
            }
        }

      
    }
}
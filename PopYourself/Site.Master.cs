using System;
using System.Web.UI;

namespace PopYourself
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void SignOut()
        {
            Session.Remove("account_id");
        }
    }
}
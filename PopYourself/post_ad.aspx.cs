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
    public partial class post_ad : System.Web.UI.Page
    {
        private string connectionString = null;
        private SqlConnection connect;
        private SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=DESKTOP-QQS5JKR\\SQLEXPRESSWEBAPP;" +
                               "" + "Initial Catalog=pop_cul_db;" +
                               "Integrated Security=SSPI;Persist Security Info=false";
            connect = new SqlConnection(connectionString);
            FileUpload1.Attributes["style"] = "display:none";
        }

        protected void postAdbtn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {

            string insertData = "insert into item values (@item_name,@item_category,@item_price," +
                "@item_city,@item_phone,@item_desc";
            try
            {
                connect.Open();
                command = new SqlCommand(insertData, connect);
                command.Parameters.AddWithValue("@item_name", itemNameBox.Text);
                command.Parameters.AddWithValue("@item_category", categoryDlist.Text);
                command.Parameters.AddWithValue("@item_price", priceBox.Text);
                command.Parameters.AddWithValue("@item_city", cityBox.Text);
                command.Parameters.AddWithValue("@item_phone", pNumBox.Text);
                command.Parameters.AddWithValue("@item_desc", descBox.Text);
                command.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$alert('New ad posted'); window.location = 'INSERT PAGE HERE';", true);
            }
            catch (SqlException ex)
            {
                Response.Write("Error in SQL!" + ex.Message);
            }
            finally
            {
                if(connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            } else
            {
                // -- validation error here
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("INSERT PAGE HERE");
        }

        protected void uploadImgBtn_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                try
                {
                    string address = Server.MapPath("~/") + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(address);
                    // -- implementation here
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}
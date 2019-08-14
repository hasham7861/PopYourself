using PopYourself.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
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
            cphItemContent = (ContentPlaceHolder)this.Page.Master.FindControl("SearchContent");
            cphItemContent.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchKeyword();
            RetrieveSearchItem();
        }

        public void SearchKeyword()
        {
            lblSearch.Text = txtItemSearch.Text;
        }

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
                    int length = browsePageDBUtil.GetItemList.Count;
                    for (int i = 1; i <= length; i++)
                    {
                        CreateImageHolder(i);

                        if ((i == 1 && length == 1) || (i % 3 != 0 && length == i))
                        {
                            ReturnCarriage();
                            CreateItemLabel(i - 1);
                        }

                        if (i % 3 == 0)
                        {
                            //insert a br after every 3 images.
                            ReturnCarriage();

                            //inside inner loop, create label for each image
                            for (int j = i - 3; j < i; j++)
                            {
                                CreateItemLabel(j);
                            }
                            ReturnCarriage();
                        }
                    }
                }
            }
        }

        public void ReturnCarriage()
        {
            string htmlString = "<br>";
            imageContainer.Controls.Add(new LiteralControl(htmlString));
        }

        public void CreateItemLabel(int j)
        {
            imageContainer.Controls.Add(new Label
            {
                ID = $"lblItem{j}",
                Text = browsePageDBUtil.GetItemList.ElementAt(j).Name,
                CssClass = "imageLabelStyle"
            });
        }

        public void CreateImageHolder(int i)
        {
            ImageButton image = new ImageButton
            {
                ID = $"image{i}",
                ImageUrl = browsePageDBUtil.GetItemList.ElementAt(i - 1).Image,
                Height = 150,
                Width = 130,
                CssClass = "imageStyle"
            };
            image.Click += new ImageClickEventHandler(ImageButton_OnClick);
            
            imageContainer.Controls.Add(image);


            //imageContainer.Controls.Add(image = new ImageButton
            //{

            //});
            //image.Command += new CommandEventHandler(ImageButton_OnCommand);
            //ImageButton fuck = (ImageButton)FindControl($"image{i}");
            //fuck.Click += new ImageClickEventHandler(ImageButton_OnCommand);
            //image.Click += new ImageClickEventHandler(Unnamed1_Click);
        }

        protected void ImageButton_OnClick(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hello');", true);
        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hello');", true);
        }
    }
}
﻿using System;
using PopYourself.DatabaseOperations;
using PopYourself.Model;

namespace PopYourself
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            bool accountExist = AccountDatabaseUtil.AccountExist(txt_email.Text);
            if (accountExist)
            {
                lbl_message.Text = "Email already Exists!";
                return;
            }
            
            Account account = new Account()
            {
                Email = txt_email.Text,
                UserName = txt_username.Text,
                Password = txt_password.Text,
                FirstName = txt_firstname.Text,
                LastName = txt_lastname.Text,
                City = txt_city.Text,
                Province = ProvinceList.Text,
                PostalCode = txt_postalcode.Text,
                Phone = txt_phone.Text,
            };

            
            bool validRegister = AccountDatabaseUtil.RegisterCustomer(account);
            if (!validRegister)
            {
                lbl_message.Text = "Unable to add the user!";
                return;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void txt_postalcode_TextChanged(object sender, EventArgs e)
        {
            txt_postalcode.Text = txt_postalcode.Text.ToUpper();
        }
    }
}
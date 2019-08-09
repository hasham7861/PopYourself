<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PopYourself.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>Pop Yourself</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/Default.css" />
</head>
<body>
   
<form runat="server">
        <div style="width: 500px; margin-top: 100px; padding: 20px;" class="container">
            <header style="text-align: center;">
                <h1 style="font-size: 70px;">PØP YØURSELF</h1>
            </header>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label style="color: red; font-size: 20px;" ID="lbl_error" runat="server"></asp:Label><br />
            <div style="margin-top: 30px; padding: 20px 30px; border-radius: 10px; background-color: #F9F9F9;" class="form-group" >
               
                <label for="loginEmail">Email&nbsp;

                    </label>
&nbsp;<asp:TextBox type="email" runat="server" class="form-control" id="loginEmail"  aria-describedby="emailHelp" placeholder="Enter email"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="loginEmail" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter email!</asp:RequiredFieldValidator>
                <br/>
                <label for="loginPassword">Password</label>
                <asp:TextBox type="password"  runat="server" class="form-control" id="loginPassword" placeholder="Enter password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="loginPassword" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter Password!</asp:RequiredFieldValidator>
                <br/>
                <div style="text-align: center;">
                    <asp:Button style="background-color: #6A84FF; color: white; padding: 5px 50px;" ID="btn_login" class="btn" runat="server" Text="Login" OnClick="btn_login_Click" />
                    <br />
                    <br />
                    
                    <a href="Register.aspx" >Sign Up?</a>
                </div>
            </div>
        </div>
    </form>
<div id="backdrop"></div>
<div id="backdrop2"></div>
</body>
</html>

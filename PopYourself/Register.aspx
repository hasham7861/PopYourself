<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PopYourself.Register" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>Pop Yourself</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/Default.css" />
</head>
<body>
   
<form runat="server">
        <div style="width: 700px; margin-top:80px; padding: 20px;" class="container">
            <header style="text-align: center;">
                <h1 style="font-size: 70px;">Register</h1>
            </header>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label style="color: red; font-size: 30px;" ID="lbl_message" runat="server" Text=""></asp:Label>
            <div style="margin-top: 30px; padding: 20px 30px; border-radius: 10px; background-color: #F9F9F9;" class="form-group" >
                
                <label for="lbl_email">Email</label>
                <asp:TextBox type="email" runat="server" class="form-control" id="txt_email"  aria-describedby="emailHelp" placeholder="Enter email"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_email" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter email!</asp:RequiredFieldValidator>
                <br/>

                <label for="lbl_username">Username</label>
                <asp:TextBox runat="server" class="form-control" id="txt_username" placeholder="Enter username"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_username" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter username!</asp:RequiredFieldValidator>
                <br/>
                
                <label for="lbl_password">Password</label>
                <asp:TextBox runat="server" class="form-control" id="txt_password" placeholder="Enter password"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_password" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter password!</asp:RequiredFieldValidator>
                <br/>
                
                <div class="form-row">
                    <div style="padding-left:0" class="form-group col-md-6">
                <label for="lbl_firstname">First Name</label>
                <asp:TextBox runat="server" class="form-control" id="txt_firstname" placeholder="Enter First Name"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_firstname" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter first name!</asp:RequiredFieldValidator>
                <br/></div>
                    <div   style="padding-left: 0; padding-right: 0;"class="form-group col-md-6">
                <label for="lbl_lastname">Last Name</label>
                <asp:TextBox runat="server" class="form-control" id="txt_lastname"  placeholder="Enter Last Nname"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_lastname" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter last Name!</asp:RequiredFieldValidator>
                <br/>
                </div>
                    </div>
                
                <div class="form-row">
                    <div style="padding-left:0" class="form-group col-md-4">
                        <label for="lbl_city">City</label>
                        <asp:TextBox runat="server" class="form-control" id="txt_city" placeholder="Enter city"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_city" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter city!</asp:RequiredFieldValidator>
                        <br/>
                        </div>
                    <div style="padding-left:0" class="form-group col-md-4">
                        <label for="lbl_province">Province</label><asp:DropDownList  class="form-control" ID="ProvinceList" runat="server">
                            <asp:ListItem Selected="True" Value="NL">NL</asp:ListItem>
                            <asp:ListItem Value="PE">PE</asp:ListItem>
                            <asp:ListItem Value="NS">NS</asp:ListItem>
                            <asp:ListItem Value="NB">ON</asp:ListItem>
                            <asp:ListItem Value="QC">QC</asp:ListItem>
                            <asp:ListItem Value="ON">MB</asp:ListItem>
                            <asp:ListItem Value="SK">SK</asp:ListItem>
                            <asp:ListItem Value="AB">AB</asp:ListItem>
                        </asp:DropDownList>
                    <%--<asp:TextBox runat="server" class="form-control" id="txt_province" placeholder="Enter in province"> </asp:TextBox>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_province" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter province!</asp:RequiredFieldValidator>--%>
                    <%--<br/>--%>

                    </div>
                    <div style="padding-left: 0; padding-right:0" class="form-group col-md-4">
                        <label for="lbl_postalcode">Postal Code</label>
                        <asp:TextBox runat="server" class="form-control" id="txt_postalcode"  placeholder="Enter postalcode"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_postalcode" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter postalcode!</asp:RequiredFieldValidator>
                    </div>
                    </div>
                    

                <div class="form-row">
                    <label for="lbl_phone">Phone</label>
                        <asp:TextBox runat="server" class="form-control" id="txt_phone"  placeholder="Enter phone"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_phone" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Enter phone!</asp:RequiredFieldValidator>
                        <br/></div>

                <div class="form-row">
                    <div style="text-align: center;">
                        <asp:Button style="background-color: #6A84FF; color: white; padding: 5px 50px;" ID="btn_register" class="btn" runat="server" Text="Register" OnClick="btn_register_Click" />
                        <br />
                        <br />
                        <a href="Default.aspx" >Already have an account?</a>
                    </div>
                    
                </div>
                
            </div>
        </div>
    </form>
<div id="backdrop"></div>
<div id="backdrop2"></div>
</body>
</html>

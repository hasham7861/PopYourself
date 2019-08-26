<%@ Page Title="ItemPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="PopYourself.ItemPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/item.page.css" rel="stylesheet" type="text/css" />
    <div class="container" runat="server" style="margin-top:30px;">
        <div id="itemInfo">
            <asp:Label ForeColor="#6A84FF" ID="name" Text="" runat="server" />
            <asp:Label ID="price" Text="" runat="server" Style="color: green;" /><br />
        </div>
        <div class="itemContainer" runat="server">
            <div id="imageArea">
                <asp:Image ID="image" ImageUrl="Content/images/defaultPostImage.png" runat="server" />
            </div>
            <div id="descInfo">
                <asp:Label ID="desc" Text="" runat="server" /><br />
            </div>

        </div>
        <div id="contactInfo">
            <a runat="server" href="mailto:test@gmail.com" id="btnContactSeller" style="background-color: #6A84FF; color: white;">Email Seller</a>
        </div>
    </div>
</asp:Content>

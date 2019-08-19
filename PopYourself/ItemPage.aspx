<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="PopYourself.ItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="Content/browse.page.css" rel="stylesheet" type="text/css" />   
    <div class="container" runat="server" style="text-align:center; margin-top:30px;">
        <div class="row">
            <div id="image" class="col">
                <asp:Image ID="image" ImageUrl="Content/images/defaultPostImage.png" Height="150px" Width="130px" runat="server" />
            </div>

            <div id="itemInfo" class="col" style="background-color:#F9F9F9; margin-top:20px;padding:20px; display:inline-block; border-radius:10px;">
                <asp:Label ID="name" Text="" runat="server" /><br />
                <asp:Label ID="price" Text="" runat="server" style="color:green;"/><br />
                <asp:Label ID="desc" Text="" runat="server" /><br />
            </div>
        </div>
        <div class="row">
            <div id="contactSeller" class="col" runat="server">
                <a  runat="server" href="mailto:test@gmail.com" ID="btnContactSeller" Style="background-color: #6A84FF; color: white; padding:10px;">Contact Seller</a>
            </div>
        </div>
    </div>
</asp:Content>

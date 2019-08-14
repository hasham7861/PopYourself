<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="PopYourself.ItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" runat="server">
        <div class="row">
            <div id="image" class="col">
                <asp:Image ImageUrl="ad_image_uploads/csharpbois.png" Height="150px" Width="130px" runat="server" />
            </div>

            <div id="itemInfo" class="col">
                <textarea id="txtArea" runat="server" style="background-color: #9DAEFF; color:white; padding: 5px 50px;">Hello from textarea</textarea>
            </div>
        </div>
        <div class="row">
            <div id="contactSeller" class="col" runat="server">
                <asp:Button ID="btnContactSeller" runat="server" Text="Contact Seller" Style="background-color: #6A84FF; color: white;" />
            </div>
        </div>
    </div>
</asp:Content>

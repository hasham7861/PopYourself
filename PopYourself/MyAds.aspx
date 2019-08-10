<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAds.aspx.cs" Inherits="PopYourself.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="grid-page-header">
      <h1>Username Ads</h1>
  </div>
    <div class="grid-view-div">
        <asp:GridView ID="userAdGrid" runat="server">

        </asp:GridView>
    </div>
</asp:Content>

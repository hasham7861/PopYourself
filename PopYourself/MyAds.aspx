<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAds.aspx.cs" Inherits="PopYourself.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/myads.page.css" rel="stylesheet" />
    
      <h1><asp:Label runat="server" ID="lbl_username"></asp:Label></h1>
   
    <div>
        <asp:Button style="background-color: #6A84FF; color: white; padding: 5px 50px" ID="postNewAd" runat="server" Text="Post New Ad" OnClick="postNewAd_Click" class="btn"/>
    </div>
    <br />
    <div>
        <asp:GridView ID="userAdGrid" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="userAdGrid_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="post_title" HeaderText="Title" />
                <asp:BoundField DataField="post_date" HeaderText="Date Posted" Readonly="true"/>
                <asp:BoundField DataField="post_expiry" HeaderText="Expiry Date" Readonly="true"/>
               
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

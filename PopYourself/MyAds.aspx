<%--
AUTHOR: Cyrus Alatraca
ID: 991146084
DATE: August 10, 2019
--%>
<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAds.aspx.cs" Inherits="PopYourself.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid-page-header">
      <h1>Username Ads</h1>
  </div>
    <div class="post-button-div">
        <asp:Button ID="postNewAd" runat="server" Text="Post New Ad" OnClick="postNewAd_Click" />
    </div>
    <br />
    <div class="grid-view-div">
        <asp:GridView ID="userAdGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnAdPostId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ad_id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="post_title" HeaderText="Title" />
                <asp:BoundField DataField="post_date" HeaderText="Date Posted" Readonly="true"/>
                <asp:BoundField DataField="post_expiry" HeaderText="Expiry Date" Readonly="true"/>
                <asp:CommandField ShowEditButton="true"/>
                <asp:CommandField ShowDeleteButton="true"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

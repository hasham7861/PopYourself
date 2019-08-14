<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="PopYourself.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
        <strong>
            <asp:Label Text="Send Email" runat="server" Style="color: #6A84FF;" /><br />
        </strong>
        <asp:TextBox runat="server" placeholder="your name" Style="background-color: #9DAEFF; padding: 5px 50px;" ForeColor="White" /><br />
        <asp:TextBox runat="server" placeholder="poster's name" Style="background-color: #9DAEFF; padding: 5px 50px;" ForeColor="White" /><br />
        <textarea id="txtInquiry" placeholder="Write something..." style="background-color: #9DAEFF; color:white;" ></textarea>
    </div>
</asp:Content>

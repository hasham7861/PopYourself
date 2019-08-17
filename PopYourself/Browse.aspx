<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="PopYourself.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/robertStyleSheet.css" rel="stylesheet" type="text/css" />
    <br />
    <br />
    <div style="text-align: center">

        <asp:TextBox ID="txtItemSearch" runat="server" class="form-control" Style="display: inline;" placeholder="Search for a pop culture item" Width="217px" Height="22px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button Style="background-color: #6A84FF; color: white; padding: 5px 50px;" ID="btnSearch" class="btn" runat="server" Text="Search" OnClick="btnSearch_Click" Height="32px" Width="164px" />

        <br />
        <br />
        <asp:Label ID="lblSearch" runat="server"></asp:Label>
        <br />

        <br />

        &nbsp;&nbsp;&nbsp;

    <br />
        <asp:RequiredFieldValidator ID="searchRequired" runat="server" ControlToValidate="txtItemSearch" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Search must not be blank</asp:RequiredFieldValidator>
    </div>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="server">
    <br />
    <table id="Table1" runat="server"></table>
</asp:Content>

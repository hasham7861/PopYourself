<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="PopYourself.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/browse.page.css" rel="stylesheet" type="text/css" />
    
    <div style="display: flex; text-align: center; flex-direction: column; margin-top: 50px;">
        <header style="text-align: center; color:#6a84ff">
            <h2 style="font-size: 40px;">BRØWSE PØP ITEMS</h2>
        </header>
        <br/>
        <div id="search" style="display: flex; justify-content: center;">
            <fieldset style="display: block;">
            <asp:TextBox ID="txtItemSearch" runat="server" class="form-control" Style="display: inline; width: 500px;" placeholder="Search for a pop culture item" ></asp:TextBox>
                <asp:Button Style="background-color: #6A84FF; color: white;" ID="btnSearch" class="btn" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </fieldset><br/>
        </div>
        <asp:Label display="block" ID="lblSearch" runat="server"></asp:Label>
        <br />
     <asp:RequiredFieldValidator ID="searchRequired" runat="server" ControlToValidate="txtItemSearch" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Search must not be blank</asp:RequiredFieldValidator>
    
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="server">
    <br />
    <table id="Table1" runat="server"></table>
</asp:Content>

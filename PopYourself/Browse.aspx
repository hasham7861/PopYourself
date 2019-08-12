<%-- 
    Author: Robert Sarmiento
    ID: 991471234
--%>

<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="PopYourself.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="SearchContent" runat="server">
    <br />
    <br />
    <div style="text-align:center">

        <asp:TextBox ID="txtItemSearch" runat="server" class="form-control" Style="display: inline;" placeholder="Search for a pop culture item" Width="217px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddFilter" runat="server" Height="33px">
        <asp:ListItem>Filter</asp:ListItem>
        <asp:ListItem Value="By Item Name"></asp:ListItem>
        <asp:ListItem Value="By Item Name">By Category</asp:ListItem>
        <asp:ListItem Value="By Item Name">By Price</asp:ListItem>
    </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSuggest" runat="server" Text="Searching for: "></asp:Label>
        <asp:Label ID="lblSearch" runat="server"></asp:Label>
        <br />

        <br />
        <asp:Button Style="background-color: #6A84FF; color: white; padding: 5px 50px;" ID="btnSearch" class="btn" runat="server" Text="Search" OnClick="btnSearch_Click" />

        &nbsp;&nbsp;&nbsp;

    <br />
        <asp:RequiredFieldValidator ID="searchRequired" runat="server" ControlToValidate="txtItemSearch" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Search must not be blank</asp:RequiredFieldValidator>
    </div>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ItemContent" runat="server">
    <br />
    <br />
    <div style="text-align:center" class="style">
        <table align="center">
            <tr>
                <td><asp:Image ID="item1" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
                <td><asp:Image ID="item2" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
                <td><asp:Image ID="item3" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
            </tr>
            <tr>
                <td><asp:Image ID="item4" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
                <td><asp:Image ID="item5" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
                <td><asp:Image ID="item6" runat="server" class="imageStyle" Width="130px" Height="150px"/></td>
            </tr>
        </table>
    </div>
</asp:Content>

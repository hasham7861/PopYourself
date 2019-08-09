<%-- 
    Author: Robert Sarmiento
    ID: 991471234
--%>

<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="PopYourself.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <input type="text" id="txtSearch" name="txtSearch" alt="Search Criteria"
        önkeyup="searchSuggest(event);" autocomplete="off" style="width: 544px" />

    <br />

    <div id="search_suggest"></div>

    <input type="submit" id="cmdSearch" name="cmdSearch"
        value="Search" alt="Run Search" />
</asp:Content>

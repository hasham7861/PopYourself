<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="post_ad.aspx.cs" Inherits="PopYourself.post_ad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html>
    <head>
        <link href="Content/cyrusStyleSheet.css" rel="stylesheet" />
    </head>
    <body>
        <div class="main-grid">
            <div class="img-grid1">
                <div class="img-container"></div>
                <div class="img-btn">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="uploadImgBtn" runat="server" Text="Upload image" OnClientClick="return showBrowseDialog();" OnClick="uploadImgBtn_Click"/>

<script type="text/javascript" language="javascript">
    function showBrowseDialog() 
    {
        document.getElementById('<%=FileUpload1.ClientID%>').click();    
    }
    </script>
            </div>
            </div>
            
            <div class="form-grid2 form-group">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="itemName" runat="server" Text="Name: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="itemNameBox" runat="server" CssClass="controlBox" Height="35px" style="margin-bottom: 19" width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="categoryLbl" runat="server" Text="Category: "></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="categoryDlist" runat="server" CssClass="controlBox dropControlBox" height="35px" width="200px">
                                <asp:ListItem>Toys</asp:ListItem>
                                <asp:ListItem>Comics/Magazines</asp:ListItem>
                                <asp:ListItem>Video Games</asp:ListItem>
                                <asp:ListItem>Memorabilia</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="priceLbl" runat="server" Text="Price: "></asp:Label></td>
                        <td>
                            <asp:TextBox ID="priceBox" runat="server" CssClass="controlBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="cityLbl" runat="server" Text="City: "></asp:Label></td>
                        <td>
                            <asp:TextBox ID="cityBox" runat="server" CssClass="controlBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="pNumLbl" runat="server" Text="Phone: "></asp:Label></td>
                        <td>
                            <asp:TextBox ID="pNumBox" runat="server" CssClass="controlBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="descLbl" runat="server" Text="Description"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="descBox" runat="server" CssClass="controlBox"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="btn-div">
                <asp:Button ID="postAdbtn" runat="server" Text="Post Ad" OnClick="postAdbtn_Click" />
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
            </div>
    </body>
    </html>
</asp:Content>

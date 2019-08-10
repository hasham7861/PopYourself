<%--
AUTHOR: Cyrus Alatraca
ID: 991146084
DATE: July 11, 2019
--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="post_ad.aspx.cs" Inherits="PopYourself.post_ad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=uploadedImg.ClientID%>').css('visibility', 'visible');
                    $('#<%=uploadedImg.ClientID%>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        </script>
    <div class="error-div">
        <asp:CustomValidator ID="itemAdValidator" runat="server" ErrorMessage="" OnServerValidate="itemAdValidator_ServerValidate"></asp:CustomValidator>
    </div>
    <div class="main-grid">
        <div class="img-grid1">
            <div class="img-container">
                <asp:Image ID="uploadedImg" runat="server" Height="200px" Width="200px" Style="border-radius: 15px;" />
            </div>
            <div class="img-btn">
                <asp:FileUpload ID="FileUpload1" runat="server" onchange="showpreview(this);" />
                <br />
                <asp:Label ID="statusLbl" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-grid2 form-group">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="itemName" runat="server" Text="Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="itemNameBox" runat="server" CssClass="controlBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="categoryLbl" runat="server" Text="Category: "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="categoryDlist" runat="server" CssClass="controlBox">
                            <asp:ListItem>Select Category</asp:ListItem>
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
                        <asp:TextBox ID="descBox" runat="server" TextMode="MultiLine" Rows="5" Width="300px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="btn-div">
        <asp:Button ID="postAdbtn" runat="server" Text="Post Ad" OnClick="postAdbtn_Click" />
        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
    </div>
</asp:Content>

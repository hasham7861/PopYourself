<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="post_ad.aspx.cs" Inherits="PopYourself.post_ad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/postad.page.css" rel="stylesheet" />
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
    <div class="post-ad-header">
        <h1>Post New Ad</h1>
    </div>
    <div class="error-div">
        <asp:CustomValidator ID="itemAdValidator" runat="server" ErrorMessage="" OnServerValidate="itemAdValidator_ServerValidate"></asp:CustomValidator>
    </div>

            <div class="img-container">
                <asp:Image ID="uploadedImg" runat="server" Height="200px" Width="200px" Style="border-radius: 15px;" />
            </div>
            <div class="img-btn">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:FileUpload ID="fileupload" runat="server" onchange="showpreview(this);" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="postAdbtn" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
                <asp:Label ID="statusLbl" runat="server" Text=""></asp:Label>
            </div>
    <div style="width: 300px;" class="form-group">
        <asp:Label ID="itemName" runat="server" Text="Name: "></asp:Label>

                <asp:TextBox class="form-control" ID="itemNameBox" runat="server" ></asp:TextBox>

                <asp:Label ID="categoryLbl" runat="server" Text="Category: "></asp:Label>
            
                <asp:DropDownList class="form-control" ID="categoryDlist" runat="server" >
                    <asp:ListItem>Select Category</asp:ListItem>
                    <asp:ListItem>Toys</asp:ListItem>
                    <asp:ListItem>Comics/Magazines</asp:ListItem>
                    <asp:ListItem>Video Games</asp:ListItem>
                    <asp:ListItem>Memorabilia</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="priceLbl" runat="server" Text="Price: "></asp:Label>
                <asp:TextBox class="form-control" ID="priceBox" runat="server" ></asp:TextBox>
       
                <asp:Label ID="cityLbl" runat="server" Text="City: "></asp:Label>
          
                <asp:TextBox class="form-control" ID="cityBox" runat="server" ></asp:TextBox>
      
                <asp:Label ID="pNumLbl" runat="server" Text="Phone: "></asp:Label>
          
                <asp:TextBox class="form-control" ID="pNumBox" runat="server" ></asp:TextBox>
        
                <asp:Label ID="descLbl" runat="server" Text="Description"></asp:Label>

                <asp:TextBox class="form-control" ID="descBox" runat="server" TextMode="MultiLine" Rows="5" Width="300px"></asp:TextBox>
      
        </div>
  
    <br />
    <div>
        <asp:Button style="background-color: #6A84FF; color: white; padding: 5px 50px" class="btn" ID="postAdbtn" runat="server" Text="Post Ad" OnClick="postAdbtn_Click" />
        <asp:Button style="background-color: #6A84FF; color: white; padding: 5px 50px" class="btn" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
    </div>
</asp:Content>

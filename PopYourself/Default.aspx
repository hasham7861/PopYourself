<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PopYourself.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>Pop Yourself</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/Default.css" />
</head>
<body>
   
<form runat="server">
        <div style="width: 500px; margin-top: 100px; padding: 20px;" class="container">
            <header style="text-align: center;">
                <h1 style="font-size: 70px;">PØP YØURSELF</h1>
            </header>
            <div style="margin-top: 30px; padding: 20px 30px; border-radius: 10px; background-color: #F9F9F9;" class="form-group" >
                <label for="loginEmail">Email</label>
                <input type="email" class="form-control" id="loginEmail"  aria-describedby="emailHelp" placeholder="Enter email"><br/>
                <label for="loginPassword">Password</label>
                <input type="password" class="form-control" id="loginPassword" placeholder="Enter password">
                <br/>
                <div style="text-align: center;">
                    
                    <button style="background-color: #6A84FF; color: white; padding: 5px 50px;"type="submit" class="btn">Login</button>
                    <br />
                    <br />
                    <a href="#" >Sign Up?</a>
                    
                </div>
                </div>
        </div>
    </form>
<div id="backdrop"></div>
<div id="backdrop2"></div>
</body>
</html>

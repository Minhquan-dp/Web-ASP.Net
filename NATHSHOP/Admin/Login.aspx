<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NATHSHOP.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>AdminCP Login</title>
    <link rel="stylesheet" type="text/css" href="Styles/login.css" media="screen" />
</head>
<body>
     <div class="wrap">
        <div id="content">
            <div id="main">
                <div class="full_w">
                    <form id="form2" runat="server">

                        <label for="login">Email:</label>
                        <asp:TextBox ID="txtEmail" class="text" runat="server" Font-Size="Small"
                            Height="20px"></asp:TextBox>
                        <label for="pass">Password:</label>
                        <asp:TextBox ID="txtPass" class="text" runat="server" Font-Size="Small"
                            Height="20px" TextMode="Password"></asp:TextBox><a href="Login.aspx">Login.aspx</a>

                        <asp:Label ID="lblMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <div class="sep"></div>

                        <asp:Button ID="btnOK" class="ok" runat="server" Text="Login" Height="29px"
                            OnClick="btnOK_Click" Width="80px" Font-Bold="True" />
                        <a class="button" href="#">Forgotten password?</a>
                    </form>
                </div>
                <div class="footer">&raquo; <a href="#">Nhóm 30 STORE</a> | Admin Nhóm 30</div>
            </div>
        </div>
    </div>
</body>
</html>

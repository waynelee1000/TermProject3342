<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsfeed.aspx.cs" Inherits="TermProject.Main_Pages.newsfeed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
        <a href="newsfeed.aspx">
            <img src="../Images/fb-white-logo.png" class="logo"/>
        </a>
        <asp:Button ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click" />
    </header>
</body>
</html>

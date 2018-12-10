<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="TermProject.Main_Pages.messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Messages</title>
</head>
<body>
    <form runat="server">
        <header>
            <a href="newsfeed.aspx">
                <img src="../Images/logo.png" class="logo"/>
            </a>
            <div id="headerButtons" style="float:right;">
                <asp:Button class="headerBtn" ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click" />
                <asp:Button class="headerBtn" ID="prefBtn" runat="server" Text="Settings" OnClick="prefBtn_Click"/>
                <asp:Button class="headerBtn" ID="messagesBtn" runat="server" Text="Messages" OnClick="messagesBtn_Click" />
                <asp:Button class="headerBtn" ID="profileBtn" runat="server" Text="My Profile" OnClick="profileBtn_Click" />
            </div>
        </header>
    </form>
</body>
</html>

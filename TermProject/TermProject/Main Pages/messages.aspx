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
        <div id="main">
            Select Conversation: <asp:DropDownList ID="threadsDDL" runat="server" OnSelectedIndexChanged="threadsDDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
            <asp:Button ID="showFriendsBtn" runat="server" Text="Start New Conversation" OnClick="showFriendsBtn_Click" />

            <asp:CheckBoxList ID="newThreadCBL" runat="server"></asp:CheckBoxList>                      
            <asp:Button ID="newThreadBtn" runat="server" Text="Create" OnClick="newThreadBtn_Click"/>

            <div id="messagingWindow">
                <div id="threadDisplay">
                    <asp:GridView ID="threadGrid" runat="server" ShowHeader="false" ShowFooter="true" AllowPaging="true" 
                        GridLines="None" OnPageIndexChanging="threadGrid_PageIndexChanging" AutoGenerateColumns="true">

                        <alternatingrowstyle BackColor="White" ForeColor="#284775"></alternatingrowstyle>
                        <footerstyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></footerstyle>
                        <pagerstyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></pagerstyle>
                        <rowstyle BackColor="#F7F6F3" ForeColor="#333333"></rowstyle>

                    </asp:GridView>
                </div>
                <div id="composeMessage">
                    <div id="messageTxtDiv">
                        <asp:TextBox ID="messageTxt" runat="server"></asp:TextBox>
                    </div>
                    <div id="messageBtnDiv">
                        <asp:Button ID="messageBtn" runat="server" Text="Send" OnClick="messageBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

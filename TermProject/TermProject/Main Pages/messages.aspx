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
            <div id="headerButtons" runat="server" style="float:right;">
            </div>
        </header>
        <div id="main">
            Select Conversation: <asp:DropDownList ID="threadsDDL" runat="server" OnSelectedIndexChanged="threadsDDL_SelectedIndexChanged"></asp:DropDownList><br />
            Create New Conversation: <asp:DropDownList ID="newThreadDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="newThreadBtn" runat="server" Text="New Conversation" OnClick="newThreadBtn_Click"/>
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
                        <asp:Button ID="messageBtn" runat="server" Text="Send" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

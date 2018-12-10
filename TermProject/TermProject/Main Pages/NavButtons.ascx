<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavButtons.ascx.cs" Inherits="TermProject.Main_Pages.NavButtons" %>
<div>
                    <asp:Button class="headerBtn" ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click" />
                <asp:Button class="headerBtn" ID="prefBtn" runat="server" Text="Settings" OnClick="prefBtn_Click"/>
                <asp:Button class="headerBtn" ID="messagesBtn" runat="server" Text="Messages" OnClick="messagesBtn_Click" />
                <asp:Button class="headerBtn" ID="profileBtn" runat="server" Text="My Profile" OnClick="profileBtn_Click" />
            
</div>

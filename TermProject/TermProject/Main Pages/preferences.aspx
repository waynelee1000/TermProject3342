<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preferences.aspx.cs" Inherits="TermProject.Main_Pages.preferences" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings</title>
</head>
<body>
    <form id="PrefFrm" runat="server">
    <header>
        <header>
            <a href="newsfeed.aspx">
                <img src="../Images/logo.png" class="logo"/>
            </a>
            <div id="headerButtons" runat ="server" style="float:right;">
            </div>
        </header>
    </header>
    <div id="main">
            <fieldset>
                <legend>Login Settings</legend>

                Current Login Preference:
                <asp:Label ID="lbl_CurrentLoginPref" runat="server" Text=""></asp:Label><br />

                Change User Login Preference
                <asp:DropDownList ID="DDL_LoginPref" runat="server">
                    <asp:ListItem Value="default">Default</asp:ListItem>
                    <asp:ListItem Value="assist">Assist</asp:ListItem>
                    <asp:ListItem Value="automatic">Automatic</asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btn_LoginPref" runat="server" Text="Confirm" OnClick="btn_LoginPref_Click" />
            </fieldset>
            <fieldset>
                <legend>Privacy Settings</legend>

                Who can view your photos: 
                <asp:DropDownList ID="photosDDL" runat="server">
                    <asp:ListItem Value="public">Public</asp:ListItem>
                    <asp:ListItem Value="friends">Friends Only</asp:ListItem>
                    <asp:ListItem Value="relatedFriends">Friends of Friends</asp:ListItem>
                </asp:DropDownList><br />

                Who can view your profile details:
                <asp:DropDownList ID="profileDDL" runat="server">
                    <asp:ListItem Value="public">Public</asp:ListItem>
                    <asp:ListItem Value="friends">Friends Only</asp:ListItem>
                    <asp:ListItem Value="relatedFriends">Friends of Friends</asp:ListItem>
                </asp:DropDownList><br />

                Who can view your contact info:
                <asp:DropDownList ID="contactDDL" runat="server">
                    <asp:ListItem Value="public">Public</asp:ListItem>
                    <asp:ListItem Value="friends">Friends Only</asp:ListItem>
                    <asp:ListItem Value="relatedFriends">Friends of Friends</asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btn_PrivacyPref" runat="server" Text="Confirm" OnClick="btn_PrivacyPref_Click"/>
            </fieldset>        
        </div>
    </form>
</body>
</html>

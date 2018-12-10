<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="TermProject.Main_Pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

        <div>
            <asp:Image ID="imgProfile" runat="server" Height="140px" Width="120px" />
            <asp:Button ID="btnEditMode" runat="server" Text="Edit Mode" OnClick="btnEditMode_Click" />
        </div>
        <div>
            Profile Picture:<asp:FileUpload ID="uploadProfilePicture" runat="server" Visible ="false" />
        </div>
        <div>
            <asp:TextBox ID="txtProfileName" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditName" runat="server" Text="Edit" Visible ="false" OnClick="btnEditName_Click"/>
        </div>
        <asp:Panel ID="PnlContactInfo" runat="server">
         <div>
            CellPhone : <asp:TextBox ID="txtProfileCellPhone" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCell" runat="server" Text="Edit" OnClick="btnEditCell_Click" Visible ="false" />
            <br />
            Address : <asp:TextBox ID="txtProfileAddress" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditAddress" runat="server" Text="Edit" OnClick="btnEditAddress_Click" Visible ="false"/>
            <br />
            City : <asp:TextBox ID="txtProfileCity" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCity" runat="server" Text="Edit" OnClick="btnEditCity_Click" Visible ="false" />
            <br />
            State : <asp:TextBox ID="txtProfileState" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditState" runat="server" Text="Edit" OnClick="btnEditState_Click" Visible ="false" />
            <br />
            ZipCode : <asp:TextBox ID="txtProfileZipCode" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditZipCode" runat="server" Text="Edit" OnClick="btnEditZipCode_Click" Visible ="false" />
        </div>
        </asp:Panel>
        <div>
            Organizations: <asp:TextBox ID="txtProfileOrgs" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditOrg" runat="server" Text="Edit" OnClick="btnEditOrg_Click" Visible ="false" />
        </div>
        <asp:Button ID="btnConfirmation" runat="server" Text="Update" OnClick="btnConfirmation_Click" Visible ="false" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Profile Wall
                <br />
                <asp:TextBox ID="txtPostWall" runat="server" Width="805px"></asp:TextBox><asp:Button ID="btnPost" runat="server" Text="Post" />
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>

    </form>
</body>
</html>

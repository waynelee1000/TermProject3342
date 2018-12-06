<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="TermProject.Main_Pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="ProfilePicture" runat="server" Height="140px" Width="120px" />
        </div>
        <div>
            Upload Profile Picture:<asp:FileUpload ID="ProfilePictureUpload" runat="server"  />
        </div>
        <div>
            <asp:TextBox ID="ProfileName" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditName" runat="server" Text="Edit" />
        </div>
        <asp:Panel ID="PnlContactInfo" runat="server">
         <div>
            CellPhone : <asp:TextBox ID="ProfileCellPhone" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCell" runat="server" Text="Edit" />
            <br />
            Address : <asp:TextBox ID="ProfileAddress" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditAddress" runat="server" Text="Edit" />
            <br />
            City : <asp:TextBox ID="ProfileCity" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCity" runat="server" Text="Edit" />
            <br />
            State : <asp:TextBox ID="ProfileState" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditState" runat="server" Text="Edit" />
            <br />
            ZipCode : <asp:TextBox ID="ProfileZipCode" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditZipCode" runat="server" Text="Edit" />
        </div>
        </asp:Panel>
        <div>
            Organizations: <asp:TextBox ID="ProfileOrgs" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditOrg" runat="server" Text="Edit" />
        </div>
        <asp:Button ID="btnConfirmation" runat="server" Text="Update" />
    </form>
</body>
</html>

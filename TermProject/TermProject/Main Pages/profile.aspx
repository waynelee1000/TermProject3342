<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="TermProject.Main_Pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgProfile" runat="server" Height="140px" Width="120px" />
        </div>
        <div>
            Upload Profile Picture:<asp:FileUpload ID="uploadProfilePicture" runat="server"  />
        </div>
        <div>
            <asp:TextBox ID="txtProfileName" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditName" runat="server" Text="Edit" />
        </div>
        <asp:Panel ID="PnlContactInfo" runat="server">
         <div>
            CellPhone : <asp:TextBox ID="txtProfileCellPhone" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCell" runat="server" Text="Edit" OnClick="btnEditCell_Click" />
            <br />
            Address : <asp:TextBox ID="txtProfileAddress" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditAddress" runat="server" Text="Edit" OnClick="btnEditAddress_Click" />
            <br />
            City : <asp:TextBox ID="txtProfileCity" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditCity" runat="server" Text="Edit" OnClick="btnEditCity_Click" />
            <br />
            State : <asp:TextBox ID="txtProfileState" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditState" runat="server" Text="Edit" OnClick="btnEditState_Click" />
            <br />
            ZipCode : <asp:TextBox ID="txtProfileZipCode" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditZipCode" runat="server" Text="Edit" OnClick="btnEditZipCode_Click" />
        </div>
        </asp:Panel>
        <div>
            Organizations: <asp:TextBox ID="txtProfileOrgs" runat="server" ReadOnly ="true"></asp:TextBox><asp:Button ID="btnEditOrg" runat="server" Text="Edit" OnClick="btnEditOrg_Click" />
        </div>
        <asp:Button ID="btnConfirmation" runat="server" Text="Update" OnClick="btnConfirmation_Click"  />
    </form>
</body>
</html>

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
            Upload Profile Picture:<asp:FileUpload ID="ProfilePictureUpload" runat="server" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login-help.aspx.cs" Inherits="TermProject.Login_Pages.login_help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook - Forgot Login</title>
</head>
<body>
    <header>  
        <a href="login.aspx">
            <img src="../Images/fb-word-white.png" class="logo"/>
        </a>
    </header>
    <div id="main">
        <form id="helpFrm" runat="server">
            &nbsp;Enter Username:<asp:TextBox ID="userTxt" runat="server"></asp:TextBox>
            <asp:Button ID="getSecurityBtn" runat="server" Text="Submit" OnClick="getSecurityBtn_Click"/>
            <asp:Label ID="lblRecoveryError" runat="server" Text=""></asp:Label>
            <br />

            <fieldset>
                <legend>Security Questions</legend>
                <asp:Label ID="Q1Lbl" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="Q1Answer" runat="server" Visible ="false"></asp:TextBox><br />
                <asp:Label ID="Q2Lbl" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="Q2Answer" runat="server" Visible ="false" ></asp:TextBox><br />
                <asp:Button ID="sumbitBtn" runat="server" Visible ="false" Text="Submit" OnClick="sumbitBtn_Click"/>
            </fieldset>
            <asp:Label ID="passwordLbl" runat="server" Text=""></asp:Label>
        </form>
    </div>
</body>
</html>

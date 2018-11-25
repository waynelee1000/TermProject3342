<!-- 
    Page Layout & Features:
        - Theme chosen from cookie if available, blue if otherwise
        - Login options in header
        - Registration options in body
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TermProject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <title>Facebook - Login or Register</title>
</head>
<body>
    <form id="mainFrm" runat="server">
    <!-- Header with login controls -->
    <header>
        <a href="login.aspx">
            <img src="../Images/fb-word-white.png" class="logo"/>
        </a>      
        
        <!-- Login form -->
        <div id="loginFrm">
            <div id="loginWrapper">
                <div id="login_emailDiv">
                    <label for="login_emailTxt">Email</label>
                    <asp:TextBox ID="login_emailTxt" type="text" runat="server"/>
                </div>
                <div id="login_passwordDiv">
                    <label for="login_passwordTxt">Password</label>
                    <asp:TextBox ID="login_passwordTxt" type="text" runat="server" />
                </div>
            </div>
            <div id="login_optionsDiv">
                <a id="login_helpLink" href="login-help.aspx" runat="server">Forgot Login</a>
                <asp:Button ID="login_Btn" type="button" value="Login" runat="server" OnClick="login_Btn_Click"/>

            </div>          
        </div>
    </header>

    <!-- Registration Form -->
    <div id="registerDiv">
        <h1>Create a New Account</h1>
        <div id="registerFrm">
            <!-- Left -->
            <div class="regFormat_Left">
                <label for="register_emailTxt" >Email</label>
                <asp:TextBox ID="register_emailTxt" runat="server"></asp:TextBox>
                
                <label for="register_FirstNameTxt" >First Name</label>
                <asp:TextBox ID="register_FirstNameTxt" runat="server"></asp:TextBox>
                
                <label for="register_PhoneTxt" >Phone Number</label>
                <asp:TextBox ID="register_PhoneTxt" runat="server"></asp:TextBox>

                <label for="register_stateTxt" >State</label>
                <asp:TextBox ID="register_stateTxt" runat="server"></asp:TextBox>

                <label for="register_securityQ1Txt" >Security Question 1</label>
                <asp:TextBox ID="register_securityQ1Txt" runat="server"></asp:TextBox>

                <label for="register_securityQ2Txt" >Security Question 2</label>
                <asp:TextBox ID="register_securityQ2Txt" runat="server"></asp:TextBox>

                <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
            </div>

            <!-- Right -->
            <div class="regFormat_Right">
                <label for="register_passwordTxt" >Password</label>
                <asp:TextBox ID="register_passwordTxt" runat="server"></asp:TextBox>                    

                <label for="register_LastNameTxt" >Last Name</label>
                <asp:TextBox ID="register_LastNameTxt" runat="server"></asp:TextBox>

                <label for="register_streetTxt" >Street Address</label>
                <asp:TextBox ID="register_streetTxt" runat="server"></asp:TextBox>

                <label for="register_zipcodeTxt" >Zip Code</label>
                <asp:TextBox ID="register_zipCodeTxt" runat="server"></asp:TextBox>

                <label for="register_securityA1Txt" >Answer</label>
                <asp:TextBox ID="register_securityA1Txt" runat="server"></asp:TextBox>

                <label for="register_securityA2Txt" >Answer</label>
                <asp:TextBox ID="register_securityA2Txt" runat="server"></asp:TextBox>

                <asp:Button ID="register_Btn" runat="server" Text="Register" OnClick="register_Btn_Click"/>
            </div>           
        </div>
    </div>
    </form>
</body>
</html>

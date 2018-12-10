<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsfeed.aspx.cs" Inherits="TermProject.Main_Pages.newsfeed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Newsfeed</title>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <header>
            <a href="newsfeed.aspx">
                <img src="../Images/logo.png" class="logo"/>
            </a>
            <div id="headerButtons" runat="server" style="float:right;">

            </div>
        </header>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>

        </div>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SecurityApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            Username:
            <asp:TextBox runat="server" ID="Username"></asp:TextBox>
        </div>

        <div>
            Password:
            <asp:TextBox TextMode="Password" runat="server" ID="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Button runat="server" Text="Login" ID="LoginBtn" OnClick="Login_Clicked"></asp:Button>
        </div>
    </form>


</body>
</html>

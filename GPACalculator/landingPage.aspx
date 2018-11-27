<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="GPACalculator.landingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter the amount of classes in the course &nbsp;
            <asp:TextBox id="txtCourseAmt" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" id="btnLoad" Text="Calculator form" OnClick="btnLoad_Click" />
        </div>
    </form>
</body>
</html>

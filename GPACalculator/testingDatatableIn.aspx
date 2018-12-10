<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testingDatatableIn.aspx.cs" Inherits="GPACalculator.testingDatatableIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="code1"></asp:TextBox>
            <asp:TextBox runat="server" ID="name1"></asp:TextBox>
            <asp:TextBox runat="server" ID="hours1"></asp:TextBox>
            <asp:TextBox runat="server" ID="grades1"></asp:TextBox>
            <asp:Button runat="server" ID="btnAdd" text="Add class" OnClick="btnAdd_Click"/>
        </div>
    </form>
</body>
</html>

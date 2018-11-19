<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="GPACalculator.CalculatorForm" %>

<%@ Register Src="~/ClassTable.ascx" TagPrefix="uc1" TagName="ClassTable" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/calcFormStyle.css" rel="Stylesheet" type="text/css" />
    <title>Calculator</title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="mainForm" runat="server">
        <div>
            <asp:Button ID="btnClear" runat="server" Text="Clear Form" />
            <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
            <asp:Button ID="btnCalc" runat="server" Text="Calculate" />
        </div>
        <div>
            <asp:Table ID="mainTable" runat="server" Width="100%">
                <asp:TableRow ID="headerRow">
                    <asp:TableCell>Course Code</asp:TableCell>
                    <asp:TableCell>Course Name</asp:TableCell>
                    <asp:TableCell>Grade</asp:TableCell>
                    <asp:TableCell>Course Hours</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Course Code</asp:TableCell>
                    <asp:TableCell>Course Name</asp:TableCell>
                    <asp:TableCell>Grade</asp:TableCell>
                    <asp:TableCell>Course Hours</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Course Code</asp:TableCell>
                    <asp:TableCell>Course Name</asp:TableCell>
                    <asp:TableCell>Grade</asp:TableCell>
                    <asp:TableCell>Course Hours</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Course Code</asp:TableCell>
                    <asp:TableCell>Course Name</asp:TableCell>
                    <asp:TableCell>Grade</asp:TableCell>
                    <asp:TableCell>Course Hours</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

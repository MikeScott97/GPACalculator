<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="GPACalculator.CalculatorForm" %>

<%@ Register Src="~/ClassTable.ascx" TagPrefix="uc1" TagName="ClassTable" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/calcFormStyle.css" rel="Stylesheet" type="text/css"/>
    <title>Calculator</title>
</head>
<body>
    <form id="mainForm" runat="server">
        <div style="display:inline-block; width: 103px; height: 24px;">
            <asp:Button ID="btnClear" runat="server" Text="Clear Form" />
            <br />
            <br />
            <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
            <br />
            <br />
            <asp:Button ID="btnCalc" runat="server" Text="Calculate" />
        </div>
        <div style="display:inline-block; width: 500px;">
            <asp:Table ID="mainTable" runat="server" width="100%">
                <asp:TableRow ID="headerRow">
                    <asp:TableCell>Course Code</asp:TableCell>
                    <asp:TableCell>Course Name</asp:TableCell>
                    <asp:TableCell>Course Hours</asp:TableCell>
                    <asp:TableCell>Grades</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

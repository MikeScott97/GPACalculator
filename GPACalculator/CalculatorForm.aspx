<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="GPACalculator.CalculatorForm" %>

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
            <asp:Button ID="btnClear" runat="server" Text="Clear Form" OnClick="btnClear_Click" />
            <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
            <asp:Button ID="btnCalc" runat="server" Text="Calculate" OnClick="btnCalc_Click" />
        </div>
        <div>
            <asp:Table ID="mainTable" runat="server">
                <asp:TableHeaderRow ID="headerRow">
                    <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Hours</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Grade</asp:TableHeaderCell>
                    <asp:TableHeaderCell>X</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div>
            <asp:Label runat="server" ID="lblGPAOut" Text=""></asp:Label>
            <br />
            <asp:Label runat="server" ID="lblMinGradeOut" Text=""></asp:Label>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CoursesConnectionString %>" SelectCommand="SELECT * FROM [Classes]"></asp:SqlDataSource>
    </form>
</body>
</html>

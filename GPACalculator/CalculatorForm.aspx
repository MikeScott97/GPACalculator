<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="GPACalculator.CalculatorForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/calcFormStyle.css" rel="Stylesheet" type="text/css" />
    <title>GPA Calculator</title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="mainForm" runat="server">
        <div class="row">
            <div class="col-md-2" style="">
                <asp:Button ID="btnClear" runat="server" Text="Clear Form" OnClick="btnClear_Click" />
                <br />
                <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" Width="115px" />
                <br />
                <asp:Button ID="btnCalc" runat="server" Text="Calculate" OnClick="btnCalc_Click" Width="115px" />
                <br />
                <br />
                <br />
                <label>Enter the name of the program:</label>
                <br />
                <asp:TextBox ID="txtTableName" runat="server" Text="" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please name the program"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save Classes" OnClick="btnSave_Click" Width="115px" />
            </div>
            <div class="col-md-8">
                <asp:Table ID="mainTable" runat="server">
                    <asp:TableHeaderRow ID="headerRow">
                        <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Course Hours</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Course Grade</asp:TableHeaderCell>
                        <asp:TableHeaderCell>X</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <br />
                <asp:ListBox ID="listOut" runat="server" Width="498px" Height="125px"></asp:ListBox>
            </div>
            <div class="col-md-2 container">
                <label>Current GPA =</label>
                <asp:Label runat="server" ID="lblGPAOut" Text=""></asp:Label>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CoursesConnectionString %>" SelectCommand="SELECT [Course Code],[Course Name],[Course Hours],[Course Grade] FROM [computerProgrammerView] ORDER BY [Semester]"></asp:SqlDataSource>
    </form>
</body>
</html>

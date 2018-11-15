<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="GPACalculator.CalculatorForm" %>

<%@ Register Src="~/ClassTable.ascx" TagPrefix="uc1" TagName="ClassTable" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/calcFormStyle.css" rel="Stylesheet" type="text/css"/>
    <title>Calculator</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr class="Table-Title">
                    <td>Course Code</td>
                    <td>Course Name</td>
                    <td>Course Hours</td>
                    <td>Grade</td>
                </tr>
                <uc1:ClassTable runat="server" ID="ClassTable" />
            </table>
            <asp:Button ID="btnCalc" runat="server" Text="Calculate GPA" />
        </div>
    </form>
</body>
</html>

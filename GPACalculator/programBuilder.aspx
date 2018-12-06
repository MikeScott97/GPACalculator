<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="programBuilder.aspx.cs" Inherits="GPACalculator.programBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="mainTable" runat="server">
                <asp:TableHeaderRow ID="headerRow">
                    <asp:TableHeaderCell>Semester</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Course Hours</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

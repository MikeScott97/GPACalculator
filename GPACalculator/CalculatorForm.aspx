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
            <asp:Button ID="btnClear" runat="server" Text="Clear Form" />
            <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
            <asp:Button ID="btnCalc" runat="server" Text="Calculate" OnClick="btnCalc_Click" />
        </div>

        <asp:GridView ID="programGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Course Code" DataSourceID="coursesDataSource" BorderColor="Black" BorderStyle="Outset" CellPadding="2" ShowFooter="True">
            <Columns>
                 <asp:TemplateField HeaderText="Course Code">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCode" Text='<%# Eval("Course Code") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCode" runat="server" Text="" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Course Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblName" Text='<%# Eval("Course Name") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text="" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Course Hours">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblHours" Text='<%# Eval("Course Hours") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtHours" runat="server" Text="" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Course Grades">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtGrade"></asp:TextBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtGrades" runat="server" Text="" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="coursesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:CCCourseConnectionString %>" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>

        <div>

        </div>
    </form>
</body>
</html>

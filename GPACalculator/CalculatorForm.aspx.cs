using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPACalculator
{
    public partial class CalculatorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int max = 5;//int.Parse(Request.QueryString["id"]);
            for (int i = 0; i > max; i++)
            {
                TableRow row = new TableRow();
                TableCell cellCode = new TableCell();
                TableCell cellName = new TableCell();
                TableCell cellGrade = new TableCell();
                TableCell cellHours = new TableCell();
                row.ID = $"row{i}";
                cellCode.ID = $"courseCode{i}";
                cellName.ID = $"courseName{i}";
                cellGrade.ID = $"courseGrade{i}";
                cellHours.ID = $"courseHours{i}";
                cellCode.Text = "test123";
                cellName.Text = "History of cars 2";
                cellGrade.Text = "97";
                cellHours.Text = "42";
                row.Cells.Add(cellCode);
                row.Cells.Add(cellName);
                row.Cells.Add(cellGrade);
                row.Cells.Add(cellHours);
                mainTable.Rows.Add(row);
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {

        }

        protected void btnCalc_Click(object sender, EventArgs e)
        { 
        }
    }
}
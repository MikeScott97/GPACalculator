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

        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell cellCode = new TableCell();
            TableCell cellName = new TableCell();
            TableCell cellGrade = new TableCell();
            TableCell cellHours = new TableCell();
            cellCode.Text = "test123";
            cellName.Text = "History of cars 2";
            cellHours.Text = "42";
            cellGrade.
            row.Cells.Add(cellCode);
            row.Cells.Add(cellName);
            row.Cells.Add(cellGrade);
            row.Cells.Add(cellHours);
            mainTable.Rows.Add(row);
        }
    }
}
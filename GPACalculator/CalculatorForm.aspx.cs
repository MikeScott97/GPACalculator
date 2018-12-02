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
            if (Session["table"] == null)//(Request.QueryString["id"].Length > 0)
            {
                if (int.TryParse(Request.QueryString["id"], out int Classes))
                {
                    List<TableRow> Rows = new List<TableRow>();
                    for (int i = 0; i < Classes; i++)
                    {
                        TableRow Row = new TableRow();
                        Row.Cells.Add(new TableCell() { Text = "Course Code" });
                        Row.Cells.Add(new TableCell() { Text = "Course Name" });
                        Row.Cells.Add(new TableCell() { Text = "Grade" });
                        Row.Cells.Add(new TableCell() { Text = "Course Hours" });
                        mainTable.Controls.Add(Row);
                        Rows.Add(Row);
                    }
                    Session["table"] = Rows;
                }
            }
            else
            {
                List<TableRow> Rows = Session["table"] as List<TableRow>;
                foreach (var a in Rows)
                {
                    mainTable.Controls.Add(a);
                }
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            List<TableRow> Rows = Session["table"] as List<TableRow>;
            foreach (var a in Rows)
            {
                mainTable.Controls.Add(a);
            }
            TableRow Row = new TableRow();
            Row.Cells.Add(new TableCell() { Text = "Course Code" });
            Row.Cells.Add(new TableCell() { Text = "Course Name" });
            Row.Cells.Add(new TableCell() { Text = "Grade" });
            Row.Cells.Add(new TableCell() { Text = "Course Hours" });
            mainTable.Controls.Add(Row);
            Rows.Add(Row);
            Session["table"] = Rows;
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["table"] = new List<TableRow>();
        }
    }
}
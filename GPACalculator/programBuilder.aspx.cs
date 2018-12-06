using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPACalculator
{
    public partial class programBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["table"] == null)
            {
                if (int.TryParse(Request.QueryString["id"], out int Classes))
                {
                    //creates a list to hold the rows
                    List<TableRow> Rows = new List<TableRow>();

                    //creates the header row of the table
                    TableRow Row = new TableRow();
                    Row.Cells.Add(new TableCell() { Text = "Course Code" });
                    Row.Cells.Add(new TableCell() { Text = "Grade" });
                    Row.Cells.Add(new TableCell() { Text = "Course Hours" });
                    mainTable.Controls.Add(Row);
                    Rows.Add(Row);
                    Row.Cells.Add(new TableCell() { Text = "Course Name" });
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
    }
}
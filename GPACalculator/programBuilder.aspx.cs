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
            if (Session["programTable"] == null)
            {
                int numRows = Convert.ToInt32(Request.QueryString["id"]);
                List<TableRow> Rows = new List<TableRow>();
                for (int i = 0; i < numRows; i++)
                {
                    TableRow Row = new TableRow();
                    Row.Cells.Add(new TableCell()
                    {
                        Controls = {
                        new TextBox()
                    }
                    });
                    Row.Cells.Add(new TableCell()
                    {
                        Controls = {
                        new TextBox()
                    }
                    }); Row.Cells.Add(new TableCell()
                    {
                        Controls = {
                        new TextBox()
                    }
                    }); Row.Cells.Add(new TableCell()
                    {
                        Controls = {
                        new TextBox()
                    }
                    });
                    programTable.Controls.Add(Row);
                    Rows.Add(Row);
                }
                Session["programTable"] = Rows;
            }
        }
    }
}
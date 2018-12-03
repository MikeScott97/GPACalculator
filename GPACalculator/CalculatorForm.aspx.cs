using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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
                else
                {
                    List<TableRow> Rows = new List<TableRow>();
                    for (int i = 0; i < 5; i++)
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
                        Button BB = new Button();
                        BB.Click += new EventHandler(BB_Click);
                        Row.Cells.Add(new TableCell()
                        {
                            Controls = {
                                BB
                            }
                        });
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

        private void BB_Click(object sender, EventArgs e)
        {
            Session["table"] = new List<TableRow>();
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
            for (int i = 1; i < mainTable.Rows.Count; i++)
            {
                for (int k = 0; k < mainTable.Rows[i].Cells.Count; k++)
                {
                    TextBox Box = mainTable.Rows[i].Cells[k].Controls[0] as TextBox;
                    switch (k)
                    {
                        case 0:
                            CheckControlText(Box);
                            break;
                        case 1:
                            CheckControlText(Box);
                            break;
                        case 2:
                            CheckControlNumber(Box);
                            break;
                        case 3:
                            CheckControlNumber(Box);
                            break;
                    }
                }
            }
        }

        protected void CheckControlText(TextBox Box)
        {
            if (Box.Text.Length <= 0 || Box.Text.Length > 30)
            {
                Box.CssClass = "redSquare";
                return;
            }
            else if (!Regex.Match(Box.Text, "^[A-Za-z0-9 ]{1,30}$").Success)
            {
                Box.CssClass = "redSquare";
                return;
            }
            Box.CssClass = null;
        }

        protected void CheckControlNumber(TextBox Box)
        {
            if (Box.Text.Length == 0 || Box.Text.Length >= 4)
            {
                Box.CssClass = "redSquare";
                return;
            }
            else if (!int.TryParse(Box.Text, out int Num))
            {
                Box.CssClass = "redSquare";
                return;
            }
            else if (Num > 100 || Num < 0)
            {
                Box.CssClass = "redSquare";
                return;
            }
            Box.CssClass = null;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["table"] = new List<TableRow>();
        }

        protected void makeDataTable()
        {
            string connString = SqlDataSource1.ConnectionString;
            string query = "select * from [Table]";
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            connection.Close();
            dataAdapter.Dispose();

        }
    }
}
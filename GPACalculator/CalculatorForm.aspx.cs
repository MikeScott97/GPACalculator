using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace GPACalculator
{
    public partial class CalculatorForm : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //calls datatable creation method
            makeDataTable();

            //checks for session data then creates the table
            if (Session["table"] == null)
            {
                if (int.TryParse(Request.QueryString["id"], out int Classes))
                {
                    //creates a list to hold the rows
                    List<TableRow> Rows = new List<TableRow>();

                    //creates the header row od the table
                    TableRow Row = new TableRow();
                    Row.Cells.Add(new TableCell() { Text = "Course Code" });
                    Row.Cells.Add(new TableCell() { Text = "Grade" });
                    Row.Cells.Add(new TableCell() { Text = "Course Hours" });
                    mainTable.Controls.Add(Row);
                    Rows.Add(Row);
                    Row.Cells.Add(new TableCell() { Text = "Course Name" });
                    Session["table"] = Rows;
                }
                else
                {
                    List<TableRow> Rows = new List<TableRow>();
                    List<TextBox> gradeInput = new List<TextBox>();
                    //for loop to grab every row from the sql table
                    for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                    {
                        TableRow Row = new TableRow();
                        //for loop to grab every column from the sql table
                        for (int columnIndex = 0; columnIndex < dt.Columns.Count; columnIndex++)
                        {   
                            //checks for grade category and creates a textbox
                            if (columnIndex == 3)
                            {
                                TextBox tb = new TextBox();
                                tb.ID = "txtGrade" + rowIndex;
                                Row.Cells.Add(new TableCell()
                                {
                                    Controls =
                                    {
                                        tb
                                    }
                                });
                                gradeInput.Add(tb);
                            }
                            else
                            {
                                //converts sql data from the datatable to the asp table
                                Row.Cells.Add(new TableCell() { Text = dt.Rows[rowIndex].ItemArray[columnIndex].ToString() });
                            }
                        }
                        //creates the table
                        mainTable.Controls.Add(Row);
                        Rows.Add(Row);
                    }
                        
                    //saves rows to session    
                    Session["table"] = Rows;
                    Session["gradeTextboxes"] = gradeInput;
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
            makeDataTable();
            List<TableRow> Rows = Session["table"] as List<TableRow>;
            foreach (var a in Rows)
            {
                mainTable.Controls.Add(a);
            }
            TableRow Row = new TableRow();
            Row.Cells.Add(new TableCell() { Text = dt.Rows[1].ItemArray[1].ToString() });
            Row.Cells.Add(new TableCell() { Text = "Course Name" });
            Row.Cells.Add(new TableCell() { Text = "Grade" });
            Row.Cells.Add(new TableCell() { Text = "Course Hours" });
            mainTable.Controls.Add(Row);
            Rows.Add(Row);
            Session["table"] = Rows;
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            List<TextBox> gradeInputs = Session["gradeTextboxes"] as List<TextBox>;
            int totalHours = 0;
            int totalGrades = 0;
            int completedHours = 0;
            int incompleteHours = 0;
            int tempGrade = 0;
            //collects all of the hours of each class
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tempGrade = Convert.ToInt32(gradeInputs[i].Text);
                totalHours = totalHours + Convert.ToInt32(dt.Rows[i].ItemArray[2]);
                if (tempGrade >= 50)
                {
                    totalGrades = totalGrades + GetGrade(tempGrade);
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
        public static int GetGrade(int Grade)
        {
            if (Grade <= 100 || Grade > 0)
            {
                if (Grade >= 80)
                {
                    return 4;
                }
                else if (Grade >= 70)
                {
                    return 3;
                }
                else if (Grade >= 60)
                {
                    return 2;
                }
                else if (Grade >= 50)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
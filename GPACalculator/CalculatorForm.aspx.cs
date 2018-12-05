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
    public class ClassHolder
    {
        public int CreditScore { get; set; }
        public string GradeString { get; set; }
        public string ClassName { get; set; }
    }

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

        public struct SGrades
        {
            public int FilledCount;//amount of filled grades
            public int FilledHours;//amount of filled hours
            public int TotalCount;//total amount of grades
            public int UnfilledCount;//amount of missing grades
            public int QualityPoints;//amount of quality points the student has
            public int TotalHours;//total amount of course hours
            public int MissingHours;//missing hours for missing classes
            public double GPA;//student's current GPA
        }
        int[] GradeValues = new int[] { 1, 2, 3, 4 };
        List<ClassHolder> Unfilled = new List<ClassHolder>();
        protected void btnCalc_Click(object sender, EventArgs e)
        {
            List<TextBox> gradeInputs = Session["gradeTextboxes"] as List<TextBox>;
            SGrades Grades = new SGrades
            {
                FilledCount = 0,
                FilledHours = 0,
                TotalCount = 0,
                UnfilledCount = 0,
                QualityPoints = 0,
                TotalHours = 0,
                MissingHours = 0,
                GPA = 0
            };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Grades.TotalHours += int.Parse(dt.Rows[i].ItemArray[2].ToString());
                if (int.TryParse(gradeInputs[i].Text, out int Grade))
                {
                    if (GradeValues.Contains((Grade = GetGrade(Grade))))
                    {
                        Grades.QualityPoints += (Grade * Convert.ToInt32(dt.Rows[i].ItemArray[2]));
                        Grades.FilledHours += Convert.ToInt32(dt.Rows[i].ItemArray[2]);
                        Grades.FilledCount++;
                    }
                    else
                    {
                        Unfilled.Add(new ClassHolder
                        {
                            ClassName = dt.Rows[i].ItemArray[1].ToString(),
                            CreditScore = int.Parse(dt.Rows[i].ItemArray[2].ToString())
                        });
                        Grades.UnfilledCount++;
                        Grades.MissingHours += int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    }
                }
                else
                {
                    Unfilled.Add(new ClassHolder
                    {
                        ClassName = dt.Rows[i].ItemArray[1].ToString(),
                        CreditScore = int.Parse(dt.Rows[i].ItemArray[2].ToString())
                    });
                    Grades.UnfilledCount++;
                    Grades.MissingHours += int.Parse(dt.Rows[i].ItemArray[2].ToString());
                }
                Grades.TotalCount++;
            }
            //calculate GPA with method call
            Grades.GPA = (double)Grades.QualityPoints / Grades.FilledHours;
            //calculate the student's missing quality points
            double QPneeded = ((Grades.TotalHours * 2) - Grades.QualityPoints);
            //output to label
            lblGPAOut.Text = Grades.GPA.ToString("0.00");

            Perm(Grades, QPneeded);
        }
        string[] StaticGrades = new string[] { "D", "C", "B", "A" };
        static int[] set = { 4, 3, 2, 1 };
        int k, n = 4;
        int[] buf;
        private void Perm(SGrades Grades, Double gpaNeeded)
        {
            //number of missing classes
            k = Grades.UnfilledCount;
            //array of length missing classes
            buf = new int[k];
            //instantiate list for the lowest grade possble to pass
            List<string> lowestGrade = new List<string>();
            //return list of lowestgrade
            List<string> lowest = rec(0, 0, Grades, gpaNeeded, lowestGrade);
            //check for if the student can pass the course
            if (ListBox1.Items.Count <= 0)
            {
                ListBox1.Items.Add("No grades will make you pass, talk to your counselor about retaking courses");
            }

            ListBox1.Items.Add("");
            ListBox1.Items.Add("The Lowest grades you will need to pass in each course are:");

            //output the lowest grade possible in each course
            foreach (string a in lowest)
            {
                ListBox1.Items.Add(a);
            }
        }

        private List<string> rec(int ind, int begin, SGrades Grades, Double gpaNeeded, List<string> lowestGrade)
        {
            //loop for going through each grade value
            for (int i = begin; i < n; i++)
            {
                //adds the grade to the array
                buf[ind] = set[i];
                //check if loop is less than the missing grade count
                if (ind + 1 < k)
                {
                    //if yes call recursive function
                    rec(ind + 1, i, Grades, gpaNeeded, lowestGrade);

                }
                //else check quality point and output to listbox
                else
                {
                    double QualityPoints = 0;
                    //loop for adding up the amount of quality points in array buf
                    for (int idx = 0; idx < buf.Length; idx++)
                    {
                        QualityPoints += buf[idx] * Unfilled[idx].CreditScore;
                    }
                    //check if buf quality points is bigger than the quality points needed to pass the course
                    if ((QualityPoints) >= gpaNeeded)
                    {
                        List<string> SendingOut = new List<string>();
                        //loop through each value in array buff
                        foreach (int X in buf)
                        {
                            //add them to a list
                            SendingOut.Add(StaticGrades[X - 1]);
                        }
                        //output sendingout as a joined string
                        ListBox1.Items.Add(string.Join(",", SendingOut));
                        //clear lowest grade
                        lowestGrade.Clear();
                        //set each unfilled class name with its lowest possible grade
                        for (int index = 0; index < Unfilled.Count; index++)
                        {
                            lowestGrade.Add(Unfilled[index].ClassName + ":  " + SendingOut[index]);
                        }
                    }
                    //output for the amount of quality points in buf
                    //Console.WriteLine(QualityPoints);
                }
            }
            //returns the lowest grades output to the listbox
            return lowestGrade;
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
            //pull the sql table from the database
            string connString = SqlDataSource1.ConnectionString;
            string query = "select * from [Classes]";
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
            if (Grade <= 100 && Grade >= 50)
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
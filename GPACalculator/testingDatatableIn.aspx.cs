using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GPACalculator
{
    public partial class testingDatatableIn : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataColumn dataColumn;
            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "courseCode";
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "courseName";
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Int32");
            dataColumn.ColumnName = "courseHours";
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Int32");
            dataColumn.ColumnName = "courseGrades";
            dataTable.Columns.Add(dataColumn);
            Session["table"] = dataTable;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int ind = 0;
            dataTable = Session["table"] as DataTable;
 
            DataRow dataRow = dataTable.NewRow();
            dataRow["courseCode"] = code1.Text;
            dataRow["courseName"] = name1.Text;
            dataRow["courseHours"] = hours1.Text;
            dataRow["courseGrades"] = grades1.Text;


            Session["table"] = dataTable;
            ind++;
        }
    }
}
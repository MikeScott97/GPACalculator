using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GPACalculator
{
    public class DataCollection
    {
        private int totalHours;
        private int completedHours;
        private double totalGrades;
        private double completedGrades;


        public DataCollection(DataTable dataTable)
        {
            CalcTotalHours();
        }
        public int CalcTotalHours()
        {
            int totalHours = 1;
            return totalHours;
        }
    }
}
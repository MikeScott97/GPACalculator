using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPACalculator
{
    public class Calculations
    {
        public double GPA(int qp, int filledHours)
        {
            double gpa = (double)qp / filledHours;
            return gpa;
        }

        public double QPNeeded(int totalHours, int qp)
        {
            double QPneeded = ((totalHours * 2) - qp);
            return QPneeded;
        }

        public void getMinimum(ref CalculatorForm.SGrades grades, double gpaNeeded)
        {

        }
    }
}
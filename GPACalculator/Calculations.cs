using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPACalculator
{
    public class Calculations
    {
        public double GPA(int QualityPoints, int FilledHours)
        {
            double gpa = QualityPoints / FilledHours;
            return gpa;
        }

        public double missingQP(int TotalHours, int QualityPoints)
        {
            double missingQP = ((TotalHours * 2) - QualityPoints);// Grades.UnfilledCount;//2490
            return missingQP;
        }

        HashSet<int> Uniques = new HashSet<int>();
        string[] StaticGrades = new string[] { "D", "C", "B", "A" };
        private static IEnumerable<int[]> Perm(int UnfilledCount, double GradeNeeded)
        {
            var stack = new Stack<int>();
            int[] Classes = new int[UnfilledCount];
            stack.Push(1);
            //int ROWS = Classes.Length;
            List<string> lowestGrade = new List<string>();

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= 4)
                {
                    Classes[index++] = value++;
                    stack.Push(value);
                    if (index == UnfilledCount)
                    {
                        yield return Classes;
                        break;
                    }
                }
            }
        }
    }
}
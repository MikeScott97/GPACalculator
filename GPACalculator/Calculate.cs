using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPACalculator
{
    public class Calculate
    {
        public static double CalcGPA(int QualityPoints, int CompleteHours)
        {
            double GPA = QualityPoints / CompleteHours;
            return GPA;
        }

        public static double CalcMissingQP(int QualityPoints, int TotalHours)
        {
            //get quality points for a 2.0 GPA and take away current quality points
            double missingQP = ((TotalHours * 2) - QualityPoints);
            return missingQP;
        }

        //array for grade outputs
        string[] StaticGrades = new string[] { "D", "C", "B", "A" };

        //instantiate array for possible grade values
        static int[] set = { 4, 3, 2, 1 };
        //k = unfilled classes
        //n = number to choose from
        static int k, n = 4;
        //instatiate variable to remember stage of sequence
        static int[] buf;

        public static void Perm(List<int> UnfilledCourses, List<string> UnfilledCourseNames, Double gpaNeeded)
        {
            //number of missing classes
            k = UnfilledCourses.Count;
            //array of length missing classes
            buf = new int[k];
            //instantiate list for the lowest grade possble to pass
            List<string> lowestGrade = new List<string>();
            //return list of lowestgrade
            List<string> lowest = rec(0, 0, UnfilledCourses,UnfilledCourseNames, gpaNeeded, lowestGrade);
        }

        private List<string> rec(int ind, int begin, List<int> UnfilledCourses, List<string> UnfilledCourseNames, Double gpaNeeded, List<string> lowestGrade)
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
                    rec(ind + 1, i, UnfilledCourses, UnfilledCourseNames, gpaNeeded, lowestGrade);

                }
                //else check quality point and output to listbox
                else
                {
                    double QualityPoints = 0;
                    //loop for adding up the amount of quality points in array buf
                    for (int idx = 0; idx < buf.Length; idx++)
                    {
                        QualityPoints += buf[idx] * UnfilledCourses[idx];
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
                        //listBox1.Items.Add(string.Join(",", SendingOut));
                        //clear lowest grade
                        lowestGrade.Clear();
                        //set each unfilled class name with its lowest possible grade
                        for (int index = 0; index < UnfilledCourses.Count; index++)
                        {
                            lowestGrade.Add(UnfilledCourseNames[index] + ":  " + SendingOut[index]);
                        }
                    }
                    //output for the amount of quality points in buf
                    //Console.WriteLine(QualityPoints);
                }
            }
            //returns the lowest grades output to the listbox
            return lowestGrade;
        }
    }
}
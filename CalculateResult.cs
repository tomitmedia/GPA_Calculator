using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Gpa_Calculator
{
    public class CalculateResult
    {

        public int totalCourseUnit { get; set; }
        public double totalCourseUnitPassed { get; set; }
        public double totalWeightPoint { get; set; }
        public double gpa { get; set; }


        public int totalCourses { get; set; }

        public string courseTitle { get; set; }
        public int courseUnit { get; set; }
        public double courseScore { get; set; }
        public int failedCourseUnit { get; set; }
        public double weightPoint { get; set; }
        public char grade { get; set; }
        public string remark { get; set; }
        public int gradeUnit { get; set; }
        public string studentName { get; set; }


        //public List<CalculateResult> Compute = new List<CalculateResult>();

        //public static CalculateResult()
        //{

        //}

        public CalculateResult(string courseTitle, int courseUnit, double courseScore, double weightPoint, char grade, string remark, int gradeUnit, int failedCourseUnit)
        {
            this.courseTitle = courseTitle;
            this.courseUnit = courseUnit;
            this.courseScore = courseScore;
            this.weightPoint = weightPoint;
            this.grade = grade;
            this.remark = remark;
            this.gradeUnit = gradeUnit;
            this.failedCourseUnit = failedCourseUnit;
        }

        public CalculateResult(string studentName)
        {
            this.studentName = studentName;

        }

        public static void Calculate()
        {

            //if (StartApp.pass == false)
            //{

            //    Console.WriteLine("yes");
            //    //PrintTable.StudentResult(Compute);
            //    //goto Gpa;
            //}



        totalCourses:
            Console.WriteLine("\n**************************************************************************");
            Console.Write("\nHow many Course(s) did you register?: ");
            string tCourses = Console.ReadLine();
            int totalCourses = 0;




            if (!int.TryParse(tCourses, out totalCourses) || totalCourses <= 0)
            {
                Console.Clear();

                Console.WriteLine("\n**************************************************************************");
                CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                goto totalCourses;
            }

            string courseTitle;
            int[] courseUnit = new int[totalCourses];
            double courseScore;
            int[] failedCourseUnit = new int[totalCourses];
            double[] weightPoint = new double[totalCourses];
            char grade;
            string remark;
            int gradeUnit;

            {
                List<CalculateResult> Compute = new List<CalculateResult>();



                for (int i = 0; i < totalCourses; i++)
                {
                    var number = CalculateResult.AddOrdinal(i + 1);


                    Console.Clear();
                courseTitle:
                    Console.WriteLine($"\n**********< '{number}' COURSE >**********");

                    Console.Write($"\nEnter your '{number}' Course: ");
                    courseTitle = Console.ReadLine();
                    string format = @"(^[A-Za-z]{3}[0-9]{3}$)";

                    if (!Regex.IsMatch(courseTitle, format))
                    {

                        Console.Clear();

                        Console.WriteLine("\n**************************************************************************");
                        CustomMessage("\nOpps! Kindly Enter your course title in this format 'MAT101'", false);
                        goto courseTitle;
                    }


                    Console.Clear();
                courseUnit:

                    Console.WriteLine("\n**************************************************************************");
                    Console.Write($"\nEnter {courseTitle.ToUpper()}'s CourseUnit: ");
                    string CourseUnit = Console.ReadLine();
                    courseUnit[i] = 0;

                    if (!int.TryParse(CourseUnit, out courseUnit[i]) || courseUnit[i] <= 0 || courseUnit[i] > 6)
                    {
                        Console.Clear();

                        Console.WriteLine("\n**************************************************************************");
                        CustomMessage("\nInvalid entry! Please enter a valid Unit!!! (between 1 and 6)", false);
                        goto courseUnit;
                    }

                    Console.Clear();
                courseScore:

                    Console.WriteLine("\n**************************************************************************");
                    Console.Write($"\nWhat did you score in {courseTitle.ToUpper()}? : ");
                    string CourseScore = Console.ReadLine();
                    courseScore = 0;

                    if (!double.TryParse(CourseScore, out courseScore) || courseScore < 0)
                    {
                        Console.Clear();

                        Console.WriteLine("\n**************************************************************************");
                        CustomMessage("\nInvalid entry! Please enter valid a Score!!!", false);
                        goto courseScore;
                    }
                    else if (courseScore >= 70 && courseScore <= 100)
                    {
                        grade = 'A';
                        gradeUnit = 5;
                        remark = "Excellent";
                        weightPoint[i] = gradeUnit * courseUnit[i];
                    }
                    else if (courseScore >= 60 && courseScore <= 69)
                    {
                        grade = 'B';
                        gradeUnit = 4;
                        remark = "Very Good";
                        weightPoint[i] = gradeUnit * courseUnit[i];
                    }
                    else if (courseScore >= 50 && courseScore <= 59)
                    {
                        grade = 'C';
                        gradeUnit = 3;
                        remark = "Good";
                        weightPoint[i] = gradeUnit * CourseUnit[i];
                    }
                    else if (courseScore >= 45 && courseScore <= 49)
                    {
                        grade = 'D';
                        gradeUnit = 2;
                        remark = "Fair";
                        weightPoint[i] = gradeUnit * courseUnit[i];
                    }
                    else if (courseScore >= 40 && courseScore <= 44)
                    {
                        grade = 'E';
                        gradeUnit = 1;
                        remark = "Pass";
                        weightPoint[i] = gradeUnit * courseUnit[i];
                    }
                    else if (courseScore >= 0 && courseScore <= 39)
                    {
                        grade = 'F';
                        gradeUnit = 0;
                        remark = "Fail";
                        failedCourseUnit[i] = courseUnit[i];
                        weightPoint[i] = gradeUnit * courseUnit[i];
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine("\n**************************************************************************");
                        Console.ForegroundColor = ConsoleColor.Red;
                        CustomMessage($"\nYou can't score {courseScore}!\n Shey u no go school ni?!", false);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto courseScore;
                    }

                    CalculateResult compute = new CalculateResult(courseTitle, courseUnit[i], courseScore, weightPoint[i], grade, remark, gradeUnit, failedCourseUnit[i]);
                    Compute.Add(compute);
                }

                Console.Clear();
                PrintTable.StudentResult(Compute);
                Console.Clear();
                CalculateResult.Gpa(weightPoint.Sum(), courseUnit.Sum(), failedCourseUnit.Sum());
                StartApp.pass = false;


                Console.WriteLine("\nPress Enter to go back to MainMenu...");
                Console.ReadKey();

                //else
                //{
                //    StartApp.pass = false;
                //}
            }
        }
        public static void Gpa(double totalWeightPoint, int totalCourseUnit, int failedCourseUnit)
        {
            double gpa = totalWeightPoint / totalCourseUnit;
            int totalCourseUnitPassed = totalCourseUnit - failedCourseUnit;
            gpa = Math.Round(gpa, 2);

            Console.WriteLine("\n**************************************************************************");
            Console.WriteLine($"\nTotal Course Unit Registered is {totalCourseUnit}");
            Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPassed}");
            Console.WriteLine($"Total Weight Point is {totalWeightPoint}");
            Console.WriteLine($"Holla, Your GPA is: {gpa} ");
            Console.WriteLine("\n**************************************************************************");
            Console.WriteLine(gpa);
            Console.WriteLine("\n**************************************************************************\n\n");
        }


        public static void CustomMessage(string msg, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;

        }


        public static void PrintDotAnimation(int timer = 10)
        {

            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

    }
}
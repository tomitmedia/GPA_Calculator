using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Gpa_Calculator
{
    public class PrintTable
    {
       

        public static void StudentResult(List<CalculateResult> Compute)
        {
            Console.Write("Fetching Result"); CalculateResult.PrintDotAnimation();

            Console.WriteLine("\n**********< STUDENT RESULT >**********");


            Console.WriteLine("\n**************************************************************************");

            var table = new ConsoleTable($"COURSE & CODE", $" COURSE UNIT", $"GRADE", $"GRADE-UNIT", $"WEIGHT Pt.", $" REMARK");

            foreach (var result in Compute)
            {
                table.AddRow($"{result.courseTitle.ToUpper()}", $"{result.courseUnit}", $"{result.grade}", $"{result.gradeUnit}", $"{result.weightPoint}", $"{result.remark}");
            }
            
            Console.WriteLine(table);
            Console.WriteLine("\n**************************************************************************\n\n");


            Console.WriteLine("\nGuess you wanna see the breakdown\nPress Enter to print your GPA...");
            Console.ReadKey();
        }
    }
}



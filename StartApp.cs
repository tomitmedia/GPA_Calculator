using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Gpa_Calculator
{
    public static class StartApp
    {
        public static string studentName { get; set; }
        public static bool pass = true;
        public static bool pass2 = false;

        public static double weightPoint { get; set; }
        public static int courseUnit { get; set; }
        public static int failedCourseUnit { get; set; } 


        public static void Launch()
        {
            List<string> sName = new List<string>();

            Console.Clear();

            bool loopBreak = true;
            while (loopBreak == true)
            {
                Console.Clear();

                Console.WriteLine("\n*************************************************************************");
                CalculateResult.CustomMessage("\nRESULT PORTAL!!!", true);
            mainMenu:
                Console.WriteLine("\n*************************************************************************");
                Console.WriteLine("\nPress 1 to Calculate you GPA");
                Console.WriteLine("Press 2 to Reprint your Result");
                Console.WriteLine("Press 3 to Exit");

                string mainMenuInput = Console.ReadLine();
                int mainMenuInput2 = 0;

                if (int.TryParse(mainMenuInput, out mainMenuInput2))
                {
                    switch (mainMenuInput2)
                    {
                        case 1:
                            Console.Clear();
                        studentName:
                            Console.WriteLine("\n*************************************************************************");
                            Console.Write("Hi! What's your Name? :");
                            string userInput = Console.ReadLine();

                            StartApp.studentName = userInput.ToUpper();

                            Console.WriteLine(StartApp.studentName);

                            if (userInput == " " || userInput == string.Empty)
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                CalculateResult.CustomMessage("\nField can't be empty!!!",false);
                                Console.WriteLine("**************************************************************************");
                                goto studentName;

                            }
                            else if (userInput.Length <= 2)
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                CalculateResult.CustomMessage("\nUsername too short!!!", false);
                                Console.WriteLine("**************************************************************************");
                                goto studentName;
                            }
                            pass2 = true;
                            

                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            CalculateResult.CustomMessage($"{userInput.ToUpper()}! Welcome to Decagon-Tech-Park Result Portal...",true);
                            Console.WriteLine("*************************************************************************");
                            CalculateResult.Calculate();
                            break;

                        case 2:


                            Console.Clear();

                            Console.WriteLine("\n*************************************************************************");
                                Console.Write("Hi! What's your Name again? :");
                            string Username = Console.ReadLine();


                            if (StartApp.studentName != Username.ToUpper())
                            {
                                Console.WriteLine("\n*************************************************************************");
                                Console.ForegroundColor = ConsoleColor.Red;
                                CalculateResult.CustomMessage("\nResult not found!!! OR Incorrect Name!!!"
                               +"\nGo and Calculate it first!!! OR Enter your name again!!!",false);
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("**************************************************************************");
                                Console.WriteLine($"\n\n\nPress any Key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            CalculateResult.CustomMessage($"{StartApp.studentName}! Welcome back...",true);
                            Console.WriteLine("*************************************************************************");

                            CalculateResult.Calculate();

                            break;

                        case 3:
                            Console.WriteLine("\n*************************************************************************");
                            Console.Write("\nAre you sure you want to logout?  Y/N: ");
                            string choice = Console.ReadLine().ToUpper();
                            if (choice == "Y")
                            {

                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                Console.WriteLine("**************************************************************************");
                                Console.WriteLine("\nThank you for chosing Tech Way!");
                                loopBreak = false;
                                Environment.Exit(0);
                            }
                            else if (choice == "N")
                            {
                                Launch();
                            }


                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("**************************************************************************");
                            CalculateResult.CustomMessage("\nResponse can only be 'Y/N' ",false);
                            goto case 3;


                        default:
                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            CalculateResult.CustomMessage("\nChoose a number between 1 to 3!!!",false);
                            goto mainMenu;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*************************************************************************");
                    CalculateResult.CustomMessage("\nInvalid entry! Please enter a valid Number!!!",false);
                    goto mainMenu;
                }
            }
        }
    }
}




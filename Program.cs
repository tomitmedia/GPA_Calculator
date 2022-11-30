using System;

namespace Gpa_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                StartApp.Launch();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Hey! You just pressed the wrong key!");
                Console.WriteLine("--------------------------------------------------------------------------\n\n");
                Console.WriteLine("--------------------------------------------------------------------------\n\n");
            }
        }
    }
}


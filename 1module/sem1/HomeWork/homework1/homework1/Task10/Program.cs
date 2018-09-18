using System;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = "! ";
            string output = "";
            for (int i = 0; i < 3; ++i)
            {
                output += Console.ReadLine() + separator[i == 2 ? 1 : 0];
            }
            Console.WriteLine(output);

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}

using System;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            for (int i = 0; i < 3; ++i)
            {
                output += "-" + Console.ReadLine() + "-\n";
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}

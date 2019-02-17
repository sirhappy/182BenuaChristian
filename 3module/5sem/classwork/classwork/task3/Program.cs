using System;
using Figures;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Cone[] arr = new Cone[10];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Cone.MakeCone();
                    Console.WriteLine(arr[i]);
                }

                Console.WriteLine("ESC...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

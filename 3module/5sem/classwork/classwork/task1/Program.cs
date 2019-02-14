using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Figures;

namespace task1
{



    class Program
    {


        static void Main(string[] args)
        {
            do
            {
                int n = Reader.Read<int>("Enter number of circles", "Smth wrong with your input, reenter pls", (arg) => arg > 0 && arg <= 1000);

                List<Circle> circles = new List<Circle>();

                for (int i = 0; i < n; ++i)
                {
                    circles.Add(Circle.ReadCircle());
                    Console.WriteLine($"{i}th circle is {circles.Last()}");
                }

                circles.Sort((current, other) => (current.Radius * (current.Center.Distance(new Point(0, 0))))
                .CompareTo(other.Radius * (other.Center.Distance(new Point(0, 0)))));

                Console.WriteLine("\nAfter sorting\n");

                circles.ForEach((arg) => Console.WriteLine(arg));

                Console.WriteLine("To exit press esc");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}

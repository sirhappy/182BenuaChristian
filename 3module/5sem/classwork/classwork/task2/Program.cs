using System;
using Figures;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("enter points of triangle");
                Point a = Point.ReadPoint();
                Point b = Point.ReadPoint();
                Point c = Point.ReadPoint();
                Triangle triangle = new Triangle(a, b, c);

                int n = Reader.Read<int>("Enter number of points you want to check", "smth wrond, renter pls", (arg) => arg > 0 && arg < 100);

                for (int i = 0; i < n; ++i) 
                {
                    Point p = Point.ReadPoint();

                    if (triangle.IsPointInside(p))
                    {
                        Console.WriteLine("Inside");
                    } 
                    else
                    {
                        Console.WriteLine("Outside");
                    }
                }

                Console.WriteLine("ESC...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

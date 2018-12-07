using System;
using mylib;
namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticTrinomial a = new QuadraticTrinomial(2, 3, 7);
            QuadraticTrinomial b = new QuadraticTrinomial(1, -5, 6);

            int[] points = { 1, -3, 3, 2, 7, 100, 0 };
            for (int i = 0; i < points.Length; ++i) {
                try {
                    Console.WriteLine(a.Divide(points[i], b));
                } catch (DivideByZeroException ex) {
                    Console.WriteLine("Divide By zero happened: ");
                    Console.WriteLine(ex.Message);
                } catch (OverflowException ex) {
                    Console.WriteLine("Overflow exception happened:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

using System;
using mylib;

namespace classwork
{
    class Program
    {

        public static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] Eye(int n) {
            if (n <= 0) {
                throw new ArgumentOutOfRangeException(nameof(n), "The size of matrix cannot be negative or zero");
            }
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; ++i) {
                arr[i, i] = 1;
            }
            return arr;
        }

        static void Main(string[] args)
        {
            do
            {
                int n;
                double b, q;
                GeomProgr g;
                try {

                    Console.WriteLine("Enter b");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine("enter q");
                    q = double.Parse(Console.ReadLine());
                    g = new GeomProgr(b, q);
                    do
                    {
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("The sum is " + g.GetSum(n));
                        Console.WriteLine("The n-th element is " + g[n]);
                        Console.WriteLine("To exit press esc");
                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                } catch (ArgumentOutOfRangeException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                } catch (OverflowException ex) {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine(GeomProgr.objectNumber);
        }
    }
}

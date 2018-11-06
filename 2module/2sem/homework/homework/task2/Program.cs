using System;

namespace task2
{



    class Point {
        public double X {
            get;set;
        }

        public double Y {
            get;set;
        }

        public double Rho {
            get {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public double Phi {
            get {
                return Math.Atan2(Y, X);
            }
        }

        public Point() {
            X = Y = 0;
        }

        public Point(double x, double y) {
            X = x;
            Y = y;
        }

        public string PointData {
            get {
                return string.Format("X = {0:F2}, Y = {1:F2}, Rho = {2:F2}, Phi = {3:F2}", X, Y, Rho, Phi);
            }
        }
    }

    class Program
    {

        public static double ReadDouble(string In, string Out, Func<double, bool> valid) {
            Console.WriteLine(In);
            double n;
            while (!(double.TryParse(Console.ReadLine(), out n) && valid(n))) {
                Console.WriteLine(Out);
            }
            return n;
        }

        static void Main(string[] args)
        {
            do
            {
                Point a, b, c;
                a = new Point(3, 4); Console.WriteLine(a.PointData);
                b = new Point(0, 3); Console.WriteLine(b.PointData); c = new Point();
                double x = 0, y = 0;
                do
                {
                    x = ReadDouble("X = ", "Smth wrong with your input, reenter \n X = ", (arg) => true);
                    y = ReadDouble("Y = ", "Smth wrong with your input, reenter \n X = ", (arg) => true);
                    c.X = x; c.Y = y;
                    var arr = new Point[] { a, b, c };
                    Array.Sort(arr, (l, r) => Math.Abs(l.Rho - r.Rho) < 1e-9 ? 0 : (l.Rho < r.Rho) ? -1 : 1);
                    foreach (var el in arr)
                    {
                        Console.WriteLine(el.PointData);
                    }
                } while (x != 0 | y != 0);
                Console.WriteLine("To exit press Escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

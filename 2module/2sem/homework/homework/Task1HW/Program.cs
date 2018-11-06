using System;

namespace Task1HW
{
    public class Circle {
        private double _r;

        public double R {
            get {
                return _r;
            }
            set {
                _r = value;
            }
        }

        public Circle() {
            _r = 1;
        }

        public Circle(double r) {
            _r = r;
        }

        public double S {
            get {
                return Math.PI * R * R;
            }
        }
    }

    class Program
    {

        public static double ReadDouble(string In, string Out, Func<double, bool> valid)
        {
            Console.WriteLine(In);
            double n;
            while (!(double.TryParse(Console.ReadLine(), out n) && valid(n)))
            {
                Console.WriteLine(Out);
            }
            return n;
        }

        static void Main(string[] args)
        {
            do
            {
                double xmin = ReadDouble("xmin : ", "Smth wrong with your input, reenter \n xmin : ", (arg) => arg > 0);
                double xmax = ReadDouble("xmax : ", "Smth wrong with your input, reenter \n xmax : ", (arg) => arg > 0 && arg > xmin);

                double delta = ReadDouble("delta : ", "Smth wrong with your input, reenter \n delta : ", (arg) => (xmax - xmin) / arg < 1e8);
                Circle c = new Circle();
                for (double curr = xmin; curr <= xmax; curr += delta) {
                    c.R = curr;
                    Console.WriteLine("R : {0:F2}, S : {1:F2}", curr, c.S);
                }
                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

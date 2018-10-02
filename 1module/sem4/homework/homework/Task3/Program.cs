using System;


class Program
{
    public static double beg = 1.0;
    public static double end = 2.0;
    public static double interc = 1.2;
    public static double eps = 1e-9;
    public static double dx = 0.05;

    public static double Eval(double a, double b, double c, double x) {
        if (x < interc && Math.Abs(x - interc) > eps) {
            return a * x * x + b * x + c;
        } else if (Math.Abs(x - interc) < eps) {
            return a / x + Math.Sqrt(x * x + 1);
        } else {
            return (a + b * x) / (Math.Sqrt(x * x + 1));
        }
    }

    public static void Tabulate(double a, double b, double c) {
        for (double t = beg; t <= end; t += dx) {
            Console.WriteLine("X:{0}, value:{1}", t, Eval(a, b, c, t));
        }
    }

    static void Main(string[] args)
    {

        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter A,B,C values");
            double a, b, c;
            while(!double.TryParse(Console.ReadLine(), out a)) {
                Console.WriteLine("Smth wrong with your input, Reenter A");
            }

            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Smth wrong with your input, Reenter B");
            }

            while (!double.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Smth wrong with your input, Reenter C");
            }
            Tabulate(a, b, c);

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);

    }
}


using System;
/*
 * БПИ 182
 * БЕнуа Кристиан
 * Задание 4 семинар 3
 * Корень по формулю ньютона
 * 
 * */

class Program
{
    public static double nextValue(double value, double A) {
        return 0.5 * ((value) + A / value);
    }
    public static bool NewtonApprox(double A, double eps, out double value) {
        double approx = A / 2;
        if (A < 0) {
            value = -1;
            return false;
        }
        double nextOne;
        while (true) {
            nextOne = nextValue(approx, A);
            if (Math.Abs(nextOne - approx) < eps) {
                value = nextOne;
                break;
            }
            approx = nextOne;
        }
        return true;
    }
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter A value and EPS: ");
            double A, eps;
            while (!double.TryParse(Console.ReadLine(), out A)) {
                Console.WriteLine("REenter A value, There was some issue with your Input");
            }

            while (!(double.TryParse(Console.ReadLine(), out eps) && eps > 0))
            {
                Console.WriteLine("REenter Eps value, There was some issue with your Input");
            }
            bool success;
            double ans;
            success = NewtonApprox(A, eps, out ans);
            if (!success) {
                Console.WriteLine("You entered negative A");
            } else {
                Console.WriteLine("Approx of square root: " + ans.ToString("F6"));
            }
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


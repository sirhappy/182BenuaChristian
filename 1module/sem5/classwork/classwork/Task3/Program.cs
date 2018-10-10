using System;


class Program
{
    public static double[] MaclourenCoefficients(int n)
    {
        double[] ans = new double[n];
        double currFact = 1;
        for (int i = 0; i < n; ++i) {
            ans[i] = 1 / currFact;
            if (i % 2 == 1) {
                ans[i] *= -1;
            }
            currFact *= (2 * (i + 1)) * (2 * (i + 1) + 1);
        }
        return ans;
    }

    public static double SinusMaclouren(double[] coeff, double x) {
        x %= (2 * Math.PI);
        double currPow = x;
        double ans = 0;
        for (int i = 0; i < coeff.Length; ++i) {
            ans += currPow * coeff[i];
            currPow *= x * x;
        }
        return ans;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter number of item in Maclouren Series");
            int n;
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0 && n < 1e8))
            {
                Console.WriteLine("Smth wrong with your input, reenter number of items");
            }
            double[] coeffs = MaclourenCoefficients(n);

            int numberOfXes;
            Console.WriteLine("enter number of x values you want to check");
            while (!(int.TryParse(Console.ReadLine(), out numberOfXes) && n > 0))
            {
                Console.WriteLine("Smth wrong with your input, reenter number of Xes");
            }

            for (int i = 0; i < numberOfXes; ++i) {
                double x;
                Console.WriteLine("Enter x value");
                while (!double.TryParse(Console.ReadLine(), out x)) {
                    Console.WriteLine("Smth wrong with your x value");
                }
                Console.WriteLine("My value:{0}, Math.Sin Value:{1}", SinusMaclouren(coeffs, x), Math.Sin(x));
            }
            Console.WriteLine("To exit press escape");

            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


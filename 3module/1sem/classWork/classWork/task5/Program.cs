using System;

namespace task5
{
    class Program
    {

        delegate double Sum(double x);

        delegate double InnerSum(double x, double i);

        delegate double SummedFunction(double x, double i, double j);

        const int maxI= 5;
        const int maxJ = 5;

        public static double Check(double x)
        {
            double res = 0;
            for (int i = 1; i <= maxI; ++i)
            {
                double mult = 1;
                for (int j = 1; j <= maxJ; ++j)
                {
                    mult *= i * x / j;
                }
                res += mult;
            }
            return res;
        }

        static void Main(string[] args)
        {
            SummedFunction summator = (x, i, j) => x * i / j;
            InnerSum innerMult = (x, i) =>
            {
                double res = 1;
                for (int j = 1; j <= maxI; ++j)
                {
                    res *= summator(x, i, j);
                }
                return res;
            };

            Sum outerSum = (x) =>
            {
                double res = 0;
                for (int i = 1; i <= maxJ; ++i)
                {
                    res += innerMult(x, i);
                }
                return res;
            };

            Console.WriteLine(outerSum(1));
            Console.WriteLine(Check(1));
        }
    }
}

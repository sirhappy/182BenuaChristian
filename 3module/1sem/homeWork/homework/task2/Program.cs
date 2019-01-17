using System;

namespace task2
{

    delegate double Sum(int n);

    public class Iteratable
    {
        public double this[int ind]
        {
            get
            {
                return 1.0 / ind;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Iteratable obj = new Iteratable();
            Sum innerSummation = (int upperbound) =>
            {
                double ans = 0;
                for (int i = 1; i <= upperbound; ++i)
                {
                    ans += obj[i];
                }
                return ans;
            };

            Sum outerSummation = (int upperbound) =>
            {
                double ans = 0;

                for (int i = 1; i <= upperbound; ++i)
                {
                    ans += innerSummation(i);
                }
                return ans;
            };
            do
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(outerSummation(n));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

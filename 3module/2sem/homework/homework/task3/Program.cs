using System;

namespace task3
{
    class Program
    {

        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            double[] arr = new double[10];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rnd.NextDouble() * 6 - 3;
            }

            int[] b = Array.ConvertAll<double, int>(arr, (a) => Math.Max(0, (int)(a)));

            Array.ForEach(arr, (el) => Console.Write($"{el:f2}  "));
            Array.ForEach(b, (el) => Console.Write(el + "  "));
        }
    }
}

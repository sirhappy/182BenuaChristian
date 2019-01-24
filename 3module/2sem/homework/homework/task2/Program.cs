using System;

namespace task2
{
    class Program
    {
        public static Random rnd = new Random();


        static void Main(string[] args)
        {
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rnd.Next(1, 20);
            }

            var arr1 = Array.ConvertAll<int, double>(arr, (inp) => 1.0/inp);

            Array.ForEach(arr, (el) => Console.Write(el.ToString() + "  "));
            Array.ForEach(arr1, (el) => Console.Write($"{el:f2}  "));

        }
    }
}

using System;

namespace homework
{
    class Program
    {
        public static Random rnd = new Random();


        static void Main(string[] args)
        {
            int[] arr = new int[15];
            for(int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rnd.Next(-15, 16);
            }

            Array.Sort(arr, (x, y) => Math.Abs(x).CompareTo(Math.Abs(y)));
            Array.ForEach(arr, (x) => Console.Write(x.ToString().PadRight(4)));
        }
    }
}

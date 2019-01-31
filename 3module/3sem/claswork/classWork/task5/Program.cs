using System;

namespace task5
{

    public class ArrayExtension
    {
        public static Random rnd = new Random();

        public static Action NewLineEvent;
        public static Action<int[,]> NewItemFilled;

        public static void Print(int[,] arr)
        {
            int cnt = 1;
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(0); ++j, cnt++)
                {
                    Console.Write(arr[i, j] + " ");
                    if (cnt % 5 == 0)
                    {
                        NewLineEvent();
                    }
                }
            }
        }

        public static void Fill(int[,] arr)
        {
            //int sum = 0;
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    arr[i, j] = rnd.Next(10, 15);
                    //sum += arr[i, j];
                    NewItemFilled(arr);
                }
            }
        }
    }

    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            ArrayExtension.NewLineEvent += () => Console.WriteLine();
            ArrayExtension.NewItemFilled += (arr) =>
            {
                int sum = 0;
                foreach (var el in arr)
                {
                    sum += el;
                }
                Console.WriteLine("Sum is :" + sum);
            };
            int max = int.MinValue;

            ArrayExtension.NewItemFilled += (arr) =>
            {
                foreach (var el in arr)
                {
                    max = Math.Max(el, max);
                }
                Console.WriteLine("Max is: " + max);
            };

            ArrayExtension.NewItemFilled += (arr) =>
            {
                int sum = 0;
                foreach (var el in arr)
                {
                    sum += el;
                }
                Console.WriteLine("Average is : " + (double)sum / arr.LongLength);
            };

            int[,] rndArr = new int[4, 4];
            ArrayExtension.Fill(rndArr);
            ArrayExtension.Print(rndArr);
        }
    }
}

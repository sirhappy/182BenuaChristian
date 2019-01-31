using System;

namespace task7
{
    class ArraySort
    {
        public static Random rnd = new Random();

        int[] arr = new int[0];

        public event Action<int, int, int> OnInnerLoopCompleted;

        public ArraySort(int[] a)
        {
            arr = new int[a.Length];
            a.CopyTo(arr, 0);
            PrintArray();
        }

        public ArraySort()
        {
            arr = new int[50];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rnd.Next(1, 10);
            }
            PrintArray();
        }

        public void PrintArray()
        {
            Array.ForEach(arr, (el) => Console.WriteLine(el + " "));
            Console.WriteLine();
        }

        public void Sort()
        {
            int swapCnt = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 1; j < arr.Length - i; ++j)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                        swapCnt++;
                    }
                }

                OnInnerLoopCompleted?.Invoke(arr.Length, swapCnt, i);

            }
            PrintArray();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ArraySort array = new ArraySort();
            array.OnInnerLoopCompleted += PrintProgressBar;
            array.OnInnerLoopCompleted += (int arrLength, int swapCnt, int iteratrion) => { Console.WriteLine($"Swaps on {iteratrion}th iteration: {swapCnt}"); };
            array.Sort();
       }

        public static void PrintProgressBar(int arrLength, int swapCnt, int iteration)
        {
            Console.WriteLine("|" + new string('\u25A1', (iteration + 1)) + new string('\u2022', arrLength - iteration - 1) + "|");
        }

    }
}

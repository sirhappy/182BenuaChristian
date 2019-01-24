using System;

namespace task5
{
    class Series
    {
        public int[] arr { get; private set; }

        public Series()
        {
            arr = new int[0];
        }

        public Series(int n)
        {
            arr = new int[n];
        }

        public Series(int[] arrToCopy)
        {
            arr = new int[arrToCopy.Length];
            arrToCopy.CopyTo(arr, 0);
        }

        public void Order(Comparison<int> func)
        {
            Array.Sort(this.arr, func);
        }

        public void Print()
        {
            Array.ForEach(arr, (el) => Console.WriteLine(el + " "));
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Series series = new Series(new int[10] { 1, 2, 3, 4, 5 ,6,7,8,9,10});

            series.Order((x, y) => -x.CompareTo(y));

            series.Print();

            series.Order((x, y) => (x % 5).CompareTo(y % 5));
            series.Print();

            
        }
    }
}

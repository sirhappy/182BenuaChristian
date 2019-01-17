using System;

namespace task2
{

    delegate int[] Method1(int a);

    delegate void Method2(int[] a);

    class Program
    {
        static void Main(string[] args)
        {
            Method1 createArray = (x) =>
            {
                int[] a = new int[5];
                for (int i = 0; i < a.Length; ++i) {
                    a[i] = x * (i + 1);
                }
                return a;
            };

            Method2 printArray = (x) =>
            {
                foreach (var el in x)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
            };

            var array = createArray(5);
            printArray(array);

            var array2 = createArray(10);
            printArray(array2);
        }
    }
}

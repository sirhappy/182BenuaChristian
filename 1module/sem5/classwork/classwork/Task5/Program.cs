using System;

class Program
{

    public static void Compress(ref int[] arr) {
        int pt = 0;
        for (int i = 0; i < arr.Length; ++i) {
            if (arr[i] % 2 != 0) {
                arr[pt++] = arr[i];
            }
        }
        if (pt > 0) {
            Array.Resize(ref arr, pt);
        }
    }

    public static void print<T>(T[] arr)
    {
        for (int i = 0; i < arr.Length; ++i)
        {
            Console.WriteLine("[{0}] : {1}   ", i, arr[i]);
        }
        //Console.WriteLine();
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int n;
            Console.WriteLine("Enter size of array");
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0)) {
                Console.WriteLine("Smth wrong with your input, reenter size of array");
            }
            Random random = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i) {
                arr[i] = random.Next(-10, 11);
            }
            print<int>(arr);
            Compress(ref arr);
            Console.WriteLine("Result");
            print<int>(arr);

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

using System;

class Program
{

    public static int Compress(ref int[] arr)
    {
        int pt = 0;
        int cnt = 0;
        int i;
        for (i = 0; i < arr.Length - 1; ++i)
        {
            if ((arr[i] + arr[i + 1]) % 3 == 0)
            {
                arr[pt++] = arr[i] * arr[i + 1];
                i++;
               cnt++;
            } else {
                arr[pt++] = arr[i];
            }
        }
        if (i == arr.Length - 1) {
            arr[pt++] = arr[i];
        }
        if (pt > 0)
        {
            Array.Resize(ref arr, pt);
        }
        return cnt;
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
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Smth wrong with your input, reenter size of array");
            }
            Random random = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = random.Next(-10, 11);
            }
            print<int>(arr);
            Console.WriteLine("Compressed {0} times", Compress(ref arr));
            Console.WriteLine("Result");
            print<int>(arr);

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

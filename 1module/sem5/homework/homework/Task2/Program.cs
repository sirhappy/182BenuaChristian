using System;

class Program
{
    public static void fill(long[] arr)
    {
        for (int i = 0; i < arr.Length; ++i)
        {
            arr[i] = (i * 2 + 1);
        }
    }
    public static void print<T>(T[] arr, char delim = ' ')
    {
        for (int i = 0; i < arr.Length; ++i)
        {
            Console.Write(arr[i].ToString() + delim.ToString());
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter array's size");

            int n;
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Smth wrong with input, reenter");
            }

            long[] arr = new long[n];
            fill(arr);

            print<long>(arr);

            Console.WriteLine("TO exit press esc");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


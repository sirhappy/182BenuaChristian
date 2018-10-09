using System;

class Program
{
    public static void fill(long[] arr, int a, int d)
    {
        for (int i = 0; i < arr.Length; ++i)
        {
            arr[i] = a + d * i;
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
            Console.WriteLine("Enter array's size, A, D");

            int n;
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 1 && n < 62))
            {
                Console.WriteLine("Smth wrong with input, reenter");
            }
            int a, d;

            while (!(int.TryParse(Console.ReadLine(), out a)))
            {
                Console.WriteLine("Smth wrong with input, reenter");
            }
            while (!(int.TryParse(Console.ReadLine(), out d)))
            {
                Console.WriteLine("Smth wrong with input, reenter");
            }


            long[] arr = new long[n];
            fill(arr, a, d);

            print<long>(arr);

            Console.WriteLine("TO exit press esc");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


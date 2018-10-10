using System;
using System.Collections.Generic;

class Program
{

    public static int[] getArray(int first) {
        List<int> arr = new List<int>()
        {
            first
        };
        for (int i = 1; ; ++i) {
            arr.Add(arr[i - 1] % 2 == 0 ? arr[i - 1] / 2 : (3 * arr[i - 1] + 1));
            if (arr[i] == 1) {
                break;
            }
            if (i % 10 == 0) {
                Console.WriteLine(i);
            }
        }
        return arr.ToArray();
    }

    public static void print<T>(T[] arr)
    {
        for (int i = 0; i < arr.Length; ++i) {
            Console.Write("[{0}] : {1}   ", i, arr[i]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter A0");
            int a0;
            while (!(int.TryParse(Console.ReadLine(), out a0) && a0 > 0)) {
                Console.WriteLine("Smth wrong with your input, reenter a0 value");
            }
            print<int>(getArray(a0));

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


using System;

class Program
{

    public static char[] getDigits(int n)
    {
        System.Collections.Generic.List<char> dig = new System.Collections.Generic.List<char>();
        while (n > 0)
        {
            dig.Add((char)(n % 10 + '0'));
            n /= 10;
        }
        char[] ans = dig.ToArray();
        Array.Reverse(ans);
        return ans;
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
            Console.WriteLine("Enter number");
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Smth wrong with your input, reenter size of array");
            }

            Console.WriteLine("Result");
            print<char>(getDigits(n));

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

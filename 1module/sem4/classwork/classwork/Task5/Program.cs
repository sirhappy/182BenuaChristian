using System;

class Program
{

    public static void Print(int k) {
        double sum = 0;
        for (int i = 1; i <= k; ++i) {
            sum += (i + 0.3) / (3 * i * i + 5);
            Console.WriteLine("K : {0}, val: {1}", i, sum.ToString("F3"));
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter Int value");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n)) {
                Console.WriteLine("Smth wrong with your input");
            }
            Print(n);
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


using System;

class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int n, m;
            Console.WriteLine("Enter n, m <= 60");

            while (!int.TryParse(Console.ReadLine(), out n) && n <= 60)
            {
                Console.WriteLine("Smth wrong with your input, Reenter n");
            }

            while (!int.TryParse(Console.ReadLine(), out m) && m <= 60)
            {
                Console.WriteLine("Smth wrong with your input, Reenter m");
            }
            Console.WriteLine("Result is : " + (long)((1l << n) + (1l << m)));
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


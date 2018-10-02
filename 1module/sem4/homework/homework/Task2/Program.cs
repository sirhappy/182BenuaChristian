using System;


class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("enter numbers...");

            int x;
            int cntNeg = 0;
            int sumNeg = 0;
            while (sumNeg >= -1000)
            {
                while (!(int.TryParse(Console.ReadLine(), out x)))
                {
                    Console.WriteLine("smth wrong with your input, reenter value");
                }
                if (x < 0) {
                    cntNeg++;
                    sumNeg += x;
                }
                ConsoleKeyInfo keyInfo2;
                Console.WriteLine("To finish entering press Q");


                keyInfo2 = Console.ReadKey(true);
                if (keyInfo2.Key == ConsoleKey.Q) {
                    break;
                }
            }
            Console.WriteLine("Neagtive average : " + (sumNeg / (double)cntNeg).ToString("F3"));


            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

using System;

class Program
{

    public static void Sums(uint number, out uint sumEven, out uint sumOdd) {
        sumEven = sumOdd = 0;
        string str = number.ToString();
        for (int i = 0; i < str.Length; i += 2) {
            sumEven += (uint)(str[i] - '0');
        }
        for (int i = 1; i < str.Length; i += 2) {
            sumOdd += (uint)(str[i] - '0');
        }
    } 

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter Int value");
            uint number;
            while (!uint.TryParse(Console.ReadLine(), out number)) {
                Console.WriteLine("Smth wrong with yout input");
            }
            uint sumOdd = 0;
            uint sumEven = 0;
            Sums(number, out sumEven, out sumOdd);
            Console.WriteLine("sumEven: {0}, sumOdd: {1}", sumEven, sumOdd);
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


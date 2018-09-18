using System;
/*БПИ182
 * Кристиан Бенуа
 * Получить от пользователя четырехзначное натуральное число и напечатать его цифры в обратном порядке
 */


class Program
{

    static void PrintDigitsInReversedOrder(int number) {
        while (number > 0) {
            Console.WriteLine(number % 10);
            number /= 10;
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int number;
            Console.WriteLine("Enter the number");
            while (!int.TryParse(Console.ReadLine(), out number) && number > 999 && number < 10000)
            {
                Console.WriteLine("Comething wrong with your input, Reenter value");
            }
            PrintDigitsInReversedOrder(number);
            Console.WriteLine("To exit press Escape");

            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);

    }
}


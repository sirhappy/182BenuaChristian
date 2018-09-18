using System;
/*БПИ182
 * Кристиан Бенуа
 * Ввести трехзначное натуральное число и напечатать его цифры "столбиком".
 */


class Program
{
    public static void GetDigits(int n) {
        Console.WriteLine(n / 100);
        Console.WriteLine((n / 10) % 10);
        Console.WriteLine(n % 10);
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int n;
            Console.WriteLine("Enter the number");
            while (!(int.TryParse(Console.ReadLine(), out n) && n >= 100 && n < 1000)) {
                Console.WriteLine("Something wrong with input, Reenter pls");
            }
            GetDigits(n);
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


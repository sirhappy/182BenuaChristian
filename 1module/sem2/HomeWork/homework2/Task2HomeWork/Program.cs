using System;
/*БПИ182
 * Кристиан Бенуа
 * Ввести натуральное трехзначное число Р. Найти наибольшее целое число, которое можно получить, переставляя цифры числа Р.
 */


class Program
{

    public static void maxNumberFromDigits(int p) {
        int x = p % 10;
        int y = (p / 10) % 10;
        int z = p / 100;

        if (x < y) {
            int temp = y;
            y = x;
            x = temp;
        }
        if (x < z) {
            int temp = z;
            z = x;
            x = temp;
        }
        if (y < z) {
            int temp = z;
            z = y;
            y = temp;
        }
        Console.WriteLine("{0}{1}{2}", x, y, z);
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter the number: ");
            int p;
            while (!(int.TryParse(Console.ReadLine(), out p)) && p >= 100 && p < 1000)
            {
                Console.WriteLine("Something wrong wuth input, reenter pls");
            }
            Console.WriteLine("Max number from these digits");
            maxNumberFromDigits(p);
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);

    }
}


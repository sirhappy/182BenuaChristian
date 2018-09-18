using System;

/*БПИ182
 * Кристиан Бенуа
 * Получить от пользователя вещественное значение – бюджет пользователя и целое число – процент бюджета,
 * выделенный на компьютерные игры. Вычислить и вывести на экран сумму в рублях\евро или долларах, выделенную
 * на компьютерные игры. Использовать спецификаторы формата для валют.
 */

class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            double budget;
            double percent;
            Console.WriteLine("Enter the budget and percent you want to spend");
            while (!(double.TryParse(Console.ReadLine(), out budget) && budget >= 0))
            {
                Console.WriteLine("Smth wrong with your input, reenter Budget pls");
            }
            while (!(double.TryParse(Console.ReadLine(), out percent) && percent >= 0 && percent <= 100))
            {
                Console.WriteLine("Smth wrong with your input, reenter percent pls");
            }
            Console.WriteLine((budget * percent / 100).ToString("C3"));
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


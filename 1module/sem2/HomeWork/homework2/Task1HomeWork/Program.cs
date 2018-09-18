using System;
/*БПИ182
 * Кристиан Бенуа
 * Ввести значение x и вывести значение полинома: F(x) = 12x4 + 9x3 - 3x2 + 2x – 4
 */

class Program
{

    public static double EvaluateFunction(double x) {
        return x * (x * (x * (12 * x + 9) - 3) + 2) - 4;

    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter x Number");
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Smth wrong with input, reenter pls");
            }
            Console.WriteLine($"F({x}) = {EvaluateFunction(x)}");
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


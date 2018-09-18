using System;
/*БПИ182
 * Кристиан Бенуа
 * Получить от пользователя три вещественных числа и проверить для них неравенство треугольника. Оператор if не применять.
 */

class Program
{

    public static void Sort(ref double x, ref double y, ref double z) {
        double a1 = x < y ? (z < x ? z : x) : (y < z ? y : z);
        double a3 = x > y ? (z > x ? z : x) : (y > z ? y : z);
        double a2 = x + y + z - a1 - a3;
    }

    public static void validateTriangle(double a, double b, double c) {
        Sort(ref a, ref b, ref c);
        string report = a + b > c ? "Valid " : "Invalid ";
        report += "Triangle";
        Console.WriteLine(report);
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            double a, b, c;
            Console.WriteLine("Enter three Lengths of edges in Triangle");
            while (!(double.TryParse(Console.ReadLine(), out a)))
            {
                Console.WriteLine("Something wrong with input, Reenter first edge Length pls");

            }

            while (!(double.TryParse(Console.ReadLine(), out b)))
            {
                Console.WriteLine("Something wrong with input, Reenter second edge Length pls");

            }

            while (!(double.TryParse(Console.ReadLine(), out c)))
            {
                Console.WriteLine("Something wrong with input, Reenter third edge Length pls");
            }
            validateTriangle(a, b, c);
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

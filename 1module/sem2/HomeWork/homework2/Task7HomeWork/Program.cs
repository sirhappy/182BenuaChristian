using System;

/*БПИ182
 * Кристиан Бенуа
 * Написать программу с использованием двух методов. Первый метод возвращает дробную и целую часть числа.
 * Второй метод возвращает квадрат и корень из числа. В основной программе пользователь вводит дробное число
 */


class Program
{
    static void FractionalAndIntParts(double d, out double fractPart, out int intPart) {
        intPart = (int)d;
        fractPart = d - intPart;
    }

    static void SquareRootAndSquare(double d, out double root, out double square) {
        if (d < 0) {
            root = -1;
        } else {
            root = Math.Sqrt(d);
        }
        square = d * d;
    }
    
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter the number");
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Smth wrong with input, Reenter pls");
            }
            double fract, root, sqaure;
            int intPart;
            FractionalAndIntParts(number, out fract, out intPart);
            SquareRootAndSquare(number, out root, out sqaure);
            string report = Math.Abs(root  + 1.0) < 1e-9 ? "Square Root Doesnt Exist" : root.ToString("F3");

            Console.WriteLine("Fract part: {0:F3}, Int Part: {1}, SqRoot: {2:F3}, Square {3:F3}", fract, intPart, report , sqaure);
            Console.WriteLine("To exit press Esc");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

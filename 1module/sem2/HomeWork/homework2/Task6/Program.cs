using System;
/*БПИ182
 * Кристиан Бенуа
 * Задан круг с центром в начале координат и радиусом R=10.
 * Ввести координаты точки и вывести сообщение: «Точка внутри круга!» или «Точка вне круга!».
 */

class Program
{

    public static bool isInsideTheCircle(double x, double y, double radius) {
        return x * x + y * y <= radius * radius;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            double radius = 10;
            double x, y;
            Console.WriteLine("Enter X coordinate");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Smth wrong with input, reenter x coordinate");
            }

            Console.WriteLine("Enter Y coordinate");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Smth wrong with input, reenter Y coordinate");
            }

            if (isInsideTheCircle(x, y, radius))
            {
                Console.WriteLine("Point Inside the circle");
            }
            else
            {
                Console.WriteLine("Point Outside the circle");
            }
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


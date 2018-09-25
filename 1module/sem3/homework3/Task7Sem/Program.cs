using System;
/*
 * БПИ 182
 * БЕнуа Кристиан
 * Задание 7 семинар 3
 * Вещественные корни КвУра
 * */

class Program
{

    public static bool Solve(double a, double b, double c, out double root1, out double root2) {
        double d = b * b - 4 * a * c;
        if (d < 0) {
            root1 = root2 = -1;
            return false;
        }
        root1 = (-b - Math.Sqrt(d)) / (2 * a);
        root2 = (-b + Math.Sqrt(d)) / (2 * a);
        return true;

    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            double a, b, c, root1, root2;
            bool success;
            Console.WriteLine("Enter A, B, C");
            //Если A = 0, то по определению это не КвУр
            while (!(double.TryParse(Console.ReadLine(), out a) && a != 0))
            {
                Console.WriteLine("Smth wrong with input, Reenter A");
            }
            while (!(double.TryParse(Console.ReadLine(), out b)))
            {
                Console.WriteLine("Smth wrong with input, Reenter B");
            }
            while (!(double.TryParse(Console.ReadLine(), out c)))
            {
                Console.WriteLine("Smth wrong with input, Reenter C");
            }
            success = Solve(a, b, c, out root1, out root2);
            if (!success) {
                Console.WriteLine("No roots exists");
            }
            else if (Math.Abs(root1 - root2) < 1e-9) {
                Console.WriteLine("One root " + root1.ToString("F3"));
            } else {
                Console.WriteLine("Two roots " + root1.ToString("F3") + "  " +  root2.ToString("F3"));
            }
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


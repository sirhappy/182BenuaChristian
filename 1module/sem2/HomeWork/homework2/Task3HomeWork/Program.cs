using System;
using System.Numerics;
/*БПИ182
 * Кристиан Бенуа
 *  Введя значения коэффициентов А, В, С, вычислить корни квадратного уравнения. Учесть (как хотите) возможность появления комплексных корней. Оператор if не применять
 */

class Program
{

    public static void AnalizeEquation(int a, int b, int c, out Complex root1, out Complex root2) {
        double d = b * b - 4 * a * c;
        root1 = d >= 0 ? new Complex((-b + Math.Sqrt(d)) / (2 * a), 0) : Complex.FromPolarCoordinates(Math.Sqrt((double)c / a), Math.Acos((-b) / (2 * Math.Sqrt(a * c))));
        root2 = d >= 0 ? new Complex((-b - Math.Sqrt(d)) / (2 * a), 0) : Complex.FromPolarCoordinates(Math.Sqrt((double)c / a), -Math.Acos((-b) / (2 * Math.Sqrt(a * c))));
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter three coefficients");
            int a, b, c;
            while (!(int.TryParse(Console.ReadLine(), out a) && a != 0))
            {
                Console.WriteLine("Something wrong with input, Reenter A pls");
            }

            while (!(int.TryParse(Console.ReadLine(), out b)))
            {
                Console.WriteLine("Something wrong with input, Reenter B pls");
            }

            while (!(int.TryParse(Console.ReadLine(), out c)))
            {
                Console.WriteLine("Something wrong with input, Reenter C pls");
            }
            Complex root1, root2;
            AnalizeEquation(a, b, c, out root1, out root2);

            string output = (root1.Equals(root2) ? "One root: " + root1 : "Two roots: " + root1 + ", " + root2);
            Console.WriteLine(output);
            
            Console.WriteLine("To exit press Esc");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


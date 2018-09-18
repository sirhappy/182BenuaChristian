using System;

/*БПИ182
 * Кристиан Бенуа
 * Задан круг с центром в начале координат и радиусом R=10.
 * Вычисление значения логической функции !(X&Y|Z)
 */
class Program
{

    public static bool EvaluateExpression(bool x, bool y, bool z) {
        return !(x && y || z);
    }
 
    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter X Y Z values");
            bool x, y, z;
            int tmp;
            while (!(int.TryParse(Console.ReadLine(), out tmp) && tmp >= 0))
            {
                Console.WriteLine("Something wrong with Input, reenter X value");
            }
            x = tmp >= 1 ? true : false;
            while (!(int.TryParse(Console.ReadLine(), out tmp) && tmp >= 0))
            {
                Console.WriteLine("Something wrong with Input, reenter Y value");
            }
            y = tmp >= 1 ? true : false;

            while (!(int.TryParse(Console.ReadLine(), out tmp) && tmp >= 0))
            {
                Console.WriteLine("Something wrong with Input, reenter Z value");
            }
            z = tmp >= 1 ? true : false;
            Console.WriteLine("!(x&y|z) = " + EvaluateExpression(x, y, z));
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);

    }
}


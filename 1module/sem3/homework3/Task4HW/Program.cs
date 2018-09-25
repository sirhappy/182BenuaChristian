using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Написать метод, вычисляющий значение функции G=F(X,Y)
 * F(x,y) = x + siny if x<y and x>0
 *          y - cosx if x>y and x<0
 *          0.5 * x * y otherwise
 */

class Program
{
    public static double Eval(double x, double y) {
        if (x < y && x > 0) {
            return x + Math.Sin(y);
        } else if (x > y && x < 0) {
            return y - Math.Cos(x);
        }
        return 0.5 * x * y;
    }

    static void Main(string[] args)
    {


        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter X Y");
            double x, y;

            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Smth wrong with your input, reenter X value");
            }

            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Smth wrong with your input, reenter Y value");
            }
            Console.WriteLine("Value of func is : " + Eval(x, y).ToString("F3"));

            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


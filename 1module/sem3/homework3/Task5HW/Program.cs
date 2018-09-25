using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Написать метод, вычисляющий значение функции G=F(X)
 * F(x) = sin(pi/2) if x<=0.5
 * F(x) = sin(pi(x-1)/2) if x>0.5

*/

class Program
{

    public static double Eval(double x) {
        if (x <= 0.5) {
            return Math.Sin(Math.PI / 2);
        } else {
            return Math.Sin(Math.PI * (x - 1) / 2);
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {

            Console.WriteLine("Enter x value");
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Smth wrong with your input, reenter X value");
            }

            Console.WriteLine("Value of function is : " + Eval(x).ToString("F3"));


            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


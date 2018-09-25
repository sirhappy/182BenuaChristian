using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Написать метод, вычисляющий логическое значение функции G=F(X,Y). Результат равен true, 
 * если точка с координатами (X,Y) попадает в фигуру G, и результат равен false, если точка с 
 * координатами (X,Y) не попадает в фигуру G. Фигура G - сектор круга радиусом R=2 в диапазоне углов -90<= fi <=45.
 * 
 * */
class Program
{

    public static bool inCircle(double x, double y, double r) {
        return x * x + y * y < r * r;
    }

    public static double CrossProd(double x, double y, double x1, double y1) {
        return x * y1 - y * x1;
    }

    public static double DotProd(double x, double y, double x1, double y1) {
        return x * x1 + y * y1;
    }

    public static bool inSecotr(double x, double y, double maxAngle = 45, double minAngle = -90, double r = 2) {
        double angle = Math.Atan2(DotProd(x, y, 0, 1), CrossProd(x, y, 0, 1));

        return angle <= Math.PI / 4 && angle >= -Math.PI / 2 && inCircle(x, y, r);
         
    } 

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter The Point");
            double x, y;

            while (!double.TryParse(Console.ReadLine(), out x)) {
                Console.WriteLine("Smth wrong with your input, reenter X value");
            }

            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Smth wrong with your input, reenter Y value");
            }
            if (inSecotr(x, y)) {
                Console.WriteLine("Inside");
            } else {
                Console.WriteLine("OutSide");
            }
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


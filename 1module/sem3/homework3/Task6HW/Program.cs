using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * 
 * Трехзначным целым числом кодируется номер аудитории в учебном корпусе. Старшая цифра обозначают номер этажа, а две младшие – номер аудитории на этаже. Из трех аудиторий определить и вывести на экран ту аудиторию, которая имеет минимальный номер внутри этажа. Если таких аудиторий несколько - вывести любую из них.
 * */

class Program
{

    public static int Solve(int x, int y, int z) {
        if (x % 100 < y % 100)
        {
            int temp = y;
            y = x;
            x = temp;
        }
        if (x % 100 < z % 100)
        {
            int temp = z;
            z = x;
            x = temp;
        }
        if (y % 100 < z % 100)
        {
            int temp = z;
            z = y;
            y = temp;
        }
        return z;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter three aufotoriyas numbers");
            int x;
            while (!((int.TryParse(Console.ReadLine(), out x) && x >= 100 && x < 1000)))
            {
                Console.WriteLine("Something wrong with input, reenter pls");
            }
            int y;
            while (!(int.TryParse(Console.ReadLine(), out y) && y >= 100 && y < 1000))
            {
                Console.WriteLine("Something wrong with input, reenter pls");
            }
            int z;
            while (!(int.TryParse(Console.ReadLine(), out z) && z >= 100 && z < 1000))
            {
                Console.WriteLine("Something wrong with input, reenter pls");
            }
            Console.WriteLine("The minimum auditoriya is : " + Solve(x, y, z));

            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


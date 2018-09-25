using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Написать метод, преобразующий число переданное в качестве параметра в число,
 * записанное теми же цифрами, но идущими в обратном порядке.
 * */

class Program
{

    public static int Solve(int num) {
        int ans = 0;
        while (num > 0) {
            ans *= 10;
            ans += num % 10;
            num /= 10;
        }
        return ans;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter the number to transorm");
            int x;
            while (!(int.TryParse(Console.ReadLine(), out x) && x > 0)) {
                Console.WriteLine("Smth wrong with imput, reenter value");
            }
            Console.WriteLine(Solve(x));




            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


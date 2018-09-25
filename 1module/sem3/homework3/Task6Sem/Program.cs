using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Задание 6 семинар 3
 * сложный процент
 * Если проценты начисляются в начале след года
 * Вклад забираем не в конце года, а в начале следующего
 * */

class Program
{
    public static void Print(double k, double r, uint n) {
        for (int i = 0; i <= n; ++i)
        {
            Console.WriteLine($"Year {i} - Value = {k}");
            k *= (1 + r / 100);
        }

    }

    public static double Total(double k, double r, uint n) {
        for (int i = 0; i < n; ++i) {
            //Console.WriteLine($"Year {i + 1} - Value = {k}");
            k *= (1 + r / 100);
        }
        return k;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            double k, r;
            int n;
            Console.WriteLine("Enter Sum on Deposit, Scale(Percentage), Years");

            while (!(double.TryParse(Console.ReadLine(), out k) && k > 0)) {
                Console.WriteLine("Smth wrong with input, Reenter Sum on Deposit Value");
            }

            while (!(double.TryParse(Console.ReadLine(), out r) && r > 0))
            {
                Console.WriteLine("Smth wrong with input, Reenter Scale");
            }

            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Smth wrong with input, Reenter Years");
            }

            double endValue = Total(k, r, (uint)n);
            Console.WriteLine("End Value: " + endValue.ToString("C"));
            Console.WriteLine("Table:");
            Print(k, r, (uint)n);
            Console.WriteLine("To exit press Escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


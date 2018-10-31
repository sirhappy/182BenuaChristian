using System;


class Program
{

    public static double Sum1(double x) {
        double sum = 0;
        double currXPower = 1;
        double currFact = 2;
        int currMult = 3;
        double curr2Power = 2;
        double zn = 1;
        while (true) {
            currXPower *= x * x;
            double sum2 = sum + curr2Power * currXPower / currFact * zn;
            curr2Power *= 4;
            currFact *= (currMult) * (currMult + 1);
            currMult += 2;
            if (Math.Abs(sum2 - sum) < 1e-9) {
                break;
            }
            sum = sum2;
            zn *= -1;
        }
        return sum;
    }

    public static double Sum2(double x) {
        double sum = 0;
        double currFact = 1;
        int currMult = 1;
        double currXPower = 1;
        while (true)
        {
            currXPower *= x;
            double sum2 = sum + currXPower / currFact;
            currFact *= (currMult);
            currMult += 1;
            if (sum2 - sum < 1e-9)
            {
                break;
         
            }
            sum = sum2;
        }
        return sum;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter Int value");
            double n;
            while (!double.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Smth wrong with your input");
            }
            Console.WriteLine(Sum1(n));
            Console.WriteLine(Sum2(n));
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


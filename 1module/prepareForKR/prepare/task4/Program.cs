using System;


class Program
{
    static int size = 201;
    public static void ReadInt(out int n, string messageIn, string messageOut, Func<int, bool> validate)
    {
        Console.WriteLine(messageIn);
        while (!(int.TryParse(Console.ReadLine(), out n) && validate(n)))
        {
            Console.WriteLine(messageOut);
        }
    }

    public static void ReadDouble(out double n, string messageIn, string messageOut, Func<double, bool> validate)
    {
        Console.WriteLine(messageIn);
        while (!(double.TryParse(Console.ReadLine(), out n) && validate(n)))
        {
            Console.WriteLine(messageOut);
        }
    }

    static double[,] binomialCoef;

    public static void fillBinomial() {
        binomialCoef = new double[size, size];
        binomialCoef[0,0] = 1;
        for (int i = 1; i < size; ++i) {
            for (int j = 0; j < size; ++j) {
                int prev = j - 1;
                if (prev >= 0) {
                    binomialCoef[i, j] += binomialCoef[i - 1, prev];
                }
                binomialCoef[i, j] += binomialCoef[i - 1, j];
            }
        }
    }

    public static double[] CreateArray(int n) {
        double[] arr = new double[n];
        arr[0] = 1;
        for (int i = 1; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                arr[i] -= binomialCoef[i + 1, j + 1] * arr[j];
            }
            arr[i] *= 1.0 / (i + 1);
        }
        return arr;
    }

    public static void SummCalculate(double[] arr, int pref, out double s1, out double s2) {
        s1 = s2 = 0;
        for (int i = 0; i < pref; i += 2) {
            s1 += arr[i];
        }
        for (int i = 1; i < pref; i += 2) {
            s2 += arr[i];
        }
    }

    public static void Print(int a, double b, double c) {
        Console.WriteLine("{0}: S1={1}, S2={2}", a, b.ToString("F3"), c.ToString("F3"));
    }

    static void Main(string[] args)
    {
        fillBinomial();
        //CreateArray(20);
        ConsoleKeyInfo keyInfo;
        do
        {
            int n;
            ReadInt(out n, "Enter size of sequence", "Smth wrong with your size of sequence, reenter pls", (arg) => arg < 200 && arg > 0);
            double[] arr = CreateArray(n);
            double s1, s2;
            double mx = double.MinValue;
            int ansInd = 0;
            for (int i = 1; i < n; ++i)
            {
                s1 = s2 = 0;
                SummCalculate(arr, i, out s1, out s2);
                if (mx <  Math.Abs(s1 + s2)) {
                    mx = Math.Abs(s1 + s2);
                    ansInd = i;
                }
                Print(i, s1, s2);

            }
            Console.WriteLine("maximum abs value at: " + ansInd);
            Console.WriteLine("Press esc to exit");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


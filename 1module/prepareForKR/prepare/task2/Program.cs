using System;


class Program
{

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

    public static double[] CreateArray(int n) {
        double[] a = new double[n];
        //Random rnd = new Random();
        for (int i = 0; i < n; ++i) {
            a[i] = 1.0 / (2 * i + 1);
            a[i] *= i % 2 == 0 ? -1 : 1;
        }
        /*a[0] = -1;
        a[1] = 0;
        a[2] = 5;
        a[3] = -7;
        a[4] = 11;*/
        /*a[0] = 1;
        a[1] = 2;
        a[2] = -4;
        a[3] = 6;
        a[4] = -8;*/
        return a;
    }

    public static void ShowArray(ref double[] arr) {
        for (int i = 0; i < arr.Length; ++i) {
            Console.Write(arr[i].ToString("F3") + " ");
        }
        Console.WriteLine();
    }

    public static void ShiftArray(ref double[] arr) {
        //int pt = 0;
        for (int i = 0; i < arr.Length; ++i) {
            if (arr[i] < 0) {
                arr[i] = i == 0? 0 : arr[0];
                for (int j = i - 1; j >= 0; --j) {
                    double t = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = t;
                }
            }
        }
        //Array.Resize(ref arr, pt);
    }


    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int k;
            ReadInt(out k, "Enter size of an array", "Smth wrong, reenter size of array", (arg) => arg > 0 && arg < 1e6);
            double[] arr = CreateArray(k);
            ShowArray(ref arr);
            ShiftArray(ref arr);
            ShowArray(ref arr);
            Console.WriteLine("Press esc to exit");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


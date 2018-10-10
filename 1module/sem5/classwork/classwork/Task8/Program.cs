using System;

class Program
{

    public static void print(double[] arr)
    {
        for (int i = 0; i < arr.Length; ++i)
        {
            Console.WriteLine("[{0}] : {1}   ", i, arr[i].ToString("F3"));
        }
        Console.WriteLine();
    }

    public static void norm(double[] arr) {
        double mx = arr[0];
        for (int i = 0; i < arr.Length; ++i) {
            mx = Math.Max(arr[i], mx);
        }
        for (int i = 0; i < arr.Length; ++i) {
            arr[i] /= mx;
        }
    }

    public static double[] fill(int n) {
        double[] arr = new double[n];
        int sum = 0;
        for (int i = 0; i < n; ++i) {
            arr[i] = sum;
            sum += i + 1;
        }
        return arr;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int n;
            Console.WriteLine("Enter number");
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 1))
            {
                Console.WriteLine("Smth wrong with your input, reenter size of array");
            }

            Console.WriteLine("Result");
            double[] arr;
            print((arr = fill(n)));
            norm(arr);
            print(arr);

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


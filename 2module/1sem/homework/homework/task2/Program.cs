using System;


class Program
{
    public static Random rnd = new Random();
    const string errBeg = "Smth wrong with your ";
    const string errEnd = " Reenter, please";

    public static double ReadDouble(string messageIn, string messageErr, Func<double, bool> valid) {
        double n;
        while (!(double.TryParse(Console.ReadLine(), out n) && valid(n)))
        {
            Console.WriteLine(messageErr);
        }
        return n;
    }

    public static int ReadInt(string messageIn, string messageErr, Func<int, bool> valid)
    {
        int n;
        Console.WriteLine(messageIn);
        while (!(int.TryParse(Console.ReadLine(), out n) && valid(n)))
        {
            Console.WriteLine(messageErr);
        }
        return n;
    }

    public static void Fill(ref double[,] mat, int mn = 1, int mx = 100)
    {
        for (int i = 0; i < mat.GetLength(0); ++i)
        {
            for (int j = 0; j < mat.GetLength(1); ++j)
            {
                mat[i, j] = rnd.NextDouble() * (mx - mn) + mn;
            }
        }
    }

    public static double[] ColumnSums(ref double[,] mat) {
        double[] sums = new double[mat.GetLength(1)];
        for (int column = 0; column < mat.GetLength(1); ++column) {
            for (int row = 0; row < mat.GetLength(0); ++row) {
                sums[column] += mat[row, column];
            }
        }
        return sums;
    }

    public static void PrintArray(double[] arr) {
        for (int i = 0; i < arr.Length; ++i) {
            Console.Write(arr[i].ToString("F3") + " ");
        }
        Console.WriteLine();
    }
    public static void PrintMatrix(ref double[,] mat)
    {
        for (int i = 0; i < mat.GetLength(0); ++i)
        {
            for (int j = 0; j < mat.GetLength(1); ++j)
            {
                Console.Write(mat[i, j].ToString("F3") + " ");
            }
            Console.WriteLine();
        }
    }



    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            int m = ReadInt("Enter m", errBeg + "m" + errEnd, (arg) => arg > 0);
            int n = ReadInt("Enter n", errBeg + "n" + errEnd, (arg) => arg > 0);
            double[,] mat = new double[m, n];
            Fill(ref mat);
            Console.WriteLine("The matrix is:");
            PrintMatrix(ref mat);
            Console.WriteLine("Sums in columns are: ");
            PrintArray(ColumnSums(ref mat));

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


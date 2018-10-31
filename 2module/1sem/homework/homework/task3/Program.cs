using System;


class Program
{
    public static Random rnd = new Random();
    const string errBeg = "Smth wrong with your ";
    const string errEnd = " Reenter, please";

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

    public static void Fill(ref int[,] mat, int mn = 1, int mx = 100)
    {
        for (int i = 0; i < mat.GetLength(0); ++i)
        {
            for (int j = 0; j < mat.GetLength(1); ++j)
            {
                mat[i, j] = rnd.Next(mn, mx);
            }
        }
    }

    public static void PrintMatrix(ref int[,] mat, string message = "")
    {
        Console.WriteLine(message);
        for (int i = 0; i < mat.GetLength(0); ++i)
        {
            for (int j = 0; j < mat.GetLength(1); ++j)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintColumnsInOrder(ref int[,] mat, int[] order, string message = "") {
        Console.WriteLine(message);
        for (int row = 0; row < mat.GetLength(0); ++row) {
            for (int column = 0; column < order.Length; ++column) {
                Console.Write(mat[row, order[column]] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintArray(int[] arr, string message = "")
    {
        Console.WriteLine(message);
        for (int i = 0; i < arr.Length; ++i)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public static int[] ColumnSums(ref int[,] mat)
    {
        int[] sums = new int[mat.GetLength(1)];
        for (int column = 0; column < mat.GetLength(1); ++column)
        {
            for (int row = 0; row < mat.GetLength(0); ++row)
            {
                sums[column] += mat[row, column];
            }
        }
        return sums;
    }

    public static int[] ColumsSumsSorted(ref int[,] mat) {
        int[] sums = ColumnSums(ref mat);

        int[] indexes = new int[sums.Length];
        for (int i = 0; i < sums.Length; ++i) {
            indexes[i] = i;
        }

        Array.Sort<int>(indexes, (int x, int y) => sums[x] < sums[y] ? -1 : (sums[x] == sums[y] ? 0 : 1));
        return indexes;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            int m = ReadInt("Enter m", errBeg + "m" + errEnd, (arg) => arg > 0);
            int n = ReadInt("Enter n", errBeg + "n" + errEnd, (arg) => arg > 0);

            int[,] mat = new int[m, n];
            Fill(ref mat);
            Console.WriteLine("Matrix is : ");
            PrintMatrix(ref mat);

            int[] sums = ColumnSums(ref mat);
            PrintArray(sums);

            int[] order = ColumsSumsSorted(ref mat);

            PrintArray(order, "Increasing ColumnsSums order");

            PrintColumnsInOrder(ref mat, order, "Matrix Columns in Sum's increasing order");

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


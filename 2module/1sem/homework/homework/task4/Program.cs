using System;
using System.Linq;

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

    public static void PrintColumnsInOrder(ref int[,] mat, int[] order, string message = "")
    {
        Console.WriteLine(message);
        for (int row = 0; row < mat.GetLength(0); ++row)
        {
            for (int column = 0; column < order.Length; ++column)
            {
                Console.Write(mat[row, order[column]] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintArray<T>(T[] arr, string message = "")
    {
        Console.WriteLine(message);
        for (int i = 0; i < arr.Length; ++i)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public static int MaxValue(int[] arr) {
        int mx = int.MinValue;
        for (int i = 0; i < arr.Length; ++i) {
            mx = Math.Max(mx, arr[i]);
        }
        return mx;
    }

    public static void ReplaceMaxValueInRow(int[,] mat) {
        for (int row = 0; row < mat.GetLength(0); ++row) {
            int[] allRow = Enumerable.Range(0, mat.GetLength(1)).Select(i => mat[row, i]).ToArray();
            int toReplace = MaxValue(allRow);
            int[] where = Enumerable.Range(0, mat.GetLength(1)).Where(i => allRow[i] == toReplace).ToArray();
            foreach (var el in where) {
                mat[row, el] = -toReplace;
            }
        }
    }

    public static int[,] InsertZeroRows(int[,] mat) {
        int[,] res = new int[(mat.GetLength(0) * 3 + 1) / 2, mat.GetLength(1)];
        int cnt = 0;
        for (int i = 0; i < res.GetLength(0); ++i) {
            if (i % 3 == 1) {
                for (int j = 0; j < res.GetLength(1); ++j) {
                    res[i, j] = 0;
                }
                cnt++;
            } else {
                for (int j = 0; j < res.GetLength(1); ++j) {
                    res[i, j] = mat[i - cnt, j];
                }
            }
        }
        return res;
    }

    public static int[] RowsWithNonZero(int[,] mat) {
        System.Collections.Generic.List<int> rows = new System.Collections.Generic.List<int>();
        for (int i = 0; i < mat.GetLength(0); ++i) {
            bool Zero = false;
            for (int j = 0; j < mat.GetLength(1); ++j) {
                if (mat[i,j] == 0) {
                    Zero = true;
                }
            }
            if (!Zero) {
                rows.Add(i);
            }
        }
        return rows.ToArray();
    }

    public static int[,] EraseRowsWithZero(int[,] mat) {
        int[] rows = RowsWithNonZero(mat);
        int[,] res = new int[rows.Length, mat.GetLength(1)];
        for (int i = 0; i < rows.Length; ++i) {
            for (int j = 0; j < mat.GetLength(1); ++j) {
                res[i, j] = mat[rows[i], j];
            }
        }
        return res;
    }

    public static void SwapColumns(int[,] mat, int c1, int c2) {
        for (int row = 0; row < mat.GetLength(0); ++row) {
            int temp = mat[row, c1];
            mat[row, c1] = mat[row, c2];
            mat[row, c2] = temp;
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            int m = ReadInt("Enter m", errBeg + "m" + errEnd, (arg) => arg > 0);
            int n = ReadInt("Enter n", errBeg + "n" + errEnd, (arg) => arg > 0);

            int[,] mat = new int[m, n];
            Fill(ref mat, -100, 100);
            Console.WriteLine("Matrix is : ");
            PrintMatrix(ref mat);

            ReplaceMaxValueInRow(mat);
            PrintMatrix(ref mat, "Changed Matrix");

            mat = InsertZeroRows(mat);
            PrintMatrix(ref mat, "Zero Rows Inserted");

            mat = EraseRowsWithZero(mat);
            PrintMatrix(ref mat, "Rows with zero erased");

            SwapColumns(mat, mat.GetLength(1) / 2, (mat.GetLength(1) - 1) / 2);
            PrintMatrix(ref mat, "Columns Swapped");

            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

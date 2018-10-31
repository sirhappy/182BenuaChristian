using System;


class Program
{
    public static Random rnd = new Random();
    const string errBeg = "Smth wrong with your ";
    const string errEnd = " Reenter, please";

    public static int ReadInt(string messageIn, string messageErr, Func<int, bool> valid) {
        int n;
        Console.WriteLine(messageIn);
        while (!(int.TryParse(Console.ReadLine(), out n) && valid(n))) {
            Console.WriteLine(messageErr);
        }
        return n;
    }

    public static void Fill(ref int[,] mat, int mn = 1, int mx = 100) {
        for (int i = 0; i < mat.GetLength(0); ++i) {
            for (int j = 0; j < mat.GetLength(1); ++j) {
                mat[i, j] = rnd.Next(mn, mx);
            }
        }
    }

    public static void Print(ref int[,] mat)
    {
        for (int i = 0; i < mat.GetLength(0); ++i)
        {
            for (int j = 0; j < mat.GetLength(1); ++j)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static bool KthRowSum(ref int[,] mat, ref long res,int k) {
        try
        {
            checked
            {
                int sum = 0;
                for (int i = 0; i < mat.GetLength(0); ++i)
                {
                    sum += mat[k, i];
                }
                res = sum;
                return true;
            }
        } catch (OverflowException ex) {
            return false;
        }
    } 

    public static bool KthRowMult(ref int[,] mat, ref long res,int k) {
        try
        {
            checked
            {
                long mult = 1;
                for (int i = 0; i < mat.GetLength(0); ++i)
                {
                    mult *= (long)mat[k, i];
                }
                res = mult;
                return true;
            }
        } catch (OverflowException ex) {
            //Console.WriteLine("Overflow happend");
            return false;
        }
    }



    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            int m = ReadInt("Enter m", errBeg + "m" + errEnd,(arg) => arg > 0);
            int n = ReadInt("Enter n", errBeg + "n" + errEnd, (arg) => arg > 0);
            int k = ReadInt("Enter k", errBeg + "k" + errEnd, (arg) => arg > 0 && arg <= m);
            k--;
            int[,] mat = new int[m, n];
            Fill(ref mat);
            Console.WriteLine("Matrix is : ");
            Print(ref mat);
            long mult = 0;
            long sum = 0;

            if (KthRowSum(ref mat, ref sum, k)) {
                Console.WriteLine("Sum is : {0}", sum);
            }
            else {
                Console.WriteLine("Overflow happend in Sum method");
            }
            //Console.WriteLine("Sum is : {0}", KthRowSum(ref mat, k));
            if (KthRowMult(ref mat, ref mult, k)) {
                Console.WriteLine("Mult is : {0}", mult);
            } else {
                Console.WriteLine("Overflow happend in Mult method");
            }
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


using System;
/*
 * Бенуа Кристиан БПИ182
 * */

class Program
{
    public static double eps = 1e-9;
    //eval f1

    public static void ReadInt(out int n, string messageIn, string messageOut, Func<int, bool> validate)
    {
        Console.WriteLine(messageIn);
        while (!(int.TryParse(Console.ReadLine(), out n) && validate(n)))
        {
            Console.WriteLine(messageOut);
        }
    }


    public static int[] CreateArray(int n, int mn, int mx)
    {
        Random rnd = new Random();
        int[] a = new int[n];
        for (int i = 0; i < n; ++i)
        {
            a[i] = rnd.Next(mn, mx + 1);
        }
        return a;
    }

    public static void PrintArray(ref int[] array, string name = "")
    {
        Console.WriteLine(name);

        for (int i = 0; i < array.Length; ++i)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    public static void Fill(ref int[] a, int def)
    {
        for (int i = 0; i < a.Length; ++i)
        {
            a[i] = def;
        }
    }

    public static void MergeArray(ref int[] a, ref int[] b, out int[] c)
    {
        int maxSz = Math.Max(a.Length, b.Length);
        c = new int[maxSz * 2];
        Fill(ref c, 0);
        for (int i = 0; i < a.Length; ++i)
        {
            c[i * 2] = a[i];
        }
        for (int i = 0; i < b.Length; ++i)
        {
            c[i * 2 + 1] = b[i];
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            int k, m;
            //Console.WriteLine("Enter k, m");
            ReadInt(out k, "Enter k", "Smth wrong with yout input", (arg) => arg > 0 && arg < 2e5);
            ReadInt(out m, "Enter m", "Smth wrong with yout input", (arg) => arg > 0 && arg < 2e5);
            int[] a = CreateArray(k, -1, 1);
            int[] b = CreateArray(m, -1, 1);
            int[] c;
            PrintArray(ref a, "A");
            PrintArray(ref b, "B");
            MergeArray(ref a, ref b, out c);
            PrintArray(ref c, "C");
            Console.WriteLine("Press esc to exit");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

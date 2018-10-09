using System;

class Program
{
    public static void replaceMaxElement(int[] arr, int toReplace) {
        int mx = arr[0];
        for (int i = 0; i < arr.Length; ++i) {
            mx = Math.Max(arr[i], mx);
        }
        for (int i = 0; i < arr.Length; ++i) {
            if (arr[i] == mx) {
                arr[i] = toReplace;
            }
        }
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {


            int n = 10;
            int[] arr = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; ++i)
            {
                arr[i] = rnd.Next(0, 10);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Enter number to replace");
            int repl;
            while (!int.TryParse(Console.ReadLine(), out repl))
            {
                Console.WriteLine("Something wrong with your input");
            }
            replaceMaxElement(arr, repl);
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("TO exit press esc");
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}


using System;
using Task5Lib;
using Generators;
using Readers;
namespace task5
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                int sale = Reader.Read<int>("Enter discount value", "Smth wrong with your input, reenter pls", (arg) => arg >= 0 && arg <= 100);
                UnitsBase[] arr = new UnitsBase[rnd.Next(5, 7)];

                for (int i = 0; i < arr.Length; ++i)
                {
                    int gen = rnd.Next(0, 3);
                    if (gen == 0)
                    {
                        arr[i] = new CD(rnd.Next(5, 100), rnd.GenerateString(5, 6), rnd.Generate(10, 20), rnd.GenerateInt(500, 5000));
                    }
                    else if (gen == 1)
                    {
                        arr[i] = new Cards(rnd.Next(5, 100), rnd.Generate(10, 20), rnd.GenerateString(5, 6), rnd.GenerateString(10, 20));
                    }
                    else
                    {
                        arr[i] = new Book(rnd.Next(5, 100), rnd.Generate(10, 20), rnd.GenerateString(5, 6), rnd.GenerateInt(100, 2000), rnd.Generatebool());
                    }
                    Console.WriteLine(arr[i]);
                    Console.WriteLine(arr[i].Dicsount(sale).ToString("F3"));
                }
                Console.WriteLine("Press escape to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

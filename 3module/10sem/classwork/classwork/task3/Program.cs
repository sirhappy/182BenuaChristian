using System;
using System.IO;

namespace task3
{
    class Program
    {
        public static Random rnd = new Random();

        public static void GenerateInputTxt(int n, int from, int to) 
        {
            using (StreamWriter writer = new StreamWriter("input.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    writer.WriteLine(rnd.Next(from, to + 1));

                }
            }

        }

        static void Main(string[] args)
        {
            GenerateInputTxt(100, 100, 1000);

            var defaultInputStream = Console.In;

            Console.SetIn(new StreamReader("input.txt"));
            int cnt = 0;
            int sum = 0;
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                while(!reader.EndOfStream)
                {
                    cnt++;
                    sum += int.Parse(reader.ReadLine());
                }
            }

            Console.WriteLine((double)sum / cnt);
            Console.SetIn(defaultInputStream);
        }
    }
}

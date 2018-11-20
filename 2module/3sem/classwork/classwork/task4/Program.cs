using System;

namespace task4
{


    public class ArithmeticSequence
    {
        double _start;
        double _increment;

        public ArithmeticSequence()
        {
            _start = _increment = 0;
        }

        public ArithmeticSequence(double _start, double _increment)
        {
            this._start = _start;
            this._increment = _increment;
        }

        public double this[int index]
        {
            get
            {
                return _start + (index - 1) * _increment;
            }
        }

        public override string ToString()
        {
            return $"Start is {_start}, increment is {_increment}";
        }

        public double GetSum(int n)
        {
            return (_start + this[n]) / 2 * n;
        }
    }

    public static class Generator {
        public static Random rnd = new Random();

        public static double Generate(int mn, int mx) {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        public static int GenerateInt(int mn, int mx) {
            return rnd.Next(mn, mx);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            do
            {
                ArithmeticSequence sequence = new ArithmeticSequence(Generator.Generate(0, 1000), Generator.Generate(1, 10));
                Console.WriteLine("Sequence " + sequence);
                ArithmeticSequence[] arr = new ArithmeticSequence[Generator.GenerateInt(5, 15)];
                for (int i = 0; i < arr.Length; ++i)
                {
                    arr[i] = new ArithmeticSequence(Generator.Generate(0, 1000), Generator.Generate(1, 10));
                    Console.WriteLine(i + " " + arr[i]);
                }
                int step = Generator.GenerateInt(3, 15);
                Console.WriteLine("Step is " + step);
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.WriteLine(i + " " + "Sum is " + arr[i].GetSum(step));
                    if (arr[i][step] > sequence[step])
                    {
                        Console.WriteLine(i + " " + arr[i]);
                    }
                }
                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

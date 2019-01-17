using System;

namespace classwork
{


    class Program
    {
        public static Random rnd = new Random();

        public static string GenerateString(int n, char st, char end) {
            if (n < 0) {
                throw new ArgumentOutOfRangeException("Length of string can not be negative");
            }
            if (end < st) {
                throw new ArgumentOutOfRangeException("Начало отрезка не может быть больше конца");
            }
            char[] arr = new char[n];
            for (int i = 0; i < n; ++i) {
                arr[i] = (char)(rnd.Next(st, end + 1));
            }
            return new String(arr);
        }

        public static string MoveOff(string source, string symbolsToDelete) {
            foreach (var el in symbolsToDelete) {
                source = source.Replace(new String(el, 1), "");
            }
            return source;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(MoveOff("abcdefggggg", "fg"));
            Console.WriteLine(MoveOff("1234567890", "02468"));
            Console.WriteLine('a'.ToString());
        }
    }
}

using System;

namespace Task2HW
{

    class LatinChar {
        char _char;

        public char Char {
            get {
                return _char;
            }
            set {
                if (value < 'A') {
                    value = 'a';
                }
                if (value > 'z') {
                    value = 'z';
                }
                _char = value;
            }
        }

        public LatinChar() {
            _char = 'a';
        }
        public LatinChar(char ch) {
            _char = ch;
        }
    }

    class Program
    {

        public static char ReadChar(string In, string Out, Func<char, bool> valid) {
            char ch;
            Console.WriteLine(In);
            while (!(char.TryParse(Console.ReadLine(), out ch) && valid(ch))) {
                Console.WriteLine(Out);
            }
            return ch;
        }


        static void Main(string[] args)
        {
            do
            {
                char minChar = ReadChar("MinChar : ", "Smth wrng with your input, reenter pls \n MinChar : ", (arg) => arg >= 'A');
                char maxChar = ReadChar("MaxChar : ", "Smth wrng with your input, reenter pls \n MinChar: ", (arg) => arg > minChar && arg <= 'z');
                LatinChar chr = new LatinChar(); 
                for (char ch = minChar; ch <= maxChar; ++ch) {
                    chr.Char = ch;
                    Console.WriteLine(chr.Char);
                }


                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class ConsolePlate
    {
        char _plateChar; // символ
        ConsoleColor _plateColor = ConsoleColor.White; // цвет символа

        public char PlateChar
        {
            get { return _plateChar; }
            set
            {
                if (value <= 31)
                {
                    value = '+';
                }

                _plateChar = value;
            }
        }

        public ConsoleColor PlateColor
        {
            get { return _plateColor; }
            set
            {
                if (value == Console.BackgroundColor)
                {
                    value = Console.BackgroundColor + 1;
                }
                _plateColor = value;
            }
        }

        public ConsolePlate()
        {
            _plateChar = '+';
        }

        public ConsolePlate(char ch, ConsoleColor clr)
        {
            _plateChar = ch;
            _plateColor = clr;
        }

        public void Print()
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = PlateColor;
            Console.Write(PlateChar);
            Console.ForegroundColor = prev;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            /*ConsolePlate[] arr = new ConsolePlate[5];
            ConsoleColor[] color = new ConsoleColor[5]
            {
                ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow
            };
            

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = new ConsolePlate();
                int rand = rnd.Next(31, 40);
                Console.WriteLine("Rand is {0}", rand);
                arr[i].PlateChar = (char) rand;
                arr[i].PlateColor = color[i];
                Console.WriteLine(arr[i].PlateChar);
                Console.WriteLine(arr[i].PlateColor);
                ConsoleColor prev = Console.ForegroundColor;
                Console.ForegroundColor = arr[i].PlateColor;
                Console.WriteLine(arr[i].PlateChar);
                Console.ForegroundColor = prev;
            }

            Console.ReadLine();*/

            int n = int.Parse(Console.ReadLine());

            ConsolePlate[] arr = new ConsolePlate[] { new ConsolePlate('X', ConsoleColor.Red), new ConsolePlate('O', ConsoleColor.White) };
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    arr[(i + j) % 2].Print();
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

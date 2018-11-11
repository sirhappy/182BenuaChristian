using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class HexNumber
    {
        uint number;
        char[] hexView;
        public HexNumber(uint n)
        { // конструктор общего вида
            number = n;
            hexView = series(n);
        }
        public HexNumber() : this(0) { }    // конструктор умолчания

        public uint Number
        {   // Свойство: десятичное целое
            get { return number; }
            set
            {
                number = value;
                hexView = series(value);
            }
        }
        public char[] HexView
        {
            get { return hexView; }
        }

        /// <summary>
        /// Gets String Hex Representation 
        /// </summary>
        /// <value>The record.</value>
        public string Record
        {
            get
            {
                string str = new String(hexView);
                return "0x" + str;
            }
        }

        /// <summary>
        /// hex Representation the specified num.
        /// </summary>
        /// <returns>hex representation</returns>
        /// <param name="num">Number for translating to hex</param>
        char[] series(uint num)
        {
            List<char> digits = new List<char>();
            while (num > 0) {
                int rem = (int)num % 16;
                digits.Add((rem) < 10 ? (char)('0' + rem) : (char)('A' + rem - 10));
                num /= 16;
            }
            digits.Reverse();
            return digits.ToArray();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            HexNumber hex;      // ссылка с типом класса
            hex = new HexNumber(0); // объект класса
            uint number;
            while (true)
            { // цикл для ввода разных значений числа 
                do Console.Write("Введите целое неотрицательное число:  ");
                while (!(uint.TryParse(Console.ReadLine(), out number))) {
                    Console.WriteLine("Something wrong with your input");
                }

                hex.Number = number;     // Изменяем объект через свойство
                Console.WriteLine("Свойство Number: " + hex.Number);
                Console.Write("Шестнадцатеричные цифры числа: ");

                foreach (char h in hex.HexView) Console.Write("{0} ", h);

                Console.WriteLine("\nШестнадцатеричная запись: " + hex.Record);
                Console.WriteLine("Для выхода нажмите клавишу ESC");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }    // while

        }
    }
}

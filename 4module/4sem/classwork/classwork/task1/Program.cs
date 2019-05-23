using System.Collections.Generic;
using System;
using System.Collections;

namespace task1
{

    public class Romashka : IEnumerable<String>
    {
        private string[] arr = { "раз ромашка ", "два ромашка", "три ромашка ", "пять ромашка ", "шесть ромашка"};


        public IEnumerator<string> GetEnumerator()
        {
            foreach (var str in arr)
            {
                yield return str;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Romashka romashka = new Romashka();
            foreach (var rom in romashka)
            {
                Console.WriteLine(rom);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace task3
{
    public class ArithmeticProgression
    {
        private int _a0;
        private int _d;

        public ArithmeticProgression(int a0, int d)
        {
            _a0 = a0;
            _d = d;
        }

        public IEnumerable<int> ArithListEnumerator(int to)
        {
            for (int i = 0; i < to; ++i)
            {
                yield return _a0 + _d * i;
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArithmeticProgression progression = new ArithmeticProgression(5, 10);
            foreach (var progElem in progression.ArithListEnumerator(10))
            {
                Console.WriteLine(progElem);
            }
        }
    }
}
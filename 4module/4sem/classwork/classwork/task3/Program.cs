using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    
    public class FibonacciCollection
    {
        private int _start = 0;
        private int _next = 1;

        public IEnumerable<int> Fibonacci(int limit)
        {
            for (int i = 0; i < limit; ++i)
            {
                (_start, _next) = (_next, _start + _next);
                yield return _start;

                if (i == limit - 1)
                {
                    _start = 0;
                    _next = 1;
                    yield break;
                }
            }
        }
    }

    public class TriangleNumbersCollection
    {
        private int _current = 0;
        private int _nextAddition = 0;

        public IEnumerable<int> TriangleNums(int limit)
        {
            for (int i = 0; i < limit; ++i)
            {
                (_current, _nextAddition) = (_current + _nextAddition, _nextAddition + 1);
                yield return _current;

                if (i == limit - 1)
                {
                    _current = 0;
                    _nextAddition = 0;
                    yield break;
                }
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            FibonacciCollection collection = new FibonacciCollection();
            TriangleNumbersCollection triangleNumbersCollection = new TriangleNumbersCollection();

            var fibEnumerable = collection.Fibonacci(15);
            var triangleEnumerable = triangleNumbersCollection.TriangleNums(15);
            
            foreach (var fib in fibEnumerable)
            {
                Console.Write(fib + " ");
            }
            Console.WriteLine();
            foreach (var triangle in triangleEnumerable)
            {
                Console.Write(triangle + " ");
            }
            Console.WriteLine();

            var result = fibEnumerable.Zip(triangleEnumerable, (el1, el2) => el1 + el2);

            foreach (var res in result)
            {
                Console.Write(res + " ");
            }
        }
    }
}
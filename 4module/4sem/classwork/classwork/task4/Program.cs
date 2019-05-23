using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;

namespace task4
{

    public static class IsPrimeExtension
    {
        public static bool IsPrime(this int num)
        {
            for (int i = 2; i < (int) Math.Ceiling(Math.Sqrt(num) + 0.5); ++i)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    public class Primes : IEnumerable<int>
    {
        private int _from;
        private int _to;

        public Primes(int _from, int _to)
        {
            this._from = _from;
            this._to = _to;
        }
        
        

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = _from; i <= _to; ++i)
            {
                if (i.IsPrime())
                {
                    yield return i;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Evens: IEnumerable<int>
    {
        private int _from;
        private int _to;

        public Evens(int _from, int _to)
        {
            this._from = _from;
            this._to = _to;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = _from + (_from % 2); i <= _to; i += 2)
            {
                yield return i;
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
            Console.WriteLine(typeof(int));
            Evens evens = new Evens(15,35);
            foreach (var ev in evens)
            {
                Console.Write(ev + " ");
            }
            
            Console.WriteLine();
            
            Primes primes = new Primes(1, 100);

            foreach (var pr in primes)
            {
                Console.Write(pr + " ");
            }
        }
    }
}
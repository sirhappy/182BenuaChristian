using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task4
{

    public class CyclicEnumerator<T>: IEnumerable<T>
    {
        private int _startIndex;
        private IList<T> _collection;

        public CyclicEnumerator(int stIndex, IList<T> collection)
        {
            _startIndex = stIndex;
            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int addition = 0; addition < _collection.Count; ++addition)
            {
                yield return _collection[(addition + _startIndex) % _collection.Count];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class EnumerableExtensions
    {
        public static CyclicEnumerator<T> CyclicEnumerator<T>(this IEnumerable<T> enumerable, int stIndx)
        {
            return new CyclicEnumerator<T>(stIndx, enumerable.ToList());
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>(new []{1,2,3,4,5,6,7,8,9,10});
            foreach (var el in list.CyclicEnumerator(1))
            {
                Console.WriteLine(el);
            }
        }
    }
}
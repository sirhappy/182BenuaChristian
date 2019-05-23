using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task1
{

    public class MessagesGrouper : IEnumerable<string[]>
    {
        private IEnumerable<string> _dictionary;

        public MessagesGrouper(IEnumerable<string> sourceDict)
        {
            _dictionary = sourceDict;
        }
        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (var el in _dictionary.GroupBy(el => el[0]).OrderBy(el => el.Key))
            {
                yield return el.ToArray();
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
            MessagesGrouper grouper = new MessagesGrouper(new []
            {
                "abacaba", "avacado", "abracadabra", "badata",
                "bigData", "carvenous", "doubt", "solt", "sent", "sad", "said"
                
            });
            foreach (var dictElement in grouper)
            {
                foreach (var word in dictElement)
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine();
            }
        }
    }
}
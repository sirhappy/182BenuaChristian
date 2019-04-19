using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task2
{

    public class RectSet
    {
        private static Random rnd = new Random();
        
        public int MinPoint { get; private set; }
        
        public int MaxPoint { get; private set; }

        public HashSet<int> PointSet { get; private set; }
     
        public RectSet() { this.PointSet = new HashSet<int>(); }

        public RectSet(int minPoint, int maxPoint, int n)
        {
            //this.MinPoint = minPoint;
            //this.MaxPoint = maxPoint;
            int[] arr = new int[n];
            int mn = Int32.MaxValue;
            int mx = Int32.MinValue;
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rnd.Next(minPoint, maxPoint + 1);
                mn = Math.Min(arr[i], mn);
                mx = Math.Max(arr[i], mx);
            }

            this.MinPoint = mn;
            this.MaxPoint = mx;
            this.PointSet = new HashSet<int>(arr);
        }

        public RectSet(IEnumerable<int> rect)
        {
            if (!rect.Any())
            {
                throw new ArgumentException();
            }
            this.PointSet = new HashSet<int>(rect);
            
            this.MinPoint = rect.Min();
            this.MaxPoint = rect.Max();
        }

        public override string ToString()
        {
            var res = $"{this.MinPoint}, {this.MaxPoint}\n";
            foreach (var el in this.PointSet)
            {
                res += el + ", ";
            }

            return res + "\n";
        }

        public static RectSet operator +(RectSet a, RectSet b)
        {
            return new RectSet(a.PointSet.Concat(b.PointSet));
        }

        public static RectSet operator *(RectSet a, RectSet b)
        {
            return new RectSet(a.PointSet.Intersect(b.PointSet));
        }

        public static RectSet operator ^(RectSet a, RectSet b)
        {
            return new RectSet((a + b).PointSet.Except((a * b).PointSet));
        }
        
        
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var set1 = new RectSet(new [] {1,2,3,4,5});
            var set2 = new RectSet(new [] {4,7,6,5,10});
            Console.WriteLine(set1 + set2);
            Console.WriteLine(set1 * set2);
            Console.WriteLine(set1 ^ set2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{

    public class RefType: IComparable<RefType>
    {
        public int X { get; set; }

        public int CompareTo(RefType other)
        {
            return X.CompareTo(other.X);
        }
    }

    public struct ValType: IComparable<ValType>
    {
        public int X { get; set; }

        public int CompareTo(ValType other)
        {
            return X.CompareTo(other.X);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();
            int n = 100000;
            ValType[] arr = new ValType[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i].X = rnd.Next(1, 1000000);
            }
            stopwatch.Start();

            Array.Sort(arr);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            RefType[] arr1 = new RefType[n];
            for (int i = 0; i < n; ++i)
            {
                arr1[i] = new RefType();
                arr1[i].X = rnd.Next(1, 1000000);
            }
            stopwatch.Start();

            Array.Sort(arr1);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);


        }
    }
}

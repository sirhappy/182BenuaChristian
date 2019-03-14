using System;
using System.Linq;

namespace task1
{

    interface IIfc1
    {
        void PrintOut(string s);
    }

    class MyClass : IIfc1
    {
        string mystr = "IS";
        int numb = 15;
        int kek = 0;

        private int Obama{get;set;}

        public void PrintOut(string s)
        {
            numb++;
            Console.Write("Call: {0} {1} {2}.", s, mystr, numb);
        }

        public void ChistKek()
        {
            Console.WriteLine(kek);
        }
    }

    class DerivedClass : MyClass
    {

    }

    public static class RandomContainer
    {
        public static Random rnd = new Random();
    }

    public class Point<T> : IComparable<Point<T>> where T : struct, IComparable<T>
    {

        public T X { get; set; }

        public T Y { get; set; }

        public double Dist(Point<T> to)
        {
            dynamic x1, x2, y1, y2;
            x1 = this.X;
            x2 = to.X;
            y1 = this.Y;
            y2 = to.Y;

            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public double Dist() 
        {
            dynamic x, y;
            x = X;
            y = Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public Point(T x, T y)
        {
            this.X = x;
            this.Y = y;
        }

        int IComparable<Point<T>>.CompareTo(Point<T> other)
        {
            return this.Dist().CompareTo(other.Dist());
        }

        public static Point<float> MakePoint()
        {
            return new Point<float>((float)RandomContainer.rnd.NextDouble() * 100,(float)RandomContainer.rnd.NextDouble() * 100);
        }

        public override string ToString()
        {
            return $"Point with {X, 10}, {Y, 10}";
        }
    }

    public class ArrayList<T>
    {
        private T[] array;

        public int itemsCount
        {
            get;
            private set;
        }

        public ArrayList()
        {
            array = new T[0];
        }

        public ArrayList(int sz)
        {
            array = new T[sz];
            itemsCount = sz;
        }

        public void Add(T item)
        {
            if (array.Length < 2 * (itemsCount + 1))
            {
                var newArr = new T[2 * (itemsCount + 1)];
                int ind = 0;
                foreach (var el in array)
                {
                    newArr[ind] = el;
                    ind++;
                }
                this.array = newArr;
            }
            array[itemsCount++] = item;
        }

        public void Erase(T item)
        {
            int ind = Array.IndexOf(this.array, item);

            if (ind != -1)
            {
                for (int i = ind + 1; i < this.array.Length; ++i)
                {
                    this.array[i - 1] = this.array[i];
                }
                itemsCount--;
            }

            if (array.Length > itemsCount * 4)
            {
                T[] newArr = new T[itemsCount * 2];

                for (int i = 0; i < this.itemsCount; ++i)
                {
                    newArr[i] = this.array[i];
                }

                this.array = newArr;

            }
        }

        public T this[int index]
        {
            get
            {
                return this.array[index];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*ArrayList<int> arr = new ArrayList<int>();
            for (int i = 0; i < 5; ++i)
            {
                arr.Add(i);
            }

            for (int i = 0; i < 5; ++i)
            {
                arr.Erase(i);
            }*/

            Point<float>[] arr = new Point<float>[10];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = Point<float>.MakePoint();
                Console.WriteLine(arr[i]);
            }
            var sortedArr = arr.OrderByDescending((arg) => arg.Dist());
            Console.WriteLine();
            foreach (var el in sortedArr)
            {
                Console.WriteLine(el);
                Console.WriteLine(el.Dist());
            }
        }
    }
}

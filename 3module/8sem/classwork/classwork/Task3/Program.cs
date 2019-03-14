using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{

    struct PointS: IComparable<PointS>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointS(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Distance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public int CompareTo(PointS other)
        {
            return Distance().CompareTo(other.Distance());
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    struct CircleS: IComparable<CircleS>
    {
        private double _radius;
        public double Radius
        {
            get => _radius;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Cant be negative");
                }
                _radius = value;
            }
        }
        private PointS _center;
        public PointS Center
        {
            get => _center;
            set
            {
                _center = value;
            }
        }

        public CircleS(double r, int x, int y)
        {
            _center = new PointS(x, y);
            _radius = r;
        }

        public int CompareTo(CircleS other)
        {
            return this.Radius.CompareTo(other.Radius);
        }

        public override string ToString()
        {
            return $"CircleS with Rad:{Radius} and center: {Center}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            CircleS[] arr = new CircleS[10];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = new CircleS(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
            }
            arr.ToList().ForEach(el => Console.WriteLine(el));
            Console.WriteLine();
            arr.OrderBy(el => el.Radius).ToList().ForEach(el => Console.WriteLine(el));
            Console.WriteLine();

            arr.OrderBy(el => el.Center).ToList().ForEach(el => Console.WriteLine(el));
        }
    }
}

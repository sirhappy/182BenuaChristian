using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{

    struct PointS : IComparable<PointS>
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

        public double Distance(PointS other)
        {
            return Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
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

    struct MassPoint
    {
        public PointS Coords { get; private set; }

        public double Weight { get; private set; }

        public MassPoint(PointS center, double weight)
        {
            this.Coords = center;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"Coords:{Coords}, mass: {Weight}";
        }
    }

    struct MassPointSet
    {
        public PointS center { get; private set; }

        public MassPoint[] arr { get; set; }

        public double Radius { get; set; }

        public MassPointSet(MassPoint[] source, double r, PointS center)
        {
            this.Radius = r;
            this.center = center;
            arr = source.Where(el => el.Coords.Distance(center) <= r).ToArray();
        }

        public MassPoint MassCenter
        {
            get
            {
                double mass = arr.ToList().ConvertAll(el => el.Weight).Aggregate((a, b) => a + b);
                if (Math.Abs(mass) <= 1e-9)
                {
                    throw new InvalidOperationException("Cant get mass center with 0 weight");
                }

                double sumx = 0;
                double sumy = 0;

                for (int i = 0; i < arr.Length; ++i)
                {
                    sumx += arr[i].Weight * arr[i].Coords.X;
                    sumy += arr[i].Weight * arr[i].Coords.Y;
                }
                return new MassPoint();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

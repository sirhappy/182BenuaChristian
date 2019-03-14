using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{

    struct PointS : IComparable<PointS>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointS(double x, double y)
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
            return $"({X:F3}, {Y:F3})";
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
            return $"Coords:{Coords}, mass: {Weight:F3}";
        }
    }

    struct MassPointSet
    {
        public PointS center { get; private set; }

        public MassPoint[] arr { get; private set; }

        public double Radius { get; private set; }

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
                return new MassPoint(new PointS(sumx / mass, sumy / mass), mass);
            }
        }

        public override string ToString()
        {
            return $"Radius: {Radius:F3}, center:{center}";
        }
    }

    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<MassPoint> points = new List<MassPoint>();
            for (int i = 0; i < n; ++i)
            {
                points.Add(new MassPoint(new PointS(rnd.NextDouble() * 20 - 10, rnd.NextDouble() * 20 - 10), rnd.NextDouble()));
                Console.WriteLine(points.Last());
            }

            do
            {
                Console.WriteLine("Enter Radius");
                double r = double.Parse(Console.ReadLine());

                MassPointSet set = new MassPointSet(points.ToArray(), r, new PointS(0, 0));

                Console.WriteLine("All items in MassPointSet");
                set.arr.ToList().ForEach(el => Console.WriteLine(el.ToString()));

                Console.WriteLine("MassCenter");
                Console.WriteLine(set.MassCenter);

                Console.WriteLine("Esc");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

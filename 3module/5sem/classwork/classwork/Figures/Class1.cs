using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Figures
{
    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
            null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[]
            { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }
    }

    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(Point other)
        {
            this.X = other.X;
            this.Y = other.Y;
        }

        public double Distance(Point other)
        {
            return Math.Sqrt((this.X - other.X) * (this.X - other.X) + (this.Y - other.Y) * (this.Y - other.Y));
        }

        public override string ToString()
        {
            return $"({X.ToString("F3")}, {Y.ToString("F3")})";
        }

        public static Point ReadPoint()
        {
            double x = Reader.Read<double>("Enter x coord of Point", "Smth wrong, reenter pls", (arg) => Math.Abs(arg) <= 10000);

            double y = Reader.Read<double>("Enter y coord of Point", "Smth wrong, reenter pls", (arg) => Math.Abs(arg) <= 10000);
            return new Point(x, y);
        }
    }

    public class Circle
    {
        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public Circle(Point center, double radius)
        {
            this.Center = new Point(center);
            this.Radius = radius;
        }

        public override string ToString()
        {
            return $"Circle with center in {Center}, and Radius: {Radius.ToString("F3")}";
        }

        public static Circle ReadCircle()
        {
            double r = Reader.Read<double>("Enter circle's radius", "smth wrong with your input, reenter pls", (arg) => arg > 0 && arg <= 1000);
            Point center = Point.ReadPoint();
            return new Circle(center, r);
        }
    }

    public class Triangle
    {
        public List<Point> Points { get; private set; }

        public Triangle(Point a, Point b, Point c)
        {
            Points.Add(new Point(a));
            Points.Add(new Point(b));
            Points.Add(new Point(c));
        }

        public Triangle(params Point[] points)
        {
            Array.ForEach(points, (el) => this.Points.Add(new Point(el)));
        }

        private double this[int ind]
        {
            get
            {
                int next = (ind + 1) % Points.Count;

                return Points[ind].Distance(Points[next]);
            }
        }

        private double Perimeter
        {
            get
            {
                double per = 0;

                for (int i = 0; i < Points.Count; ++i)
                {
                    int next = (i + 1) % Points.Count;

                    per += Points[i].Distance(Points[next]);
                }
                return per;
            }
        }

        public double Area => Math.Sqrt((Perimeter / 2) * (Perimeter / 2 - this[0]) * (Perimeter / 2 - this[1]) * (Perimeter / 2 - this[2]));

    }
}

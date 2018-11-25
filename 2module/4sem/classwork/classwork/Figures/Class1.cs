using System;
using System.Collections.Generic;
namespace Figures
{

    public class Rand
    {
        public static Random rnd = new Random();
    }

    public class Point
    {
        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public virtual double Area
        {
            get
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"X : {X}, Y : {Y}";
        }

        public Point()
        {
            X = Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point MakePoint() {
            return new Point(Rand.rnd.Next(-100, 100), Rand.rnd.Next(-100, 100));
        }

        public static Point[] FigArray()
        {
            int sz = Rand.rnd.Next(1, 11);
            Point[] arr = new Point[sz];
            for (int i = 0; i < sz; ++i)
            {
                int gen = Rand.rnd.Next(0, 3);
                if (gen == 1)
                {
                    arr[i] = new Circle(Rand.rnd.Next(10, 100), Rand.rnd.Next(10, 100), Rand.rnd.Next(10, 100));
                }
                else if (gen == 2)
                {
                    arr[i] = new Square(Rand.rnd.Next(10, 100), Rand.rnd.Next(10, 100), Rand.rnd.Next(10, 100));
                } else {
                    arr[i] = new Triangle(MakePoint(), MakePoint(), MakePoint());
                }
            }
            return arr;
        }

        public double DistTo(Point o) {
            return Math.Sqrt((X - o.X) * (X - o.X) + (Y - o.Y) * (Y - o.Y));
        }
    }

    public class Circle : Point
    {
        private double rad;
        public double Rad
        {
            get
            {
                return rad;
            }
            private set
            {
                rad = value;
            }
        }

        public override string ToString()
        {
            return $"Radius : {rad}, x : {X}, y : {Y}";
        }

        public override double Area => Math.PI * rad * rad;

        public double Len => 2 * Math.PI * rad;

        public Circle()
        {
            rad = 0;
        }

        public Circle(double x, double y, double rad) : base(x, y)
        {
            Rad = rad;
        }

    }

    public class Square : Point
    {
        private double side;
        public double Side
        {
            get
            {
                return side;
            }
            private set
            {
                side = value;
            }
        }

        public override string ToString()
        {
            return $"side : {Side}, X : {X}, Y : {Y}";
        }

        public override double Area => side * side;

        public double Len => side * 4;

        public Square()
        {
            side = 0;
        }

        public Square(double side, double x, double y) : base(x, y)
        {
            this.side = side;
        }
    }

    public class Triangle : Point {
        Point a, b;

        public Triangle() {}

        public Triangle(Point a, Point b, Point c) : base(a.X,a.Y) {
            this.a = b;
            this.b = c;
        }

        public double Len => DistTo(a) + a.DistTo(b) + b.DistTo(new Point(base.X, base.Y));

        public override double Area => Math.Sqrt(Len/2 * (Len/2 - base.DistTo(a)) * (Len / 2 - a.DistTo(b)) * (Len / 2 - b.DistTo(new Point(base.X, base.Y))));

        public override string ToString()
        {
            return $"Triangle, a:{base.ToString()}, b:{a}, c:{b}";
        }
    }

    public abstract class Dimensions {
        protected List<double> dimSizes;

        protected Dimensions() {
            dimSizes = new List<double>();
        }

        protected Dimensions(params double[] arr) : this() {
            for (int i = 0; i < arr.Length; ++i) {
                dimSizes.Add(arr[i]);
            }
        }

        public void Scale(double me) {
            for (int i = 0; i < dimSizes.Count; ++i) {
                dimSizes[i] *= me;
            }
        }

        public abstract string Info();

        public abstract double Volume
        {
            get;
        }
    }

    public class Ellipse : Dimensions {

        public Ellipse(){}

        public Ellipse(params double[] a) : base(a) {}

        public override double Volume {
            get {
                double ans = Math.PI;
                for (int i = 0; i < dimSizes.Count; ++i) {
                    ans += dimSizes[i];
                }
                return ans;
            }
        }

        public override string Info()
        {
            string ans = "Ellipse ";
            for (int i = 0; i < dimSizes.Count; ++i) {
                ans += $"{dimSizes[i].ToString("F3")} ";
            }
            return ans;
        }
    }

    public class Triangle1 : Dimensions {
        public Triangle1(){}

        public Triangle1(double x, double y) : base(x,y) {}

        public override string Info()
        {
            return $"Triangle {dimSizes[0]} {dimSizes[1]}";
        }
        public override double Volume => dimSizes[0] * dimSizes[1];
    }
}

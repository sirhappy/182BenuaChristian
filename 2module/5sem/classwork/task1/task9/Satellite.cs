using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{

    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point operator *(Point a, double b)
        {
            return new Point(a.X * b, a.Y * b);
        }

        public static Point operator /(Point a, double b)
        {
            return new Point(a.X / b, a.Y / b);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point Rotate(Point a, double angle)
        {
            return new Point(a.X * Math.Cos(angle) - a.Y * Math.Sin(angle),
                a.X * Math.Sin(angle) + a.Y * Math.Cos(angle));
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Spiral
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double MaxValue { get;  set; }

        public Spiral()
        {
            A = B = 0;
        }

        public Spiral(double a, double b, double maxValue = 0)
        {
            A = a;
            B = b;
            MaxValue = maxValue;
        }

        public double Radius(double thetta)
        {
            return Math.Min(A + B * thetta, MaxValue*1.5);
        }
    }

    public class Satellite
    {
        public double Rad { get; private set; }
        public Point Center { get; set; }
        public double Dthetta { get; private set; }
        public Spiral orbitSpiral { get; private set; }


        public Satellite()
        {
            Dthetta = 0;
            Center = new Point(0, 0);
        }

        public Satellite(double cx, double cy, double dt, double rad, double mo, double a, double b)
        {
            Center = new Point(cx, cy);
            Dthetta = dt;
            Rad = rad;
            orbitSpiral = new Spiral(a, b, mo);
        }

        public void Draw(Bitmap image,int tickNumber)
        {
            double angle = Dthetta * tickNumber;
            Point toRotate = new Point(0,1);
            toRotate = Point.Rotate(toRotate, angle);
            double rad = orbitSpiral.Radius(angle);
            Point centerOfSatellite = Center + toRotate * rad;
            Point leftTopPoint = centerOfSatellite - new Point(Rad, Rad) / Math.Sqrt(2);
            using (var g = Graphics.FromImage(image))
            {
                g.FillEllipse(new SolidBrush(Color.DarkGray), (float)leftTopPoint.X, (float)leftTopPoint.Y, (float)Rad, (float)Rad);
            }
        }
    }
}

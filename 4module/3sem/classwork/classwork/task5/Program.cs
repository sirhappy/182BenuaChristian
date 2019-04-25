using System;
using System.Security.Policy;

namespace task5
{

    public class Interval
    {
        public double MinPoint { get; private set; }
        public double MaxPoint { get; private set; }

        public double Length => MaxPoint - MinPoint;

        public Interval(double left, double right)
        {

            if (left > right)
            {
                (left, right) = (right, left);
            }
            
            this.MinPoint = left;
            this.MaxPoint = right;
            
        }

        public Interval(Interval a)
        {
            this.MinPoint = a.MinPoint;
            this.MaxPoint = a.MaxPoint;
        }

        public override string ToString()
        {
            return $"({MinPoint:F3}, {MaxPoint:F3})";
        }

        public static Interval operator +(Interval a, Interval b)
        {
            return new Interval(a.MinPoint + b.MinPoint, a.MaxPoint + b.MaxPoint);
        }

        public static Interval operator -(Interval a, Interval b)
        {
            return new Interval(a.MinPoint - b.MinPoint, a.MaxPoint - b.MaxPoint);
        }

        public static Interval operator *(Interval a, Interval b)
        {
            double left = Math.Min(Math.Min(a.MinPoint * b.MinPoint, a.MinPoint * b.MaxPoint),
                Math.Min(a.MaxPoint * b.MinPoint, a.MaxPoint * b.MaxPoint));
            double right = Math.Max(Math.Max(a.MinPoint * b.MinPoint, a.MinPoint * b.MaxPoint),
                Math.Max(a.MaxPoint * b.MinPoint, a.MaxPoint * b.MaxPoint));
            
            return new Interval(left, right);
        }

        public static Interval operator /(Interval a, Interval b)
        {
            if (Math.Abs(b.MinPoint) < 1e-9 || Math.Abs(b.MaxPoint) < 1e-9)
            {
                throw new DivideByZeroException();
            }
            
            double left = Math.Min(Math.Min(a.MinPoint / b.MinPoint, a.MinPoint / b.MaxPoint), Math.Min(a.MaxPoint / b.MinPoint, a.MaxPoint / b.MaxPoint));
            double right = Math.Max(Math.Max(a.MinPoint / b.MinPoint, a.MinPoint / b.MaxPoint), Math.Max(a.MaxPoint / b.MinPoint, a.MaxPoint / b.MaxPoint));
            
            
            return new Interval(left, right);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Interval a = new Interval(5, 9);
            Interval b = new Interval(6, 10);
            Console.WriteLine(a + b);
            Console.WriteLine((a + b).Length);
            Console.WriteLine(a - b);
            Console.WriteLine((a - b).Length);

            Console.WriteLine(a * b);
            Console.WriteLine((a * b).Length);

            Console.WriteLine(a / b);
            Console.WriteLine((a / b).Length);

        }
    }
}
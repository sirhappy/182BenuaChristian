using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task2
{
    public class Point: IEquatable<Point> {
        
        public Point(int x, int y) 
        { 
            this.X = x;
            this.Y = y; 
        }
        public int X { get; set; } 
        public int Y { get; set; } 
        
        public double Mod
        {
            get { return Math.Sqrt(X * X + Y * Y); } }
 
        public bool Equals(Point other)
        {
            if (X == other.X && Y == other.Y)
                return true; 
            else
                return false; 
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, mod = {2:G5}", X, Y, Mod);
        } 
    }

    public class DistinctPointSet : IEnumerable<Point>
    {
        private IEnumerable<Point> _pointSet;

        public DistinctPointSet()
        {
            _pointSet = new List<Point>();
        }
        
        public DistinctPointSet(IEnumerable<Point> points)
        {
            _pointSet = points;
        }
        
        public IEnumerator<Point> GetEnumerator()
        {
            return _pointSet.Distinct().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Point point)
        {
            _pointSet = _pointSet.Append(point);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            DistinctPointSet set = new DistinctPointSet( );
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(7, 1));
            set.Add(new Point(7, 2));
            set.Add(new Point(5, 2));
            set.Add(new Point(7, 2)); 
            Console.WriteLine("Список точек на плоскости:"); 
            foreach (Point p in set)
                Console.WriteLine(p.ToString()); 
        }
    }
}
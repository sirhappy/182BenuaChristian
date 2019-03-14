using System;
using System.Linq;

namespace task3
{

    public static class RandomContainer
    {
        public static Random rnd = new Random();
    }

    public interface IFigure
    {
        double GetArea();
    }

    public class Square : IFigure
    {
        public int Side { get; private set; }

        public Square(int sd)
        {
            Side = sd;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public static Square MakeSquare()
        {
            return new Square(RandomContainer.rnd.Next(1, 100));
        }
        public override string ToString()
        {
            return $"Square with {GetArea()}";
        }
    }

    public class Circle : IFigure
    {
        public int Radius { get; private set; }

        public Circle(int rad)
        {
            this.Radius = rad;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public static Circle MakeCircle()
        {
            return new Circle(RandomContainer.rnd.Next(1, 100));
        }

        public override string ToString()
        {
            return $"Circle with {GetArea()}";
        }
    }



    class Program
    {

        public static void FilterAreas<T>(T[] arr, double maxArea) where T:IFigure
        {
            arr.Where(arg => arg.GetArea() <= maxArea).ToList().ForEach(el => Console.WriteLine(el));
        }

        static void Main(string[] args)
        {
            Circle[] circles = new Circle[10];
            Square[] squares = new Square[10];

            for (int i = 0; i < circles.Length; ++i)
            {
                circles[i] = Circle.MakeCircle();
                squares[i] = Square.MakeSquare();
                Console.WriteLine(circles[i]);
                Console.WriteLine(squares[i]);
            }
            Console.WriteLine("Filter");
            FilterAreas<Square>(squares, 100);
            FilterAreas<Circle>(circles, 100);
        }
    }
}

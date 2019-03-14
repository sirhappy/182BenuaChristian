using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    struct Coords
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Circle
    {
        private Coords _center;

        public Coords Center
        {
            get => _center;
            set
            {
                _center = value;
            }
        }

        private double _radius;

        public double Radius
        {
            get => _radius;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Radius cant be negative");
                }
                _radius = value;

            }
        }


        public Circle(double x, double y, double r)
        {
            _center.X = x;
            _center.Y = y;
        }

        public Circle(double r, Coords c)
        {
            this.Center = c;
            this.Radius = r;
        }

        public override string ToString()
        {
            return $"Circle with radius {Radius.ToString("F3")}, X: {Center.X}, Y: {Center.Y}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Polygon
    {
        private int Sides;
        private double InnerRadius;

        public Polygon(int sides = 3, double innerRadius = 1)
        {
            Sides = sides;
            InnerRadius = innerRadius;
        }

        public double Perimeter
        {
            get { return Sides * 2 * InnerRadius / Math.Tan(Math.PI / Sides); }
        }

        public double Area
        {
            get { return InnerRadius * Perimeter / 2; }
        }

        public string PolygonData()
        {
            string res = "{0} Sides, InnerRadius is {1}, Perimeter is {2}, Area is {3}";
            return string.Format(res, Sides, InnerRadius, Perimeter, Area);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            List<Polygon> list = new List<Polygon>();
            for (int i = 0; ; ++i)
            {
                int sides = int.Parse(Console.ReadLine());
                double radius = double.Parse(Console.ReadLine());
                if (sides == 0 && Math.Abs(radius) < 1e-9)
                {
                    break;
                }
                list.Add(new Polygon(sides, radius));
                Console.WriteLine(list.Last().PolygonData());
            }

            list.Sort((a, b) => Math.Abs(a.Area - b.Area) < 1e-9 ? 0 : a.Area < b.Area ? -1 : 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(list[0].PolygonData());
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i < list.Count - 1; ++i)
            {
                Console.WriteLine(list[i].PolygonData());
            }

            if (list.Count != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(list.Last().PolygonData());
            }

            Console.ReadLine();
        }
    }
}

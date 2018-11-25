using System;
using Figures;
namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Point p = new Point(1,2);

            p.Display();
            Console.WriteLine(p.Area);
            Console.WriteLine();

            p = new Circle(1, 2, 6);
            p.Display();
            Console.WriteLine(p.Area);
            Console.WriteLine();

            p = new Square(3, 1, 2);
            p.Display();
            Console.WriteLine(p.Area);*/

            Point[] pts = Point.FigArray();
            int cntSq = 0;
            int cntCirc = 0;
            for (int i = 0; i < pts.Length; ++i)
            {
                Console.WriteLine(pts[i]);
                if (pts[i] is Circle)
                {
                    cntCirc++;
                    Console.Write(" " + ((Circle)pts[i]).Len.ToString("F3"));
                }
                if (pts[i] is Square)
                {
                    cntSq++;
                    Console.Write(" " + ((Square)pts[i]).Len.ToString("F3"));
                }
                Console.WriteLine(" " + pts[i].Area.ToString("F3"));
            }
            Console.WriteLine();
            Console.WriteLine(cntSq);
            Console.WriteLine(cntCirc);

            Array.Sort(pts, (Point x, Point y) => x.Area == y.Area ? 0 : x.Area < y.Area ? -1 : 1);
            for (int i = 0; i < pts.Length; ++i) {
                Console.WriteLine(pts[i]);
                Console.WriteLine(pts[i].Area);
                Console.WriteLine();
            }
            //Array.Sort(pts, (Point x, Point y) => (x.X * x.X + x.Y * x.Y).CompareTo(y.X * y.X + y.Y * y.Y);
        }
    }
}

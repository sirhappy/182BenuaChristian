using System;
using System.Reflection;

namespace task2
{
    public class Point
    {
        double _x;
        double _y;
        public double X
        {
            get => _x;

            private set
            {
                _x = value;
            }
        }
        public double Y
        {
            get => _y;

            private set
            {
                _y = value;
            }
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

        public Point(Point a)
        {
            this.X = a.X;
            this.Y = a.Y;
        }

    }

    public class Square
    {
        public event Action<double> OnSizeChanged;

        public Point _origin;

        public Point _rightmostPoint;

        public Point Origin
        {
            get => _origin;

            private set
            {
                _origin = value;
                OnSizeChanged?.Invoke(RightmostPoint.X - Origin.X);
            }
        }

        public Point RightmostPoint
        {
            get => _rightmostPoint;

            set
            {
                _rightmostPoint = value;
                OnSizeChanged?.Invoke(RightmostPoint.X - Origin.X);
            }
        }


        public Square()
        {
            Origin = new Point();
            RightmostPoint = new Point();
        }


        public Square(Point origin, double len)
        {
            Origin = new Point(origin);
            RightmostPoint = new Point(origin.X + len, origin.Y + len);
        }

        public Square(Point origin, Point right)
        {
            Origin = new Point(origin);
            RightmostPoint = new Point(right);
        }


    }

    class Program
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static |
            BindingFlags.Public, null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[] { Console.ReadLine(), null })))
             && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }

        static void Main(string[] args)
        {
            do
            {
                Square testable = new Square();
                testable.OnSizeChanged += SquareConsoleInfo;
                double x1, x2, y1, y2;
                x1 = x2 = y1 = y2 = 0;
                while (x2 != -1 || y2 != -1)
                {
                    Console.WriteLine("TO exit enter  -1 -1");
                    //x1 = Read<double>("X of the origin", "error, reenter", (a) => Math.Abs(a) < 10000);
                    //y1 = Read<double>("y of the origin", "error, reenter", (a) => Math.Abs(a) < 10000);

                    x2 = Read<double>("x of the rightmost Point", "error, reenter", (a) => Math.Abs(a) < 10000);
                    y2 = Read<double>("y of the rightmost Point", "error, reenter", (a) => Math.Abs(a) < 10000);

                    testable.RightmostPoint = new Point(x2, y2);

                }

                Console.WriteLine("To exit press Esc");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static void SquareConsoleInfo(double len)
        {
            Console.WriteLine($"Length of square is {len.ToString("F2")}");
        }
    }
}

using System;
using System.Reflection;

namespace homework
{

    public static class RandomContainer
    {
        public static Random rnd = new Random();
    }

    class Point
    {

        public event Action<Point> OnCoordsChanged;

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

        public void PointFlow()
        {//ЭТО ЧТО, ПОТОКИ? {
            for (int i = 0; i < 10; ++i)
            {
                X = RandomContainer.rnd.NextDouble() * 20 - 10;
                Y = RandomContainer.rnd.NextDouble() * 20 - 10;
                if (_y < 0 && _x < 0)
                {
                    OnCoordsChanged?.Invoke(this);
                }
                Console.WriteLine($"{X}, {Y}");
            }
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
            double x = Read<double>("Enter X coord", "error, reenter", (arg) => Math.Abs(arg) < 1000);
            double y = Read<double>("Enter y coord", "error, reenter", (arg) => Math.Abs(arg) < 1000);

            Point point = new Point(x, y);
            point.OnCoordsChanged += PrintInfo;
            point.PointFlow();
        }

        public static void PrintInfo(Point a)
        {
            Console.WriteLine($"({a.X}, {a.Y})");
        }
    }
}

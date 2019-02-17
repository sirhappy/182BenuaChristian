using System;
using System.Reflection;

namespace task2
{

    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
            null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[]
            { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }
    }

    public class Point
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                XChanged?.Invoke();
            }
        }

        public double Y
        {
            get => _y;

            set
            {
                _y = value;
                YChanged?.Invoke();
            }
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public event Action XChanged;
        public event Action YChanged;

    }

    public class Circle
    {
        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public Circle(double x, double y, double rad)
        {
            Center = new Point(x, y);
            Center.XChanged += () => { Console.WriteLine(Center.X - Radius); Console.WriteLine(Center.X + Radius); };
            Center.YChanged += () => { Console.WriteLine(Center.X - Radius); Console.WriteLine(Center.X + Radius); };

            Radius = rad;
        }

        public static Circle ReadCircle()
        {
            double x = Reader.Read<double>("X coord", "xmth wrong, reenter", (arg) => arg > -1000 && arg < 1000); 
            double y = Reader.Read<double>("y coord", "xmth wrong, reenter", (arg) => arg > -1000 && arg < 1000);
            double r = Reader.Read<double>("rad", "xmth wrong, reenter", (arg) => arg > 0 && arg < 1000);
            return new Circle(x, y, r);
        }
    }

    class Program
    {
        public static void PrintMenu(Circle r)
        {
            Console.WriteLine("1. Change X coord");
            Console.WriteLine("2. Change Y coord");
            int option = Reader.Read<int>("", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 3);

            double ch = Reader.Read<double>("Enter new coord", "smth wrong, reenter pls", (arg) => arg > -1000 && arg < 1000);

            if (option == 1)
            {
                r.Center.X = ch; ;
            }
            else
            {
                r.Center.Y = ch;
            }

        }

        static void Main(string[] args)
        {
            do
            {
                Circle r = Circle.ReadCircle();
                while (true)
                {
                    PrintMenu(r);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

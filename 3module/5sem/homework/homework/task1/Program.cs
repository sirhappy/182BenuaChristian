using System;
using System.Reflection;

namespace task1
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

    public class RectChangedMyEventArgs : EventArgs
    {
        public double Change { get; private set; }
        public RectChangedMyEventArgs(double ch)
        {
            Change = ch;
        }
    }

    public class Rectangle
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }

        public double Area => Side1 * Side2;

        public Rectangle(double h, double w)
        {
            Side1 = h;
            Side2 = w;
        }

        public void SetSide1(double val)
        {
            double prev = Side1;
            Side1 = val;
            OnRectChanged?.Invoke(this, new RectChangedMyEventArgs(prev * Side2 / (Side1 * Side2)));
        }

        public void SetSide2(double val)
        {
            double prev = Side2;
            Side2 = val;
            OnRectChanged?.Invoke(this, new RectChangedMyEventArgs(prev * Side1 / (Side1 * Side2)));
        }

        public event EventHandler<RectChangedMyEventArgs> OnRectChanged;
    }

    public class Block
    {
        public Rectangle rectangle { get; private set; }

        public double Height { get; private set; }

        public double Volume => Height * rectangle.Area;

        public Block(Rectangle r, double h)
        {
            rectangle = r;
            Height = h;
            r.OnRectChanged += OnRectChanged;
        }

        public void OnRectChanged(object sender, RectChangedMyEventArgs e)
        {
            Height *= e.Change;
        }
    }


    class Program
    {

        public static void PrintMenu(Block r)
        {
            Console.WriteLine("1. Change first side");
            Console.WriteLine("2. Change second side");
            int option = Reader.Read<int>("", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 3);

            double ch = Reader.Read<double>("Enter new side", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 1000);

            if (option == 1)
            {
                r.rectangle.SetSide1(ch);
            }
            else
            {
                r.rectangle.SetSide2(ch);
            }

        }

        static void Main(string[] args)
        {
            do
            {
                double W = Reader.Read<double>("first side", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 10000);
                double L = Reader.Read<double>("sec side", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 10000);

                double H = Reader.Read<double>("third side", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 10000);

                Block block = new Block(new Rectangle(W, L), H);
                Console.WriteLine(block.Volume);
                while (true)
                {
                    PrintMenu(block);
                    Console.WriteLine(block.Volume);

                }


                Console.WriteLine("Esc...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

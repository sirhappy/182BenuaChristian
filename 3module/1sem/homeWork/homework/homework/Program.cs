using System;

namespace homework
{
    delegate int MyDelegate(double x, double y);

    public class TestClass
    {
        public int TestMethod(double x, double y)
        {
            return (int)(x) + (int)(y);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            do
            {
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());

                MyDelegate myDelegate = new TestClass().TestMethod;
                Console.WriteLine(myDelegate(x, y));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

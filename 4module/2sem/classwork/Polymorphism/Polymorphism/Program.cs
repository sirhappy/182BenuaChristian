using System;

namespace Polymorphism
{

    public class Base
    {
        private int _cnt = 0;

        public void Print()
        {
            Console.WriteLine(_cnt);
            _cnt++;
        }
    }

    public class Inherit : Base
    {
        public Inherit()
        {
            Console.WriteLine("BANZAI");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Inherit a = new Inherit();
            a.Print();
            a.Print();
        }
    }
}
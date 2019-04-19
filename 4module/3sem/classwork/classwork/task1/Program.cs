using System;
using System.Data.Common;

namespace task1
{

    public class MyComplex
    {
        public double Re { get; private set; }
        
        public double Im { get; private set; }

        public double Abs => Math.Sqrt(Re * Re + Im * Im);

        public MyComplex(double r, double i)
        {
            this.Re = r;
            this.Im = i;
        }


        public override string ToString()
        {
            return $"({Re}, {Im})";
        }

        public static MyComplex operator --(MyComplex a)
        {
            return new MyComplex(a.Re - 1, a.Im - 1);
            //a.Re--;
            //a.Im--;
            //return a;
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re + b.Re, a.Im + b.Im);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re - b.Re, a.Im - b.Im);
        }

        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
        }

        public static MyComplex operator /(MyComplex a, MyComplex b)
        {
            if (Math.Abs(b.Abs) < 1e-9)
            {
                throw new DivideByZeroException();
            }

            double re = (a.Re * b.Re + a.Im * b.Im) / (b.Abs * b.Abs);
            double im = (a.Im * b.Re - a.Re * b.Im) / (b.Abs * b.Abs);
            
            return new MyComplex(re, im);
        }

        public static bool operator <(MyComplex a, MyComplex b)
        {
            return a.Abs < b.Abs;
        }

        public static bool operator >(MyComplex a, MyComplex b)
        {
            return a.Abs > b.Abs;
        }

        public static bool operator true(MyComplex a)
        {
            return a.Abs > 1;
        }

        public static bool operator false(MyComplex b)
        {
            return b.Abs <= 1;
        }
        
        
    }
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyComplex a = new MyComplex(5, 6);

            MyComplex b = new MyComplex(6, 7);
            
            Console.WriteLine(a * b);
        }
    }
}
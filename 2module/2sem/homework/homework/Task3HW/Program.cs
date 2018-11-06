using System;

namespace Task3HW
{

    public class Complex {
        double a, b;

        public Complex() {
            a = b = 0;
        }
        public Complex(double re, double im) {
            a = re;
            b = im;
        }

        public Complex(Complex other) {
            a = other.a;
            b = other.b;
        }
        public Complex(double re) {
            a = re;
            b = 0;
        }

        public double Re {
            get {
                return a;
            }
            set {
                a = value;
            }
        }

        public double Im {
            get {
                return b;
            }
            set {
                b = value;
            }
        }

        public double Abs {
            get {
                return Math.Sqrt(a * a + b * b);
            }
        }

        public double Arg {
            get {
                return Math.Atan2(Im, Re);
            }
        }

        public static Complex operator +(Complex a,Complex other) {
            return new Complex(a.Re + other.Re, a.Im + other.Im);
        }
        public static Complex operator + (Complex a, double b) {
            return new Complex(a.Re + b, a.Im);
        }

        public static Complex operator +(double b, Complex a)
        {
            return new Complex(a.Re + b, a.Im);
        }

        public static Complex operator -(Complex a, Complex other) {
            return new Complex(a.Re - other.Re, a.Im - other.Im);
        }

        public static Complex operator - (Complex a, double b) {
            return new Complex(a.Re - b, a.Im);
        }

        public static Complex operator - (double a, Complex b) {
            return new Complex(a - b.Re, -b.Im);
        }

        public static Complex operator * (Complex a, Complex other) {
            return new Complex(a.Re * other.Re - a.Im * other.Im, a.Re * other.Im + a.Im * other.Re);
        }

        public static Complex operator * (Complex a, double b) {
            return new Complex(a.Re * b, a.Im * b);
        }

        public static Complex operator * (double a, Complex b) {
            return new Complex(a * b.Re, a * b.Im);
        }

        public static Complex operator / (Complex a, double b) {
            return new Complex(a.Re / b, a.Im / b);
        }

        public static Complex operator / (Complex a, Complex b) {
            return new Complex(a.Re * b.Re + a.Im * b.Im, -a.Re * b.Im + a.Im * b.Re) / b.Abs / b.Abs;
        }

        public static Complex operator / (double b, Complex a) {
            return new Complex(new Complex(b, 0) / a);
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}i)", Re, Im);
        }
        
    }

    class Program
    {
        public static double ReadDouble(string In, string Out, Func<double, bool> valid)
        {
            Console.WriteLine(In);
            double n;
            while (!(double.TryParse(Console.ReadLine(), out n) && valid(n)))
            {
                Console.WriteLine(Out);
            }
            return n;
        }

        public static (Complex, Complex) SolveQuadrEquation(double a, double b, double c) {
            double discr = b * b - 4 * a * c;
            if (discr >= 0) {
                return (new Complex((-b + Math.Sqrt(discr)) / (2 * a)), new Complex((-b - Math.Sqrt(discr)) / (2 * a)));
            } else {
                return (new Complex(-b, Math.Sqrt(-discr)) / (2 * a), new Complex(-b, -Math.Sqrt(-discr)) / (2 * a));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a, b, c - coef of quadratic equation");
            double a, b, c;
            a = ReadDouble("A :", "Error, enter A : ", (arg) => Math.Abs(arg) > 1e-5);
            b = ReadDouble("B : ", "Error, enter B : ", (arg) => true);
            c = ReadDouble("C : ", "Error, enter C : ", (arg) => true);
            Console.WriteLine(SolveQuadrEquation(a, b, c));
        }
    }
}

using System;

namespace task6
{
    public class Polynomial2
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Polynomial2(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public int Degree
        {
            get
            {
                if (Math.Abs(A) > 1e-9)
                {
                    return 2;
                }

                if (Math.Abs(B) > 1e-9)
                {
                    return 1;
                }

                return 0;
            }
        }

        public Polynomial2(Polynomial2 another) : this(another.A, another.B, another.C)
        {
        }

        public double Value(double arg) => A * arg * arg + B * arg + C;

        public static Polynomial2 operator +(Polynomial2 lhs, Polynomial2 rhs)
        {
            return new Polynomial2(lhs.A + rhs.A, lhs.B + rhs.B, lhs.C + rhs.C);
        }

        public static Polynomial2 operator -(Polynomial2 lhs, Polynomial2 rhs)
        {
            return new Polynomial2(lhs.A - rhs.A, lhs.B - rhs.B, lhs.C - rhs.C);
        }

        public static Polynomial2 operator *(Polynomial2 lhs, double rhs)
        {
            return new Polynomial2(lhs.A * rhs, lhs.B * rhs, lhs.C * rhs);
        }

        public static Polynomial2 operator /(Polynomial2 lhs, double rhs)
        {
            if (Math.Abs(rhs) < 1e-9)
            {
                throw new DivideByZeroException();
            }

            return new Polynomial2(lhs.A / rhs, lhs.B / rhs, lhs.C / rhs);
        }

        public static Polynomial2 operator %(Polynomial2 lhs, Polynomial2 rhs)
        {
            if (lhs.Degree < rhs.Degree)
            {
                return lhs;
            }

            else if (rhs.Degree == 0)
            {
                if (Math.Abs(rhs.B) < 1e-9)
                {
                    throw new DivideByZeroException();
                }
                return new Polynomial2(0, 0, 0);
            }

            else if (rhs.Degree == 1)
            {
                if (lhs.Degree == 1)
                {
                    double mult = lhs.B / rhs.B;
                    return new Polynomial2(0, 0, lhs.C - mult * rhs.C);
                }
                else
                {
                    double xMult = lhs.A / rhs.B;
                    var temp = lhs - new Polynomial2(rhs.B * xMult, rhs.C * xMult, 0);
                    double finalMult = temp.B / rhs.B;
                    return new Polynomial2(0, 0, temp.C - finalMult * rhs.C);
                }
            }

            else
            {    
                double mult = lhs.A / rhs.A;
                var temp = lhs - (rhs * mult);
                return temp;
            }
        }

        public override string ToString()
        {
            return $"{A}x^2 + {B}x + {C}";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var poly1 = new Polynomial2(1, 2, 1);
            var poly2 = poly1 * 5;
            Console.WriteLine(poly1.Value(1));
            Console.WriteLine(poly2.Value(1));
            Console.WriteLine(poly1 % poly2);
            poly2 -= new Polynomial2(0, 1, 0);
            Console.WriteLine(poly1 % poly2);
        }
    }
}
using System;

namespace task3
{
    interface IFraction
    {
        long Numerator { get; }
        long Denominator { get; }
    }

    public class Fraction : IFraction
    {
        public long Numerator { get; private set; }

        public long Denominator { get; private set; }

        public Fraction(long num, long den)
        {
            if (den == 0)
            {
                throw new ArgumentException("Denominator cant be null");
            }

            int sign = Math.Sign(num) * Math.Sign(den);
            this.Numerator = Math.Abs(num) * sign;
            this.Denominator = Math.Abs(den);
            this.ReduceFraction();
        }

        public Fraction(double value)
        {
            string str = value.ToString("F10").TrimEnd('0');
            int numberOfDigitsAfterDot = Math.Max(str.Length - str.IndexOf('.') - 1, 0);

            double tenPower = Math.Pow(10, numberOfDigitsAfterDot);
            //throws
            long den = checked((long) (tenPower));
            long newValue = checked((long) Math.Ceiling(value * tenPower));
            int sign = Math.Sign(newValue) * Math.Sign(den);

            this.Numerator = Math.Abs(newValue) * sign;
            this.Denominator = Math.Abs(den);
            this.ReduceFraction();
        }

        public double ToDecimal()
        {
            return (double) this.Numerator / this.Denominator;
        }

        private void ReduceFraction()
        {
            long gcd = GCD(Math.Abs(this.Numerator), Math.Abs(this.Denominator));
            this.Numerator /= gcd;
            this.Denominator /= gcd;
        }

        public override string ToString()
        {
            return $"{this.Numerator} / {this.Denominator}";
        }

        public static long GCD(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }

        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return new Fraction(lhs.Numerator * rhs.Denominator + rhs.Numerator * lhs.Denominator,
                rhs.Denominator * lhs.Denominator);
        }

        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return lhs + (-rhs);
        }

        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            return new Fraction(lhs.Numerator * rhs.Numerator, lhs.Denominator * rhs.Denominator);
        }

        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            return new Fraction(lhs.Numerator * rhs.Denominator, lhs.Denominator * rhs.Numerator);
        }

        public static bool operator >(Fraction lhs, Fraction rhs)
        {
            return lhs.Numerator * rhs.Denominator - rhs.Numerator * lhs.Denominator > 0;
        }

        public static bool operator <(Fraction lhs, Fraction rhs)
        {
            return lhs.Numerator * rhs.Denominator - rhs.Numerator * lhs.Denominator < 0;
        }

        public static Fraction operator ++(Fraction fraction)
        {
            return new Fraction(fraction.Numerator + fraction.Denominator, fraction.Denominator);
        }

        public static Fraction operator --(Fraction fraction)
        {
            return new Fraction(fraction.Numerator - fraction.Denominator, fraction.Denominator);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Fraction(0));
        }
    }
}
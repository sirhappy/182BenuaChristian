using System;

namespace mylib
{



    public static class Generator
    {
        /// <summary>
        /// static Random instance
        /// </summary>
        public static Random rnd = new Random();

        /// <summary>
        /// Generate double between mn and mx.
        /// </summary>
        /// <returns>The generate.</returns>
        /// <param name="mn">Min value </param>
        /// <param name="mx">Max value</param>
        public static double Generate(int mn, int mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        /// <summary>
        /// Generates the int between mn and mx
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="mn">Min value.</param>
        /// <param name="mx">Max value</param>
        public static int GenerateInt(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }
        /// <summary>
        /// Generates the string of lenght between mnLen and mxLen
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="mnLen">Mimimum length.</param>
        /// <param name="mxLen">Maximum length.</param>
        public static string GenerateString(int mnLen, int mxLen)
        {
            int len = rnd.Next(mnLen, mxLen);
            string ans = "";
            for (int i = 0; i < len; ++i)
            {
                ans += (char)(rnd.Next('a', 'z' + 1));
            }
            return ans;
        }
        /// <summary>
        /// Generates bool with the specified prob.
        /// </summary>
        /// <returns>The generatebool.</returns>
        /// <param name="prob">Probability</param>
        public static bool GenerateBool(double prob = 0.5)
        {
            if (rnd.Next() < prob)
            {
                return true;
            }
            return false;
        }
    }

    public class GeomProgr
    {
        public static double BinPow(double a, int n) {
            if (n == 0) {
                return 1;
            }
            if (n % 2 == 1) {
                return a * BinPow(a, n - 1);
            } else {
                return BinPow(a * a, n / 2);
            }
        }

        public static int objectNumber = 0;
        double _b;
        double _q;
        public double B { get { return _b; } private set { if (value == 0) throw new ArgumentOutOfRangeException(); _b = value; } }
        public double Q { get { return _q; } private set { if (value == 0) throw new ArgumentOutOfRangeException(); _q = value; } }
   
        public GeomProgr() {
            B = Q = 1;
            objectNumber++;
        }
        public GeomProgr(double b, double q) {
            B = b;
            Q = q;
            objectNumber++;
        }

        public double this[int index] {
            get {
                if (index <= 0) {
                    throw new ArgumentOutOfRangeException();
                }
                return checked(B * BinPow(Q, index - 1));
            }
        }

        public double GetSum(int n) {
            if (n <= 0) {
                throw new ArgumentOutOfRangeException();
            }
            if (Q == 1) {
                return checked(n * B);
            }
            double ans = B * (BinPow(Q, n) - 1) / (Q - 1);
            if (double.IsInfinity(ans)) {
                throw new OverflowException();
            }
            return ans;
        }
    }

    public class RusString : MyString {


        string _rusString;
        public override string Str {
            get {
                return _rusString;
            }
            protected set {
                if (!Valid(value)) {
                    throw new ArgumentOutOfRangeException(nameof(_rusString), "contains non-russian symbols");
                }
                _rusString = value;
            }
        }

        public RusString() {
            this.Str = "";
        }

        public RusString(int n, char st, char fin) : this() {
            if (!Valid(st) || !Valid(fin)) {
                throw new ArgumentOutOfRangeException();
            }
            if (n < 0) {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < n; ++i) {
                this.Str += (char)(rnd.Next(st - 'а', fin - 'а') + 'а');
            }
        }

        public RusString(string s) {
            this.Str = s;
        }

        public int CountLetter(char ch) {
            if (!Valid(ch)) {
                throw new ArgumentOutOfRangeException(nameof(ch), "You cant count non-russian letters in russian word");
            }
            int cnt = 0;
            for (int i = 0; i < _rusString.Length; ++i)
            {
                if (_rusString[i] == ch) {
                    cnt++;
                }
            }
            return cnt;

        }

        public override bool Valid() {
            return Valid(Str);
        }

        public static bool Valid(char ch)
        {
            return (ch >= 'а' && ch <= 'я') || ch == ' ';
        }

        public static bool Valid(string s)
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (!Valid(s[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public abstract class MyString {
        public static Random rnd = new Random();

        public virtual string Str { get; protected set; }

        public virtual bool IsPalindrome() {
            int n = Str.Length;
            for (int i = 0; i < n / 2; ++i)
            {
                if (Str[i] != Str[n - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public abstract bool Valid();
    }

    public class LatString : MyString {

        string _String;
        public override string Str
        {
            get
            {
                return _String;
            }
            protected set
            {
                if (!Valid(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(_String), "contains non-russian symbols");
                }
                _String = value;
            }
        }

        public LatString()
        {
            this.Str = "";
        }

        public LatString(int n, char st, char fin) : this()
        {
            if (!Valid(st) || !Valid(fin))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < n; ++i)
            {
                this.Str += (char)(rnd.Next(st - 'a', fin - 'a') + 'a');
            }
        }

        public LatString(string s)
        {
            this.Str = s;
        }



        public override bool Valid() {
            return Valid(Str);
        }

        public static bool Valid(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || ch == ' ';
        }

        public static bool Valid(string s)
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (!Valid(s[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class QuadraticTrinomial {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }


        public QuadraticTrinomial() {
            A = B = C = 0;
        }

        public QuadraticTrinomial(double a, double b, double c) {
            A = a;
            B = b;
            C = c;
        }

        public double Calculate(double x0) {
            double ans = this.A * x0 * x0 + this.B * x0 + C;
            if (double.IsInfinity(ans)) {
                throw new OverflowException("Too big value in this point");
            }
            return ans;
        }

        public double Divide(double x0, QuadraticTrinomial other) {
            if (Math.Abs(other.Calculate(x0)) < 1e-7) {
                throw new DivideByZeroException("rvalue in this point was almost zero");
            }
            double ans = Calculate(x0) / other.Calculate(x0);
            if (double.IsInfinity(ans))
            {
                throw new OverflowException("Too big value in this point");
            }
            return ans;
        }
    }

    public abstract class Pair<T> where T : IComparable, IEquatable<T> {
        T _x;
        public virtual T X {
            get {
                return _x;
            }
            protected set {
                _x = value;
            }
        }

        public T Y {
            get;
            protected set;
        }

        protected Pair() { }

        protected Pair(T x, T y) {
            X = x;
            Y = y;
        }

        public abstract Pair<T> Add(Pair<T> other);

        public abstract Pair<T> Sub(Pair<T> other);

        public abstract Pair<T> Mult(Pair<T> other);

        public bool Equal(Pair<T> other) {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public int PairEqual(Pair<T> other) {
            if (Equal(other)) {
                return 0;
            }
            if (this.X.Equals(other.X)) {
                return Y.CompareTo(other.Y);
            }
            return this.X.CompareTo(other.X);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static T Add(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }

        public static T Sub(T x, T y) {
            dynamic dx = x, dy = y;
            return dx - dy;
        }

        public static T Mult(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx * dy;
        }

        public static T Division(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx / dy;
        }
    }

    public class Complex<T> : Pair<T> where T : IEquatable<T>, IComparable {
        public Complex(T a, T b) : base(a, b) {}

        public Complex() : base() {}

        public override Pair<T> Add(Pair<T> other)
        {
            return new Complex<T>(Pair<T>.Add(this.X, other.X), Pair<T>.Add(this.Y, other.Y));
        }

        public override Pair<T> Sub(Pair<T> other)
        {
            return new Complex<T>(Pair<T>.Sub(this.X, other.X), Pair<T>.Sub(this.Y, other.Y));
        }

        public override Pair<T> Mult(Pair<T> other)
        {
            return new Complex<T>(Pair<T>.Sub(Pair<T>.Mult(this.X, other.X), Pair<T>.Mult(this.Y, other.Y)),
                                  Pair<T>.Add(Pair<T>.Mult(this.X, other.Y), Pair<T>.Mult(this.Y, this.X)));
        }

        public override string ToString()
        {
            return $"{X} + {Y}i";
        }

        public static Complex<int> MakeComplex() {
            return new Complex<int>(Generator.GenerateInt(-50, 51), Generator.GenerateInt(-50, 51));
        }
    }

    public class Rational : Pair<int> {

        public override int X
        {
            get
            {
                return base.X;
            }
            protected set
            {
                if (value == 0) {
                    base.X = 1;
                    throw new DivideByZeroException("Znamenatel is zero, I'll make it 1");
                }
                base.X = value;
            }
        }

        public Rational(int a, int b) : base(a, b) {}

        public Rational() : base() {}

        private int gcd(int a, int b) {
            if (b == 0) {
                return a;
            }
            return gcd(b, a % b);
        }

        public Rational Reduce() {
            int g = gcd(X, Y);
            return new Rational(X / g, Y / g);
        }

        public override Pair<int> Add(Pair<int> other)
        {
            Rational ans = new Rational(this.X * other.Y + other.X * this.Y, this.Y * other.Y);
            return ans.Reduce();
        }

        public override Pair<int> Sub(Pair<int> other)
        {
            Rational ans = new Rational(this.X * other.Y - other.X * this.Y, this.Y * other.Y);
            return ans.Reduce();
        }

        public override Pair<int> Mult(Pair<int> other)
        {
            Rational ans = new Rational(this.X * other.X, this.Y * other.Y);
            return ans.Reduce();
        }

        public static Rational MakeRational()
        {
            return new Rational(Generator.GenerateInt(-50, 51), Generator.GenerateInt(-50, 51));
        }

        public static bool operator < (Rational a, Rational b) {
            return ((double)a.X / a.Y).CompareTo((double)b.X / b.Y) == -1;
        }
        public static bool operator >(Rational a, Rational b)
        {
            return ((double)a.X / a.Y).CompareTo((double)b.X / b.Y) == 1;
        }
        public static bool operator == (Rational a, Rational b)
        {
            return ((double)a.X / a.Y).CompareTo((double)b.X / b.Y) == 0;
        }
        public static bool operator != (Rational a, Rational b) {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{X} / {Y}";
        }
    }
}

using System;

namespace mylib
{

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
}

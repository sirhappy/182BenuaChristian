using System;
using System.Reflection;

namespace task11
{

    public static class Helper {
        public static double BinPow(double a, int n) {
            if (n == 0) {
                return 1;
            }
            if (n % 2 == 0) {
                return BinPow(a * a, n / 2);
            } else {
                return a * BinPow(a, n - 1);
            }
        }
    }

    public class GeometicProgression {
        double _start;
        double _increment;

        public GeometicProgression() {
            _start = _increment = 1;
        }

        public GeometicProgression(double _start, double _increment) {
            this._start = _start;
            this._increment = _increment;
        }

        public double this[int index] {
            get {
                if (index <= 0) {
                    throw new ArgumentOutOfRangeException();
                }
                double ans = _start * Helper.BinPow(_increment, index - 1);
                if (double.IsInfinity(ans)) {
                    throw new OverflowException();
                }
                return ans;
            }
        }

        public double GetSum(int n) {
            double ans = _start * (Helper.BinPow(_increment, n) - 1) / (_increment - 1);
            if (double.IsInfinity(ans)) {
                throw new OverflowException();
            }
            return ans;
        }

        public override string ToString()
        {
            return $"Geometric: ({_start}, {_increment})";
        }

        public static GeometicProgression MakeGeometricProgression() {
            return new GeometicProgression(Generator.Generate(1, 2), Generator.Generate(1, 2));
        }
    }

    public static class Generator
    {
        public static Random rnd = new Random();

        public static double Generate(int mn, int mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        public static int GenerateInt(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }

        public static string GenerateString(int mnLen, int mxLen)
        {
            int len = rnd.Next(mnLen, mxLen);
            string ans = "";
            for (int i = 0; i < len; ++i)
            {
                ans += (char)(rnd.Next('a', 'z'));
            }
            return ans;
        }
    }

    class Program
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[] { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }

        static void Main(string[] args)
        {
            GeometicProgression a = GeometicProgression.MakeGeometricProgression();
            Console.WriteLine("Other is " + a);
            GeometicProgression[] arr = new GeometicProgression[Generator.GenerateInt(5, 15)];
            for (int i = 0; i < arr.Length; ++i) {
                arr[i] = GeometicProgression.MakeGeometricProgression();
                Console.WriteLine(i + "th is " + arr[i]);
            }
            int step = Generator.GenerateInt(3, 4);
            for (int i = 0; i < arr.Length; ++i) {
                Console.WriteLine(i + "Th sum of first " + step + " is " + arr[i].GetSum(step));
                if (arr[i][step] > a[step]) {
                    Console.WriteLine(i + "th geom prog " + step + "th number is greater than separate object's " + step + "th number");
                }
            }
        }
    }
}

using System;
using System.Reflection;

namespace task10
{

    public static class Rand {
        public static Random rnd = new Random();
    }

    public static class Generator
    {
        public static double Generate(this Random rnd, int mn, int mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        public static int GenerateInt(this Random rnd, int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }

        public static string GenerateString(this Random rnd, int mnLen, int mxLen)
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

    public class Circle {
        double centerX, centerY, r;

        public Circle() {
            centerX = centerY = r = 0;
        }

        public Circle(double cx, double cy, double rad) {
            centerX = cx;
            centerY = cy;
            r = rad;
        }

        public static Circle MakeCircle() {
            return new Circle(Rand.rnd.GenerateInt(1, 15), Rand.rnd.GenerateInt(1, 15), Rand.rnd.GenerateInt(1, 15));
        }

        public static bool Intersect(Circle a, Circle b) {
            return (Math.Sqrt((a.centerX - b.centerX) * (a.centerX - b.centerX) + (a.centerY - b.centerY) * (a.centerY - b.centerY)) <= a.r + b.r);
            
        }

        public override string ToString()
        {
            return $"(({centerX}, {centerY}), {r})";
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
            do
            {
                int n = Read<int>("Enter size of array", "Smth wrong with array size, reenter pls", (arg) => arg > 0 && arg < 1e7);
                Circle[] arr = new Circle[n];
                for (int i = 0; i < arr.Length; ++i)
                {
                    arr[i] = Circle.MakeCircle();
                    Console.WriteLine(i + "th elem is " + arr[i]);
                }
                Circle another = Circle.MakeCircle();
                Console.WriteLine("Another is " + another);
                for (int i = 0; i < n; ++i) {
                    if (Circle.Intersect(arr[i], another)) {
                        Console.WriteLine(arr[i]);
                    }
                }
                Console.WriteLine("To exit press escape");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

using System;
using System.Reflection;
using mylib;

namespace KR
{
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

        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                int n = Read<int>("Enter amount of objects", "Smth wrong with it, reenter pls", (arg) => arg > 0 && arg < 1e5);

                Pair<int>[] arr = new Pair<int>[n];
                for (int i = 0; i < n; ++i) {
                    try {
                        if (Generator.GenerateInt(0, 2) == 0) {
                            arr[i] = Complex<int>.MakeComplex();
                        } else {
                            arr[i] = Rational.MakeRational();
                        }
                    } catch (DivideByZeroException ex) {
                        Console.WriteLine(ex);
                    }
                    Console.WriteLine(arr[i]);
                }

                Rational other = Rational.MakeRational();
                Console.WriteLine(other);
                Console.WriteLine("Those who are bigger");
                for (int i = 0; i < n; ++i) {
                    if (arr[i] is Rational) {
                        if ((arr[i] as Rational) > other) {
                            Console.WriteLine("This " + arr[i] + " is bigger than " + other);
                            Console.WriteLine("And their mult is " + arr[i].Mult(other));

                        }
                    }
                }


                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

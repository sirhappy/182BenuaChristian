using System;
using Task6Lib;
namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Fxdx[] arr = { new Func1(-1, 2), new Func2(0, 0.5), new Func3(-1, 1) };
            for (int i = 0; i < arr.Length; ++i) {
                Console.WriteLine(i + "th value is " + Fxdx.Integral(arr[i], 20));
                Console.WriteLine(i + "th value is " + Fxdx.IntegralRect(arr[i], 20));
            }
        }
    }
}

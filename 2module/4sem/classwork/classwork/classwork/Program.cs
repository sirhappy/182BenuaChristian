using System;
using ClassLibrary;

namespace classwork
{
    
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            A[] arr = new A[10];
            for (int i = 0; i < arr.Length; ++i) {
                if (rnd.Next(0, 3) % 2 == 1) {
                    arr[i] = new A();
                } else {
                    arr[i] = new B();
                }
            }

            for (int i = 0; i < arr.Length; ++i) {
                arr[i].getA();
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; ++i) {
                if (arr[i] is B) {
                    arr[i].getA();
                }
            }

            Console.WriteLine();
            for (int i = 0; i < arr.Length; ++i) {
                var array = arr[i].GetType().ToString().Split(".");
                if (array[array.Length - 1] == "A") {
                    arr[i].getA();
                    Console.WriteLine(arr[i].GetType() + "   " + ((A)arr[i]).GetType());
                }
            }
        }
    }
}

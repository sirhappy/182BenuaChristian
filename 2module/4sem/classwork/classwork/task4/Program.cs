using System;
using EmployeesClassLibrary;
using FiguresExtended;
using System.Collections.Generic;

namespace task4
{
    class Program
    {

        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            do
            {
                Dictionary<Type, int> dict = new Dictionary<Type, int>();
                Shape[] arr = new Shape[rnd.GenerateInt(7, 10)];
                for (int i = 0; i < arr.Length; ++i)
                {
                    int gen = rnd.Next(0, 3);
                    if (gen == 0)
                    {
                        arr[i] = new Circle(rnd.Generate(1, 10));
                        if (!dict.ContainsKey(arr[i].GetType()))
                        {
                            dict.Add(arr[i].GetType(), 0);
                        }
                    }
                    else if (gen == 2)
                    {
                        arr[i] = new Sphere(rnd.Generate(1, 10));
                        if (!dict.ContainsKey(arr[i].GetType()))
                        {
                            dict.Add(arr[i].GetType(), 2);
                        }
                    }
                    else
                    {
                        arr[i] = new Cylinder(rnd.Generate(1, 10), rnd.Generate(1, 10));
                        if (!dict.ContainsKey(arr[i].GetType()))
                        {
                            dict.Add(arr[i].GetType(), 1);
                        }
                    }
                    Console.WriteLine(arr[i]);
                }
                Console.WriteLine();
                Array.Sort(arr, (Shape x, Shape y) => dict[x.GetType()].CompareTo(dict[y.GetType()]));
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.WriteLine(arr[i]);
                }

                Console.WriteLine("Press escape to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

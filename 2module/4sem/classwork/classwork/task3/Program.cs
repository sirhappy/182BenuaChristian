using System;
using EmployeesClassLibrary;

namespace task3
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            Employee[] arr = new Employee[rnd.Next(10, 15)];
            for (int i = 0; i < arr.Length; ++i) {
                if (rnd.Next(0,2) % 2 == 1) {
                    arr[i] = new PartTimeEmployee(rnd.GenerateString(5, 6), rnd.Generate(1000, 10000), rnd.GenerateInt(10, 30));
                } else {
                    arr[i] = new SalesEmployee(rnd.GenerateString(5, 6), rnd.Generate(1000, 10000), rnd.Generate(100, 200));
                }
            }

            Array.Sort(arr, (Employee x, Employee y) => x.CalculatePay().CompareTo(y.CalculatePay()));

            for (int i = 0; i < arr.Length; ++i) {
                Console.WriteLine(arr[i]);
                Console.WriteLine(arr[i].CalculatePay().ToString("F3"));
                Console.WriteLine();
            }

        }
    }
}

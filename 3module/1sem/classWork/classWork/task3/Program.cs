using System;

namespace task3
{
    delegate double delegateConvertTemperature(double from);

    public static class TemperatureConverterImp {
        public static double Fahr2Celsius(double fahr) {
            return (fahr - 32) * 5 / 9;
        }

        public static double Celsius2Fahr(double cels) {
            return (cels) * 9 / 5 + 32;
        }

        public static double Celsius2Roumor(double cels) {
            return cels / 1.25;
        }

        public static double Roumor2Celsius(double r) {
            return r * 1.25;
        }

        public static double Celsius2Rankin(double cels) {
            return (cels + 273.15) * 9 / 5;
        }

        public static double Rankin2Celsius(double ran) {
            return (ran - 491.67) * 5 / 9;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*delegateConvertTemperature toFahr = TemperatureConverterImp.Celsius2Fahr;
            delegateConvertTemperature toCels = TemperatureConverterImp.Fahr2Celsius;


            Console.WriteLine(toFahr(10));

            Console.WriteLine(toCels(10));
            Console.WriteLine(toFahr(-12.22222));

            Console.WriteLine(toFahr(20));
            Console.WriteLine(toCels(20));*/

            do
            {
                double cels = int.Parse(Console.ReadLine());
                string[] arr = new string[4] { "Celsius", "Fahrenheit", "Rankin", "Roumor" };
                delegateConvertTemperature[] delArr = new delegateConvertTemperature[4]{
                    (x)=>x,
                    TemperatureConverterImp.Celsius2Fahr,
                    TemperatureConverterImp.Celsius2Rankin,
                    TemperatureConverterImp.Celsius2Roumor
                };

                for (int i = 0; i < arr.Length; ++i) {
                    Console.WriteLine(arr[i] + " " + delArr[i](cels).ToString("F3"));
                }




                Console.WriteLine("Press esc to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);




        }

    }
}

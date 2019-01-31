using System;
using System.Reflection;

namespace task8
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
        public static double Generate(double mn, double mx)
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

        public static double[] GenerateArray(int len, double mn, double mx)
        {
            double[] arr = new double[len];
            for (int i = 0; i < len; ++i)
            {
                arr[len] = Generate(mn, mx);
            }
            return arr;
        }

        public static double[,] GenerateMatrix(int len, int innerLen, double mn, double mx)
        {
            double[,] arr = new double[len, innerLen];
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    arr[i, j] = Generate(mn, mx);
                }
            }
            return arr;
        }
    }

    public class Plant
    {
        double _growth, _photoSensitivity, _frostResistance;

        public double Growth
        {
            get => _growth;

            private set
            {
                if (value < 25 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(Growth), "Cannot be less than 25 or bigger than 100");
                }
                _growth = value;
            }
        }

        public double PhotoSensitivity
        {
            get => _photoSensitivity;

            private set
            {

                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(PhotoSensitivity), "Cannot be less than 0 or bigger than 100");
                }

                _photoSensitivity = value;
            }
        }

        public double FrostResistance
        {
            get => _frostResistance;

            private set
            {

                if (value < 0 || value > 80)
                {
                    throw new ArgumentOutOfRangeException(nameof(FrostResistance), "Cannot be less than 0 or bigger than 80");

                }

                _frostResistance = value;
            }
        }

        public Plant()
        {
            _growth = 25;
            _photoSensitivity = 0;
            _frostResistance = 0;
        }

        public Plant(double gr, double ps, double fr)
        {
            Growth = gr;
            PhotoSensitivity = ps;
            FrostResistance = fr;
        }

        public override string ToString()
        {
            return $"Growth:{Growth.ToString("F3")}, PhotoSensitivity:{PhotoSensitivity.ToString("F3")}, FrostResistance:{FrostResistance.ToString("F3")}";
        }

        public static Plant CreatePlant()
        {
            return new Plant(Generator.Generate(25, 100), Generator.Generate(0,100), Generator.Generate(0,80));
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

        public static int Comapre(Plant a, Plant b)
        {
            return (((int)a.PhotoSensitivity) % 2).CompareTo((int)b.PhotoSensitivity % 2);
        }

        static void Main(string[] args)
        {
            do
            {
                int n = Read<int>("Enter number of plants", "Error in entering number of plants, reenter", (a)=>a>0 && a<100);
                Plant[] arr = new Plant[n];

                for (int i = 0; i < n; ++i)
                {
                    arr[i] = Plant.CreatePlant();
                }

                Array.ForEach(arr, (el) => Console.WriteLine(el + " "));

                Comparison<Plant> pred = delegate(Plant a, Plant b) {
                    return -a.Growth.CompareTo(b.Growth);
                };
                Console.WriteLine();
                Array.Sort(arr, pred);

                Array.ForEach(arr, (el) => Console.WriteLine(el + " "));

                Console.WriteLine();


                Array.Sort(arr, (a, b) => a.FrostResistance.CompareTo(b.FrostResistance));

                Array.ForEach(arr, (el) => Console.WriteLine(el + " "));

                Console.WriteLine();

                Array.Sort(arr, Comapre);
                Array.ForEach(arr, (el) => Console.WriteLine(el + " "));
                Console.WriteLine();
                Array.ForEach(Array.ConvertAll<Plant, Plant>(arr, (a) => new Plant(a.Growth, a.PhotoSensitivity,
                (int)a.FrostResistance % 2 == 0 ? a.FrostResistance / 3 : a.FrostResistance / 2)), (el) => Console.WriteLine(el + " "));

                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

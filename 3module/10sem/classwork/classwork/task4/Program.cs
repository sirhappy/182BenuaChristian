using System;
using System.IO;
using System.Collections.Generic;


namespace task4
{
    class Program
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
            /// <summary>
            /// Generates the matrix.
            /// </summary>
            /// <returns>The matrix.</returns>
            /// <param name="len">Length.</param>
            /// <param name="innerLen">Inner length.</param>
            /// <param name="mn">Mn val</param>
            /// <param name="mx">Mx val</param>
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


        public static void GenerateFile(int n)
        {
            string[] names = new string[6];

            for (int i = 0; i < names.Length; ++i)
            {
                names[i] = Generator.GenerateString(5, 6);
            }

            using (StreamWriter writer = new StreamWriter("phoneCalls.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    writer.WriteLine(names[Generator.GenerateInt(0, names.Length)] + ":" + Generator.GenerateInt(10, 1000));
                }
            }
        }

        static void Main(string[] args)
        {
            GenerateFile(6);

            Dictionary<string, int> totalDuration = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("phoneCalls.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var components = reader.ReadLine().Split(':');
                    var name = components[0];
                    var duration = int.Parse(components[1]);

                    if (totalDuration.ContainsKey(name))
                    {
                        totalDuration[name] += duration;
                    }
                    else
                    {
                        totalDuration.Add(name, duration);
                    }

                }
            }

            foreach (var el in totalDuration)
            {
                Console.WriteLine(el.Key + " with total duration " + el.Value);
            }


        }
    }
}

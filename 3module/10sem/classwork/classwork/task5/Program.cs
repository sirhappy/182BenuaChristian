using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace task5
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


    class Program
    {

        public static void GenerateFile(int n)
        {
            using (StreamWriter writer = new StreamWriter("text.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    writer.Write(Generator.GenerateString(3, 10));
                }
            }
        }

        static void Main(string[] args)
        {
            GenerateFile(15);

            Dictionary<byte, int> byteFrequency = new Dictionary<byte, int>();
            using (BinaryReader reader = new BinaryReader(new FileStream("text.txt", FileMode.Open)))
            {
                for (int i = 0; i < reader.BaseStream.Length; ++i)
                {
                    byte currentByte = reader.ReadByte();

                    if (byteFrequency.ContainsKey(currentByte))
                    {
                        byteFrequency[currentByte]++;
                    }
                    else
                    {
                        byteFrequency.Add(currentByte, 1);
                    }
                }
            }

            foreach (byte key in byteFrequency.Keys.OrderByDescending(el => byteFrequency[el]).Take(10))
            {
                Console.WriteLine($"Byte {key} with freq {byteFrequency[key]}");
            }
        }

    }
}

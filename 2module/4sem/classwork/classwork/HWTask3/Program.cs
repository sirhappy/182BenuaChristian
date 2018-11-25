using System;
using Figures;
using System.IO;
using System.Collections.Generic;
namespace HWTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ellipse ellipse = new Ellipse(3, 8);
            Console.WriteLine(ellipse.Info());
            ellipse.Scale(10);
            Console.WriteLine(ellipse.Info());
            Triangle1 t = new Triangle1(5, 4);
            Console.WriteLine(t.Info());
            Console.WriteLine();
            Dimensions[] arr = new Dimensions[] { ellipse, t, new Ellipse(4, 6), new Triangle1(2, 8) };
            for (int i = 0; i < arr.Length; ++i) {
                Console.WriteLine(arr[i].Info());
            }
            StreamWriter wr = new StreamWriter("Figures");
            for (int i = 0; i < arr.Length; ++i) {
                wr.WriteLine(arr[i].Info());
            }
            wr.Flush();
            wr.Close();

            StreamReader reader = new StreamReader("Figures");
            string curr;
            List<string> inputLines = new List<string>();
            while ((curr = reader.ReadLine()) != null) {
                inputLines.Add(curr);
            }
            Console.WriteLine("\n\n");
            Dimensions[] fromFile = new Dimensions[inputLines.Count];
            for (int i = 0; i < fromFile.Length; ++i) {
                string[] split = inputLines[i].Split(" ");

                if (split[0] == "Ellipse") {
                    fromFile[i] = new Ellipse(double.Parse(split[1]), double.Parse(split[2]));
                } else {
                    fromFile[i] = new Triangle1(double.Parse(split[1]), double.Parse(split[2]));
                }
                Console.WriteLine(fromFile[i].Info());
            }
        }
    }
}

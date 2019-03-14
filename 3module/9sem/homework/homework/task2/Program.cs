using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    public static class RandomContainer
    {
        public static Random rnd = new Random();
    }

    public class ColorPoint
    {
        public static readonly string[] colors = { "Red", "Green",
"DarkRed", "Magenta", "DarkSeaGreen", "Lime", "Purple" , "DarkGreen", "DarkOrange", "Black", "BlueViolet", "Crimson", "Gray" , "Brown", "CadetBlue" };


        public double X { get; private set; }

        public double Y { get; private set; }

        public String Color { get; private set; }

        public static ColorPoint MakeColorPoint()
        {
            ColorPoint colorPoint = new ColorPoint();
            colorPoint.X = RandomContainer.rnd.NextDouble();
            colorPoint.Y = RandomContainer.rnd.NextDouble();
            colorPoint.Color = colors[RandomContainer.rnd.Next(0, colors.Length)];

            return colorPoint;
        }

        public ColorPoint()
        {
            X = Y = 0;
            Color = colors[0];
        }

        public ColorPoint(double x, double y)
        {
            X = x;
            Y = y;
            this.Color = colors[RandomContainer.rnd.Next(0, colors.Length)];
        }

        public ColorPoint(double x, double y, string color)
        {
            X = x;
            Y = y;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{X:F3} {Y:F3} {Color}";
        }
    }


    class Program
    {
        public static void FillFile(int n)
        {
            using (FileStream writer = new FileStream("colors.txt", FileMode.OpenOrCreate))
            {
                for (int i = 0; i < n; ++i)
                {
                    var color = ColorPoint.MakeColorPoint();
                    writer.Write(color.ToString().ToList().ConvertAll(el => (byte)el).ToArray(), 0, color.ToString().Length);
                }
            }
        }

        public static List<ColorPoint> ReadFromFile()
        {
            List<ColorPoint> lst = new List<ColorPoint>();
            using (FileStream reader = new FileStream("colors.txt", FileMode.Open))
            {
                char currentChar;
                string currentWord = "";
                int currentByte = 0;
                while (currentByte >= 0)
                {
                    while ((currentByte = (char)reader.ReadByte()) != -1 && (currentChar = (char)currentByte) != '\n')
                    {
                        currentWord += currentChar;
                    }
                    var comps = currentWord.Split(' ');
                    lst.Add(new ColorPoint(double.Parse(comps[0]), double.Parse(comps[1]), comps[2]));
                }
            }
            return lst;
        }


        static void Main(string[] args)
        {
            FillFile(15);

            ReadFromFile().ForEach(el => Console.WriteLine(el.ToString()));
            Console.ReadKey();
        }
    }
}

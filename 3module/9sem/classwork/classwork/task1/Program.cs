﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
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
            using (StreamWriter writer = new StreamWriter("colors.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    var color = ColorPoint.MakeColorPoint();
                    writer.WriteLine(color.ToString());
                }
            }
        }

        public static List<ColorPoint> ReadFromFile()
        {
            List<ColorPoint> lst = new List<ColorPoint>();
            using (StreamReader reader = new StreamReader("colors.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var components = reader.ReadLine().Split(' ');
                    lst.Add(new ColorPoint(double.Parse(components[0]), double.Parse(components[1]), components[2]));
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

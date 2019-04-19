using System;
using System.Collections.Generic;
using System.IO;

namespace task3
{
    
    public class MyColor
    {
        public string ColorName { get; private set; }
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public MyColor()
        {
            this.ColorName = "";
            R = G = B = 0;
        }

        public MyColor(string name, string hexColor)
        {
            this.ColorName = name;
            (R, G, B) = hexColorToComponents(hexColor);
        }

        public static (byte, byte, byte) hexColorToComponents(string hexColor)
        {
            byte r = (byte)((hexToInt(hexColor[1]) * 16) + hexToInt(hexColor[2]));
            byte g = (byte)((hexToInt(hexColor[3]) * 16) + hexToInt(hexColor[4]));
            byte b = (byte)((hexToInt(hexColor[5]) * 16) + hexToInt(hexColor[6]));
            return (r, g, b);
        }

        public static int hexToInt(char hex)
        {
            if (hex >= '0' && hex <= '9')
            {
                return (hex - '0');
            }
            
            return (10 + hex - 'a');
            
        }
    }

    public class ColorsJsonReader
    {
        public static List<MyColor> ReadeColors(string filePath)
        {
            List<MyColor> colors = new List<MyColor>();

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().Trim();
                    var components = line.Split(new string[] {": "}, StringSplitOptions.RemoveEmptyEntries);
                    if (components.Length == 2)
                    {
                        string name = components[0].Substring(1, components[0].Length - 2);
                        string hexColor = components[1].Substring(1, components[1].Length - 2);
                        colors.Add(new MyColor(name, hexColor));
                    }
                }
            }

            return colors;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var colors = ColorsJsonReader.ReadeColors("../../colors.json");
        }
    }
}
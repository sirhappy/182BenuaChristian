using System;

namespace task5
{

    public class VideoFile {
        private string _name;
        int _duration;
        int _quality;

        public VideoFile() {
            _name = "";
        }

        public VideoFile(string name, int duration, int quality) {
            _name = name;
            _duration = duration;
            _quality = quality;
        }

        public int Size {
            get {
                int ans = checked(_duration * _quality);
                return ans;
            }
        }

        public override string ToString()
        {
            return $"Name: {_name}, Duration: {_duration}, Quality: {_quality}, Size is {Size}";
        }
    }

    public static class Generator
    {
        public static Random rnd = new Random();

        public static double Generate(int mn, int mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        public static int GenerateInt(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }

        public static string GenerateString(int mnLen, int mxLen) {
            int len = rnd.Next(mnLen, mxLen);
            string ans = "";
            for (int i = 0; i < len; ++i) {
                ans += (char)(rnd.Next('a', 'z'));
            }
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                VideoFile file = new VideoFile("first", Generator.GenerateInt(60, 360), Generator.GenerateInt(100, 1000));
                Console.WriteLine(file);
                Console.WriteLine();
                VideoFile[] arr = new VideoFile[Generator.GenerateInt(5, 15)];
                for (int i = 0; i < arr.Length; ++i)
                {
                    arr[i] = new VideoFile(Generator.GenerateString(2, 9), Generator.GenerateInt(60, 360), Generator.GenerateInt(100, 1000));
                    Console.WriteLine(i + " " + arr[i]);
                }

                for (int i = 0; i < arr.Length; ++i)
                {
                    try
                    {
                        if (arr[i].Size > file.Size)
                        {
                            Console.WriteLine(i + " " + arr[i]);
                        }
                    } catch (OverflowException e) {
                        Console.WriteLine("Overflow happend in " + i + "th element of array of in separate object");
                    }
                }
                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}

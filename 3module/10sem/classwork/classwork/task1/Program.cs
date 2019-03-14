using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            var fs = new FileStream("text.txt", FileMode.Open);

            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(10);
                writer.Write(20);
                writer.Write(30);
            }
            fs = new FileStream("text.txt", FileMode.Open);

            List<int> lst = new List<int>();
            using (BinaryReader reader = new BinaryReader(fs))
            {
            
            int len = (int)fs.Length / sizeof(int);
                for (int i = 0; i < len; ++i)
                {
                    lst.Add(reader.ReadInt32());
                    Console.WriteLine(lst.Last());
                }
                fs.Seek(0, SeekOrigin.Begin);
                Console.WriteLine(fs.CanRead);
            }
            Console.WriteLine(fs.CanRead);
            fs = new FileStream("text.txt", FileMode.Open);
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int len = (int)fs.Length;

                for (int i = (int)len - sizeof(int); i >= 0; i -= sizeof(int))
                {
                   //fs.Seek(i, SeekOrigin.Begin);
                    fs.Position = i;
                    Console.WriteLine(reader.ReadInt32());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            using(BinaryReader reader = new BinaryReader(new FileStream(@"..\..\Program.cs", FileMode.Open)))
            {
                int len = (int)reader.BaseStream.Length;

                for (int i = 0; i < len; ++i)
                {

                    var currentByte = reader.ReadByte();

                    if (currentByte >= '0' && currentByte <= '9')
                    {
                        Console.WriteLine((char)currentByte);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3_1
{
    class Program
    {
        struct Kek
        {
            double a;
            double b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(sizeof(bool));

            Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(new Kek()));

            /*string file = Console.ReadLine();
            char ch = char.Parse(Console.ReadLine());
            using (FileStream reader = new FileStream(file, FileMode.OpenOrCreate))
            {
                for (int i = 0; i < reader.Length; ++i)
                {
                    reader.Seek(i, SeekOrigin.Begin);
                    if (reader.ReadByte() == ch)
                    {
                        reader.Seek(-1, SeekOrigin.Current);
                        reader.WriteByte((byte)'*');
                    }
                }
            }*/
        }
    }
}

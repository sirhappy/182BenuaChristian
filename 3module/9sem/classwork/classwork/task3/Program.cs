using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (FileStream stream = new FileStream("text.txt", FileMode.OpenOrCreate))
            {
                long len = stream.Length;
                if (len < 26)
                {
                    stream.Seek(len, SeekOrigin.Begin);
                    stream.WriteByte((byte)('a' + (int)len));
                }
            }
        }
    }
}

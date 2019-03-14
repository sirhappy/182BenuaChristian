using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace classwork
{

   

    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());


            using (StreamWriter writer = new StreamWriter("text.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    writer.WriteLine(rnd.Next(-20, 21));
                }
            }


            List<int> readInts = new List<int>();
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    readInts.Add(int.Parse(line));
                }
            }

            using (StreamWriter writer = new StreamWriter("text2.txt"))
            {
                readInts.Where(el => el % 2 == 0).ToList().ForEach(el => writer.WriteLine(el.ToString()));
            }

            using (StreamWriter writer = new StreamWriter("text3.txt"))
            {
                readInts.Where(el => el % 2 == 1).ToList().ForEach(el => writer.WriteLine(el.ToString()));
            }

        }

    }
}

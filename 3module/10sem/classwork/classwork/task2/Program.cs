using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace task2
{

    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
            null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[]
            { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }
    }

    class Program
    {

        public static Random rnd = new Random();

        static void Main(string[] args)
        {


            using (BinaryWriter writer = new BinaryWriter(new FileStream("text.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    writer.Write(rnd.Next(1, 101));
                }
            }

            var fs = new FileStream("text.txt", FileMode.OpenOrCreate);

            using (BinaryReader reader = new BinaryReader(fs))
            {
                int len = (int)fs.Length;

                for (int i = 0; i < len / sizeof(int); ++i)
                {
                    Console.WriteLine(reader.ReadInt32());
                }
            }

            int whatToReplace = Reader.Read<int>("Enter what you want to replace", "smth wrong, reenter pls", arg => arg >= 0 && arg <= 100);
            int replaceNum = Reader.Read<int>("Enter what you want to replace with", "smth wrong, reenter pls", arg => arg >= 0 && arg <= 100);


            fs = new FileStream("text.txt", FileMode.Open);
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int len = (int)fs.Length / sizeof(int);
                int best = (int)1e9;
                int toBeReplaced = 0;
                for (int i = 0; i < len; ++i)
                {
                    int current = reader.ReadInt32();
                    if (Math.Abs(current - whatToReplace) < best && (current <= 100 && current >= 1))
                    {
                        best = Math.Abs(current - whatToReplace);
                        toBeReplaced = current;
                    }
                }


                fs.Position = 0;

                var fs1 = new FileStream("text.txt", FileMode.Open);
                using (BinaryWriter writer = new BinaryWriter(fs1)) {
                    for (int i = 0; i < len; ++i)
                    {
                        int current = reader.ReadInt32();
                        if (current == toBeReplaced)
                        {
                            fs1.Position = fs.Position - sizeof(int);
                            //fs.Position -= sizeof(int);
                            writer.Write(replaceNum);
                            break;
                        }
                    }
                }
            }

            fs = new FileStream("text.txt", FileMode.Open);
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int len = (int)fs.Length;

                for (int i = 0; i < len / sizeof(int); ++i)
                {
                    Console.WriteLine(reader.ReadInt32());
                }
            }

        }
    }
}

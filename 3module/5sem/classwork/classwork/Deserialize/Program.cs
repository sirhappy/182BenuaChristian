using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmeraldCityLib;

namespace DeSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Uri path = new Uri(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
                string newPath = "file:/" + String.Join("", path.Segments.TakeWhile((arg) => arg != "Deserialize/")
                    .Append("EmeraldCity/").Append("bin/").Append("Debug/").Append("out.ser"));
                StreetContainer container = StreetContainer.Deserialize((new Uri(newPath)).AbsolutePath);
                Console.WriteLine("Magic streets are \n");
                container?.Streets.Where((arg) => ~arg % 2 == 1 && !arg)
                    .ToList().ForEach((arg) => Console.WriteLine(arg.ToString()));

                Console.WriteLine("Press esc to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

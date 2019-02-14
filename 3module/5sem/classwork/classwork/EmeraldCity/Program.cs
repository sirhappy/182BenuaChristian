using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmeraldCityLib;

namespace EmeraldCity
{
    /// <summary>
    /// File content checker.
    /// </summary>
    public class FileContentChecker
    {
        /// <summary>
        /// Checks the content of the line.
        /// </summary>
        /// <returns>The correctness of content's line.</returns>
        /// <param name="fileLine">File line.</param>
        public static (bool, Street) CheckLineContent(string fileLine)
        {
            var arr = fileLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name;
            List<int> houses = new List<int>();

            if (arr.Length <= 1)
            {
                return (false, null);
            }

            if (arr[0].Count((arg) => (arg >= 'а' && arg <= 'я') || (arg >= 'А' && arg <= 'Я')) != arr[0].Count())
            {
                return (false, null);
            }
            else
            {
                name = arr[0];
            }

            for (int i = 1; i < arr.Count(); ++i)
            {
                if (arr[i].Count(arg => (arg >= '0' && arg <= '9')) != arr[i].Count())
                {
                    return (false, null);
                }

                int num = 0;
                if (int.TryParse(arr[i], out num) && num > 0)
                {
                    houses.Add(num);
                }
                else
                {
                    return (false, null);
                }
            }

            return (true, new Street(name, houses));
        }
    }

    class Program
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>The file path.</returns>
        /// <param name="EndPoint">End point.</param>
        public static string GetFilePath(string EndPoint = "data.txt")
        {
            return System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\" + EndPoint;
        }

        static void Main(string[] args)
        {
            do
            {
                int n = Reader.Read<int>("Enter number of streets", "smth wrong, reenter pls", (arg) => arg > 0 && arg <= 100);
                List<string> lines = new List<string>();
                try
                {
                    //Read file content
                    using (StreamReader reader = new StreamReader("data.txt", Encoding.GetEncoding("Windows-1251")))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            lines.Add(line);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error in reading from file");
                    Console.WriteLine(ex.Message);
                }

                List<Street> streetArray = new List<Street>();

                if (lines.Where((arg) => arg.Count() > 1).Any((arg) => !FileContentChecker.CheckLineContent(arg).Item1))
                {
                    Console.WriteLine("Warning, invalid file format!!");
                    for (int i = 0; i < n; ++i)
                    {
                        streetArray.Add(Street.MakeStreet());
                    }
                }
                else
                {
                    int nonzeroLine = lines.Count((arg) => arg.Count() >= 0);

                    int toTake = Math.Min(nonzeroLine, n);

                    streetArray.AddRange(lines.ConvertAll<Street>((arg) => FileContentChecker.CheckLineContent(arg).Item2).Take(toTake));
                }

                streetArray.ForEach((arg) => Console.WriteLine(arg + "\n"));

                //writing to file
                StreetContainer container = new StreetContainer(streetArray);
                try
                {
                    container.SerializeSelf(GetFilePath("out.ser"));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (System.Xml.XmlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}

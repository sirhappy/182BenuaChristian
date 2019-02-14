using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace EmeraldCityLib
{
    /// <summary>
    /// Reader.
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Read the specified In, Out and valid.
        /// </summary>
        /// <returns>The read.</returns>
        /// <param name="In">In.</param>
        /// <param name="Out">Out.</param>
        /// <param name="valid">Valid.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
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

    /// <summary>
    /// Random container.
    /// </summary>
    public static class RandomContainer
    {
        /// <summary>
        /// The random.
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Nexts the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="mn">Mn.</param>
        /// <param name="mx">Mx.</param>
        public static int NextInt(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }

        /// <summary>
        /// Generates the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="len">Length.</param>
        public static string GenerateString(int len)
        {
            char[] arr = new char[len];

            for (int i = 0; i < len; ++i)
            {
                arr[i] = (char)NextInt((int)'a', (int)'z');
            }
            return new string(arr);
        }
    }

    /// <summary>
    /// Street container.
    /// </summary>
    [Serializable()]
    [XmlType("StreetContainer")]
    public class StreetContainer
    {
        /// <summary>
        /// Gets or sets the streets.
        /// </summary>
        /// <value>The streets.</value>
        public List<Street> Streets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClassLibrary1.StreetContainer"/> class.
        /// </summary>
        /// <param name="streets">Streets.</param>
        public StreetContainer(List<Street> streets)
        {
            Streets = new List<Street>(streets);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClassLibrary1.StreetContainer"/> class.
        /// </summary>
        public StreetContainer()
        {
            Streets = new List<Street>();
        }

        /// <summary>
        /// Serializes the self.
        /// </summary>
        /// <param name="filePath">File path.</param>
        public void SerializeSelf(string filePath)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(this.GetType());
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                serializer.Serialize(stream, this);
                stream.Position = 0;
                doc.Load(stream);
                doc.Save(filePath);
            }
        }

        /// <summary>
        /// Deserialize the specified filePath.
        /// </summary>
        /// <returns>The deserialize.</returns>
        /// <param name="filePath">File path.</param>
        public static StreetContainer Deserialize(string filePath)
        {
            StreetContainer container = new StreetContainer();
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer((new StreetContainer()).GetType());
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    container = (StreetContainer)serializer.Deserialize(reader);
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while reading from file");
                Console.WriteLine(ex.Message);
                return null;
            }
            return container;
        }
    }

    /// <summary>
    /// Street.
    /// </summary>
    [Serializable()]
    [XmlType("Street")]
    public class Street
    {
        /// <summary>
        /// The minimum houses amount.
        /// </summary>
        const int minHousesAmount = 2;

        /// <summary>
        /// The max houses amount.
        /// </summary>
        const int maxHousesAmount = 10;

        /// <summary>
        /// The minimum house number.
        /// </summary>
        const int minHouseNumber = 1;

        /// <summary>
        /// The max house number.
        /// </summary>
        const int maxHouseNumber = 101;

        /// <summary>
        /// The length of the name.
        /// </summary>
        const int nameLength = 10;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the houses.
        /// </summary>
        /// <value>The houses.</value>
        public List<int> Houses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClassLibrary1.Street"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="houses">Houses.</param>
        public Street(string name, List<int> houses)
        {
            this.Name = name;
            this.Houses = new List<int>(houses);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClassLibrary1.Street"/> class.
        /// </summary>
        public Street()
        {
            this.Name = "";
            this.Houses = new List<int>();
        }

        /// <summary> Gets amount of streets </summary>
        /// <param name="street">Street.</param>
        public static int operator ~(Street street)
        {
            return street.Houses.Count;
        }

        /// <summary> Checks whether goo street or not </summary>
        /// <param name="street">Street.</param>
        public static bool operator !(Street street)
        {
            return street.Houses.ConvertAll<string>((arg) => arg.ToString()).Any((arg) => arg.Contains('7'));
        }

        /// <summary>
        /// Returns a <see cref="!:System.String"/> that represents the current <see cref="T:ClassLibrary1.Street"/>.
        /// </summary>
        /// <returns>A <see cref="!:System.String"/> that represents the current <see cref="T:ClassLibrary1.Street"/>.</returns>
        public override string ToString()
        {
            string textRepresentation = $"Street with name {Name}, Streets are:\n";
            Houses.ForEach((arg) => textRepresentation += arg + "\n");

            return textRepresentation;
        }

        /// <summary>
        /// Makes the street.
        /// </summary>
        /// <returns>The street.</returns>
        public static Street MakeStreet()
        {
            int len = RandomContainer.NextInt(minHousesAmount, maxHousesAmount);
            List<int> houses = new List<int>();

            for (int i = 0; i < len; ++i)
            {
                houses.Add(RandomContainer.NextInt(minHouseNumber, maxHouseNumber));
            }
            string name = RandomContainer.GenerateString(nameLength);
            return new Street(name, houses);
        }
    }
}


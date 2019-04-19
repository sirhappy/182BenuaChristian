using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace task4
{

    public class RandomContainer
    {
        private static Random rnd = new Random();

        public static double GenerateDouble(double from, double to)
        {
            return rnd.NextDouble() * (to - from) + from;
        }

        public static int GenerateInt(int from, int to)
        {
            return rnd.Next(from, to);
        }
    }
    
    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
                null, new[] {typeof(string), typeof(T).MakeByRefType()}, null);
            while (!((bool) (methodInfo.Invoke(null, (parameters = new object[]
                         {Console.ReadLine(), null}))) && valid((T) parameters[1])))
            {
                Console.WriteLine(Out);
            }

            return (T) parameters[1];
        }
    }    
    public interface IMultiple
    {
        string Name { get; }
        
        int Divisor { get; set; }
        
        List<int> MultipliesOfDivisor { get; }

        void CreateMultipliesOfDivisor(int[] arr);
    }

    [Serializable]
    public class Multiple : IMultiple
    {
        private static string[] DigitsNames =
        {
            "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять"
        };
        
        private string _name;
        private int _divisor;
        private List<int> _multipliesOfDivisor;

        [XmlIgnore]
        public string Name
        {
            get => DigitsNames[this.Divisor - 1];
        }

        public int Divisor
        {
            get => _divisor;
            set
            {
                if (value > 9 || value < 1)
                {
                    throw new ArgumentOutOfRangeException("Wrong divisor", nameof(Divisor));
                }

                _divisor = value;
            }
        }


        public List<int> MultipliesOfDivisor
        {
            get => _multipliesOfDivisor;
            set => _multipliesOfDivisor = value;
        }

        public void CreateMultipliesOfDivisor(int[] arr)
        {
            this.MultipliesOfDivisor = arr.Where((el) => el % Divisor == 0).ToList();
        }

        public Multiple()
        {
            this.Divisor = 1;
            this.CreateMultipliesOfDivisor(new int[]{});
        }

        public Multiple(int divisor, int[] arr)
        {
            this.Divisor = divisor;
            this.CreateMultipliesOfDivisor(arr);
        }

        public override string ToString()
        {
            var res = $"Divisor: {Divisor}, name is: {Name}\nMultiples:\n";
            foreach (var el in this.MultipliesOfDivisor)
            {
                res += $"{el}, ";
            }

            return res;
        }
    }

    public interface ISerializer<T>
    {
        void Serialize(string fileName, T serializableObject);
    }

    public interface IDeserializer<T>
    {
        T Deserialize(string fileName);
    }

    public interface ICollectionSerializationManager<T>: ISerializer<T[]>, IDeserializer<T[]>
    {
        ISerializer<T[]> Serializer { get; }
        
        IDeserializer<T[]> Deserializer { get; }   
    }

    public class BinaryCollectionSerializer<T> : ISerializer<T[]>
    {
        public void Serialize(string fileName, T[] serializableObject)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                foreach (var el in serializableObject)
                {
                    formatter.Serialize(fileStream, el);
                }
            }
        }
    }

    public class XmlCollectionSerializer<T> : ISerializer<T[]>
    {
        public void Serialize(string fileName, T[] serializableObject)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                serializer.Serialize(fileStream, serializableObject);
            }
        }
    }

    public class BinaryCollectionDeserializer<T> : IDeserializer<T[]>
    {
        public T[] Deserialize(string fileName)
        {
            List<T> deserializedObject = new List<T>();

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                while (fileStream.Position != fileStream.Length)
                {
                    deserializedObject.Add((T)formatter.Deserialize(fileStream));
                }
            }

            return deserializedObject.ToArray();
        }
    }

    public class XmlCollectionDeserializer<T> : IDeserializer<T[]>
    {
        public T[] Deserialize(string fileName)
        {
            T[] deserializedObject = new T[] { };

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                deserializedObject =  (T[])serializer.Deserialize(fileStream);
            }

            return deserializedObject;
        }
    }

    public class CollectionSerializationManager<T> : ICollectionSerializationManager<T>
    {
        public void Serialize(string fileName, T[] serializableObject)
        {
            this.Serializer.Serialize(fileName, serializableObject);
        }

        public T[] Deserialize(string fileName)
        {
            return this.Deserializer.Deserialize(fileName);
        }

        public ISerializer<T[]> Serializer { get; private set; }

        public IDeserializer<T[]> Deserializer { get; private set; }

        public CollectionSerializationManager(ISerializer<T[]> serializer, IDeserializer<T[]> deserializer)
        {
            this.Serializer = serializer;
            this.Deserializer = deserializer;
        }
    }

    public interface ICoreAssembly<T>
    {
        ICollectionSerializationManager<T> SerializationManager { get; }
    }
    
    public enum SerializationType
    {
        Binary, XML
    }

    public class CoreAssembly<T> : ICoreAssembly<T>
    {
        private ICollectionSerializationManager<T> _serializationManager;
        private ISerializer<T[]> _serializer;
        private IDeserializer<T[]> _deserializer;

        public ICollectionSerializationManager<T> SerializationManager
        {
            get => _serializationManager;

            private set { _serializationManager = value; }
        }
        
        public CoreAssembly(SerializationType type = SerializationType.Binary)
        {
            if (type == SerializationType.Binary)
            {
                this._serializer = new BinaryCollectionSerializer<T>();
                this._deserializer = new BinaryCollectionDeserializer<T>();
            }
            else
            {
                this._serializer = new XmlCollectionSerializer<T>();
                this._deserializer = new XmlCollectionDeserializer<T>();
            }
            this.SerializationManager = new CollectionSerializationManager<T>(this._serializer, this._deserializer);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            int sequenceLen = Reader.Read<int>("Enter lenght of general sequence", "smth wrong, reenter pls",
                (el) => el > 0 && el <= 100);
            int[] sequence = new int[sequenceLen];

            for (int i = 0; i < sequenceLen; ++i)
            {
                sequence[i] = RandomContainer.GenerateInt(1, 100);
                Console.WriteLine($"{i}th is: " + sequence[i]);
            }
            
            int n = Reader.Read<int>("Enter amount of object", "Smth wrong, reenter pls", (el) => el > 0 && el <= 10);
            Multiple[] multiples = new Multiple[n];

            for (int i = 0; i < n; ++i)
            {
                int divisor = Reader.Read<int>("Enter divisor from 1 to 9", "Smth wrong, reenter pls",
                    (el) => el >= 1 && el <= 9);
                multiples[i] = new Multiple(divisor, sequence);
            }
            
            //Binary
            {
                
                CoreAssembly<Multiple> coreAssembly = new CoreAssembly<Multiple>(SerializationType.Binary);
                coreAssembly.SerializationManager.Serialize("Multiple.ser", multiples);
                coreAssembly.SerializationManager.Deserialize("Multiple.ser").ToList().ForEach(Console.WriteLine);
            }
            //XML
            {
                CoreAssembly<Multiple> coreAssembly = new CoreAssembly<Multiple>(SerializationType.XML);
                coreAssembly.SerializationManager.Serialize("XmlMultiple.xml", multiples);
                coreAssembly.SerializationManager.Deserialize("XmlMultiple.xml").ToList().ForEach(Console.WriteLine);
            }
            
        }
    }
}
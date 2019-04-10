using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Serialization;

namespace task3
{

    public class RandomContainer
    {
        private static Random rnd = new Random();

        public static double GenerateDouble(double from, double to)
        {
            return rnd.NextDouble() * (to - from) + from;
        }
    }
    public interface ISolvable<T>
    {
        T[] GetSolutions();
    }

    [Serializable]
    public class QuadraticEquation : ISolvable<double>
    {
        private const double eps = 1e-8;
        private double _a;
        private double _b;
        private double _c;

        public double A
        {
            get => _a;

            set
            {
                if (Math.Abs(value) < eps)
                {
                    throw new ArgumentException("Head argument cant be null", nameof(A));
                }

                _a = value;
            }
        }
        
        public double B
        {
            get => _b;

            set { _b = value; }
        }

        public double C
        {
            get => _c;

            set { _c = value; }
        }

        public QuadraticEquation(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public QuadraticEquation()
        {
            this.A = 1;
            this.B = 0;
            this.C = 0;
        }

       [XmlIgnore]
        public double Discriminant
        {
            get { return B * B - 4 * A * C; }
        }
        
        
        
        public double[] GetSolutions()
        {
            double discriminant = Math.Sqrt(this.Discriminant);

            List<double> solutions = new List<double>();
            
            if (Math.Abs(this.Discriminant) < eps)
            {
                solutions.Append(-B / (2 * A));
            }
            else if (this.Discriminant > eps)
            {
                double dividedDiscr = discriminant / 2 / A;
                double mainPart = -B / 2 / A;

                solutions.Add(mainPart + dividedDiscr);
                solutions.Add(mainPart - dividedDiscr);
            }

            return solutions.ToArray();
        }

        public override string ToString()
        {
            return $"A:{A:F3}, B:{B:F3}, C:{C:F3}, Discr: {Discriminant:F3}";
        }

        public static QuadraticEquation RandomQuadraticEquation(double from = -10, double to = 10)
        {
            return new QuadraticEquation(RandomContainer.GenerateDouble(from, to), RandomContainer.GenerateDouble(from, to),
                RandomContainer.GenerateDouble(from, to));
        }
    }
    
    

    public interface IEquationFabric
    {
        QuadraticEquation[] GenerateArray(int count);
    }

    public class EquationFabric : IEquationFabric
    {
        public QuadraticEquation[] GenerateArray(int count)
        {
            QuadraticEquation[] generatedArray = new QuadraticEquation[count];

            for (int i = 0; i < count; ++i)
            {
                generatedArray[i] = QuadraticEquation.RandomQuadraticEquation();
            }

            return generatedArray;
        }
    }

    public interface ICoreAssembly
    {
        IEquationFabric EquationFabric { get; }
        
        IEquationSerializationManager EquationSerializationManager { get; }
    }

    public enum SerializationType
    {
        Binary, XML
    }
    
    public class CoreAssembly : ICoreAssembly
    {
        public IEquationFabric EquationFabric { get; private set; }

        private IEquationSerializer EquationSerializer { get; set; }

        private IEquationDeserializer EquationDeserializer { get; set; }

        public IEquationSerializationManager EquationSerializationManager { get; private set; }

        public CoreAssembly(SerializationType type = SerializationType.Binary)
        {
            this.EquationFabric = new EquationFabric();

            if (type == SerializationType.Binary) {
                this.EquationSerializer = new EquationSerializer();
                this.EquationDeserializer = new EquationDeserializer();
                
            } 
            else if (type == SerializationType.XML)
            {
                this.EquationSerializer = new XmlEquationSerializer();
                this.EquationDeserializer = new XmlEquationDeserializer();
            }
            
            this.EquationSerializationManager =
                new EquationSerializationManager(this.EquationSerializer, this.EquationDeserializer);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            {
                Console.WriteLine("Binary Serialization");
                var coreAssembly = new CoreAssembly();

                coreAssembly.EquationSerializationManager.SerializeEquations("equation.ser", coreAssembly
                    .EquationFabric.GenerateArray(10).ToList(), 10);
                Console.WriteLine("Serialized 10 Equations");
                Console.WriteLine("Reding from file");

                coreAssembly.EquationSerializationManager.DeserializeEquations("equation.ser", coreAssembly
                    .EquationSerializationManager.PrintAdditionalInfo);
            }
            {
                Console.WriteLine("XMl Serialization");
                var coreAssembly = new CoreAssembly(SerializationType.XML);
                coreAssembly.EquationSerializationManager.SerializeEquations("xmlEquation.xml", coreAssembly
                    .EquationFabric.GenerateArray(10).ToList(), 10);
                Console.WriteLine("Serialized 10 equations");
                
                coreAssembly.EquationSerializationManager.DeserializeEquations("xmlEquation.xml", coreAssembly
                    .EquationSerializationManager.PrintAdditionalInfo);
            }
        }
    }
}
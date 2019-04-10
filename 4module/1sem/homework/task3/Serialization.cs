

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using task3;

namespace Serialization
{
    //Вообще-то плохо использовать статические классы(их нельзя покрыть интерфейсами), поэтому их тут не будет

    public interface IEquationSerializer
    {
        void SerializeEquations(string fileName, List<QuadraticEquation> equations, int prefixLen);
    }

    public interface IEquationDeserializer
    {
        void DeserializeEquations(string fromFile, Action<QuadraticEquation> callback);
    }
    
    public interface IEquationSerializationManager: IEquationSerializer, IEquationDeserializer
    {
        void PrintAdditionalInfo(QuadraticEquation equation);

        void PrintGeneralInfo(QuadraticEquation equation);

        IEquationSerializer Serializer { get; }
        
        IEquationDeserializer Deserializer { get; }

    }

    public class EquationSerializer : IEquationSerializer
    {
        public void SerializeEquations(string fileName, List<QuadraticEquation> equations, int prefixLen)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                for (int i = 0; i < Math.Max(prefixLen, equations.Count); ++i)
                {
                    formatter.Serialize(fileStream, equations[i]);
                }
            }
        }
    }

    public class XmlEquationSerializer : IEquationSerializer
    {
        public void SerializeEquations(string fileName, List<QuadraticEquation> equations, int prefixLen)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var formatter = new XmlSerializer(typeof(List<QuadraticEquation>));

                var prefix = equations.Take(prefixLen);
                formatter.Serialize(fileStream, prefix.ToList());
            }
        }
    }

    public class EquationDeserializer : IEquationDeserializer
    {
        public void DeserializeEquations(string fromFile, Action<QuadraticEquation> callback)
        {
            using (FileStream fileStream = new FileStream(fromFile, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                while (fileStream.Position != fileStream.Length)
                {
                    QuadraticEquation equation = (QuadraticEquation) formatter.Deserialize(fileStream);
                    callback?.Invoke(equation);
                }
            }
        }
    }

    public class XmlEquationDeserializer : IEquationDeserializer
    {
        public void DeserializeEquations(string fromFile, Action<QuadraticEquation> callback)
        {
            using (FileStream fileStream = new FileStream(fromFile, FileMode.Open))
            {
                var formatter = new XmlSerializer(typeof(List<QuadraticEquation>));
                
                    var equations = (List<QuadraticEquation>)formatter.Deserialize(fileStream);
                    equations.ToList().ForEach(callback);
                    //callback?.Invoke(equation);
                
            }
        }
    }

    public class EquationSerializationManager : IEquationSerializationManager
    {
        private IEquationSerializer _serializer;
        private IEquationDeserializer _deserializer;

        public void PrintAdditionalInfo(QuadraticEquation equation)
        {
            String info = equation.ToString() + "\nRoots:";
            equation.GetSolutions().ToList().ForEach((solution) => { info += $"{solution:F3}, "; });
            Console.WriteLine(info);
        }

        public void PrintGeneralInfo(QuadraticEquation equation)
        {
            Console.WriteLine(equation);
        }

        public IEquationSerializer Serializer
        {
            get => _serializer;

            private set { _serializer = value; }
        }

        public IEquationDeserializer Deserializer
        {
            get => _deserializer;

            private set { _deserializer = value; }
        }

        public EquationSerializationManager(IEquationSerializer serializer, IEquationDeserializer deserializer)
        {
            this.Serializer = serializer;
            this.Deserializer = deserializer;
        }

        public void SerializeEquations(string fileName, List<QuadraticEquation> equations, int prefixLen)
        {
            this.Serializer.SerializeEquations(fileName, equations, prefixLen);
        }

        public void DeserializeEquations(string fromFile, Action<QuadraticEquation> callback)
        {
            this.Deserializer.DeserializeEquations(fromFile, callback);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace dbTask
{

    public interface ISerializer<T>
    {
        void Serialize(string fileName, T serializableObject);
    }

    public interface IDeserializer<T>
    {
        T Deserialize(string fileName);
    }

    public interface ICollectionSerializationManager<T>: ISerializer<IEnumerable<T>>, IDeserializer<IEnumerable<T>>
    {
        ISerializer<IEnumerable<T>> Serializer { get; }
        
        IDeserializer<IEnumerable<T>> Deserializer { get; }   
    }
    
    public class JSONCollectionSerializer<T>: ISerializer<IEnumerable<T>>
    {
        public void Serialize(string fileName, IEnumerable<T> serializableObject)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
                serializer.WriteObject(fileStream, serializableObject);
            }
        }
    }

    public class JSONCollectionDeserializer<T> : IDeserializer<IEnumerable<T>>
    {
        public IEnumerable<T> Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
                return (IEnumerable<T>)deserializer.ReadObject(fileStream);
            }
        }
    }
    
    
    
}
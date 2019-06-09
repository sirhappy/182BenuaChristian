using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace dbTask
{
    /// <summary>
    /// Serializer.
    /// </summary>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Serialize the specified serializableObject to filename.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="serializableObject">Serializable object.</param>
        void Serialize(string fileName, T serializableObject);
    }

    /// <summary>
    /// Deserializer.
    /// </summary>
    public interface IDeserializer<T>
    {
        /// <summary>
        /// Deserialize the object from specified fileName.
        /// </summary>
        /// <returns>The deserialize.</returns>
        /// <param name="fileName">File name.</param>
        T Deserialize(string fileName);
    }

    /// <summary>
    /// Collection serialization manager.
    /// </summary>
    public interface ICollectionSerializationManager<T> : ISerializer<IEnumerable<T>>, IDeserializer<IEnumerable<T>>
    {
        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        ISerializer<IEnumerable<T>> Serializer { get; }

        /// <summary>
        /// Gets the deserializer.
        /// </summary>
        /// <value>The deserializer.</value>
        IDeserializer<IEnumerable<T>> Deserializer { get; }
    }

    /// <summary>
    /// JSONC ollection serializer.
    /// </summary>
    public class JSONCollectionSerializer<T> : ISerializer<IEnumerable<T>>
    {
        /// <summary>
        /// Serialize the specified serializableObject to filename.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="serializableObject">Serializable object.</param>
        public void Serialize(string fileName, IEnumerable<T> serializableObject)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
                serializer.WriteObject(fileStream, serializableObject);
            }
        }
    }

    /// <summary>
    /// JSONC ollection deserializer.
    /// </summary>
    public class JSONCollectionDeserializer<T> : IDeserializer<IEnumerable<T>>
    {
        /// <summary>
        /// Deserialize the specified fileName.
        /// </summary>
        /// <returns>The deserialize.</returns>
        /// <param name="fileName">File name.</param>
        public IEnumerable<T> Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
                return (IEnumerable<T>) deserializer.ReadObject(fileStream);
            }
        }
    }
}
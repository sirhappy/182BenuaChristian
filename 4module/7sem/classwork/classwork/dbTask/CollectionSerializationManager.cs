using System.Collections.Generic;

namespace dbTask
{
    public class CollectionSerializationManager<T> : ICollectionSerializationManager<T>
    {
        public void Serialize(string fileName, IEnumerable<T> serializableObject)
        {
            this.Serializer.Serialize(fileName, serializableObject);
        }

        public IEnumerable<T> Deserialize(string fileName)
        {
            return this.Deserializer.Deserialize(fileName);
        }

        public ISerializer<IEnumerable<T>> Serializer { get; private set; }

        public IDeserializer<IEnumerable<T>> Deserializer { get; private set; }

        public CollectionSerializationManager(ISerializer<IEnumerable<T>> serializer, IDeserializer<IEnumerable<T>> deserializer)
        {
            this.Serializer = serializer;
            this.Deserializer = deserializer;
        }
    }
}
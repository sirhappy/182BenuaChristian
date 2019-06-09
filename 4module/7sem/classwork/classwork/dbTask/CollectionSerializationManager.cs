using System.Collections.Generic;

namespace dbTask
{
    /// <summary>
    /// Collection serialization manager.
    /// </summary>
    public class CollectionSerializationManager<T> : ICollectionSerializationManager<T>
    {
        /// <summary>
        /// Serialize serializableObject to the fileName.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="serializableObject">Serializable object.</param>
        public void Serialize(string fileName, IEnumerable<T> serializableObject)
        {
            this.Serializer.Serialize(fileName, serializableObject);
        }

        /// <summary>
        /// Deserialize object from the specified fileName.
        /// </summary>
        /// <returns>The deserialized object.</returns>
        /// <param name="fileName">File name.</param>
        public IEnumerable<T> Deserialize(string fileName)
        {
            return this.Deserializer.Deserialize(fileName);
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        public ISerializer<IEnumerable<T>> Serializer { get; private set; }

        /// <summary>
        /// Gets the deserializer.
        /// </summary>
        /// <value>The deserializer.</value>
        public IDeserializer<IEnumerable<T>> Deserializer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.CollectionSerializationManager`1"/> class.
        /// </summary>
        /// <param name="serializer">Serializer.</param>
        /// <param name="deserializer">Deserializer.</param>
        public CollectionSerializationManager(ISerializer<IEnumerable<T>> serializer,
            IDeserializer<IEnumerable<T>> deserializer)
        {
            this.Serializer = serializer;
            this.Deserializer = deserializer;
        }
    }
}
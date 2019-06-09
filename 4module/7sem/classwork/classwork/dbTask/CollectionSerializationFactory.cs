namespace dbTask
{
    /// <summary>
    /// Collection serialization factory.
    /// </summary>
    public class CollectionSerializationFactory
    {
        /// <summary>
        /// Gets Json collection serializer.
        /// </summary>
        /// <returns>The collection serializer.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public ICollectionSerializationManager<T> JsonCollectionSerializer<T>()
        {
            return new CollectionSerializationManager<T>(new JSONCollectionSerializer<T>(),
                new JSONCollectionDeserializer<T>());
        }
    }
}
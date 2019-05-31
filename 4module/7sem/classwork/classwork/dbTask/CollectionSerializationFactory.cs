namespace dbTask
{
    public class CollectionSerializationFactory
    {
        public ICollectionSerializationManager<T> CollectionSerializer<T>()
        {
            return new CollectionSerializationManager<T>(new JSONCollectionSerializer<T>(), new JSONCollectionDeserializer<T>());
        }
    }
}
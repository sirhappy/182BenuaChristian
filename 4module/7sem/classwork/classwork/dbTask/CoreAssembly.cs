namespace dbTask
{
    public class CoreAssembly
    {
        public CollectionSerializationFactory SerializationFactory { get; }
        
        public DataBase MyDataBase { get; }
        
        public IRequestsFactory RequestsFactory { get; }

        public CoreAssembly()
        {
            SerializationFactory = new CollectionSerializationFactory();
            MyDataBase = new DataBase("MyDB", SerializationFactory);
            RequestsFactory = new RequestsFactory();
        }
    }
}
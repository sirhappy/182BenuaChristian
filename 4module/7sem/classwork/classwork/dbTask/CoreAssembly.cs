namespace dbTask
{
    public class CoreAssembly
    {
        public CollectionSerializationFactory SerializationFactory { get; }

        public DataBase MyDataBase { get; }

        public IRequestsFactory RequestsFactory { get; }

        public FactoryCorrectnessChecker CorrectnessChecker { get; }

        public IDataBaseContentChecker DataBaseContentChecker { get; }

        public CoreAssembly()
        {
            SerializationFactory = new CollectionSerializationFactory();
            MyDataBase = new DataBase("MyDB", SerializationFactory);
            RequestsFactory = new RequestsFactory();
            CorrectnessChecker = new FactoryCorrectnessChecker(MyDataBase);
            DataBaseContentChecker = new DataBaseContentChecker();
        }

        public static void PrepareForTest()
        {
            ShopFactory.ResetIdsForTests();
            OrderFactory.ResetIdsForTests();
            CustomerFactory.ResetIdsForTests();
            GoodFactory.ResetIdsForTests();
        }
    }
}
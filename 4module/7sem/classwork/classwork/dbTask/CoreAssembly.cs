namespace dbTask
{
    /// <summary>
    /// Core assembly.
    /// </summary>
    public class CoreAssembly
    {
        /// <summary>
        /// Gets the serialization factory.
        /// </summary>
        /// <value>The serialization factory.</value>
        public CollectionSerializationFactory SerializationFactory { get; }

        /// <summary>
        /// Gets my data base.
        /// </summary>
        /// <value>My data base.</value>
        public DataBase MyDataBase { get; }

        /// <summary>
        /// Gets the requests factory.
        /// </summary>
        /// <value>The requests factory.</value>
        public IRequestsFactory RequestsFactory { get; }

        /// <summary>
        /// Gets the correctness checker.
        /// </summary>
        /// <value>The correctness checker.</value>
        public FactoryCorrectnessChecker CorrectnessChecker { get; }

        /// <summary>
        /// Gets the data base content checker.
        /// </summary>
        /// <value>The data base content checker.</value>
        public IDataBaseContentChecker DataBaseContentChecker { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.CoreAssembly"/> class.
        /// </summary>
        public CoreAssembly()
        {
            SerializationFactory = new CollectionSerializationFactory();
            MyDataBase = new DataBase("MyDB", SerializationFactory);
            RequestsFactory = new RequestsFactory();
            CorrectnessChecker = new FactoryCorrectnessChecker(MyDataBase);
            DataBaseContentChecker = new DataBaseContentChecker();
        }

        /// <summary>
        /// Prepares for test.
        /// </summary>
        public static void PrepareForTest()
        {
            ITestEntityFactory<Shop>.ResetIdsForTests();
            ITestEntityFactory<Order>.ResetIdsForTests();
            ITestEntityFactory<Customer>.ResetIdsForTests();
            ITestEntityFactory<Good>.ResetIdsForTests();
        }
    }
}
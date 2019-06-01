namespace dbTask
{
    public interface IEntityFactory<T>
    {
        T Instance { get; }
    }

    public abstract class ITestEntityFactory<T> : IEntityFactory<T>
    {
        protected static long _lastGeneratedId;
        private T _instance;

        public static void ResetIdsForTests()
        {
            _lastGeneratedId = 0;
        }

        public abstract T Instance { get; }
    }
}
namespace dbTask
{
    /// <summary>
    /// Entity factory.
    /// </summary>
    public interface IEntityFactory<T>
    {
        T Instance { get; }
    }

    /// <summary>
    /// IT est entity factory.
    /// </summary>
    public abstract class ITestEntityFactory<T> : IEntityFactory<T>
    {
        /// <summary>
        /// The last generated identifier.
        /// </summary>
        protected static long _lastGeneratedId;

        /// <summary>
        /// Resets the identifiers for tests.
        /// </summary>
        public static void ResetIdsForTests()
        {
            _lastGeneratedId = 0;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public abstract T Instance { get; }
    }
}
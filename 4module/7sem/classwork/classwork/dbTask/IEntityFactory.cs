namespace dbTask
{
    public interface IEntityFactory<T>
    {
        T Instance { get; }
    }
}
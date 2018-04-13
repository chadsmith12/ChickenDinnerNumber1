using SQLite;

namespace ChickenDinnerNumber1.Database
{
    public interface IRepository
    {
        AsyncTableQuery<TEntity> GetAllAsync<TEntity, T>() where TEntity : IEntity<T>, new();
    }
}

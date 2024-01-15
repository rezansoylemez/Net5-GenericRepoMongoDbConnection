namespace Mongo.Repository2.WriteRepositories.IMongoWriteRepository
{
    public interface IMongoWriteRepository<T, TIdType> where T : Entity<TIdType>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}

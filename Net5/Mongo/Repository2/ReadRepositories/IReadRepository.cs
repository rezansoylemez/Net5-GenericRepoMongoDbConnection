using System.Linq;
using System;
using System.Linq.Expressions;

namespace Mongo.Repository2.ReadRepositories.IMongoReadRepository
{
    public interface IMongoReadRepository<T, TIdType> where T : Entity<TIdType>
    {
        T Get(Expression<Func<T, bool>> predicate);

        IPaginate<T> GetList(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true
        );

        IPaginate<T> GetListByDynamic(
            Dynamic.Dynamic dynamic,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true
        );
    } 
}
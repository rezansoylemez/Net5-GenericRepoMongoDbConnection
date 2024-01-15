using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mongo.Repository2.ReadRepositories.IMongoAsyncReadRepository
{
    public interface IMongoAsyncReadRepository<T, TIdType> where T : Entity<TIdType>
    {
        Task<T?> GetAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        );

        Task<IPaginate<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        );

        Task<IPaginate<T>> GetListByDynamicAsync(
            Dynamic.Dynamic dynamic,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        );

        Task<IPaginate<T>> GetListAsync(int index = 0, int size = 10);

        Task<List<T>> GetListAsyncWithOutPaginate(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = true
        );
    }
}

﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mongo.Repository2.IMongoAsyncWriteRepository
{
    public interface IMongoAsyncWriteRepository<T, TIdType> where T : Entity<TIdType>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateAsyncTrackerClear(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);
        Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Mongo.Repository2.IMongoAsyncWriteRepository;
using Mongo.Repository2.ReadRepositories;
using Mongo.Repository2.ReadRepositories.IMongoAsyncReadRepository;
using Mongo.Repository2.WriteRepositories.IMongoWriteRepository;
using MongoDB.Driver;

namespace Mongo.Repository2.MongoRepositoryBase2
{
    public class MongoRepositoryBase2<TEntity, TIdType> : IMongoAsyncReadRepository<TEntity, TIdType>, IMongoReadRepository<TEntity, TIdType>,
                                                           IMongoAsyncWriteRepository<TEntity, TIdType>, IMongoWriteRepository<TEntity, TIdType>
        where TEntity : Entity<TIdType>
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var cursor = await _collection.FindAsync(predicate, cancellationToken: cancellationToken);
            return await cursor.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int index = 0,
            int size = 10,
            CancellationToken cancellationToken = default)
        {
            var queryable = _collection.AsQueryable();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                queryable = orderBy(queryable);

            return await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken);
            return entities;
        }

        public IQueryable<TEntity> Query() => _collection.AsQueryable();

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = false }, cancellationToken);
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.DeleteOneAsync(filter, cancellationToken);
            return entity;
        }

        // Implement other interface methods as needed
    }
}

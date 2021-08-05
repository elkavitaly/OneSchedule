using Domain.Entity;
using Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<TEntity> _entities;

        public Repository(IMongoDatabase mongoDatabase, string collectionString)
        {
            _mongoDatabase = mongoDatabase;
            _entities = _mongoDatabase.GetCollection<TEntity>(collectionString);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null) =>
            await _entities.Find(filter ?? (e => true)).ToListAsync();

        public async Task<TEntity> GetByIdAsync(string id) =>
            await _entities.Find(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, TEntity entity) =>
            await _entities.ReplaceOneAsync(e => e.Id == id, entity);

        public async Task DeleteAsync(TEntity entity) =>
            await _entities.DeleteOneAsync(e => e.Id == entity.Id);

        public async Task DeleteAsync(string id) =>
            await _entities.DeleteOneAsync(e => e.Id == id);


    }
}

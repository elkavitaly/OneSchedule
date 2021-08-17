using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OneSchedule.Data.Abstractions;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OneSchedule.Helpers;
using OneSchedule.Settings;

namespace OneSchedule.Data
{
    public class MongodbRepository<T> : IRepository<T> where T : BaseEntityModel
    {
        private readonly IMongoCollection<T> _collection;

        public MongodbRepository(IMongoClient client, IOptions<DatabaseSettings> options)
        {
            var optionsValue = options.Value;
            var database = client.GetDatabase(optionsValue.DatabaseName);
            var collectionName = CollectionNameReader.GetCollectionName<T>();
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task AddAsync(T data)
        {
            await _collection.InsertOneAsync(data);
        }

        public async Task UpdateAsync(T data)
        {
            var filter = Builders<T>.Filter.Where(e => e.Id == data.Id);
            await _collection.ReplaceOneAsync(filter, data);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Where(e => e.Id == id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync() != null;
        }
    }
}

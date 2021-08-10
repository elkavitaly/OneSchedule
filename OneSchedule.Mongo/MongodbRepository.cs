using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Entities;
using OneSchedule.Helper;
using OneSchedule.Settings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OneSchedule.Mongodb
{
    public class MongodbRepository<T> : IRepository<T> where T:BaseEntityModel
    {
        private readonly IMongoCollection<T> _collection;
        public MongodbRepository(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            var collectionName = typeof(T).GetCustomAttribute(typeof(CollectionName)) 
                is CollectionName collectionNameAttribute ? collectionNameAttribute.Name : nameof(T);

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

        public async Task<DeleteResult> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Where(e => e.Id == id);
            return await _collection.DeleteOneAsync(filter);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = await _collection.FindAsync(predicate);
            return collection.FirstOrDefault();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = await _collection.FindAsync(predicate);
            return collection.ToList();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = await _collection.FindAsync(predicate);
            return await collection.AnyAsync();
        }
    }
}

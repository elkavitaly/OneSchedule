using MongoDB.Driver;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneSchedule.Data.Abstractions
{
    public interface IRepository<T> where T : BaseEntityModel
    {
        public Task Add(T data);

        public Task Update(T data);

        public Task<DeleteResult> Delete(string id);

        public Task<T> FindFirst(Expression<Func<T, bool>> predicate);

        public Task<List<T>> Find(Expression<Func<T, bool>> predicate);

        public Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}

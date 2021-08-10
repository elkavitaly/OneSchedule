using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneSchedule.Data.Abstractions
{
    public interface IRepository<T> where T : BaseEntityModel
    {
        public Task AddAsync(T data);

        public Task UpdateAsync(T data);

        public Task DeleteAsync(string id);

        public Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate);

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}

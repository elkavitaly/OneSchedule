using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    public interface IService<T> where T : BaseDomainModel
    {
        public Task AddAsync(T data);

        public Task UpdateAsync(T data);

        public Task DeleteAsync(string id);

        public Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate);

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}

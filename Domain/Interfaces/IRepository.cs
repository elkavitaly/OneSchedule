using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);

        public Task<TEntity> GetByIdAsync(string id);

        public Task<TEntity> AddAsync(TEntity entity);

        public Task UpdateAsync(string id, TEntity entity);

        public Task DeleteAsync(TEntity entity);

        public Task DeleteAsync(string id);
    }
}

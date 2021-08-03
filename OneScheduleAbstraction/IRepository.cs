namespace OneScheduleAbstraction
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Infrastructure;
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<T> FindFirstAsync(
            Expression<Func<T, bool>> predicate,
            bool isTracked = false,
            params string[] includes);

        Task<List<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            SelectParameters parameters = null,
            bool isTracked = false,
            params string[] includes);
    }
}
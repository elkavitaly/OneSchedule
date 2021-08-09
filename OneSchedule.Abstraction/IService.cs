using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OneSchedule.Abstraction
{
    public interface IService<T>
    {
        public void Add(T data);

        public void Update(T data);

        public DeleteResult Delete(string id);

        public T FindFirst(Expression<Func<T, bool>> predicate);

        public List<T> Find(Expression<Func<T, bool>> predicate);

        public bool Any(Expression<Func<T, bool>> predicate);
    }
}

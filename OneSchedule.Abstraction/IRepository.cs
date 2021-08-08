namespace OneSchedule.Abstraction
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> where T: DbModel
    {
        public Task Add(T data);

        public Task Update(T data);

        public Task<DeleteResult> Delete(string id);

        public Task<T> FindFirst(Func<T, bool> predicate);

        public Task<ICollection<T>> Find(Func<T, bool> predicate);

        public Task<bool> Any(Func<T,bool> predicate);
    }
}

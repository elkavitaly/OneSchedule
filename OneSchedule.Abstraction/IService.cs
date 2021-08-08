namespace OneSchedule.Abstraction
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using System;


    public interface IService<T> 
    {
        public void Add(T data);

        public void Update(T data);

        public DeleteResult Delete(string id);

        public T FindFirst(Func<T,bool> predicate);

        public ICollection<T> Find(Func<T, bool> predicate);

        public bool Any(Func<T, bool> predicate);
    }
}

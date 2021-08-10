using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneSchedule.Services
{
    public class EventService : IService<EventEntity>
    {
        private readonly IRepository<EventEntity> _repository;

        public EventService(IRepository<EventEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(EventEntity data)
        {
            await _repository.AddAsync(data);
        }

        public async Task UpdateAsync(EventEntity data)
        {
            await _repository.UpdateAsync(data);
        }

        public async Task<DeleteResult> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EventEntity> FindFirstAsync(Expression<Func<EventEntity, bool>> predicate)
        {
            return await _repository.FindFirstAsync(predicate);
        }

        public async Task<List<EventEntity>> FindAsync(Expression<Func<EventEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<EventEntity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }
    }
}

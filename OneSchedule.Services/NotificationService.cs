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
    public class NotificationService:IService<NotificationEntity>
    {
        private readonly IRepository<NotificationEntity> _repository;

        public NotificationService(IRepository<NotificationEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(NotificationEntity data)
        {
            await _repository.AddAsync(data);
        }

        public async Task UpdateAsync(NotificationEntity data)
        {
            await _repository.UpdateAsync(data);
        }

        public async Task<DeleteResult> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<NotificationEntity> FindFirstAsync(Expression<Func<NotificationEntity, bool>> predicate)
        {
            return await _repository.FindFirstAsync(predicate);
        }

        public async Task<List<NotificationEntity>> FindAsync(Expression<Func<NotificationEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<NotificationEntity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }
    }
}

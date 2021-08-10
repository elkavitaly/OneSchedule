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
    public class UserService:IService<UserEntity>
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(UserEntity data)
        {
            await _repository.AddAsync(data);
        }

        public async Task UpdateAsync(UserEntity data)
        {
            await _repository.UpdateAsync(data);
        }

        public async Task<DeleteResult> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> FindFirstAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return await _repository.FindFirstAsync(predicate);
        }

        public async Task<List<UserEntity>> FindAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }
    }
}

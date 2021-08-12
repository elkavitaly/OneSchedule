using AutoMapper;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneSchedule.Services
{
    public class UserService : IService<UserDomain>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserDomain data)
        {
            var entityData = _mapper.Map<UserEntity>(data);
            await _repository.AddAsync(entityData);
        }

        public async Task UpdateAsync(UserDomain data)
        {
            var entityData = _mapper.Map<UserEntity>(data);
            await _repository.UpdateAsync(entityData);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<UserDomain> FindFirstAsync(Expression<Func<UserDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDomain>> FindAsync(Expression<Func<UserDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<UserDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

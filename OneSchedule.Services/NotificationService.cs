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
    public class NotificationService : IService<NotificationDomain>
    {
        private readonly IRepository<NotificationEntity> _repository;
        private readonly IMapper _mapper;

        public NotificationService(IRepository<NotificationEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(NotificationDomain data)
        {
            var entityData = _mapper.Map<NotificationEntity>(data);
            await _repository.AddAsync(entityData);
        }

        public async Task UpdateAsync(NotificationDomain data)
        {
            var entityData = _mapper.Map<NotificationEntity>(data);
            await _repository.UpdateAsync(entityData);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<NotificationDomain> FindFirstAsync(Expression<Func<NotificationDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NotificationDomain>> FindAsync(Expression<Func<NotificationDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<NotificationDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class EventService : IService<EventDomain>
    {
        private readonly IRepository<EventEntity> _repository;
        private readonly IMapper _mapper;

        public EventService(IRepository<EventEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(EventDomain data)
        {
            var entityData = _mapper.Map<EventEntity>(data);
            await _repository.AddAsync(entityData);
        }

        public async Task UpdateAsync(EventDomain data)
        {
            var entityData = _mapper.Map<EventEntity>(data);
            await _repository.UpdateAsync(entityData);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<EventDomain> FindFirstAsync(Expression<Func<EventDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EventDomain>> FindAsync(Expression<Func<EventDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<EventDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

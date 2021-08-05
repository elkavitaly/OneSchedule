using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IRepository<TEntity> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}

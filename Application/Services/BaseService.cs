using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

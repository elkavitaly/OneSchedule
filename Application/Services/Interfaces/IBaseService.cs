using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public class IBaseService<TEntity> where TEntity : BaseEntity
    {
    }
}

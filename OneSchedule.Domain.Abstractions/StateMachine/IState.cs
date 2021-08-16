using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OneSchedule.Domain.Abstractions
{
    public interface IState
    {
        public Task HandleAsync(DtoDomain dtoDomain);

        public void SetContext(IStateContext context);
    }
}

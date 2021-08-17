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
        public void Handle(IStateContext stateContext, DtoDomain dtoDomain);
    }
}

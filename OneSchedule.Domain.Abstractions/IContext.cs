using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    public interface IContext
    {
        public void SetState(IBotState state);
    }
}

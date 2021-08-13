using OneSchedule.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    public class Context : IContext
    {
        private IBotState _state;

        public Context(IBotState initialState)
        {
            _state = initialState;
            _state.SetContext(this);
        }

        public void SetState(IBotState state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}

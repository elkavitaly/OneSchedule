using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    [StateName("SetTitle")]
    public class EventSetTitleState : IState
    {
        private const string SetBeginDateTime = "SetBeginDateTime";
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly Dictionary<string, IState> _states;

        public EventSetTitleState(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.Title = dtoDomain.MessageText;
            stateContext.SetState(SetBeginDateTime);
     
            await _contextRepository.UpdateAsync(contextEntity);
        }

        public void SetContext(IStateContext context)
        {
            _context = (StateContext)context;
        }
    }
}
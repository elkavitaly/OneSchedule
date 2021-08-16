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
        private readonly IRepository<ContextEntity> _contextRepository;
        private StateContext _context;

        private Dictionary<string, IState> _states;
        private readonly string _nextState = "SetBeginDateTime";

        public EventSetTitleState(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _states = states.ToDictionary(s => StateNameReader.GetStateName(s.GetType()));
            _contextRepository = contextRepository;
        }

        public async Task HandleAsync(DtoDomain dtoDomain)
        {
            var contextEntity = await GetContextEntity(dtoDomain);
            contextEntity.Event.Title = dtoDomain.MessageText;
            contextEntity.NextState = _nextState;
            _context.SetState(_states[_nextState]);
            await _contextRepository.UpdateAsync(contextEntity);
        }

        public void SetContext(IStateContext context)
        {
            _context = (StateContext)context;
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
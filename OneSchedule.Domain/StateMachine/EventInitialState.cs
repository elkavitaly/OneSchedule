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
    [StateName("EventInitial")]
    public class EventInitialState : IState
    {
        private readonly IRepository<ContextEntity> _contextRepository;
        private EventContext _context;

        private Dictionary<string, IState> _states;
        private readonly string _nextState = "SetTitle";

        public EventInitialState(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _states = states.ToDictionary(s => StateNameReader.GetStateName(s.GetType()));
            _contextRepository = contextRepository;
        }

        public async Task HandleAsync(DtoDomain dtoDomain)
        {
            var contextEntity = await GetContextEntity(dtoDomain);
            if (contextEntity == null)
            {
                contextEntity = new ContextEntity()
                {
                    Event = new EventEntity() { ChatId = dtoDomain.ChatId, OwnerId = dtoDomain.UserId },
                    NextState = _nextState
                };

                await _contextRepository.AddAsync(contextEntity);

                _context.SetState(_states[_nextState]);
            }
            else
            {
                _context.SetState(_states[contextEntity.NextState]);
            }

            await _context.HandleAsync(dtoDomain);
        }

        public void SetContext(IStateMachineContext context)
        {
            _context = (EventContext)context;
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
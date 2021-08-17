using AutoMapper;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class StateContext : IStateContext
    {
        private IState _state;
        //private readonly IRepository<EventEntity> _eventRepository
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly Dictionary<string, IState> _states;
        private const string SetTitle = "SetTitle";

        public EventEntity EventEntity { get; set; }

        public StateContext(string state)
        {
            SetState(state);
        }

        public StateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _states = states.ToDictionary(s => StateNameReader.GetStateName(s.GetType()));
            _contextRepository = contextRepository;
        }

        public void SetState(string state)
        {
            _state = _states[state];
        }

        public async Task HandleAsync(DtoDomain dtoDomain)
        {
            var contextEntity = await GetContextEntity(dtoDomain);
            if (contextEntity == null)
            {
                contextEntity = new ContextEntity()
                {
                    Event = new EventEntity() { ChatId = dtoDomain.ChatId, OwnerId = dtoDomain.UserId },
                    NextState = SetTitle
                };

                await _contextRepository.AddAsync(contextEntity);
            }
            else
            {
                SetState(contextEntity.NextState);
                EventEntity = contextEntity.Event;
                await _state.HandleAsync(this, dtoDomain);

                await _contextRepository.UpdateAsync(contextEntity);
            }
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
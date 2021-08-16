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
        private readonly ITelegramBotClient _bot;
        //private readonly IRepository<EventEntity> _eventRepository;
        private readonly Dictionary<string, IState> _states;

        public StateContext(IState state)
        {
            SetState(state);
        }

        public StateContext(IEnumerable<IState> states)
        {
            _states = states.ToDictionary(s => StateNameReader.GetStateName(s.GetType()));
            var initialState = _states["Initial"];
            SetState(initialState);
        }

        public void SetState(IState state)
        {
            _state = state;
            _state.SetContext(this);
        }

        public async Task HandleAsync(DtoDomain dtoDomain)
        {
            await _state.HandleAsync(dtoDomain);
        }
    }
}

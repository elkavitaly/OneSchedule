using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine
{
    public class StateContext : IStateContext
    {
        private const string NextState = "EventMenu";
        private IState _state;
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly Dictionary<string, IState> _states;
        public EventEntity EventEntity { get; set; }
        public bool IsContextCompleted => EventEntity.StartDate != default(DateTime)
                                          && string.IsNullOrWhiteSpace(EventEntity.Title)
                                          && EventEntity.Notifications is
                                          {
                                              Count: > 0
                                          };

        public StateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _states = states.ToDictionary(s =>
                StateNameReader.GetStateName(s.GetType()));
            _contextRepository = contextRepository;
        }

        public void SetState(string state)
        {
            _state = _states[state];
        }

        public async Task DeleteContextAsync(string id)
        {
            await _contextRepository.DeleteAsync(id);
        }

        public async Task HandleAsync(DtoDomain dtoDomain)
        {
            var contextEntity = await GetContextEntity(dtoDomain);

            if (contextEntity == null)
            {
                contextEntity = new ContextEntity()
                {
                    Event = new EventEntity()
                    {
                        ChatId = dtoDomain.ChatId,
                        OwnerId = dtoDomain.UserId
                    },
                    NextState = NextState
                };

                await _contextRepository.AddAsync(contextEntity);
            }

            if (dtoDomain.MessageText.Contains("Id"))
            {
                var id = dtoDomain.MessageText.Substring(dtoDomain.MessageText.IndexOf("Id", StringComparison.Ordinal) + 2);
                contextEntity.Event.Id = id;
            }

            EventEntity = contextEntity.Event;
            SetState(contextEntity.NextState);
            await _state.HandleAsync(this, dtoDomain);
            await _contextRepository.UpdateAsync(contextEntity);
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
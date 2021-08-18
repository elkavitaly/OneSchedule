using OneSchedule.Attributes;
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
    [StateContextName("Create")]
    public class CreateStateContext : IStateContext
    {
        private const string NextState = "AskEventMenu";
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly Dictionary<string, IState> _states;
        private IState _state;
        
        public ContextEntity ContextEntity { get; set; }

        public bool IsContextCompleted => ContextEntity.Event.StartDate != default(DateTime)
                                          && string.IsNullOrWhiteSpace(ContextEntity.Event.Title)
                                          && ContextEntity.Event.Notifications is
                                          {
                                              Count: > 0
                                          };

        public CreateStateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            _states = states.ToDictionary(s =>
                StateNameReader.GetStateName(s.GetType()));
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
                    Event = new EventEntity()
                    {
                        ChatId = dtoDomain.ChatId,
                        OwnerId = dtoDomain.UserId
                    },
                    NextState = NextState
                };

                await _contextRepository.AddAsync(contextEntity);
            }

            ContextEntity = contextEntity;
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
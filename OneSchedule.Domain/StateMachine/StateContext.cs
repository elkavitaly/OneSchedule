using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine
{
    [StateContextName("Menu")]
    public class StateContext : IStateContext
    {
        private const string DefaultState = "AskMainMenu";
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly Dictionary<string, IState> _states;
        private readonly Dictionary<string, IStrategy> _strategies;
        private IState _state;

        public DateTime MinStartDate { get; set; }

        public DateTime MaxStartDate { get; set; }

        public ContextEntity ContextEntity { get; set; }

        public bool IsContextCompleted => ContextEntity.Event.StartDate != default(DateTime)
                                          && !string.IsNullOrWhiteSpace(ContextEntity.Event.Title)
                                          && ContextEntity.Event.Notifications is
                                          {
                                              Count: > 0
                                          };

        public StateContext(IEnumerable<IState> states,
            IRepository<ContextEntity> contextRepository, IEnumerable<IStrategy> strategies)
        {
            _states = states.ToDictionary(s =>
                StateNameReader.GetStateName(s.GetType()));
            _strategies = strategies.ToDictionary(s =>
                StrategyNameReader.GetStrategyName(s.GetType()));
            _contextRepository = contextRepository;
        }

        public void SetState(string state)
        {
            _state = _states[state];
        }

        public async Task Execute(DtoDomain dtoDomain)
        {
            await _state.HandleAsync(this, dtoDomain);
        }

        public virtual async Task HandleAsync(DtoDomain dtoDomain)
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
                    LastState = DefaultState
                };
                await _contextRepository.AddAsync(contextEntity);
                await _states[DefaultState].HandleAsync(this, dtoDomain);
            }

            ContextEntity = contextEntity;
            var currentStrategy = _strategies
                .FirstOrDefault(s => dtoDomain.MessageText.Contains(s.Key));

            if (currentStrategy.Equals(default(KeyValuePair<string, IStrategy>)))
            {
                await _strategies["[data]"].ExecuteAsync(this, dtoDomain);
            }
            else
            {
                await currentStrategy.Value.ExecuteAsync(this, dtoDomain);
            }

            await _contextRepository.UpdateAsync(contextEntity);

        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                                                               && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
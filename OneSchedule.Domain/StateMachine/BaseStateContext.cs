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
    [StateContextName("Menu")]
    public abstract class BaseStateContext : IStateContext
    {
        protected string NextState = "AskMainMenu";
        protected readonly IRepository<ContextEntity> ContextRepository;
        protected readonly Dictionary<string, IState> States;
        protected IState State;

        public ContextEntity ContextEntity { get; set; }

        public bool IsContextCompleted => ContextEntity.Event.StartDate != default(DateTime)
                                          && string.IsNullOrWhiteSpace(ContextEntity.Event.Title)
                                          && ContextEntity.Event.Notifications is
                                          {
                                              Count: > 0
                                          };

        protected BaseStateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository)
        {
            States = states.ToDictionary(s =>
                StateNameReader.GetStateName(s.GetType()));
            ContextRepository = contextRepository;
        }

        public void SetState(string state)
        {
            State = States[state];
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
                    NextState = NextState
                };

                await ContextRepository.AddAsync(contextEntity);
            }

            ContextEntity = contextEntity;
            SetState(contextEntity.NextState);
            await State.HandleAsync(this, dtoDomain);
            await ContextRepository.UpdateAsync(contextEntity);
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await ContextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
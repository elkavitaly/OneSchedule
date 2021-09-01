using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[edit]")]
    public class EditStrategy : IStrategy
    {
        private const string State = "AskEventMenu";
        private readonly IRepository<EventEntity> _eventRepository;

        public EditStrategy(IRepository<EventEntity> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            var evenEntity = await _eventRepository
                .FindFirstAsync(e => e.Title == dto.MessageText.Split()[1]);

            context.ContextEntity.Event = evenEntity;

            context.SetState(State);
            await context.Execute(dto);
            context.ContextEntity.LastState = State;
        }
    }
}

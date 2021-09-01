using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[delete]")]
    public class DeleteStrategy : IStrategy
    {
        private const string State = "AskMainMenu";
        private readonly IRepository<EventEntity> _eventRepository;
        private readonly IRepository<ContextEntity> _contextRepository;

        public DeleteStrategy(IRepository<EventEntity> eventRepository, IRepository<ContextEntity> contextRepository)
        {
            _eventRepository = eventRepository;
            _contextRepository = contextRepository;
        }

        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            if (!string.IsNullOrWhiteSpace(context.ContextEntity.Event.Id))
            {
                await _eventRepository.DeleteAsync(context.ContextEntity.Event.Id);
            }

            await _contextRepository.DeleteAsync(context.ContextEntity.Id);

            context.SetState(State);
            await context.Execute(dto);
            context.ContextEntity.LastState = State;
        }
    }
}

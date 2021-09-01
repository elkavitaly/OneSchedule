using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("/menu")]
    public class MenuStrategy2 : IStrategy
    {
        private const string State = "AskMainMenu";
        private readonly IRepository<ContextEntity> _contextRepository;

        public MenuStrategy2(IRepository<ContextEntity> contextRepository)
        {
            _contextRepository = contextRepository;
        }
        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            await _contextRepository.DeleteAsync(context.ContextEntity.Id);
            context.SetState(State);
            await context.Execute(dto);
            context.ContextEntity.LastState = State;
        }
    }
}

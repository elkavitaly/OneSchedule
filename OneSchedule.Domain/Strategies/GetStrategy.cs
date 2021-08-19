using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[get]")]
    public class GetStrategy : IStrategy
    {
        private const string State= "AskEventList";
        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            context.SetState(State);
            await context.Execute(dto);
            context.ContextEntity.LastState = State;
        }
    }
}

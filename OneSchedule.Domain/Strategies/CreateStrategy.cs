using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[create]")]
    public class CreateStrategy : IStrategy
    {
        private const string State = "AskEventMenu";

        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            context.SetState(State);
            await context.Execute(dto);
            context.ContextEntity.LastState = State;
        }
    }
}

using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetMainMenu")]
    public class GetMainMenuState : IState
    {
        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.SetState(dtoDomain.MessageText);
            return Task.CompletedTask;
        }
    }
}
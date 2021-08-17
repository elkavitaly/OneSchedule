using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetMainMenu")]
    public class GetMainMenuState : IState
    {
        private const string NextState = "AskEventMenu";
        private const string Create = "Create";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
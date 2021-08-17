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

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {

            if (dtoDomain.MessageText != "Create")
            {
                stateContext.EventEntity.Id = dtoDomain.MessageText;
            }

            stateContext.SetState(NextState);

            return Task.CompletedTask;
        }
    }
}
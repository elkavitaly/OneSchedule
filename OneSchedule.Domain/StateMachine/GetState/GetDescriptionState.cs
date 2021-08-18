using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetDescription")]
    public class GetDescriptionState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.ContextEntity.Event.Description = dtoDomain.MessageText;
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}

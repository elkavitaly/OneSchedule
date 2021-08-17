using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("AskDescription")]
    public class GetDescriptionState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.Description = dtoDomain.MessageText;
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}

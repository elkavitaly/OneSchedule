using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetTitle")]
    public class GetTitleState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.ContextEntity.Event.Title = dtoDomain.MessageText;
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
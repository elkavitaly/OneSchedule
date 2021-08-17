using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetShowEventList")]
    public class GetShowEventListState : IState
    {
        private const string Menu = "AskMainMenu";
        private const string EventMenu = "AskEventMenu";
        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (dtoDomain.MessageText == Menu)
            {
                stateContext.SetState(dtoDomain.MessageText);
            }
            else
            {
                stateContext.SetState(EventMenu);
            }
            return Task.CompletedTask;
        }
    }
}
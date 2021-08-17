using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEndDate")]
    public class GetEndDateState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.ContextEntity.Event.EndDate = DateTime.Parse(dtoDomain.MessageText);
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
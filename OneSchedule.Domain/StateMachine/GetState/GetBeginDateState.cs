using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetBeginDate")]
    public class GetBeginDateState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.StartDate = DateTime.Parse(dtoDomain.MessageText);
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
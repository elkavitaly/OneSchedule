using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEventList")]
    public class GetEventListState : IState
    {
        private const string NextState = "AskShowEventList";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (stateContext is FindStateContext findState)
            {
                var dates = dtoDomain.MessageText.Split("-").Select(DateTime.Parse).ToList();
                findState.MinStartDate = dates[0];
                findState.MaxStartDate = dates[1];
            }

            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
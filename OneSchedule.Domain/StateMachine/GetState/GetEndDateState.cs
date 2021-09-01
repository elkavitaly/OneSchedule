using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEndDate")]
    public class GetEndDateState : IState
    {
        private const string State = "GetEndDate";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (DateTime.TryParse(dtoDomain.MessageText, out var date))
            {
                stateContext.ContextEntity.Event.EndDate = date;
                stateContext.ContextEntity.LastState = State;
            }
            else
            {
                throw new BotAppInternalException("Invalid date format");
            }
            return Task.CompletedTask;
        }
    }
}
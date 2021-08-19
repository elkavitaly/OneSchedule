using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetBeginDate")]
    public class GetBeginDateState : IState
    {
        private const string State = "GetBeginDate";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (DateTime.TryParse(dtoDomain.MessageText,out var date))
            {
                stateContext.ContextEntity.Event.StartDate = date;
                stateContext.ContextEntity.LastState = State;
            }
            else
            {
                throw new Exception("Invalid date format");
            }
            return Task.CompletedTask;
        }
    }
}
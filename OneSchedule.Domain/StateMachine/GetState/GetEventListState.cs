using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEventList")]
    public class GetEventListState : IState
    {
        private const string State = "GetEventList";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            (DateTime, DateTime) dateTuple;
            var dates = dtoDomain.MessageText.Split("|");

            if (dates.Length == 2 && DateTime.TryParse(dates[0], out dateTuple.Item1) 
                                  && DateTime.TryParse(dates[1], out dateTuple.Item2))
            {
                stateContext.MinStartDate = dateTuple.Item1;
                stateContext.MaxStartDate = dateTuple.Item2;
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
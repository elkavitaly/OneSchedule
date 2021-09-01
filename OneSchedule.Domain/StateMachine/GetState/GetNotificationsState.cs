using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetNotifications")]
    public class GetNotificationsState : IState
    {
        private const string State = "GetNotifications";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            try
            {
                var dates = dtoDomain.MessageText.Split("|");
                var notifications = dates.Select(d =>
                {
                    DateTime.TryParse(d, out var dateTime);
                    return new NotificationEntity() { Date = dateTime };
                }).ToList();

                if (notifications.Count > 0)
                {
                    stateContext.ContextEntity.Event.Notifications = notifications;
                    stateContext.ContextEntity.LastState = State;
                }
                else
                {
                    throw new BotAppInternalException("Invalid date format");
                }
            }
            catch 
            {
                throw new BotAppInternalException("Invalid date format");
            }
            return Task.CompletedTask;
        }
    }
}
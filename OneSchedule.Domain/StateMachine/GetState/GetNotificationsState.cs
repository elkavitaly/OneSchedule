using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetNotifications")]
    public class GetNotificationsState : IState
    {
        private const string NextState = "AskEventMenu";

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            var dates = dtoDomain.MessageText.Split(" ");
            var notifications = dates.Select(d=>
                new NotificationEntity(){Date = DateTime.Parse(d)}).ToList();

            stateContext.EventEntity.Notifications = notifications;
            stateContext.SetState(NextState);
            return Task.CompletedTask;
        }
    }
}
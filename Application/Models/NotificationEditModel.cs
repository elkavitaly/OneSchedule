using System;

namespace Application.Models
{

    public record NotificationEditModel(string Id, string UserId, string EventId, DateTime Date);
}

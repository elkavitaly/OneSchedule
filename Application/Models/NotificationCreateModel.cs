using System;

namespace Application.Models
{

    public record NotificationCreateModel(string UserId, string EventId, DateTime Date);
}

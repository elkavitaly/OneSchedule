using System;
using System.Net;

namespace Application.Exceptions
{
    public class NotificationDateException : BaseApplicationException
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public NotificationDateException()
        {
        }

        public NotificationDateException(string message) : base(message)
        {
        }

        public NotificationDateException(DateTime notificationDate, DateTime eventStart)
            : base($"Notification date ({notificationDate}) is later than event start ({eventStart})!")
        {
        }

    }
}

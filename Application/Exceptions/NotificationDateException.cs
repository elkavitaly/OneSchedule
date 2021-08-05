using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

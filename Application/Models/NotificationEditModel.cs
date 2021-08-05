using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{

    public record NotificationEditModel(string Id, string UserId, string EventId, DateTime Date);
}

using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{

    public record EventCreateModel(string UserId, int ChatId, string Title, string Description, DateTime Start, DateTime End);
}

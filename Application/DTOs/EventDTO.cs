using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record EventDTO(string Id, int ChatId, string Title, string Description, DateTime Start, DateTime End);
}

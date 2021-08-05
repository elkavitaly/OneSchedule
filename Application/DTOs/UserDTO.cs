using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record UserDTO (string Id, int TelegramUserId, string FirstName, string LastName, string PhoneNumber);
}
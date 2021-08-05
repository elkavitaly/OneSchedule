using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public record UserEditModel(string Id, string FirstName, string LastName, string PhoneNumber);
}

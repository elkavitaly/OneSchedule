using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class User : BaseEntity
    {
        public int TelegramUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        private ICollection<Event> events;

        public ICollection<Event> Events { get => events ??= new List<Event>(); set => events = value; }
    }
}

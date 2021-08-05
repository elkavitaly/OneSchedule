using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Event : BaseEntity
    {
        public int ChatId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        private ICollection<Notification> notifications;

        public ICollection<Notification> Notifications { get => notifications ??= new List<Notification>(); set => notifications = value; }

    }
}
﻿using System;
using System.Collections.Generic;

namespace OneSchedule.ViewModels
{
    public class EventView : BaseViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string OwnerId { get; set; }

        public int ChatId { get; set; }

        public List<NotificationView> Notifications { get; set; }
    }
}

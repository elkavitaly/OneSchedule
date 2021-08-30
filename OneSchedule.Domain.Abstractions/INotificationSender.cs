﻿using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    public interface INotificationSender
    {
        public async Task SendNotification() { }
    }
}

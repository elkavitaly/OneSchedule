using Application.DTOs;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface INotificationService
    {
        public Task<NotificationDTO> AddAsync(NotificationCreateModel model);


        public Task<NotificationDTO> GetByIdAsync(string userId, string eventId, string notificationId);


        public Task<NotificationDTO> EditAsync(NotificationEditModel model);

        public Task<bool> DeleteAsync(string userId, string eventId, string notificationId);


        public Task<IEnumerable<NotificationDTO>> GetAllAsync(string userId, string eventId);
    }
}

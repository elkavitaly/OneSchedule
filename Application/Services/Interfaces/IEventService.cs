using Application.DTOs;
using Application.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEventService
    {
        public Task<EventDTO> AddAsync(EventCreateModel model);


        public Task<EventDTO> GetByIdAsync(string userId, string eventId);


        public Task<EventDTO> EditAsync(EventEditModel model);

        public Task<bool> DeleteAsync(string userId, string eventId);


        public Task<IEnumerable<EventDTO>> GetAllAsync(string userId);


        public Task<IEnumerable<EventDTO>> GetAllByPeriodAsync(string userId, PeriodModel period);
    }
}

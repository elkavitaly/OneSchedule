using Application.DTOs;
using Application.Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Services
{
    public class EventService : BaseService<User>, IEventService
    {
        public EventService(IMapper mapper, IRepository<User> repository) : base(mapper, repository) { }



        public async Task<EventDTO> AddAsync(EventCreateModel model)
        {
            var @event = _mapper.Map<Event>(model);

            @event.Id = ObjectId.GenerateNewId().ToString();

            var user = await _repository.GetByIdAsync(model.UserId);

            if (user is null)
                return null;

            user.Events.Add(@event);

            await _repository.UpdateAsync(model.UserId, user);

            return _mapper.Map<EventDTO>(@event);
        }


        public async Task<EventDTO> GetByIdAsync(string userId, string eventId)
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user is null)
                return null;

            var @event = user.Events.Where(e => e.Id == eventId).FirstOrDefault();

            return _mapper.Map<EventDTO>(@event);
        }


        public async Task<EventDTO> EditAsync(EventEditModel model)
        {
            var editEvent = _mapper.Map<Event>(model);

            var user = await _repository.GetByIdAsync(model.UserId);

            if (user is null)
                return null;

            var @event = user.Events.FirstOrDefault(e => e.Id == editEvent.Id);

            if (@event is null)
                return null;

            @event.Title = editEvent.Title;
            @event.Description = editEvent.Description;
            @event.Start = editEvent.Start;
            @event.End = editEvent.End;

            await _repository.UpdateAsync(user.Id, user);

            return _mapper.Map<EventDTO>(@event);
        }

        public async Task<bool> DeleteAsync(string userId, string eventId)
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user is null)
                return false;

            var @event = user.Events.FirstOrDefault(e => e.Id == eventId);

            if (@event is null)
                return false;

            user.Events.Remove(@event);

            return true;
        }


        public async Task<IEnumerable<EventDTO>> GetAllAsync(string userId)
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user is null)
                return null;

            return _mapper.Map<IEnumerable<EventDTO>>(user.Events);
        }


        public async Task<IEnumerable<EventDTO>> GetAllByPeriodAsync(string userId, PeriodModel period)
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user is null)
                return null;

            var events = user.Events.Where(e => e.Start <= period.End && e.End >= period.Begin);

            return _mapper.Map<IEnumerable<EventDTO>>(events);
        }
       
    }
}

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
using Application.Exceptions;

namespace Application.Services
{
    public class NotificationService : BaseService<User>, INotificationService
    {
        public NotificationService(IMapper mapper, IRepository<User> repository) : base(mapper, repository) { }



        public async Task<NotificationDTO> AddAsync(NotificationCreateModel model)
        {
            var notification = _mapper.Map<Notification>(model);

            notification.Id = ObjectId.GenerateNewId().ToString();

            var user = await _repository.GetByIdAsync(model.UserId);

            if (user is null)
                return null;

            var @event =  user.Events.FirstOrDefault(e => e.Id == model.EventId);

            if (@event is null)
                return null;

            if (@event.Start < model.Date)
                throw new NotificationDateException(model.Date, @event.Start);


            @event.Notifications.Add(notification);

            await _repository.UpdateAsync(model.UserId, user);

            return _mapper.Map<NotificationDTO>(notification);
        }


        public async Task<NotificationDTO> GetByIdAsync(string userId, string eventId, string notificationId)
        {
            var notification = (await _repository.GetByIdAsync(userId))?
                .Events.Where(e => e.Id == eventId).FirstOrDefault()?
                .Notifications.Where(n => n.Id == notificationId).FirstOrDefault();

            return _mapper.Map<NotificationDTO>(notification);
        }


        public async Task<NotificationDTO> EditAsync(NotificationEditModel model)
        {
            var editNotification = _mapper.Map<Notification>(model);

            var user = await _repository.GetByIdAsync(model.UserId);

            if (user is null)
                return null;

            var notification = user.Events.FirstOrDefault(e => e.Id == model.EventId)?
                .Notifications.FirstOrDefault(n => n.Id == editNotification.Id);

            if (notification is null)
                return null;

            notification.Date = editNotification.Date;

            await _repository.UpdateAsync(user.Id, user);

            return _mapper.Map<NotificationDTO>(notification);
        }

        public async Task<bool> DeleteAsync(string userId, string eventId, string notificationId)
        {
            var @event = (await _repository.GetByIdAsync(userId))?
                .Events.FirstOrDefault(e => e.Id == eventId);

            if (@event is null)
                return false;

            var notification = @event.Notifications.FirstOrDefault(n => n.Id == notificationId);

            if (notification is null)
                return false;

            @event.Notifications.Remove(notification);

            return true;
        }


        public async Task<IEnumerable<NotificationDTO>> GetAllAsync(string userId, string eventId)
        {
            var @event = (await _repository.GetByIdAsync(userId))?
                .Events.FirstOrDefault(e => e.Id == eventId);

            if (@event is null)
                return null;

            return _mapper.Map<IEnumerable<NotificationDTO>>(@event.Notifications);
        }








        //public async Task<PersonWithCustomerIdAndGuestIdDTO> AddAsync(PersonCreateModel personCreateModel)
        //{
        //    var person = _mapper.Map<Person>(personCreateModel);

        //    await _repository.AddAsync(person);
        //    await _repository.SaveAsync();

        //    return _mapper.Map<PersonWithCustomerIdAndGuestIdDTO>(person);
        //}

        //public async Task<bool> DeleteAsync(IdModel model)
        //{
        //    var person = await _repository.GetByIdAsync(model.Id, true);

        //    if (person is null)
        //        //return false;
        //        throw new NotFoundException(nameof(Person), model.Id);

        //    _repository.Delete(person);
        //    await _repository.SaveAsync();

        //    return true;
        //}

        //public async Task<PersonDTO> EditAsync(PersonEditModel personModel)
        //{
        //    var person = _mapper.Map<Person>(personModel);

        //    _repository.Update(person);
        //    await _repository.SaveAsync();

        //    return _mapper.Map<PersonDTO>(person);
        //}

        //public async Task<IEnumerable<PersonWithCustomerIdAndGuestIdDTO>> GetAllAsync()
        //{
        //    return await _repository.GetAllAsync(
        //        new PersonWithCustomerIdAndGuestIdSpecification(), true);
        //}

        //public async Task<PersonWithCustomerIdAndGuestIdDTO> GetByIdAsync(int id)
        //{
        //    return await _repository.GetByIdAsync(
        //        id, new PersonWithCustomerIdAndGuestIdSpecification(), true);
        //}
    }
}

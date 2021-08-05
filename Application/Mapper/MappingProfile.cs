using Application.DTOs;
using Application.Models;
using AutoMapper;
using Domain.Entity;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Event, EventDTO>();

            CreateMap<EventCreateModel, Event>();

            CreateMap<EventEditModel, Event>();

            CreateMap<Notification, NotificationDTO>();

            CreateMap<NotificationCreateModel, Notification>();

            CreateMap<NotificationEditModel, Notification>();

            CreateMap<User, UserDTO>();

            CreateMap<UserCreateModel, User>();

            CreateMap<UserEditModel, User>();
        }
    }
}

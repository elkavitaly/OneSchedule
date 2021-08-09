using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationDomain, NotificationEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<NotificationView, NotificationDomain>()
                .ReverseMap();

            CreateMap<NotificationView, NotificationEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

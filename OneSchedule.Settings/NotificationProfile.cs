using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;

namespace OneSchedule.Settings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationDomain, NotificationEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

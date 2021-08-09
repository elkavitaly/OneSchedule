using AutoMapper;
using OneSchedule.DomainModels;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<DomainNotification, EntityNotification>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<ViewNotification, DomainNotification>()
                .ReverseMap();

            CreateMap<ViewNotification, EntityNotification>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

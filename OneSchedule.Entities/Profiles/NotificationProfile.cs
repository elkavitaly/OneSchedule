namespace OneSchedule.Entities.Profiles
{
    using AutoMapper;
    using DbModels;
    using DtoModels;
    using ViewModels;

    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<DtoNotification, DbNotification>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<ViewNotification, DtoNotification>()
                .ReverseMap();

            CreateMap<ViewNotification, DbNotification>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

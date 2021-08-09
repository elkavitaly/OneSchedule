using AutoMapper;
using OneSchedule.DomainModels;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DomainUser, EntityUser>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<ViewUser, DomainUser>()
                .ReverseMap();

            CreateMap<ViewUser, EntityUser>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDomain, UserEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<UserView, UserDomain>()
                .ReverseMap();

            CreateMap<UserView, UserEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

        }
    }
}

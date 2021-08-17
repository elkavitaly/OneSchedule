using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;

namespace OneSchedule.Settings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDomain, UserEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

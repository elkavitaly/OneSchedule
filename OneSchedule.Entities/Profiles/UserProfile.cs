namespace OneSchedule.Entities.Profiles
{
    using AutoMapper;
    using DbModels;
    using DtoModels;
    using ViewModels;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DtoUser, DbUser>()
                .ForMember(m=>m.Id,option=>option.Ignore())
                .ReverseMap();

            CreateMap<ViewUser, DtoUser>()
                .ReverseMap();

            CreateMap<ViewUser, DbUser>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

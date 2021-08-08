namespace OneSchedule.Entities.Profiles
{
    using AutoMapper;
    using DbModels;
    using DtoModels;
    using ViewModels;

    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DtoEvent, DbEvent>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<ViewEvent, DtoEvent>()
                .ReverseMap();

            CreateMap<ViewEvent, DbEvent>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

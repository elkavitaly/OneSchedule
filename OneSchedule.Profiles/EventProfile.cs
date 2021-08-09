using AutoMapper;
using OneSchedule.DomainModels;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DomainEvent, EntityEvent>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<ViewEvent, DomainEvent>()
                .ReverseMap();

            CreateMap<ViewEvent, EntityEvent>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

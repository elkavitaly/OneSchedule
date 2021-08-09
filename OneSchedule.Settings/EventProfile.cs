using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.ViewModels;

namespace OneSchedule.Settings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDomain, EventEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();

            CreateMap<EventView, EventDomain>()
                .ReverseMap();

            CreateMap<EventView, EventEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

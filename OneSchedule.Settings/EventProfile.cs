using AutoMapper;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;

namespace OneSchedule.Settings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDomain, EventEntity>()
                .ForMember(m => m.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}

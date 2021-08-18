using AutoMapper;
using OneSchedule.Domain.Models;
using Telegram.Bot.Types;

namespace OneSchedule.Settings
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Update, DtoDomain>()
                .ForMember(dest => dest.MessageText,
                    opt => opt
                        .MapFrom(src => src.Message.Text))
                .ForMember(dest => dest.UserId,
                    opt => opt
                        .MapFrom(src => src.Message.From.Id))
                .ForMember(dest => dest.ChatId,
                    opt => opt
                        .MapFrom(src => src.Message.Chat.Id))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}

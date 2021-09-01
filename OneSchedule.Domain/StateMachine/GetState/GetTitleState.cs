using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Exceptions.CustomExceptions;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetTitle")]
    public class GetTitleState : IState
    {
        private const string State = "GetTitle";
        private readonly IRepository<EventEntity> _eventRepository;
        public GetTitleState(IRepository<EventEntity> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            var hasSame = await _eventRepository.AnyAsync(e => e.Title == dtoDomain.MessageText);
            if (!hasSame)
            {
                stateContext.ContextEntity.Event.Title = dtoDomain.MessageText;
                stateContext.ContextEntity.LastState = State;
            }
            else
            {
                throw new BotAppInternalException("Has same Title");
            }
        }
    }
}
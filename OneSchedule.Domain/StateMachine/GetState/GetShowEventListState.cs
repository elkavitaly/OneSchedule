using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetShowEventList")]
    public class GetShowEventListState : IState
    {
        private const string Menu = "AskMainMenu";
        private const string EventMenu = "AskEventMenu";
        private readonly IRepository<ContextEntity> _contextRepository;

        public GetShowEventListState(IRepository<ContextEntity> contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (dtoDomain.MessageText == Menu)
            {
                stateContext.SetState(dtoDomain.MessageText);
                _contextRepository.DeleteAsync(stateContext.ContextEntity.Id);
            }
            else
            {
                stateContext.ContextEntity.Event.Id = dtoDomain.MessageText;
                stateContext.SetState(EventMenu);
            }
            return Task.CompletedTask;
        }
    }
}
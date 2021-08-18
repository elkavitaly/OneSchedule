using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEventMenu")]
    public class GetEventMenuState : IState
    {
        private const string Menu = "AskEventMenu";
        private readonly IRepository<EventEntity> _eventRepository;
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly ITelegramBotClient _bot;

        public GetEventMenuState(IRepository<EventEntity> eventRepository, IRepository<ContextEntity> contextRepository, ITelegramBotClient bot)
        {
            _contextRepository = contextRepository;
            _eventRepository = eventRepository;
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            if (dtoDomain.MessageText.Contains("Save"))
            {
                if (!stateContext.IsContextCompleted)
                {
                    await _bot.SendTextMessageAsync(dtoDomain.ChatId,
                        "Error: Title, StartDate, Notifications fields are required to be filled.");

                    stateContext.SetState(Menu);
                }

                var currentEvent = await _eventRepository.FindFirstAsync(e =>
                    e.Id == stateContext.ContextEntity.Event.Id);

                if (currentEvent == null)
                {
                    await _eventRepository.AddAsync(stateContext.ContextEntity.Event);
                }
                else
                {
                    await _eventRepository.UpdateAsync(stateContext.ContextEntity.Event);
                }

                await BackToMenu(stateContext);
            }
            else if (dtoDomain.MessageText.Contains("Back"))
            {
                await BackToMenu(stateContext);
            }
            else if (dtoDomain.MessageText.Contains("Delete"))
            {
                await _eventRepository.DeleteAsync(stateContext.ContextEntity.Event.Id);
                await BackToMenu(stateContext);
            }
            else
            {
                stateContext.SetState(dtoDomain.MessageText);
            }
        }

        private async Task BackToMenu(IStateContext stateContext)
        {
            await _contextRepository.DeleteAsync(stateContext.ContextEntity.Id);
            stateContext.SetState(Menu);
        }
    }
}
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
        private readonly ITelegramBotClient _bot;

        public GetEventMenuState(IRepository<EventEntity> eventRepository, ITelegramBotClient bot)
        {
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
                    e.Id == stateContext.EventEntity.Id);

                if (currentEvent == null)
                {
                    await _eventRepository.AddAsync(stateContext.EventEntity);
                }
                else
                {
                    await _eventRepository.UpdateAsync(stateContext.EventEntity);
                }

                var contextId = dtoDomain.MessageText.Split()[1];
                await stateContext.DeleteContextAsync(contextId);
                stateContext.SetState(Menu);
            }
            else if (dtoDomain.MessageText.Contains("Back"))
            {
                var contextId = dtoDomain.MessageText.Split()[1];
                await stateContext.DeleteContextAsync(contextId);
                stateContext.SetState(Menu);
            }
            else if (dtoDomain.MessageText.Contains("Delete"))
            {
                await _eventRepository.DeleteAsync(stateContext.EventEntity.Id);
                var contextId = dtoDomain.MessageText.Split()[1];
                await stateContext.DeleteContextAsync(contextId);
                stateContext.SetState(Menu);
            }
            else
            {
                stateContext.SetState(dtoDomain.MessageText);
            }
        }
    }
}
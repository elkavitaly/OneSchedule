using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEventMenu")]
    public class GetEventMenuState : IState
    {
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

                    stateContext.SetState("AskEventMenu");
                }

                var currentEvent = await _eventRepository.FindFirstAsync(e =>
                    e.Id == stateContext.EventEntity.Id);

                if (currentEvent == null)
                {
                    await _eventRepository.AddAsync(stateContext.EventEntity);
                }
                else
                {
                    currentEvent.Description = stateContext.EventEntity.Description;
                    currentEvent.Notifications = stateContext.EventEntity.Notifications;
                    currentEvent.StartDate = stateContext.EventEntity.StartDate;
                    currentEvent.EndDate = stateContext.EventEntity.EndDate;
                    currentEvent.Title = stateContext.EventEntity.Title;
                    currentEvent.LastUpdate = DateTime.Now;
                    await _eventRepository.UpdateAsync(currentEvent);
                }

                var contextId = dtoDomain.MessageText.Split()[1];
                await stateContext.DeleteContextAsync(contextId);
                stateContext.SetState("AskMainMenu");
            }
            else if (dtoDomain.MessageText.Contains("Back"))
            {
                var contextId = dtoDomain.MessageText.Split()[1];
                await stateContext.DeleteContextAsync(contextId);
                stateContext.SetState("AskMainMenu");
            }
            else
            {
                stateContext.SetState(dtoDomain.MessageText);
            }
        }
    }
}
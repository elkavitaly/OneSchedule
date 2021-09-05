using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Exceptions.CustomExceptions;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[save]")]
    public class SaveStrategy : IStrategy
    {
        private const string State = "AskMainMenu";
        private readonly IRepository<EventEntity> _eventRepository;
        private readonly IRepository<ContextEntity> _contextRepository;
        private readonly INotificationScheduler _notificationScheduler;

        public SaveStrategy(IRepository<EventEntity> eventRepository, IRepository<ContextEntity> contextRepository, INotificationScheduler notificationScheduler)
        {
            _eventRepository = eventRepository;
            _contextRepository = contextRepository;
            _notificationScheduler = notificationScheduler;
        }

        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            if (context.IsContextCompleted)
            {
                if (string.IsNullOrWhiteSpace(context.ContextEntity.Event.Id))
                {
                    await _eventRepository.AddAsync(context.ContextEntity.Event);
                }
                else
                {
                    await _eventRepository.UpdateAsync(context.ContextEntity.Event);
                }

                _notificationScheduler.ScheduleNotifications(context.ContextEntity.Event);

                await _contextRepository.DeleteAsync(context.ContextEntity.Id);

                context.SetState(State);
                await context.Execute(dto);
                context.ContextEntity.LastState = State;
            }
            else
            {
                throw new BotAppInternalException("Event not completed. Title, Start date, Notifications are required");
            }
        }
    }
}

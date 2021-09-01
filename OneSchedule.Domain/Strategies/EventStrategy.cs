using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[event]")]
    public class EventStrategy : IStrategy
    {
        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            if (dto.MessageText.Contains("Title"))
            {
                context.SetState("AskTitle");
                await context.Execute(dto);
            }
            else if(dto.MessageText.Contains("Start date"))
            {
                context.SetState("AskBeginDate");
                await context.Execute(dto);
            }
            else if (dto.MessageText.Contains("End date"))
            {
                context.SetState("AskEndDate");
                await context.Execute(dto);
            }
            else if (dto.MessageText.Contains("Description"))
            {
                context.SetState("AskDescription");
                await context.Execute(dto);
            }
            else if (dto.MessageText.Contains("Notifications"))
            {
                context.SetState("AskNotifications");
                await context.Execute(dto);
            }
        }
    }
}

using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("[data]")]
    public class DataStrategy : IStrategy
    {
        private readonly ITelegramBotClient _bot;
        public DataStrategy(ITelegramBotClient bot)
        {
            _bot = bot;
        }
        public async Task ExecuteAsync(IStateContext context, DtoDomain dto)
        {
            switch (context.ContextEntity.LastState)
            {
                case "AskEventList":
                    context.SetState("GetEventList");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState== "GetEventList")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                        context.SetState("AskShowEventList");
                        await context.Execute(dto);
                    }
                    break;

                case "AskTitle":
                    context.SetState("GetTitle");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState == "GetTitle")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                        context.SetState("AskEventMenu");
                        await context.Execute(dto);
                    }
                    break;
                
                case "AskBeginDate":
                    context.SetState("GetBeginDate");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState == "GetBeginDate")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                        context.SetState("AskEventMenu");
                        await context.Execute(dto);
                    }
                    break;

                case "AskEndDate":
                    context.SetState("GetEndDate");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState == "GetEndDate")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                        context.SetState("AskEventMenu");
                        await context.Execute(dto);
                    }
                    break;

                case "AskDescription":
                    context.SetState("GetDescription");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState== "GetDescription")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                    }
                    context.SetState("AskEventMenu");
                    await context.Execute(dto);
                    break;

                case "AskNotifications":
                    context.SetState("GetNotifications");
                    await context.Execute(dto);
                    if (context.ContextEntity.LastState == "GetNotifications")
                    {
                        await _bot.SendTextMessageAsync(dto.ChatId, "Success");
                        context.SetState("AskEventMenu");
                        await context.Execute(dto);
                    }
                    break;
            }
        }
    }
}

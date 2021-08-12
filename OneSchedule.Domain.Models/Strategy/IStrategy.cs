using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace OneSchedule.Domain.Models.Strategy
{
    public interface IStrategy
    {
        Task Execute(Message message);
    }
}

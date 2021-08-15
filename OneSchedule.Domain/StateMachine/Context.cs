using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace OneSchedule.Domain
{
    public class Context : IContext
    {
        private IBotState _state;
        public ITelegramBotClient Bot;
        public Update update;

        public EventDomain eventDomain;
        public Context(IBotState initialState, ITelegramBotClient bot)
        {
            _state = initialState;
            _state.SetContext(this);
            Bot = bot;
        }

        public void SetState(IBotState state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}

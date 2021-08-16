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
    public class EventContext : IStateMachineContext
    {
        private IState _state;
        private readonly ITelegramBotClient _bot;
        private Update _update;

        public EventContext(IState initialState, ITelegramBotClient bot)
        {
            _state = initialState;
            _state.SetContext(this);
            _bot = bot;
        }

        public Update Update
        {
            get 
            {
                return _update;
            }
        }

        public void SetState(IState state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}

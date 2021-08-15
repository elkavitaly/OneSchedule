
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using OneSchedule;

namespace OneSchedule.Domain
{
    public class EventSetTitleState : IBotState
    {
        private Context _context;
        private ITelegramBotClient _bot;

        public EventSetTitleState(ITelegramBotClient bot)
        {
            _bot=bot;
        }

        public void Handle() 
        {
            EventDomain eventDomain = new EventDomain();
            eventDomain.Title = _context.update.Message.Text;
            eventDomain.OwnerId = _context.update.Message.From.Id.ToString();
            eventDomain.ChatId = (int)_context.update.Message.Chat.Id;
            _context.eventDomain = eventDomain;

            

            var newState = new EventSetDateTimeState(_bot);
            _context.SetState(newState);        
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}


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

        public EventSetTitleState()
        {
        }

        public void Handle() 
        {
            EventDomain eventDomain = new EventDomain();
            eventDomain.Title = _context.update.Message.Text;
            eventDomain.OwnerId = _context.update.Message.From.Id.ToString();
            eventDomain.ChatId = (int)_context.update.Message.Chat.Id;
            _context.eventDomain = eventDomain;
            var nextStateRequestMessage = "Enter event begin Date and time";

            _context.Bot.SendTextMessageAsync(eventDomain.ChatId,nextStateRequestMessage);
            
            ///GetUpdate...

            var newState = new EventSetBeginDateTimeState();
            _context.SetState(newState);        
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}

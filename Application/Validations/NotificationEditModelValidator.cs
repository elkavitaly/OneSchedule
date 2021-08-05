using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations 
{
    public class NotificationEditModelValidator : AbstractValidator<NotificationEditModel>
    {
        public NotificationEditModelValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.EventId).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => m.Date).NotEmpty();
        }
    }
}

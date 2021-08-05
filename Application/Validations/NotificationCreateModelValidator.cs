using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations 
{
    public class NotificationCreateModelValidator : AbstractValidator<NotificationCreateModel>
    {
        public NotificationCreateModelValidator()
        {
            RuleFor(m => m.EventId).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => m.Date).NotEmpty();
        }
    }
}

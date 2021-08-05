using Application.Models;
using FluentValidation;

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

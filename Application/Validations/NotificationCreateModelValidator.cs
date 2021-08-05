using Application.Models;
using FluentValidation;

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

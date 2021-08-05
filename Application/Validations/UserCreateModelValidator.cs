using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(m => m.TelegramUserId).GreaterThan(0);
            RuleFor(m => m.PhoneNumber).Length(0, 21);
            RuleFor(m => m.FirstName).Length(2, 20).NotEmpty();
            RuleFor(m => m.LastName).Length(2, 20).NotEmpty();
        }
    }
}

using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class UserEditModelValidator : AbstractValidator<UserEditModel>
    {
        public UserEditModelValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.PhoneNumber).Length(0, 21);
            RuleFor(m => m.FirstName).Length(2, 20).NotEmpty();
            RuleFor(m => m.LastName).Length(2, 20).NotEmpty();
        }
    }
}

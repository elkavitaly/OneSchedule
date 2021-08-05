using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations 
{
    public class PeriodModelValidator : AbstractValidator<PeriodModel>
    {
        public PeriodModelValidator()
        {
            RuleFor(m => m.Begin).NotEmpty();
            RuleFor(m => m.End).NotEmpty().GreaterThan(m => m.Begin).WithMessage("End date must be grater than begin date!");
        }
    }
}

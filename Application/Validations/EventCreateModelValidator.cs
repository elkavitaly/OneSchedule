﻿using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations 
{
    public class EventCreateModelValidator : AbstractValidator<EventCreateModel>
    {
        public EventCreateModelValidator()
        {
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => m.ChatId).GreaterThan(0);
            RuleFor(m => m.Title).Length(3, 20).NotEmpty();
            RuleFor(m => m.Description).Length(0, 300);
            RuleFor(m => m.Start).NotEmpty();
            RuleFor(m => m.End).NotEmpty().GreaterThan(m => m.Start).WithMessage("End date must be grater than start date!");
        }
    }
}

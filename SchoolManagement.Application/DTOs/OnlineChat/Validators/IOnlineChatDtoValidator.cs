using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineChat.Validators
{
    public class IOnlineChatDtoValidator : AbstractValidator<IOnlineChatDto>
    {
        public IOnlineChatDtoValidator()
        {
            //RuleFor(b => b.Notes)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

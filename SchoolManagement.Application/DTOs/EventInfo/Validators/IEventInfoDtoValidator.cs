using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.EventInfo.Validators
{
    public class IEventInfoDtoValidator : AbstractValidator<IEventInfoDto>
    {
        public IEventInfoDtoValidator() 
        {
            RuleFor(b => b.EventName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

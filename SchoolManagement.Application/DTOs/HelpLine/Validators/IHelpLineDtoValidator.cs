using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.HelpLine.Validators
{
    public class IHelpLineDtoValidator : AbstractValidator<IHelpLineDto>
    {
        public IHelpLineDtoValidator() 
        {
            RuleFor(b => b.HelpContact)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

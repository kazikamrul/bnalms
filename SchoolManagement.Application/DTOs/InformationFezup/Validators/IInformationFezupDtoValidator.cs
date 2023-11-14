using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.InformationFezup.Validators
{
    public class IInformationFezupDtoValidator : AbstractValidator<IInformationFezupDto>
    {
        public IInformationFezupDtoValidator() 
        {
            RuleFor(b => b.MemberName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

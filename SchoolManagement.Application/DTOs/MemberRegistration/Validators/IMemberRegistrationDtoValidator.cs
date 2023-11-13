using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberRegistration.Validators
{
    public class IMemberRegistrationDtoValidator : AbstractValidator<IMemberRegistrationDto>
    {
        public IMemberRegistrationDtoValidator() 
        {
            RuleFor(b => b.MemberName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

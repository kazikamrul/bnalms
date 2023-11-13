using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DamageInformationByLibrary.Validators
{
    public class IDamageInformationByLibraryDtoValidator : AbstractValidator<IDamageInformationByLibraryDto>
    {
        public IDamageInformationByLibraryDtoValidator() 
        {
            RuleFor(b => b.DamageBy)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

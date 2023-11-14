using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Designation.Validators
{
    public class IDesignationDtoValidator : AbstractValidator<IDesignationDto>
    {
        public IDesignationDtoValidator() 
        {
            RuleFor(b => b.DesignationName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

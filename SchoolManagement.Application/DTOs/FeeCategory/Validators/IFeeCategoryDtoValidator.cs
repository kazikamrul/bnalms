using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FeeCategory.Validators
{
    public class IFeeCategoryDtoValidator : AbstractValidator<IFeeCategoryDto>
    {
        public IFeeCategoryDtoValidator() 
        {
            RuleFor(b => b.FeeCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

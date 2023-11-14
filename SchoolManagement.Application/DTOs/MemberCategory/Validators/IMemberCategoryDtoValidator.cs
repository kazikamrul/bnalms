using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberCategory.Validators
{
    public class IMemberCategoryDtoValidator : AbstractValidator<IMemberCategoryDto>
    {
        public IMemberCategoryDtoValidator() 
        {
            //RuleFor(b => b.MemberCategoryName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

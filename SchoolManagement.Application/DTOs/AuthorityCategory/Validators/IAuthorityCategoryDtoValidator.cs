using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AuthorityCategory.Validators
{
    public class IAuthorityCategoryDtoValidator : AbstractValidator<IAuthorityCategoryDto>
    {
        public IAuthorityCategoryDtoValidator() 
        {
            RuleFor(b => b.AuthorCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

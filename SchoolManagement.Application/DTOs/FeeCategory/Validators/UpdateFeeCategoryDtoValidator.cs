using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FeeCategory.Validators
{
    public class UpdateFeeCategoryDtoValidator : AbstractValidator<FeeCategoryDto>
    {
        public UpdateFeeCategoryDtoValidator()
        {
            Include(new IFeeCategoryDtoValidator());

            RuleFor(b => b.FeeCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


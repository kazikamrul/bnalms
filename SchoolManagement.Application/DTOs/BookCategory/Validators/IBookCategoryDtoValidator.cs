using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookCategory.Validators
{
    public class IBookCategoryDtoValidator : AbstractValidator<IBookCategoryDto>
    {
        public IBookCategoryDtoValidator() 
        {
            RuleFor(b => b.BookCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

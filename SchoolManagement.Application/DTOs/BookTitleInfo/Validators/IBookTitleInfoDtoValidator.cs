using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookTitleInfo.Validators
{
    public class IBookTitleInfoDtoValidator : AbstractValidator<IBookTitleInfoDto>
    {
        public IBookTitleInfoDtoValidator() 
        {
            RuleFor(b => b.BookTitleName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DemandBook.Validators
{
    public class IDemandBookDtoValidator : AbstractValidator<IDemandBookDto>
    {
        public IDemandBookDtoValidator() 
        {
            RuleFor(b => b.BookName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

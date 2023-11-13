using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookInformation.Validators
{
    public class IBookInformationDtoValidator : AbstractValidator<IBookInformationDto>
    {
        public IBookInformationDtoValidator() 
        {
            RuleFor(b => b.AccessionNo)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

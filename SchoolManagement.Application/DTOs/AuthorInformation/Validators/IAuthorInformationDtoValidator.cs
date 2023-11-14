using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AuthorInformation.Validators
{
    public class IAuthorInformationDtoValidator : AbstractValidator<IAuthorInformationDto>
    {
        public IAuthorInformationDtoValidator() 
        {
            RuleFor(b => b.AuthorName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

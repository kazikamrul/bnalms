using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ReaderInformation.Validators
{
    public class IReaderInformationDtoValidator : AbstractValidator<IReaderInformationDto>
    {
        public IReaderInformationDtoValidator() 
        {
            RuleFor(b => b.ReaderName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

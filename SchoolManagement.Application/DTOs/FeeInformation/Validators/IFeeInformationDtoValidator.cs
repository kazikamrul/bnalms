using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FeeInformation.Validators
{
    public class IFeeInformationDtoValidator : AbstractValidator<IFeeInformationDto>
    {
        public IFeeInformationDtoValidator() 
        {
            //RuleFor(b => b.ShelfName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

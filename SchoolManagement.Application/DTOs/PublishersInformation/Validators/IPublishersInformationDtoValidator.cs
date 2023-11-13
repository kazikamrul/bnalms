using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PublishersInformation.Validators
{
    public class IPublishersInformationDtoValidator : AbstractValidator<IPublishersInformationDto>
    {
        public IPublishersInformationDtoValidator() 
        {
            RuleFor(b => b.PublishersName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PublishersInformation.Validators
{
    public class UpdatePublishersInformationDtoValidator : AbstractValidator<PublishersInformationDto>
    {
        public UpdatePublishersInformationDtoValidator()
        {
            Include(new IPublishersInformationDtoValidator());

            RuleFor(b => b.PublishersInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


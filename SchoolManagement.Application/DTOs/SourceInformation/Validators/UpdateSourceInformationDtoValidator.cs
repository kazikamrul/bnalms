using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SourceInformation.Validators
{
    public class UpdateSourceInformationDtoValidator : AbstractValidator<SourceInformationDto>
    {
        public UpdateSourceInformationDtoValidator()
        {
            Include(new ISourceInformationDtoValidator());

            RuleFor(b => b.SourceInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


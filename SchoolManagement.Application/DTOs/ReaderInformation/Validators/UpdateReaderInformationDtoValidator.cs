using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ReaderInformation.Validators
{
    public class UpdateReaderInformationDtoValidator : AbstractValidator<ReaderInformationDto>
    {
        public UpdateReaderInformationDtoValidator()
        {
            Include(new IReaderInformationDtoValidator());

            RuleFor(b => b.ReaderInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


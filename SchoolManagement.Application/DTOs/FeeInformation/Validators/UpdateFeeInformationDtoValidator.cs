using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FeeInformation.Validators
{
    public class UpdateFeeInformationDtoValidator : AbstractValidator<FeeInformationDto>
    {
        public UpdateFeeInformationDtoValidator()
        {
            Include(new IFeeInformationDtoValidator());

            RuleFor(b => b.FeeInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


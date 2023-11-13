using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.InformationFezup.Validators
{
    public class UpdateInformationFezupDtoValidator : AbstractValidator<InformationFezupDto>
    {
        public UpdateInformationFezupDtoValidator()
        {
            Include(new IInformationFezupDtoValidator());

            RuleFor(b => b.InformationFezupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


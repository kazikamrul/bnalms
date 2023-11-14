using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.HelpLine.Validators
{
    public class UpdateHelpLineDtoValidator : AbstractValidator<HelpLineDto>
    {
        public UpdateHelpLineDtoValidator()
        {
            Include(new IHelpLineDtoValidator());

            RuleFor(b => b.HelpLineId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


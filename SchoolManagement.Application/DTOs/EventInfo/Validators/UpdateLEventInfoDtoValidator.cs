using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.EventInfo.Validators
{
    public class UpdateEventInfoDtoValidator : AbstractValidator<EventInfoDto>
    {
        public UpdateEventInfoDtoValidator()
        {
            Include(new IEventInfoDtoValidator());

            RuleFor(b => b.EventInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


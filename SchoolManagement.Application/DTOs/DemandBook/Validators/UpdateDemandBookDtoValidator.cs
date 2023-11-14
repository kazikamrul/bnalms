using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DemandBook.Validators
{
    public class UpdateDemandBookDtoValidator : AbstractValidator<DemandBookDto>
    {
        public UpdateDemandBookDtoValidator()
        {
            Include(new IDemandBookDtoValidator());

            RuleFor(b => b.DemandBookId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


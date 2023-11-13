using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MainClass.Validators
{
    public class UpdateMainClassDtoValidator : AbstractValidator<MainClassDto>
    {
        public UpdateMainClassDtoValidator()
        {
            Include(new IMainClassDtoValidator());

            RuleFor(b => b.MainClassId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


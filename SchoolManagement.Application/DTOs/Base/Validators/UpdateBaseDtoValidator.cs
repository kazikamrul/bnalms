using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Base.Validators
{
    public class UpdateBaseDtoValidator : AbstractValidator<BasemDto>
    {
        public UpdateBaseDtoValidator()
        {
            Include(new IBaseDtoValidator());

            RuleFor(b => b.BaseId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


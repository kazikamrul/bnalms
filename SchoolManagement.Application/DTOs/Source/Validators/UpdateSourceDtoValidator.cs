using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Source.Validators
{
    public class UpdateSourceDtoValidator : AbstractValidator<SourceDto>
    {
        public UpdateSourceDtoValidator()
        {
            Include(new ISourceDtoValidator());

            RuleFor(b => b.SourceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


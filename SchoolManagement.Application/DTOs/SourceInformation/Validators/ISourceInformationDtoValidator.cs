﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SourceInformation.Validators
{
    public class ISourceInformationDtoValidator : AbstractValidator<ISourceInformationDto>
    {
        public ISourceInformationDtoValidator() 
        {
            RuleFor(b => b.SourceName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

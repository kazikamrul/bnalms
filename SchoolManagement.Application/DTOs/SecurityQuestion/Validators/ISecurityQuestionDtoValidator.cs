﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SecurityQuestion.Validators
{
    public class ISecurityQuestionDtoValidator : AbstractValidator<ISecurityQuestionDto>
    {
        public ISecurityQuestionDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

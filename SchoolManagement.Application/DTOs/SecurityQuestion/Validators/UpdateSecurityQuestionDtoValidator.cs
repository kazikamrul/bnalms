using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SecurityQuestion.Validators
{
    public class UpdateSecurityQuestionDtoValidator : AbstractValidator<SecurityQuestionDto>
    {
        public UpdateSecurityQuestionDtoValidator()
        {
            Include(new ISecurityQuestionDtoValidator());

            RuleFor(b => b.SecurityQuestionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


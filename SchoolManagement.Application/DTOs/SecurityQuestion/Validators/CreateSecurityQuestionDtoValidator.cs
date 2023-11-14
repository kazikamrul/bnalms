using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SecurityQuestion.Validators
{
    public class CreateSecurityQuestionDtoValidator : AbstractValidator<CreateSecurityQuestionDto>
    {
        public CreateSecurityQuestionDtoValidator()  
        {
            Include(new ISecurityQuestionDtoValidator()); 
        }
    }
}

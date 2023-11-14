using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberInfo.Validators
{
    public class IMemberInfoDtoValidator : AbstractValidator<IMemberInfoDto>
    {
        public IMemberInfoDtoValidator() 
        {
            RuleFor(b => b.MemberName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

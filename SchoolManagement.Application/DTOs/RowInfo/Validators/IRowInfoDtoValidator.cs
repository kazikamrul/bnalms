using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.RowInfo.Validators
{
    public class IRowInfoDtoValidator : AbstractValidator<IRowInfoDto>
    {
        public IRowInfoDtoValidator() 
        {
            RuleFor(b => b.RowName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

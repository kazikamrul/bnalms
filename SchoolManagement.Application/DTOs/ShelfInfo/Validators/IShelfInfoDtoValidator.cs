using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ShelfInfo.Validators
{
    public class IShelfInfoDtoValidator : AbstractValidator<IShelfInfoDto>
    {
        public IShelfInfoDtoValidator() 
        {
            RuleFor(b => b.ShelfName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

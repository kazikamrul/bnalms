using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookBindingInfo.Validators
{
    public class IBookBindingInfoDtoValidator : AbstractValidator<IBookBindingInfoDto>
    {
        public IBookBindingInfoDtoValidator() 
        {
            RuleFor(b => b.PressName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

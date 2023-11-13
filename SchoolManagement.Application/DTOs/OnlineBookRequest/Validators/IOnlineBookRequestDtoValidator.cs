using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OnlineBookRequest.Validators
{
    public class IOnlineBookRequestDtoValidator : AbstractValidator<IOnlineBookRequestDto>
    {
        public IOnlineBookRequestDtoValidator() 
        {
            //RuleFor(b => b.EventName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

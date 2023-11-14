using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.NoticeInfo.Validators
{
    public class INoticeInfoDtoValidator : AbstractValidator<INoticeInfoDto>
    {
        public INoticeInfoDtoValidator() 
        {
            RuleFor(b => b.NoticeTitle)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}

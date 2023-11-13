using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.NoticeInfo.Validators
{
    public class UpdateNoticeInfoDtoValidator : AbstractValidator<CreateNoticeInfoDto>
    {
        public UpdateNoticeInfoDtoValidator()
        {
            Include(new INoticeInfoDtoValidator());

            RuleFor(b => b.NoticeInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


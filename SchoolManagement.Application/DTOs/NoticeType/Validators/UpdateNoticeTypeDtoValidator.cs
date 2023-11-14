using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.NoticeType.Validators
{
    public class UpdateNoticeTypeDtoValidator : AbstractValidator<NoticeTypeDto>
    {
        public UpdateNoticeTypeDtoValidator()
        {
            Include(new INoticeTypeDtoValidator());

            RuleFor(b => b.NoticeTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


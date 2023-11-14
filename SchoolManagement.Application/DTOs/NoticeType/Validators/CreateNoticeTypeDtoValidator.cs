using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NoticeType.Validators
{
    public class CreateNoticeTypeDtoValidator : AbstractValidator<CreateNoticeTypeDto>
    {
        public CreateNoticeTypeDtoValidator()  
        {
            Include(new INoticeTypeDtoValidator()); 
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NoticeInfo.Validators
{
    public class CreateNoticeInfoDtoValidator : AbstractValidator<CreateNoticeInfoDto>
    {
        public CreateNoticeInfoDtoValidator()  
        {
            Include(new INoticeInfoDtoValidator()); 
        }
    }
}

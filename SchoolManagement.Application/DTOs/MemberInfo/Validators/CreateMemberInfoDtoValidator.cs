using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MemberInfo.Validators
{
    public class CreateMemberInfoDtoValidator : AbstractValidator<CreateMemberInfoDto>
    {
        public CreateMemberInfoDtoValidator()  
        {
            Include(new IMemberInfoDtoValidator()); 
        }
    }
}

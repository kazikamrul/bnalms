using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberInfo.Validators
{
    public class UpdateMemberInfoDtoValidator : AbstractValidator<MemberInfoDto>
    {
        public UpdateMemberInfoDtoValidator()
        {
            Include(new IMemberInfoDtoValidator());

            RuleFor(b => b.MemberInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


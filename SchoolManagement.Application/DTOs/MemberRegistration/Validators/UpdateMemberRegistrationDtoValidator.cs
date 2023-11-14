using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberRegistration.Validators
{
    public class UpdateMemberRegistrationDtoValidator : AbstractValidator<MemberRegistrationDto>
    {
        public UpdateMemberRegistrationDtoValidator()
        {
            Include(new IMemberRegistrationDtoValidator());

            RuleFor(b => b.MemberRegistrationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MemberRegistration.Validators
{
    public class CreateMemberRegistrationDtoValidator : AbstractValidator<CreateMemberRegistrationDto>
    {
        public CreateMemberRegistrationDtoValidator()  
        {
            Include(new IMemberRegistrationDtoValidator()); 
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MemberCategory.Validators
{
    public class CreateMemberCategoryDtoValidator : AbstractValidator<CreateMemberCategoryDto>
    {
        public CreateMemberCategoryDtoValidator()  
        {
            Include(new IMemberCategoryDtoValidator()); 
        }
    }
}

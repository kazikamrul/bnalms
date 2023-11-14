using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MemberCategory.Validators
{
    public class UpdateMemberCategoryDtoValidator : AbstractValidator<MemberCategoryDto>
    {
        public UpdateMemberCategoryDtoValidator()
        {
            Include(new IMemberCategoryDtoValidator());

            RuleFor(b => b.MemberCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}


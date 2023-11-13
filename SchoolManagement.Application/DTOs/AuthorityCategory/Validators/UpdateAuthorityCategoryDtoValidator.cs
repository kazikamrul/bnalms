using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AuthorityCategory.Validators
{
    public class UpdateAuthorityCategoryDtoValidator : AbstractValidator<AuthorityCategoryDto>
    {
        public UpdateAuthorityCategoryDtoValidator()
        {
            Include(new IAuthorityCategoryDtoValidator());

            RuleFor(b => b.AuthorityCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

